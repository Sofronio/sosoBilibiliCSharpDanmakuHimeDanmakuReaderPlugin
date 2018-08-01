using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using BilibiliDM_PluginFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Speech.Synthesis;
using System.Threading;
using Bililive_TTS_Plugin_soso;
using System.Web.Script.Serialization;

namespace Bililive_TTS_Plugin
{
    public class BililiveTtsPlugin : DMPlugin
    {
        //config file path
        private static readonly string str_myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string str_xmlpath = str_myDocuments + @"\弹幕姬\Plugins\soso_Google_Hime_Setting.xml";
        private static readonly string str_xmlRegexPath = str_myDocuments + @"\弹幕姬\Plugins\soso_Google_Hime_Regex.xml";
        private readonly string str_dontforget = "请不要忘记！对本次0.0.6版本，必不可少的！B站ID：红色曳光蛋 同学！";
        private readonly string str_soso = "那就是soso！专注美食一百年！";
        private static Int64 timer_countdown_interval = 3500;      
        private static bool bool_sosoReadDanmaku = true;
        private static bool bool_sosoReadGfit = true;
        private static bool bool_sosoReadSir = true;
        private static bool bool_sosoReadSuffix = true;
        private static bool bool_sosoLatiaoCounter = true;
        private static bool bool_sosoBlockDuplicate = true;
        private static JsonGiftSuffix[] jsonGiftSuffix;
        private static JsonRegex[] jsonRegex;
        private static JsonBlackList[] jsonBlackList;
        string[] str_lastDanmaku = { "", "Chinese" };
        
        public System.Timers.Timer timer_countdown;       

        int int_chinese = 0;
        int int_japanese = 0;
        int int_korean = 0;
        int int_english = 0;
        //词数统计，不可删掉
        private static string str_TTSChinese = "";
        private static string str_TTSJapanese = "";
        private static string str_TTSEnglish = "";
        //三个List，里面放的是分割好的语句，待朗读
        delegate void sosoDisplayError(string str_input);
        //发声线程报错时修改主线程，需要委托主线程
        private Queue<string[]> MsgQuene;
        //发声队列
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        //实例化朗诵者

        public BililiveTtsPlugin()
        {
            this.PluginAuth = "Sofronio";
            this.PluginCont = "sofronio@sofronio.cn";
            this.PluginName = "谷歌娘";
            this.PluginDesc = "中日英读弹幕读礼物";
            this.PluginVer  = "0.3.3";
            InitTimer();
            this.ReceivedDanmaku += new ReceivedDanmakuEvt(this.BililiveTtsPlugin_ReceivedDanmaku);

            this.MsgQuene = new Queue<string[]>();
            new Thread(new ThreadStart(this.Read))
            {
                IsBackground = true
            }.Start();
        }

        #region 辣条防火墙
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        private System.Windows.Forms.Timer timer1;

        List<Gift> myGifts = new List<Gift>();
        class Gift
        {
            public string User { get; set; }
            public string Type { get; set; }
            public int Count { get; set; }
            public Int64 Time { get; set; }
        }

        private void GiftCreate(string User, string Type, int Count, Int64 Time)
        {
            //Log("giftCreate");
            bool foundGift = false;
            foreach (Gift myGift in myGifts)
            {
                if (myGift.User == User && myGift.Type == Type)
                {
                    myGift.Count += Count;
                    myGift.Time = Time;
                    foundGift = true;
                    break;
                }
            }
            if (foundGift == false)
            {
                Gift newGift = new Gift
                {
                    User = User,
                    Type = Type,
                    Count = Count,
                    Time = Time
                };
                myGifts.Add(newGift);
            }
        }

        private void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            RefeshList();
        }

        private void RefeshList()
        {
            String timeStamp = GetTimestamp(DateTime.Now);           
            foreach (Gift myGift in myGifts)
            {
                if (Convert.ToInt64(timeStamp) - Convert.ToInt64(myGift.Time) > timer_countdown_interval * 10)
                {
                    MsgQuene.Enqueue(StrG_StringArray(GiftDanmakuProcess(myGift.User, myGift.Count.ToString(), myGift.Type), "chinese"));
                    Log(GiftDanmakuProcess(myGift.User, myGift.Count.ToString(), myGift.Type));
                    myGifts.Remove(myGift);
                    break;
                }
            }
        }
        #endregion

        public static void ApplySetting(bool[] bool_setting, double double_countdown, string[] str_TTSSetting)
        {
            //设置窗口调用此方法，对主程序设置
            //			0 checkBox_text.Checked,			收到文字弹幕		
            //			1 checkBox_gift.Checked, 			收到礼物进行播报
            //			2 checkBox_sir.Checked, 			收到老爷进行播报
            //			3 checkBox_suffix.Checked, 			结尾添加卖萌
            //			4 checkBox_latiaoCounter.Checked	辣条整合播报
            //          5 checkBox_blockDuplicate.Checked   相同弹幕屏蔽
            //

            //			  double_countdown					倒计时间隔
            //			0 listTTSSetting					chinese
            //			1 listTTSSetting					japanese
            //			2 listTTSSetting					english
            bool_sosoReadDanmaku = bool_setting[0];
            bool_sosoReadGfit = bool_setting[1];
            bool_sosoReadSir = bool_setting[2];
            bool_sosoReadSuffix = bool_setting[3];
            bool_sosoLatiaoCounter = bool_setting[4];
            bool_sosoBlockDuplicate = bool_setting[5];

            timer_countdown_interval = Convert.ToInt64(double_countdown * 1000);

            str_TTSChinese = str_TTSSetting[0];
            str_TTSJapanese = str_TTSSetting[1];
            str_TTSEnglish = str_TTSSetting[2];
        }

        private string[] StrG_StringArray(string str_0, string str_1)
        {
            string[] str_temp = { str_0, str_1 };
            return str_temp;
        }

        public override void Start()
        {
            base.Start();
            ReloadJson();
        }

        public override void Admin()
        {
            base.Admin();
            Form_setting form_setting = new Form_setting();
            form_setting.Show();
        }

        private void Read()
        {
            //朗诵功能
            try
            {
                speechSynthesizer.SetOutputToDefaultAudioDevice();
                speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new CultureInfo("zh-CN"));
                string str_defaultSpeaker = speechSynthesizer.Voice.Name;
                //选择默认播音员
                while (true)
                {
                    if (MsgQuene.Count > 0)
                    {
                        string[] str_temp = MsgQuene.Dequeue();
                        if (str_temp[0] != "")
                        {
                            string str_voice = str_defaultSpeaker;
                            Random rdm = new Random();
                            //多选朗诵者的随机选择
                            switch (str_temp[1])
                            {
                                case "chinese":
                                    if (str_TTSChinese.Trim() != "")
                                    {
                                        str_voice = str_TTSChinese;
                                    }
                                    break;
                                case "japanese":
                                    if (str_TTSJapanese.Trim() != "")
                                        str_voice = str_TTSJapanese;
                                    break;
                                case "english":
                                    if (str_TTSEnglish.Trim() != "")
                                        str_voice = str_TTSEnglish;
                                    break;
                                default:
                                    str_voice = str_defaultSpeaker;
                                    break;
                            }
                            try
                            {
                                speechSynthesizer.SelectVoice(str_voice);
                                speechSynthesizer.Speak(str_temp[0]);
                            }
                            catch (ArgumentException)
                            {
                                Log("貌似找不到合适的朗诵者");
                                AddDM("貌似找不到合适的朗诵者");
                            }
                        }
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            finally
            {
                if (speechSynthesizer != null)
                    ((IDisposable)speechSynthesizer).Dispose();
            }
        }

        private void BililiveTtsPlugin_ReceivedDanmaku(object sender, ReceivedDanmakuArgs e)
        {
            if (!IsBlackList(e.Danmaku.CommentUser) || !IsBlackList(e.Danmaku.GiftUser))
            //user or GiftSender is not in blacklist
            {
                string flag = e.Danmaku.MsgType.ToString();
                switch (e.Danmaku.MsgType)
                {
                    case MsgTypeEnum.Comment:
                        if (bool_sosoReadDanmaku)
                        {                            

                            string str_temp = e.Danmaku.CommentText.ToString();
                            foreach (string[] str_array in ReceivedDanmakuList(str_temp))
                            {
                                if (bool_sosoBlockDuplicate)
                                {
                                    if (str_lastDanmaku[0] != str_array[0])
                                    {
                                        MsgQuene.Enqueue(str_array);
                                        str_lastDanmaku = str_array;
                                    }
                                }
                                else
                                {
                                    MsgQuene.Enqueue(str_array);
                                }
                            }
                            if (str_temp == "红色曳光弹是谁")
                                MsgQuene.Enqueue(StrG_StringArray(str_dontforget, "chinese"));
                            if ((str_temp == "Sofronio是谁") || (str_temp == "soso是谁"))
                                MsgQuene.Enqueue(StrG_StringArray(str_soso, "chinese"));
                            if ((str_temp == "今天的谷歌娘是谁") || (str_temp == "谷歌娘是谁"))
                            {
                                string str_google_hime = "谷歌娘给你请安啦";
                                switch (str_TTSChinese)
                                {
                                    case "Microsoft Server Speech Text to Speech Voice (zh-TW, HanHan)":
                                        str_google_hime = "人家是国语娘啦，来自台湾";
                                        break;
                                    case "Microsoft Server Speech Text to Speech Voice (zh-CN, HuiHui)":
                                        str_google_hime = "哼，人家是慧慧啦，来自帝都";
                                        break;
                                    case "Microsoft Lili":
                                        str_google_hime = "哼，人家是莉莉啦，来自帝都";
                                        break;
                                    case "Microsoft Server Speech Text to Speech Voice (zh-HK, HunYee)":
                                        str_google_hime = "我喺边个白话娘，来自广州";
                                        break;
                                }
                                MsgQuene.Enqueue(StrG_StringArray(str_google_hime, "chinese"));
                            }
                        }
                        break;
                    case MsgTypeEnum.GiftSend:
                        if (bool_sosoReadGfit)
                        {
                            string User = e.Danmaku.GiftUser.ToString();
                            string Type = e.Danmaku.GiftName.ToString();
                            int Count = Convert.ToInt32(e.Danmaku.GiftNum);
                            Int64 Time = Convert.ToInt64(GetTimestamp(DateTime.Now));
                            GiftCreate(User, Type, Count, Time);
                        }
                        break;
                    case MsgTypeEnum.Welcome:
                        if (bool_sosoReadSir)
                        {
                            MsgQuene.Enqueue(StrG_StringArray(ReceivedWelcome(e.Danmaku.CommentUser.ToString(), e.Danmaku.isVIP, e.Danmaku.isAdmin), "chinese"));
                        }
                        break;
                    //case MsgTypeEnum.LiveStart:
                    //    if (bool_sosoReadLiveStart)
                    //    {
                    //        MsgQuene.Enqueue(sosoStringArray("直播开始啦！", "chinese"));
                    //        AddDM("直播开始啦！");                        
                    //    }
                    //    break;
                    //case MsgTypeEnum.LiveEnd:
                    //    if (bool_sosoReadLiveStop)
                    //    {
                    //        MsgQuene.Enqueue(sosoStringArray("今天的直播结束啦！", "chinese"));
                    //    }
                    //    break;
                    default:
                        break;
                }
            }
        }

        private string ReceivedWelcome(string str_CommentText, bool bool_isVIP, bool bool_isAdmin)
        {
            if (bool_isVIP)
                return "欢迎" + str_CommentText + "老爷的光临";
            else if (bool_isAdmin)
                return "欢迎管理员" + str_CommentText + "回到房间";
            else
                return "欢迎" + str_CommentText + "的光临";
        }

        private List<string[]> ReceivedDanmakuList(string str_CommentText)
        {
            List<string[]> listStringArray = new List<string[]>();
            string[] str_temp = { str_CommentText, "chinese" };
            
            string[] str_line;
            if ((str_temp[0].Length > 3 && str_temp[0].Substring(0, 3) == "计算 "))
            {
                string[] str_result = { "", "" };
                try
                {
                    MathCalculate sosoMath = new MathCalculate();
                    char[] char_splitter = { ' ', };
                    str_line = str_temp[0].Split(char_splitter, 2);
                    string str_math = sosoMath.MathCalculator(str_line[1]).ToString();
                    str_result[0] = "计算的结果是" + str_math + "，还不快谢谢我";
                    str_result[1] = "chinese";
                    Log(str_result[0]);
                    AddDM(str_result[0]);
                }
                catch
                {
                    str_result[0] = "计算错误啦，谷歌娘不认识那么复杂的东西";
                    str_result[1] = "chinese";
                }
                listStringArray.Add(str_result);
            }
            else
            {

                if (str_temp[0].Length > 3 && str_temp[0].Substring(0, 3) == "点歌 ")
                {
                    char[] char_splitter = { ' ', };
                    str_line = str_CommentText.Split(char_splitter, 2);
                }
                else
                {
                    char[] char_splitter = { ',', '，', '。', '；', ';', '？', '！', '?', '!' };
                    str_line = str_CommentText.Split(char_splitter);
                }
                foreach (string str in str_line)
                {
                    listStringArray.Add(StrG_LanguageMatch(RegexMatch(str)));
                }
            }
            return listStringArray;
        }

        private string GiftDanmakuProcess(string str_GiftUser, string str_GiftNum, string str_GiftName)
        {
            string result = "谢谢" + str_GiftUser + "送的" + str_GiftNum + StrG_ClassifierSuffix(str_GiftName)[0] + RegexMatch(str_GiftName) + StrG_ClassifierSuffix(str_GiftName)[1];
            return result;
        }

        public string[] StrG_ClassifierSuffix(string str_GiftName)
        {
            string str_classifier = "个";
            string str_suffix = "";
            
            for (int i=0; i< jsonGiftSuffix.Length; i++)
            {
                if (str_GiftName == jsonGiftSuffix[i].GiftName)
                {
                    str_classifier = jsonGiftSuffix[i].Classifier;
                    str_suffix = jsonGiftSuffix[i].Suffix;
                }
            }

            if (!bool_sosoReadSuffix)
            {
                //禁止后缀卖萌
                str_suffix = "";
            }
            string[] result = { str_classifier, str_suffix };
            return result;
        }

        private string[] StrG_LanguageMatch(string str_input)
        {
            //正则式语言判断
            foreach (char char_tmp in str_input)
            {
                // 判断韩语
                if (System.Text.RegularExpressions.Regex.IsMatch(char_tmp.ToString(), @"^[\uac00-\ud7ff]+$"))
                {
                    int_korean++;
                }

                // 判断日语
                if (System.Text.RegularExpressions.Regex.IsMatch(char_tmp.ToString(), @"^[\u0800-\u4e00]+$"))
                {
                    int_japanese++;
                }

                // 判断中文
                if (System.Text.RegularExpressions.Regex.IsMatch(char_tmp.ToString(), @"^[\u4e00-\u9fa5]+$"))
                {
                    int_chinese++;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(char_tmp.ToString(), @"^[A-Za-z,;.\s]+$"))
                {
                    int_english++;
                }
            }
            //语言统计 一只鹅坡下就是一条河宽宽的河肥肥 ←◡←
            string[] str_result = { str_input, "chinese" };
            if (int_japanese >= 3)
            {
                str_result[1] = "japanese";
            }
            else if ((int_chinese > 0) && (int_japanese < 3))
            {
                str_result[1] = "chinese";
            }
            else if ((int_english > 0) && (int_japanese < 2) && (int_chinese < 2))
            {
                str_result[1] = "english";
            }
            int_chinese = 0;
            int_japanese = 0;
            int_korean = 0;
            int_english = 0;
            return str_result;
        }

        class MathCalculate
        {
            public object MathCalculator(string expression)
            {
                object retvar = null;
                Microsoft.CSharp.CSharpCodeProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
                System.CodeDom.Compiler.CompilerParameters cp = new System.CodeDom.Compiler.CompilerParameters(
                new string[] { @"System.dll" });
                StringBuilder builder = new StringBuilder("using System;class CalcExp{public static object Calc(){ return \"expression\";}}");
                builder.Replace("\"expression\"", expression);
                string code = builder.ToString();
                System.CodeDom.Compiler.CompilerResults results;
                results = provider.CompileAssemblyFromSource(cp, new string[] { code });
                if (results.Errors.HasErrors)
                {
                    retvar = null;
                }
                else
                {
                    System.Reflection.Assembly a = results.CompiledAssembly;
                    Type t = a.GetType("CalcExp");
                    retvar = t.InvokeMember("Calc", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod
                        , System.Type.DefaultBinder, null, null);
                }
                return retvar;
            }
        }

        public class JsonGiftSuffix
        {
            public string GiftName { get; set; }
            public string Classifier { get; set; }
            public string Suffix { get; set; }
        }

        public class JsonRegex
        {
            public string Regex { get; set; }
            public string Chinese { get; set; }
        }

        public class JsonBlackList
        {
            public string Type { get; set; }
            public string Name { get; set; }
        }

        static public void ReloadJson()
        {
            string json = "";
            StreamReader file = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\弹幕姬\Plugins\soso_Google_Hime_Regex.json", Encoding.Default);
            string s = "";
            while (s != null)
            {
                s = file.ReadLine();
                if (!string.IsNullOrEmpty(s))
                {
                    s = s.Replace((char)13, (char)0);
                    json = json + s;
                }

            }
            file.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            jsonRegex = js.Deserialize<JsonRegex[]>(json);

            json = "";
            StreamReader file1 = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\弹幕姬\Plugins\soso_Google_Hime_GiftSuffix.json", Encoding.Default);
            s = "";
            while (s != null)
            {
                s = file1.ReadLine();
                if (!string.IsNullOrEmpty(s))
                {
                    s = s.Replace((char)13, (char)0);
                    json = json + s;
                }
            }
            file.Close();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            jsonGiftSuffix = js1.Deserialize<JsonGiftSuffix[]>(json);

            json = "";
            StreamReader file2 = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\弹幕姬\Plugins\soso_Google_Hime_BlackList.json", Encoding.Default);
            s = "";
            while (s != null)
            {
                s = file2.ReadLine();
                if (!string.IsNullOrEmpty(s))
                {
                    s = s.Replace((char)13, (char)0);
                    json = json + s;
                }
            }
            file.Close();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            jsonBlackList = js2.Deserialize<JsonBlackList[]>(json);

        }
        
        private string RegexMatch(string str_input)
		{
          
            for (int i = 0; i< jsonRegex.Length; i++)
			{
				string str_pattern = jsonRegex[i].Regex;
				string str_replace = jsonRegex[i].Chinese;
				Regex rgx = new Regex(str_pattern);
				str_input = rgx.Replace(str_input, str_replace);
			}
			return str_input;
		}

        private bool IsBlackList(string str_input)
        {
            string str_name = "";
            bool result = false;
            for (int i = 0; i < jsonBlackList.Length; i++)
            {
                if (str_input == jsonBlackList[i].Name)
                {
                    result = true;
                    Log("检测到黑名单用户" + " " + str_name);
                }
            }            
            //string[] result = { str_type, str_name };
            return result;
        }
    }
}
/*
 * 已经更新礼物倒计时功能 2017.07.06
 -----------------------------------
 * 下一步的思路

 * 很厉害的up主会有很多人发弹幕，如果发太多谷歌娘就会说不出，所以需要加限制
 * 必备思路1：礼物的信息一定要优先级高
 * 必备思路2：多条队列，分别抓取不同的消息类型
 * 限制思路1：直接抛弃，或抛弃一半
 * 限制思路2：随机抛弃若干
 * 限制思路3：23333和66666进行精简
 * 限制思路4：进行3号精简后是否有改善，之后再进行1、2精简
 * 限制思路5：中间进行跳跃
 * 
 * 
 * TODO 1 配置文件保存
 * TODO 2 黑名单
 * TODO 3 视频姬播放列表
 * TODO 4 礼物统计功能
 * TODO 5 繁体用粤语
 一句里面都好太多，直接去掉逗号
 */