
namespace Taiko5DXSaveEditor.DataEditForms.WorldEdit
{
    partial class WorldEditForm
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
            this._CancelButton = new System.Windows.Forms.Button();
            this._OKButton = new System.Windows.Forms.Button();
            this._ScenarioComboBox = new System.Windows.Forms.ComboBox();
            this._YearTextBox = new System.Windows.Forms.TextBox();
            this._MonthComboBox = new System.Windows.Forms.ComboBox();
            this._DayComboBox = new System.Windows.Forms.ComboBox();
            this._TimeComboBox = new System.Windows.Forms.ComboBox();
            this._PlayDaysTextBox = new System.Windows.Forms.TextBox();
            this._NextMeetingDaysTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(317, 156);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 101;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(229, 156);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _ScenarioComboBox
            // 
            this._ScenarioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ScenarioComboBox.FormattingEnabled = true;
            this._ScenarioComboBox.Location = new System.Drawing.Point(63, 11);
            this._ScenarioComboBox.Name = "_ScenarioComboBox";
            this._ScenarioComboBox.Size = new System.Drawing.Size(125, 23);
            this._ScenarioComboBox.TabIndex = 0;
            // 
            // _YearTextBox
            // 
            this._YearTextBox.Location = new System.Drawing.Point(17, 57);
            this._YearTextBox.MaxLength = 4;
            this._YearTextBox.Name = "_YearTextBox";
            this._YearTextBox.Size = new System.Drawing.Size(80, 23);
            this._YearTextBox.TabIndex = 2;
            this._ToolTip.SetToolTip(this._YearTextBox, "1500-1755");
            // 
            // _MonthComboBox
            // 
            this._MonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._MonthComboBox.FormattingEnabled = true;
            this._MonthComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this._MonthComboBox.Location = new System.Drawing.Point(128, 57);
            this._MonthComboBox.Name = "_MonthComboBox";
            this._MonthComboBox.Size = new System.Drawing.Size(60, 23);
            this._MonthComboBox.TabIndex = 3;
            // 
            // _DayComboBox
            // 
            this._DayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._DayComboBox.FormattingEnabled = true;
            this._DayComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this._DayComboBox.Location = new System.Drawing.Point(219, 57);
            this._DayComboBox.Name = "_DayComboBox";
            this._DayComboBox.Size = new System.Drawing.Size(60, 23);
            this._DayComboBox.TabIndex = 4;
            // 
            // _TimeComboBox
            // 
            this._TimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._TimeComboBox.FormattingEnabled = true;
            this._TimeComboBox.Items.AddRange(new object[] {
            "未明",
            "朝",
            "昼",
            "夕"});
            this._TimeComboBox.Location = new System.Drawing.Point(322, 57);
            this._TimeComboBox.Name = "_TimeComboBox";
            this._TimeComboBox.Size = new System.Drawing.Size(70, 23);
            this._TimeComboBox.TabIndex = 5;
            // 
            // _PlayDaysTextBox
            // 
            this._PlayDaysTextBox.Location = new System.Drawing.Point(292, 11);
            this._PlayDaysTextBox.MaxLength = 5;
            this._PlayDaysTextBox.Name = "_PlayDaysTextBox";
            this._PlayDaysTextBox.Size = new System.Drawing.Size(100, 23);
            this._PlayDaysTextBox.TabIndex = 1;
            this._ToolTip.SetToolTip(this._PlayDaysTextBox, "0-65535");
            // 
            // _NextMeetingDaysTextBox
            // 
            this._NextMeetingDaysTextBox.Location = new System.Drawing.Point(292, 99);
            this._NextMeetingDaysTextBox.MaxLength = 3;
            this._NextMeetingDaysTextBox.Name = "_NextMeetingDaysTextBox";
            this._NextMeetingDaysTextBox.Size = new System.Drawing.Size(100, 23);
            this._NextMeetingDaysTextBox.TabIndex = 6;
            this._ToolTip.SetToolTip(this._NextMeetingDaysTextBox, "0-255\r\n255だと開催されない");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "シナリオ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "年";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "総経過日数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "次回評定までの日数";
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // WorldEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(404, 191);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._NextMeetingDaysTextBox);
            this.Controls.Add(this._PlayDaysTextBox);
            this.Controls.Add(this._TimeComboBox);
            this.Controls.Add(this._DayComboBox);
            this.Controls.Add(this._MonthComboBox);
            this.Controls.Add(this._YearTextBox);
            this.Controls.Add(this._ScenarioComboBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "WorldEditForm";
            this.Text = "世界：主要項目の編集";
            this.Load += new System.EventHandler(this.WorldEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.ComboBox _ScenarioComboBox;
        private System.Windows.Forms.TextBox _YearTextBox;
        private System.Windows.Forms.ComboBox _MonthComboBox;
        private System.Windows.Forms.ComboBox _DayComboBox;
        private System.Windows.Forms.ComboBox _TimeComboBox;
        private System.Windows.Forms.TextBox _PlayDaysTextBox;
        private System.Windows.Forms.TextBox _NextMeetingDaysTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip _ToolTip;
    }
}