/*
 * 由SharpDevelop创建。
 * 用户： John
 * 日期: 02/05/2016
 * 时间: 12:02
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Bililive_TTS_Plugin_soso
{
	partial class Form_setting
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button_apply;
		private System.Windows.Forms.Button button_reset;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox_sir;
		private System.Windows.Forms.CheckBox checkBox_gift;
		private System.Windows.Forms.CheckBox checkBox_text;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox_suffix;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_countdown;
		private System.Windows.Forms.CheckBox checkBox_latiaoCounter;
		private System.Windows.Forms.Label label_sosoAbout;
		private System.Windows.Forms.TabControl tabControl_setting;
		private System.Windows.Forms.TabPage tabPage_main;
		private System.Windows.Forms.TabPage tabPage_tts;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_setting));
            this.tabControl_setting = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_reload = new System.Windows.Forms.Button();
            this.label_sosoAbout = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_countdown = new System.Windows.Forms.TextBox();
            this.checkBox_suffix = new System.Windows.Forms.CheckBox();
            this.checkBox_latiaoCounter = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_sir = new System.Windows.Forms.CheckBox();
            this.checkBox_gift = new System.Windows.Forms.CheckBox();
            this.checkBox_text = new System.Windows.Forms.CheckBox();
            this.tabPage_tts = new System.Windows.Forms.TabPage();
            this.comboBox_English = new System.Windows.Forms.ComboBox();
            this.comboBox_Japanese = new System.Windows.Forms.ComboBox();
            this.comboBox_Chinese = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox_blockDuplicate = new System.Windows.Forms.CheckBox();
            this.tabControl_setting.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_tts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_setting
            // 
            this.tabControl_setting.Controls.Add(this.tabPage_main);
            this.tabControl_setting.Controls.Add(this.tabPage_tts);
            this.tabControl_setting.Location = new System.Drawing.Point(22, 21);
            this.tabControl_setting.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabControl_setting.Name = "tabControl_setting";
            this.tabControl_setting.SelectedIndex = 0;
            this.tabControl_setting.Size = new System.Drawing.Size(835, 496);
            this.tabControl_setting.TabIndex = 7;
            // 
            // tabPage_main
            // 
            this.tabPage_main.Controls.Add(this.label6);
            this.tabPage_main.Controls.Add(this.label1);
            this.tabPage_main.Controls.Add(this.button_reload);
            this.tabPage_main.Controls.Add(this.label_sosoAbout);
            this.tabPage_main.Controls.Add(this.groupBox2);
            this.tabPage_main.Controls.Add(this.groupBox1);
            this.tabPage_main.Location = new System.Drawing.Point(4, 31);
            this.tabPage_main.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage_main.Size = new System.Drawing.Size(827, 461);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "总体调教";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(572, 303);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 31);
            this.label6.TabIndex = 15;
            this.label6.Text = "更新网站 Sofronio.cn";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(604, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 31);
            this.label1.TabIndex = 14;
            this.label1.Text = "B站直播间 20767";
            // 
            // button_reload
            // 
            this.button_reload.Location = new System.Drawing.Point(559, 55);
            this.button_reload.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(242, 96);
            this.button_reload.TabIndex = 9;
            this.button_reload.Text = "重新加载正则替换与卖萌尾音";
            this.button_reload.UseVisualStyleBackColor = true;
            this.button_reload.Click += new System.EventHandler(this.button_reload_Click);
            // 
            // label_sosoAbout
            // 
            this.label_sosoAbout.Location = new System.Drawing.Point(615, 242);
            this.label_sosoAbout.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_sosoAbout.Name = "label_sosoAbout";
            this.label_sosoAbout.Size = new System.Drawing.Size(218, 43);
            this.label_sosoAbout.TabIndex = 13;
            this.label_sosoAbout.Text = "作者 Sofronio";
            this.label_sosoAbout.Click += new System.EventHandler(this.AboutSoso);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_countdown);
            this.groupBox2.Controls.Add(this.checkBox_suffix);
            this.groupBox2.Controls.Add(this.checkBox_latiaoCounter);
            this.groupBox2.Location = new System.Drawing.Point(62, 230);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBox2.Size = new System.Drawing.Size(479, 106);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "礼物播报调教";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(409, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 40);
            this.label2.TabIndex = 9;
            this.label2.Text = "秒";
            // 
            // textBox_countdown
            // 
            this.textBox_countdown.Location = new System.Drawing.Point(344, 41);
            this.textBox_countdown.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBox_countdown.Name = "textBox_countdown";
            this.textBox_countdown.Size = new System.Drawing.Size(65, 31);
            this.textBox_countdown.TabIndex = 8;
            this.textBox_countdown.Text = "3.5";            
            this.textBox_countdown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_countdown_KeyPress);
            // 
            // checkBox_suffix
            // 
            this.checkBox_suffix.Checked = true;
            this.checkBox_suffix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_suffix.Location = new System.Drawing.Point(13, 37);
            this.checkBox_suffix.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBox_suffix.Name = "checkBox_suffix";
            this.checkBox_suffix.Size = new System.Drawing.Size(140, 42);
            this.checkBox_suffix.TabIndex = 1;
            this.checkBox_suffix.Text = "卖萌尾音";
            this.checkBox_suffix.UseVisualStyleBackColor = true;
            // 
            // checkBox_latiaoCounter
            // 
            this.checkBox_latiaoCounter.Checked = true;
            this.checkBox_latiaoCounter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_latiaoCounter.Location = new System.Drawing.Point(165, 37);
            this.checkBox_latiaoCounter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBox_latiaoCounter.Name = "checkBox_latiaoCounter";
            this.checkBox_latiaoCounter.Size = new System.Drawing.Size(191, 42);
            this.checkBox_latiaoCounter.TabIndex = 0;
            this.checkBox_latiaoCounter.Text = "礼物防火墙间隔";
            this.checkBox_latiaoCounter.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_blockDuplicate);
            this.groupBox1.Controls.Add(this.checkBox_sir);
            this.groupBox1.Controls.Add(this.checkBox_gift);
            this.groupBox1.Controls.Add(this.checkBox_text);
            this.groupBox1.Location = new System.Drawing.Point(50, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBox1.Size = new System.Drawing.Size(479, 157);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "总体播报调教";
            // 
            // checkBox_sir
            // 
            this.checkBox_sir.Checked = true;
            this.checkBox_sir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_sir.Location = new System.Drawing.Point(330, 37);
            this.checkBox_sir.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBox_sir.Name = "checkBox_sir";
            this.checkBox_sir.Size = new System.Drawing.Size(137, 42);
            this.checkBox_sir.TabIndex = 2;
            this.checkBox_sir.Text = "老爷进屋";
            this.checkBox_sir.UseVisualStyleBackColor = true;
            // 
            // checkBox_gift
            // 
            this.checkBox_gift.Checked = true;
            this.checkBox_gift.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_gift.Location = new System.Drawing.Point(165, 37);
            this.checkBox_gift.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBox_gift.Name = "checkBox_gift";
            this.checkBox_gift.Size = new System.Drawing.Size(191, 42);
            this.checkBox_gift.TabIndex = 1;
            this.checkBox_gift.Text = "收到礼物";
            this.checkBox_gift.UseVisualStyleBackColor = true;
            // 
            // checkBox_text
            // 
            this.checkBox_text.Checked = true;
            this.checkBox_text.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_text.Location = new System.Drawing.Point(13, 37);
            this.checkBox_text.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBox_text.Name = "checkBox_text";
            this.checkBox_text.Size = new System.Drawing.Size(191, 42);
            this.checkBox_text.TabIndex = 0;
            this.checkBox_text.Text = "文字弹幕";
            this.checkBox_text.UseVisualStyleBackColor = true;
            
            // 
            // tabPage_tts
            // 
            this.tabPage_tts.Controls.Add(this.comboBox_English);
            this.tabPage_tts.Controls.Add(this.comboBox_Japanese);
            this.tabPage_tts.Controls.Add(this.comboBox_Chinese);
            this.tabPage_tts.Controls.Add(this.label5);
            this.tabPage_tts.Controls.Add(this.label4);
            this.tabPage_tts.Controls.Add(this.label3);
            this.tabPage_tts.Location = new System.Drawing.Point(4, 31);
            this.tabPage_tts.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage_tts.Name = "tabPage_tts";
            this.tabPage_tts.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage_tts.Size = new System.Drawing.Size(827, 355);
            this.tabPage_tts.TabIndex = 1;
            this.tabPage_tts.Text = "声音调教";
            this.tabPage_tts.UseVisualStyleBackColor = true;
            // 
            // comboBox_English
            // 
            this.comboBox_English.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_English.FormattingEnabled = true;
            this.comboBox_English.Location = new System.Drawing.Point(161, 172);
            this.comboBox_English.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBox_English.Name = "comboBox_English";
            this.comboBox_English.Size = new System.Drawing.Size(594, 29);
            this.comboBox_English.TabIndex = 24;
            // 
            // comboBox_Japanese
            // 
            this.comboBox_Japanese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Japanese.FormattingEnabled = true;
            this.comboBox_Japanese.Location = new System.Drawing.Point(161, 105);
            this.comboBox_Japanese.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBox_Japanese.Name = "comboBox_Japanese";
            this.comboBox_Japanese.Size = new System.Drawing.Size(594, 29);
            this.comboBox_Japanese.TabIndex = 23;
            // 
            // comboBox_Chinese
            // 
            this.comboBox_Chinese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Chinese.FormattingEnabled = true;
            this.comboBox_Chinese.Location = new System.Drawing.Point(161, 40);
            this.comboBox_Chinese.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBox_Chinese.Name = "comboBox_Chinese";
            this.comboBox_Chinese.Size = new System.Drawing.Size(594, 29);
            this.comboBox_Chinese.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 177);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "英语引擎";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "日语引擎";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "中文引擎";
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(26, 567);
            this.button_reset.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(138, 46);
            this.button_reset.TabIndex = 8;
            this.button_reset.Text = "默认调教";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.ResetSetting);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(715, 567);
            this.button_apply.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(138, 46);
            this.button_apply.TabIndex = 7;
            this.button_apply.Text = "应用调教";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.ApplySetting);
            // 
            // checkBox_blockDuplicate
            // 
            this.checkBox_blockDuplicate.Checked = true;
            this.checkBox_blockDuplicate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_blockDuplicate.Location = new System.Drawing.Point(12, 89);
            this.checkBox_blockDuplicate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.checkBox_blockDuplicate.Name = "checkBox_blockDuplicate";
            this.checkBox_blockDuplicate.Size = new System.Drawing.Size(192, 42);
            this.checkBox_blockDuplicate.TabIndex = 3;
            this.checkBox_blockDuplicate.Text = "屏蔽重复弹幕";
            this.checkBox_blockDuplicate.UseVisualStyleBackColor = true;
            // 
            // Form_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 643);
            this.Controls.Add(this.tabControl_setting);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.button_reset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "Form_setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "谷歌娘属性调教中心";
            this.Load += new System.EventHandler(this.Form_setting_Load);
            this.tabControl_setting.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage_tts.ResumeLayout(false);
            this.tabPage_tts.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.ComboBox comboBox_English;
        private System.Windows.Forms.ComboBox comboBox_Japanese;
        private System.Windows.Forms.ComboBox comboBox_Chinese;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button_reload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_blockDuplicate;
    }
}
