/*
 * 由SharpDevelop创建。
 * 用户： John
 * 日期: 02/05/2016
 * 时间: 12:02
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Bililive_TTS_Plugin;
using System.Speech.Synthesis;
using Properties;

namespace Bililive_TTS_Plugin_soso
{
	/// <summary>
	/// Description of Form_setting.
	/// </summary>
	public partial class Form_setting : Form
	{
		string str_TTSChinese;
        string str_TTSJapanese;
        string str_TTSEnglish;
        SpeechSynthesizer speechSynthesizer;


        public Form_setting()
		{
			InitializeComponent();
			//弹出气泡设置
			ToolTipSet(label_sosoAbout,
						"谷歌娘调教说明 (=・ω・=)",
			           	"本插件由弹幕姬制作者 黑喵老爷" +
			           	"\n0.0.1版 真·弹幕姬 修改扩展而来" +
			           	"\n希望大家能够喜欢"
			           );	
			ReadSetting();
		}

        void ReadSetting()
        {
            //读取设置
            textBox_countdown.Text = Settings.Default["double_countdown"].ToString();
            checkBox_text.Checked = Convert.ToBoolean(Settings.Default["checkBox_text"]);
            checkBox_gift.Checked = Convert.ToBoolean(Settings.Default["checkBox_gift"]);
            checkBox_sir.Checked = Convert.ToBoolean(Settings.Default["checkBox_sir"]); ;
            checkBox_suffix.Checked = Convert.ToBoolean(Settings.Default["checkBox_suffix"]); ;
            checkBox_latiaoCounter.Checked = Convert.ToBoolean(Settings.Default["checkBox_latiaoCounter"]); ;
            checkBox_blockDuplicate.Checked = Convert.ToBoolean(Settings.Default["checkBox_blockDuplicate"]); ;
            str_TTSChinese = Settings.Default["str_TTSChinese"].ToString();
            str_TTSJapanese = Settings.Default["str_TTSJapanese"].ToString();
            str_TTSEnglish = Settings.Default["str_TTSEnglish"].ToString();
        }

        void ApplySetting(object sender, EventArgs e)
        {
            //应用设置

            Settings.Default["double_countdown"] = Convert.ToDouble(textBox_countdown.Text);
            Settings.Default["checkBox_text"] = checkBox_text.Checked;
            Settings.Default["checkBox_gift"] = checkBox_gift.Checked;
            Settings.Default["checkBox_sir"] = checkBox_sir.Checked;
            Settings.Default["checkBox_suffix"] = checkBox_suffix.Checked;
            Settings.Default["checkBox_latiaoCounter"] = checkBox_latiaoCounter.Checked;
            Settings.Default["checkBox_blockDuplicate"] = checkBox_blockDuplicate.Checked;
            if (comboBox_Chinese.SelectedIndex==-1)
                Settings.Default["str_TTSChinese"] = "";
            else
                Settings.Default["str_TTSChinese"] = comboBox_Chinese.Items[comboBox_Chinese.SelectedIndex].ToString();
            if (comboBox_English.SelectedIndex == -1)
                Settings.Default["str_TTSEnglish"] = "";
            else
                Settings.Default["str_TTSEnglish"] = comboBox_English.Items[comboBox_English.SelectedIndex].ToString();
            if (comboBox_Japanese.SelectedIndex == -1)
                Settings.Default["str_TTSJapanese"] = "";
            else
                Settings.Default["str_TTSJapanese"] = comboBox_Japanese.Items[comboBox_Japanese.SelectedIndex].ToString();
            Settings.Default.Save();

            bool[] bool_setting =
            {
                checkBox_text.Checked,
                checkBox_gift.Checked,
                checkBox_sir.Checked,
                checkBox_suffix.Checked,
                checkBox_latiaoCounter.Checked,
                checkBox_blockDuplicate.Checked,
            };
            Double double_countdown = Convert.ToDouble(textBox_countdown.Text);

            string[] str_TTSSetting =
            {
                comboBox_Chinese.Items[comboBox_Chinese.SelectedIndex].ToString(),
                comboBox_Japanese.Items[comboBox_Japanese.SelectedIndex].ToString(),
                comboBox_English.Items[comboBox_English.SelectedIndex].ToString(),
            };

            BililiveTtsPlugin.ApplySetting(bool_setting, double_countdown, str_TTSSetting);
            this.Text = "谷歌娘属性调教中心";
            this.Text = "谷歌娘属性调教中心 - 调教成功";
        }

		void ResetSetting(object sender, EventArgs e)
		{
            //重置设置
            Settings.Default.Reset();
		}

		void TextBox_countdownKeyPress(object sender, KeyPressEventArgs e)
		{
			//禁止非数字字符输入
			if ((e.KeyChar != 8) && (e.KeyChar != 13) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 46))
			{			   
				//8 删除键 13回车 46 小数点
				this.Text = "谷歌娘属性调教中心";
				this.Text = "谷歌娘属性调教中心 - 请输入数字";
				e.Handled = true;//禁止输入
			}
			if(e.KeyChar==46)
            {
                if (textBox_countdown.SelectionStart==0)//判断小数点不能为1
                {
					e.Handled = true;
					this.Text = "谷歌娘属性调教中心";
					this.Text = "谷歌娘属性调教中心 - 小数点不能在第一位";
                }
           	}
		}

		void ToolTipSet(Control control, string str_title, string str_text)
		{
			//气泡说明文字生成
			ToolTip yourToolTip = new ToolTip();
			//The below are optional, of course,			
			yourToolTip.ToolTipIcon = ToolTipIcon.Info;
			yourToolTip.IsBalloon = true;
			yourToolTip.ShowAlways = true;
			yourToolTip.ToolTipTitle = str_title;
			yourToolTip.SetToolTip(control, str_text);	
		}

		void AboutSoso(object sender, EventArgs e)
		{
			//访问Sofronio的直播间
			System.Diagnostics.Process.Start("http://live.bilibili.com/20767");
		}
		void DownloadAddress(object sender, EventArgs e)
		{
			//访问Sofronio.cn
			System.Diagnostics.Process.Start("http://sofronio.cn/page-tool.php");
		}
		
        private void Form_setting_Load(object sender, EventArgs e)
        {
            var speechChinese = GetSpeechVoice("chinese");
            var speechJapanese = GetSpeechVoice("japanese");
            var speechEnglish = GetSpeechVoice("english");
            var speechAll = GetSpeechVoice("all");

            foreach (string str in speechChinese)
                comboBox_Chinese.Items.Add(str);
            foreach (string str in speechJapanese)
                comboBox_Japanese.Items.Add(str);
            foreach (string str in speechEnglish)
                comboBox_English.Items.Add(str);
            comboBox_Chinese.SelectedIndex = comboBox_Chinese.FindStringExact(str_TTSChinese);
            comboBox_Japanese.SelectedIndex = comboBox_Japanese.FindStringExact(str_TTSJapanese);
            comboBox_English.SelectedIndex = comboBox_English.FindStringExact(str_TTSEnglish);
            //comboBox_Chinese.DropDownStyle
        }

        List<string> GetSpeechVoice(string str_input)
        {
            speechSynthesizer = new SpeechSynthesizer();
            var listString = new List<string>();
            foreach (InstalledVoice voice in speechSynthesizer.GetInstalledVoices())
            {
                switch (str_input)
                {
                    case "chinese":
                        if (voice.VoiceInfo.Culture.ToString() == "zh-CN" || 
                            voice.VoiceInfo.Culture.ToString() == "zh-TW" || 
                            voice.VoiceInfo.Culture.ToString() == "zh-HK")
                            listString.Add(voice.VoiceInfo.Name);
                        break;
                    case "japanese":
                        if (voice.VoiceInfo.Culture.ToString() == "ja-JP" ||
                            voice.VoiceInfo.Culture.ToString() == "zh-CN" ||
                            voice.VoiceInfo.Culture.ToString() == "zh-TW" ||
                            voice.VoiceInfo.Culture.ToString() == "zh-HK")
                            listString.Add(voice.VoiceInfo.Name);
                        break;
                    case "english":
                        if (voice.VoiceInfo.Culture.ToString() == "en-AU" ||
                            voice.VoiceInfo.Culture.ToString() == "en-GB" ||
                            voice.VoiceInfo.Culture.ToString() == "en-US" ||
                            voice.VoiceInfo.Culture.ToString() == "zh-CN" ||
                            voice.VoiceInfo.Culture.ToString() == "zh-TW" ||
                            voice.VoiceInfo.Culture.ToString() == "zh-HK")
                            listString.Add(voice.VoiceInfo.Name);
                        break;
                    default:
                        listString.Add(voice.VoiceInfo.Name);
                        break;
                }                
            }
            listString.Sort();
            return listString;
        }

        private void button_reload_Click(object sender, EventArgs e)
        {
            BililiveTtsPlugin.ReloadJson();
        }


        private void textBox_countdown_KeyPress(object sender, KeyPressEventArgs e)
        {
            //禁止非数字字符输入
            if ((e.KeyChar != 8) && (e.KeyChar != 13) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 46))
            {
                //8 删除键 13回车 46 小数点
                this.Text = "谷歌娘属性调教中心";
                this.Text = "谷歌娘属性调教中心 - 请输入数字";
                e.Handled = true;//禁止输入
            }
            if (e.KeyChar == 46)
            {
                if (textBox_countdown.SelectionStart == 0)//判断小数点不能为1
                {
                    e.Handled = true;
                    this.Text = "谷歌娘属性调教中心";
                    this.Text = "谷歌娘属性调教中心 - 小数点不能在第一位";
                }
            }
        }
    }
}
