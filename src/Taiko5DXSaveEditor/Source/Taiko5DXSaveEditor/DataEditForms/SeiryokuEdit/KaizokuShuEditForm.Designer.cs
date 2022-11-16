
namespace Taiko5DXSaveEditor.DataEditForms.SeiryokuEdit
{
    partial class KaizokuShuEditForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._CancelButton = new System.Windows.Forms.Button();
            this._OKButton = new System.Windows.Forms.Button();
            this._DepartureCounterComboBox = new System.Windows.Forms.ComboBox();
            this._RelationshipWithShujinkoComboBox = new System.Windows.Forms.ComboBox();
            this._LeaderComboBox = new System.Windows.Forms.ComboBox();
            this._NameComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._SenryakuTargetComboBox = new System.Windows.Forms.ComboBox();
            this._SenryakuComboBox = new System.Windows.Forms.ComboBox();
            this._ShipbuildingMiddleComboBox = new System.Windows.Forms.ComboBox();
            this._ShipbuildingStrongComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "※当主無し勢力は滅亡";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "出奔カウンタ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 30);
            this.label4.TabIndex = 200;
            this.label4.Text = "主人公\r\nとの関係";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "当主";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "海賊衆名";
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(297, 195);
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
            this._OKButton.Location = new System.Drawing.Point(202, 195);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _DepartureCounterComboBox
            // 
            this._DepartureCounterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._DepartureCounterComboBox.FormattingEnabled = true;
            this._DepartureCounterComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this._DepartureCounterComboBox.Location = new System.Drawing.Point(273, 143);
            this._DepartureCounterComboBox.Name = "_DepartureCounterComboBox";
            this._DepartureCounterComboBox.Size = new System.Drawing.Size(99, 23);
            this._DepartureCounterComboBox.TabIndex = 7;
            // 
            // _RelationshipWithShujinkoComboBox
            // 
            this._RelationshipWithShujinkoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._RelationshipWithShujinkoComboBox.FormattingEnabled = true;
            this._RelationshipWithShujinkoComboBox.Items.AddRange(new object[] {
            "無関係",
            "以前仕えていた",
            "裏切った",
            "謀反した"});
            this._RelationshipWithShujinkoComboBox.Location = new System.Drawing.Point(88, 143);
            this._RelationshipWithShujinkoComboBox.Name = "_RelationshipWithShujinkoComboBox";
            this._RelationshipWithShujinkoComboBox.Size = new System.Drawing.Size(99, 23);
            this._RelationshipWithShujinkoComboBox.TabIndex = 6;
            // 
            // _LeaderComboBox
            // 
            this._LeaderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LeaderComboBox.FormattingEnabled = true;
            this._LeaderComboBox.Location = new System.Drawing.Point(88, 47);
            this._LeaderComboBox.Name = "_LeaderComboBox";
            this._LeaderComboBox.Size = new System.Drawing.Size(284, 23);
            this._LeaderComboBox.TabIndex = 1;
            // 
            // _NameComboBox
            // 
            this._NameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._NameComboBox.FormattingEnabled = true;
            this._NameComboBox.Location = new System.Drawing.Point(88, 16);
            this._NameComboBox.Name = "_NameComboBox";
            this._NameComboBox.Size = new System.Drawing.Size(284, 23);
            this._NameComboBox.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "戦略ターゲット";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "戦略";
            // 
            // _SenryakuTargetComboBox
            // 
            this._SenryakuTargetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._SenryakuTargetComboBox.FormattingEnabled = true;
            this._SenryakuTargetComboBox.Location = new System.Drawing.Point(273, 78);
            this._SenryakuTargetComboBox.Name = "_SenryakuTargetComboBox";
            this._SenryakuTargetComboBox.Size = new System.Drawing.Size(99, 23);
            this._SenryakuTargetComboBox.TabIndex = 3;
            // 
            // _SenryakuComboBox
            // 
            this._SenryakuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._SenryakuComboBox.FormattingEnabled = true;
            this._SenryakuComboBox.Items.AddRange(new object[] {
            "砦守備",
            "砦増強",
            "他衆攻略",
            "大名支援"});
            this._SenryakuComboBox.Location = new System.Drawing.Point(88, 78);
            this._SenryakuComboBox.Name = "_SenryakuComboBox";
            this._SenryakuComboBox.Size = new System.Drawing.Size(99, 23);
            this._SenryakuComboBox.TabIndex = 2;
            this._SenryakuComboBox.SelectedIndexChanged += new System.EventHandler(this._SenryakuComboBox_SelectedIndexChanged);
            // 
            // _ShipbuildingMiddleComboBox
            // 
            this._ShipbuildingMiddleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ShipbuildingMiddleComboBox.FormattingEnabled = true;
            this._ShipbuildingMiddleComboBox.Items.AddRange(new object[] {
            "ない",
            "ある",
            "量産可能"});
            this._ShipbuildingMiddleComboBox.Location = new System.Drawing.Point(88, 110);
            this._ShipbuildingMiddleComboBox.Name = "_ShipbuildingMiddleComboBox";
            this._ShipbuildingMiddleComboBox.Size = new System.Drawing.Size(99, 23);
            this._ShipbuildingMiddleComboBox.TabIndex = 4;
            // 
            // _ShipbuildingStrongComboBox
            // 
            this._ShipbuildingStrongComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ShipbuildingStrongComboBox.FormattingEnabled = true;
            this._ShipbuildingStrongComboBox.Items.AddRange(new object[] {
            "ない",
            "ある",
            "量産可能"});
            this._ShipbuildingStrongComboBox.Location = new System.Drawing.Point(273, 110);
            this._ShipbuildingStrongComboBox.Name = "_ShipbuildingStrongComboBox";
            this._ShipbuildingStrongComboBox.Size = new System.Drawing.Size(99, 23);
            this._ShipbuildingStrongComboBox.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "大型船技術";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 200;
            this.label9.Text = "鉄甲船技術";
            // 
            // KaizokuShuEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(384, 231);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._ShipbuildingStrongComboBox);
            this.Controls.Add(this._ShipbuildingMiddleComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._SenryakuTargetComboBox);
            this.Controls.Add(this._SenryakuComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this._DepartureCounterComboBox);
            this.Controls.Add(this._RelationshipWithShujinkoComboBox);
            this.Controls.Add(this._LeaderComboBox);
            this.Controls.Add(this._NameComboBox);
            this.Name = "KaizokuShuEditForm";
            this.Text = "海賊衆：主要項目の編集";
            this.Load += new System.EventHandler(this.KaizokuShuEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.ComboBox _DepartureCounterComboBox;
        private System.Windows.Forms.ComboBox _RelationshipWithShujinkoComboBox;
        private System.Windows.Forms.ComboBox _LeaderComboBox;
        private System.Windows.Forms.ComboBox _NameComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _SenryakuTargetComboBox;
        private System.Windows.Forms.ComboBox _SenryakuComboBox;
        private System.Windows.Forms.ComboBox _ShipbuildingMiddleComboBox;
        private System.Windows.Forms.ComboBox _ShipbuildingStrongComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}