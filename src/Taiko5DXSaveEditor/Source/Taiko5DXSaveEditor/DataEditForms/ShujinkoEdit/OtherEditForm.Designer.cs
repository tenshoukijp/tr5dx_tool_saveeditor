
namespace Taiko5DXSaveEditor.DataEditForms.ShujinkoEdit
{
    partial class OtherEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._OKButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._NumOfWinsTextBox = new System.Windows.Forms.TextBox();
            this._NumOfConsecutiveWinsTextBox = new System.Windows.Forms.TextBox();
            this._NumOfDefeatsTextBox = new System.Windows.Forms.TextBox();
            this._BodyguardDaysTextBox = new System.Windows.Forms.TextBox();
            this._NumOfDisciplesTextBox = new System.Windows.Forms.TextBox();
            this._DojoMoneyTextBox = new System.Windows.Forms.TextBox();
            this._NumOfWinsWithSwordTextBox = new System.Windows.Forms.TextBox();
            this._NumOfWinsWithSpearTextBox = new System.Windows.Forms.TextBox();
            this._NumOfWinsWithKunaiTextBox = new System.Windows.Forms.TextBox();
            this._NumOfWinsWithGunTextBox = new System.Windows.Forms.TextBox();
            this._NumOfWinsWithKusarigamaTextBox = new System.Windows.Forms.TextBox();
            this._NumOfWinsWithBowTextBox = new System.Windows.Forms.TextBox();
            this._BodyguardRankComboBox = new System.Windows.Forms.ComboBox();
            this._InstructionDaimyokeComboBox = new System.Windows.Forms.ComboBox();
            this._RivalComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(284, 251);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 101;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(382, 251);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 102;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // _NumOfWinsTextBox
            // 
            this._NumOfWinsTextBox.Location = new System.Drawing.Point(95, 40);
            this._NumOfWinsTextBox.MaxLength = 10;
            this._NumOfWinsTextBox.Name = "_NumOfWinsTextBox";
            this._NumOfWinsTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfWinsTextBox.TabIndex = 0;
            this._ToolTip.SetToolTip(this._NumOfWinsTextBox, "0-4294967295");
            // 
            // _NumOfConsecutiveWinsTextBox
            // 
            this._NumOfConsecutiveWinsTextBox.Location = new System.Drawing.Point(95, 67);
            this._NumOfConsecutiveWinsTextBox.MaxLength = 10;
            this._NumOfConsecutiveWinsTextBox.Name = "_NumOfConsecutiveWinsTextBox";
            this._NumOfConsecutiveWinsTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfConsecutiveWinsTextBox.TabIndex = 1;
            this._ToolTip.SetToolTip(this._NumOfConsecutiveWinsTextBox, "0-4294967295");
            // 
            // _NumOfDefeatsTextBox
            // 
            this._NumOfDefeatsTextBox.Location = new System.Drawing.Point(95, 94);
            this._NumOfDefeatsTextBox.MaxLength = 10;
            this._NumOfDefeatsTextBox.Name = "_NumOfDefeatsTextBox";
            this._NumOfDefeatsTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfDefeatsTextBox.TabIndex = 2;
            this._ToolTip.SetToolTip(this._NumOfDefeatsTextBox, "0-4294967295");
            // 
            // _BodyguardDaysTextBox
            // 
            this._BodyguardDaysTextBox.Location = new System.Drawing.Point(284, 205);
            this._BodyguardDaysTextBox.MaxLength = 3;
            this._BodyguardDaysTextBox.Name = "_BodyguardDaysTextBox";
            this._BodyguardDaysTextBox.Size = new System.Drawing.Size(60, 23);
            this._BodyguardDaysTextBox.TabIndex = 13;
            this._ToolTip.SetToolTip(this._BodyguardDaysTextBox, "0-255\r\n255だと雇用無し");
            // 
            // _NumOfDisciplesTextBox
            // 
            this._NumOfDisciplesTextBox.Location = new System.Drawing.Point(95, 150);
            this._NumOfDisciplesTextBox.MaxLength = 5;
            this._NumOfDisciplesTextBox.Name = "_NumOfDisciplesTextBox";
            this._NumOfDisciplesTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfDisciplesTextBox.TabIndex = 9;
            this._ToolTip.SetToolTip(this._NumOfDisciplesTextBox, "0-65535");
            // 
            // _DojoMoneyTextBox
            // 
            this._DojoMoneyTextBox.Location = new System.Drawing.Point(95, 177);
            this._DojoMoneyTextBox.MaxLength = 5;
            this._DojoMoneyTextBox.Name = "_DojoMoneyTextBox";
            this._DojoMoneyTextBox.Size = new System.Drawing.Size(100, 23);
            this._DojoMoneyTextBox.TabIndex = 10;
            this._ToolTip.SetToolTip(this._DojoMoneyTextBox, "0-65535");
            // 
            // _NumOfWinsWithSwordTextBox
            // 
            this._NumOfWinsWithSwordTextBox.Location = new System.Drawing.Point(284, 39);
            this._NumOfWinsWithSwordTextBox.MaxLength = 3;
            this._NumOfWinsWithSwordTextBox.Name = "_NumOfWinsWithSwordTextBox";
            this._NumOfWinsWithSwordTextBox.Size = new System.Drawing.Size(60, 23);
            this._NumOfWinsWithSwordTextBox.TabIndex = 3;
            this._ToolTip.SetToolTip(this._NumOfWinsWithSwordTextBox, "0-255");
            // 
            // _NumOfWinsWithSpearTextBox
            // 
            this._NumOfWinsWithSpearTextBox.Location = new System.Drawing.Point(397, 40);
            this._NumOfWinsWithSpearTextBox.MaxLength = 3;
            this._NumOfWinsWithSpearTextBox.Name = "_NumOfWinsWithSpearTextBox";
            this._NumOfWinsWithSpearTextBox.Size = new System.Drawing.Size(60, 23);
            this._NumOfWinsWithSpearTextBox.TabIndex = 4;
            this._ToolTip.SetToolTip(this._NumOfWinsWithSpearTextBox, "0-255");
            // 
            // _NumOfWinsWithKunaiTextBox
            // 
            this._NumOfWinsWithKunaiTextBox.Location = new System.Drawing.Point(284, 67);
            this._NumOfWinsWithKunaiTextBox.MaxLength = 3;
            this._NumOfWinsWithKunaiTextBox.Name = "_NumOfWinsWithKunaiTextBox";
            this._NumOfWinsWithKunaiTextBox.Size = new System.Drawing.Size(60, 23);
            this._NumOfWinsWithKunaiTextBox.TabIndex = 5;
            this._ToolTip.SetToolTip(this._NumOfWinsWithKunaiTextBox, "0-255");
            // 
            // _NumOfWinsWithGunTextBox
            // 
            this._NumOfWinsWithGunTextBox.Location = new System.Drawing.Point(284, 94);
            this._NumOfWinsWithGunTextBox.MaxLength = 3;
            this._NumOfWinsWithGunTextBox.Name = "_NumOfWinsWithGunTextBox";
            this._NumOfWinsWithGunTextBox.Size = new System.Drawing.Size(60, 23);
            this._NumOfWinsWithGunTextBox.TabIndex = 7;
            this._ToolTip.SetToolTip(this._NumOfWinsWithGunTextBox, "0-255");
            // 
            // _NumOfWinsWithKusarigamaTextBox
            // 
            this._NumOfWinsWithKusarigamaTextBox.Location = new System.Drawing.Point(397, 67);
            this._NumOfWinsWithKusarigamaTextBox.MaxLength = 3;
            this._NumOfWinsWithKusarigamaTextBox.Name = "_NumOfWinsWithKusarigamaTextBox";
            this._NumOfWinsWithKusarigamaTextBox.Size = new System.Drawing.Size(60, 23);
            this._NumOfWinsWithKusarigamaTextBox.TabIndex = 6;
            this._ToolTip.SetToolTip(this._NumOfWinsWithKusarigamaTextBox, "0-255");
            // 
            // _NumOfWinsWithBowTextBox
            // 
            this._NumOfWinsWithBowTextBox.Location = new System.Drawing.Point(397, 94);
            this._NumOfWinsWithBowTextBox.MaxLength = 3;
            this._NumOfWinsWithBowTextBox.Name = "_NumOfWinsWithBowTextBox";
            this._NumOfWinsWithBowTextBox.Size = new System.Drawing.Size(60, 23);
            this._NumOfWinsWithBowTextBox.TabIndex = 8;
            this._ToolTip.SetToolTip(this._NumOfWinsWithBowTextBox, "0-255");
            // 
            // _BodyguardRankComboBox
            // 
            this._BodyguardRankComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._BodyguardRankComboBox.FormattingEnabled = true;
            this._BodyguardRankComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this._BodyguardRankComboBox.Location = new System.Drawing.Point(397, 205);
            this._BodyguardRankComboBox.Name = "_BodyguardRankComboBox";
            this._BodyguardRankComboBox.Size = new System.Drawing.Size(60, 23);
            this._BodyguardRankComboBox.TabIndex = 14;
            // 
            // _InstructionDaimyokeComboBox
            // 
            this._InstructionDaimyokeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._InstructionDaimyokeComboBox.FormattingEnabled = true;
            this._InstructionDaimyokeComboBox.Location = new System.Drawing.Point(95, 205);
            this._InstructionDaimyokeComboBox.Name = "_InstructionDaimyokeComboBox";
            this._InstructionDaimyokeComboBox.Size = new System.Drawing.Size(100, 23);
            this._InstructionDaimyokeComboBox.TabIndex = 11;
            // 
            // _RivalComboBox
            // 
            this._RivalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._RivalComboBox.FormattingEnabled = true;
            this._RivalComboBox.Location = new System.Drawing.Point(284, 149);
            this._RivalComboBox.Name = "_RivalComboBox";
            this._RivalComboBox.Size = new System.Drawing.Size(173, 23);
            this._RivalComboBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "勝利数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "連勝数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "敗北数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "個人戦の戦績";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "刀剣";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "槍";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "苦無";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "鎖鎌";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(238, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 200;
            this.label9.Text = "火縄銃";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(375, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 15);
            this.label10.TabIndex = 200;
            this.label10.Text = "弓";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(214, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 15);
            this.label11.TabIndex = 200;
            this.label11.Text = "武器種別ごとの勝利数";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 15);
            this.label12.TabIndex = 200;
            this.label12.Text = "道場、兵法指南";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 200;
            this.label13.Text = "道場投資金";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 15);
            this.label14.TabIndex = 200;
            this.label14.Text = "門弟数";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(37, 204);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 30);
            this.label15.TabIndex = 200;
            this.label15.Text = "兵法指南\r\n大名家";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(214, 128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 15);
            this.label16.TabIndex = 200;
            this.label16.Text = "ライバル武将";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(214, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 15);
            this.label17.TabIndex = 200;
            this.label17.Text = "用心棒";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(227, 208);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 15);
            this.label18.TabIndex = 200;
            this.label18.Text = "雇用期間";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(361, 208);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 15);
            this.label19.TabIndex = 200;
            this.label19.Text = "ランク";
            // 
            // OtherEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(469, 286);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._NumOfWinsWithBowTextBox);
            this.Controls.Add(this._NumOfWinsWithKusarigamaTextBox);
            this.Controls.Add(this._NumOfWinsWithGunTextBox);
            this.Controls.Add(this._NumOfWinsWithKunaiTextBox);
            this.Controls.Add(this._NumOfWinsWithSpearTextBox);
            this.Controls.Add(this._NumOfWinsWithSwordTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._RivalComboBox);
            this.Controls.Add(this._DojoMoneyTextBox);
            this.Controls.Add(this._InstructionDaimyokeComboBox);
            this.Controls.Add(this._BodyguardRankComboBox);
            this.Controls.Add(this._NumOfDisciplesTextBox);
            this.Controls.Add(this._BodyguardDaysTextBox);
            this.Controls.Add(this._NumOfDefeatsTextBox);
            this.Controls.Add(this._NumOfConsecutiveWinsTextBox);
            this.Controls.Add(this._NumOfWinsTextBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "OtherEditForm";
            this.Text = "主人公：戦績、その他の編集";
            this.Load += new System.EventHandler(this.OtherEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.TextBox _NumOfWinsTextBox;
        private System.Windows.Forms.TextBox _NumOfConsecutiveWinsTextBox;
        private System.Windows.Forms.TextBox _NumOfDefeatsTextBox;
        private System.Windows.Forms.TextBox _BodyguardDaysTextBox;
        private System.Windows.Forms.TextBox _NumOfDisciplesTextBox;
        private System.Windows.Forms.ComboBox _BodyguardRankComboBox;
        private System.Windows.Forms.ComboBox _InstructionDaimyokeComboBox;
        private System.Windows.Forms.TextBox _DojoMoneyTextBox;
        private System.Windows.Forms.ComboBox _RivalComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _NumOfWinsWithSwordTextBox;
        private System.Windows.Forms.TextBox _NumOfWinsWithSpearTextBox;
        private System.Windows.Forms.TextBox _NumOfWinsWithKunaiTextBox;
        private System.Windows.Forms.TextBox _NumOfWinsWithGunTextBox;
        private System.Windows.Forms.TextBox _NumOfWinsWithKusarigamaTextBox;
        private System.Windows.Forms.TextBox _NumOfWinsWithBowTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}