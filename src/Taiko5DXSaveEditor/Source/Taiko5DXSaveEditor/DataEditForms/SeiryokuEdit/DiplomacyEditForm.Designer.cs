
namespace Taiko5DXSaveEditor.DataEditForms.SeiryokuEdit
{
    partial class DiplomacyEditForm
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
            this._SeiryokuListBox = new System.Windows.Forms.ListBox();
            this._Diplomacy2ComboBox = new System.Windows.Forms.ComboBox();
            this._CeasefireTextBox = new System.Windows.Forms.TextBox();
            this._JustCauseTextBox = new System.Windows.Forms.TextBox();
            this._Diplomacy1ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._SeiryokuTextBox = new System.Windows.Forms.TextBox();
            this._LeaderTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(347, 336);
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
            this._OKButton.Location = new System.Drawing.Point(252, 336);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _SeiryokuListBox
            // 
            this._SeiryokuListBox.FormattingEnabled = true;
            this._SeiryokuListBox.ItemHeight = 15;
            this._SeiryokuListBox.Location = new System.Drawing.Point(12, 12);
            this._SeiryokuListBox.Name = "_SeiryokuListBox";
            this._SeiryokuListBox.ScrollAlwaysVisible = true;
            this._SeiryokuListBox.Size = new System.Drawing.Size(150, 304);
            this._SeiryokuListBox.TabIndex = 0;
            // 
            // _Diplomacy2ComboBox
            // 
            this._Diplomacy2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Diplomacy2ComboBox.FormattingEnabled = true;
            this._Diplomacy2ComboBox.Items.AddRange(new object[] {
            "0 : 絶交",
            "1 : 絶交",
            "2 : 絶交",
            "3 : 険悪",
            "4 : 険悪",
            "5 : 険悪",
            "6 : 敵視",
            "7 : 敵視",
            "8 : 敵視",
            "9 : 普通",
            "10 : 普通",
            "11 : 普通",
            "12 : 良好",
            "13 : 良好",
            "14 : 良好",
            "15 : 友好",
            "16 : 友好",
            "17 : 友好",
            "18 : 盟友",
            "19 : 盟友",
            "20 : 盟友"});
            this._Diplomacy2ComboBox.Location = new System.Drawing.Point(240, 121);
            this._Diplomacy2ComboBox.Name = "_Diplomacy2ComboBox";
            this._Diplomacy2ComboBox.Size = new System.Drawing.Size(182, 23);
            this._Diplomacy2ComboBox.TabIndex = 4;
            // 
            // _CeasefireTextBox
            // 
            this._CeasefireTextBox.Location = new System.Drawing.Point(240, 155);
            this._CeasefireTextBox.MaxLength = 3;
            this._CeasefireTextBox.Name = "_CeasefireTextBox";
            this._CeasefireTextBox.Size = new System.Drawing.Size(144, 23);
            this._CeasefireTextBox.TabIndex = 5;
            this._ToolTip.SetToolTip(this._CeasefireTextBox, "0-255");
            // 
            // _JustCauseTextBox
            // 
            this._JustCauseTextBox.Location = new System.Drawing.Point(240, 189);
            this._JustCauseTextBox.MaxLength = 3;
            this._JustCauseTextBox.Name = "_JustCauseTextBox";
            this._JustCauseTextBox.Size = new System.Drawing.Size(144, 23);
            this._JustCauseTextBox.TabIndex = 6;
            this._ToolTip.SetToolTip(this._JustCauseTextBox, "0-255");
            // 
            // _Diplomacy1ComboBox
            // 
            this._Diplomacy1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Diplomacy1ComboBox.FormattingEnabled = true;
            this._Diplomacy1ComboBox.Items.AddRange(new object[] {
            "なし",
            "同盟",
            "従属",
            "支配"});
            this._Diplomacy1ComboBox.Location = new System.Drawing.Point(240, 87);
            this._Diplomacy1ComboBox.Name = "_Diplomacy1ComboBox";
            this._Diplomacy1ComboBox.Size = new System.Drawing.Size(182, 23);
            this._Diplomacy1ComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "外交関係";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "外交感情";
            // 
            // _SeiryokuTextBox
            // 
            this._SeiryokuTextBox.Location = new System.Drawing.Point(172, 35);
            this._SeiryokuTextBox.Name = "_SeiryokuTextBox";
            this._SeiryokuTextBox.ReadOnly = true;
            this._SeiryokuTextBox.Size = new System.Drawing.Size(120, 23);
            this._SeiryokuTextBox.TabIndex = 1;
            // 
            // _LeaderTextBox
            // 
            this._LeaderTextBox.Location = new System.Drawing.Point(302, 35);
            this._LeaderTextBox.Name = "_LeaderTextBox";
            this._LeaderTextBox.ReadOnly = true;
            this._LeaderTextBox.Size = new System.Drawing.Size(120, 23);
            this._LeaderTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "外交相手";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(173, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 1);
            this.label4.TabIndex = 114;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "停戦約定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "攻込名分";
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "カ月";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "カ月";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 30);
            this.label9.TabIndex = 201;
            this.label9.Text = "※ 正常に動作させるためには、相手側\r\n　 でも別途設定を行う必要があります";
            // 
            // DiplomacyEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(434, 371);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._LeaderTextBox);
            this.Controls.Add(this._SeiryokuTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._Diplomacy1ComboBox);
            this.Controls.Add(this._JustCauseTextBox);
            this.Controls.Add(this._CeasefireTextBox);
            this.Controls.Add(this._Diplomacy2ComboBox);
            this.Controls.Add(this._SeiryokuListBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "DiplomacyEditForm";
            this.Text = "：外交関係の編集";
            this.Load += new System.EventHandler(this.DiplomacyEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.ListBox _SeiryokuListBox;
        private System.Windows.Forms.ComboBox _Diplomacy2ComboBox;
        private System.Windows.Forms.TextBox _CeasefireTextBox;
        private System.Windows.Forms.TextBox _JustCauseTextBox;
        private System.Windows.Forms.ComboBox _Diplomacy1ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _SeiryokuTextBox;
        private System.Windows.Forms.TextBox _LeaderTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}