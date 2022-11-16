
namespace Taiko5DXSaveEditor.DataEditForms.KyotenEdit
{
    partial class TorideEditForm
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
            this._NameComboBox = new System.Windows.Forms.ComboBox();
            this._LeaderComboBox = new System.Windows.Forms.ComboBox();
            this._ScaleTextBox = new System.Windows.Forms.TextBox();
            this._MoneyTextBox = new System.Windows.Forms.TextBox();
            this._MilitaryFoodTextBox = new System.Windows.Forms.TextBox();
            this._DegreeOfTrainingTextBox = new System.Windows.Forms.TextBox();
            this._NumOfWeakWarshipsTextBox = new System.Windows.Forms.TextBox();
            this._NumOfMiddleWarshipsTextBox = new System.Windows.Forms.TextBox();
            this._NumOfStrongWarshipsTextBox = new System.Windows.Forms.TextBox();
            this._DefensePowerTextBox = new System.Windows.Forms.TextBox();
            this._MoraleTextBox = new System.Windows.Forms.TextBox();
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
            this._ScaleLevelLabel = new System.Windows.Forms.Label();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._LocationComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(170, 236);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(267, 236);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 101;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // _NameComboBox
            // 
            this._NameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._NameComboBox.FormattingEnabled = true;
            this._NameComboBox.Location = new System.Drawing.Point(67, 16);
            this._NameComboBox.Name = "_NameComboBox";
            this._NameComboBox.Size = new System.Drawing.Size(275, 23);
            this._NameComboBox.TabIndex = 0;
            // 
            // _LeaderComboBox
            // 
            this._LeaderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LeaderComboBox.FormattingEnabled = true;
            this._LeaderComboBox.Location = new System.Drawing.Point(67, 45);
            this._LeaderComboBox.Name = "_LeaderComboBox";
            this._LeaderComboBox.Size = new System.Drawing.Size(275, 23);
            this._LeaderComboBox.TabIndex = 1;
            // 
            // _ScaleTextBox
            // 
            this._ScaleTextBox.Location = new System.Drawing.Point(67, 79);
            this._ScaleTextBox.MaxLength = 3;
            this._ScaleTextBox.Name = "_ScaleTextBox";
            this._ScaleTextBox.Size = new System.Drawing.Size(70, 23);
            this._ScaleTextBox.TabIndex = 2;
            this._ToolTip.SetToolTip(this._ScaleTextBox, "0-255\r\nゲーム中の最大値は22");
            // 
            // _MoneyTextBox
            // 
            this._MoneyTextBox.Location = new System.Drawing.Point(67, 108);
            this._MoneyTextBox.MaxLength = 10;
            this._MoneyTextBox.Name = "_MoneyTextBox";
            this._MoneyTextBox.Size = new System.Drawing.Size(100, 23);
            this._MoneyTextBox.TabIndex = 3;
            this._ToolTip.SetToolTip(this._MoneyTextBox, "0-4294967295");
            // 
            // _MilitaryFoodTextBox
            // 
            this._MilitaryFoodTextBox.Location = new System.Drawing.Point(67, 137);
            this._MilitaryFoodTextBox.MaxLength = 10;
            this._MilitaryFoodTextBox.Name = "_MilitaryFoodTextBox";
            this._MilitaryFoodTextBox.Size = new System.Drawing.Size(100, 23);
            this._MilitaryFoodTextBox.TabIndex = 4;
            this._ToolTip.SetToolTip(this._MilitaryFoodTextBox, "0-4294967295");
            // 
            // _DegreeOfTrainingTextBox
            // 
            this._DegreeOfTrainingTextBox.Location = new System.Drawing.Point(67, 166);
            this._DegreeOfTrainingTextBox.MaxLength = 3;
            this._DegreeOfTrainingTextBox.Name = "_DegreeOfTrainingTextBox";
            this._DegreeOfTrainingTextBox.Size = new System.Drawing.Size(100, 23);
            this._DegreeOfTrainingTextBox.TabIndex = 5;
            this._ToolTip.SetToolTip(this._DegreeOfTrainingTextBox, "0-255");
            // 
            // _NumOfWeakWarshipsTextBox
            // 
            this._NumOfWeakWarshipsTextBox.Location = new System.Drawing.Point(242, 137);
            this._NumOfWeakWarshipsTextBox.MaxLength = 5;
            this._NumOfWeakWarshipsTextBox.Name = "_NumOfWeakWarshipsTextBox";
            this._NumOfWeakWarshipsTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfWeakWarshipsTextBox.TabIndex = 9;
            this._ToolTip.SetToolTip(this._NumOfWeakWarshipsTextBox, "0-65535");
            // 
            // _NumOfMiddleWarshipsTextBox
            // 
            this._NumOfMiddleWarshipsTextBox.Location = new System.Drawing.Point(242, 166);
            this._NumOfMiddleWarshipsTextBox.MaxLength = 5;
            this._NumOfMiddleWarshipsTextBox.Name = "_NumOfMiddleWarshipsTextBox";
            this._NumOfMiddleWarshipsTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfMiddleWarshipsTextBox.TabIndex = 10;
            this._ToolTip.SetToolTip(this._NumOfMiddleWarshipsTextBox, "0-65535");
            // 
            // _NumOfStrongWarshipsTextBox
            // 
            this._NumOfStrongWarshipsTextBox.Location = new System.Drawing.Point(242, 195);
            this._NumOfStrongWarshipsTextBox.MaxLength = 5;
            this._NumOfStrongWarshipsTextBox.Name = "_NumOfStrongWarshipsTextBox";
            this._NumOfStrongWarshipsTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfStrongWarshipsTextBox.TabIndex = 11;
            this._ToolTip.SetToolTip(this._NumOfStrongWarshipsTextBox, "0-65535");
            // 
            // _DefensePowerTextBox
            // 
            this._DefensePowerTextBox.Location = new System.Drawing.Point(242, 108);
            this._DefensePowerTextBox.MaxLength = 3;
            this._DefensePowerTextBox.Name = "_DefensePowerTextBox";
            this._DefensePowerTextBox.Size = new System.Drawing.Size(100, 23);
            this._DefensePowerTextBox.TabIndex = 8;
            this._ToolTip.SetToolTip(this._DefensePowerTextBox, "0-255");
            // 
            // _MoraleTextBox
            // 
            this._MoraleTextBox.Location = new System.Drawing.Point(67, 195);
            this._MoraleTextBox.MaxLength = 3;
            this._MoraleTextBox.Name = "_MoraleTextBox";
            this._MoraleTextBox.Size = new System.Drawing.Size(100, 23);
            this._MoraleTextBox.TabIndex = 6;
            this._ToolTip.SetToolTip(this._MoraleTextBox, "0-255");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "砦名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "拠点主";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "軍資金";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "兵糧";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "規模";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "訓練度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "関船";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "大型船";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 200;
            this.label9.Text = "鉄甲船";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(190, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 200;
            this.label10.Text = "防御度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 200;
            this.label11.Text = "士気";
            // 
            // _ScaleLevelLabel
            // 
            this._ScaleLevelLabel.AutoSize = true;
            this._ScaleLevelLabel.Location = new System.Drawing.Point(142, 82);
            this._ScaleLevelLabel.Name = "_ScaleLevelLabel";
            this._ScaleLevelLabel.Size = new System.Drawing.Size(27, 15);
            this._ScaleLevelLabel.TabIndex = 200;
            this._ScaleLevelLabel.Text = "(？)";
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // _LocationComboBox
            // 
            this._LocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LocationComboBox.FormattingEnabled = true;
            this._LocationComboBox.Items.AddRange(new object[] {
            "港湾",
            "平地",
            "山地"});
            this._LocationComboBox.Location = new System.Drawing.Point(242, 79);
            this._LocationComboBox.Name = "_LocationComboBox";
            this._LocationComboBox.Size = new System.Drawing.Size(100, 23);
            this._LocationComboBox.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(190, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 200;
            this.label12.Text = "立地";
            // 
            // TorideEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(354, 271);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._LocationComboBox);
            this.Controls.Add(this._ScaleLevelLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._MoraleTextBox);
            this.Controls.Add(this._DefensePowerTextBox);
            this.Controls.Add(this._NumOfStrongWarshipsTextBox);
            this.Controls.Add(this._NumOfMiddleWarshipsTextBox);
            this.Controls.Add(this._NumOfWeakWarshipsTextBox);
            this.Controls.Add(this._DegreeOfTrainingTextBox);
            this.Controls.Add(this._MilitaryFoodTextBox);
            this.Controls.Add(this._MoneyTextBox);
            this.Controls.Add(this._ScaleTextBox);
            this.Controls.Add(this._LeaderComboBox);
            this.Controls.Add(this._NameComboBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "TorideEditForm";
            this.Text = "海賊砦：主要項目の編集";
            this.Load += new System.EventHandler(this.TorideEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.ComboBox _NameComboBox;
        private System.Windows.Forms.ComboBox _LeaderComboBox;
        private System.Windows.Forms.TextBox _ScaleTextBox;
        private System.Windows.Forms.TextBox _MoneyTextBox;
        private System.Windows.Forms.TextBox _MilitaryFoodTextBox;
        private System.Windows.Forms.TextBox _DegreeOfTrainingTextBox;
        private System.Windows.Forms.TextBox _NumOfWeakWarshipsTextBox;
        private System.Windows.Forms.TextBox _NumOfMiddleWarshipsTextBox;
        private System.Windows.Forms.TextBox _NumOfStrongWarshipsTextBox;
        private System.Windows.Forms.TextBox _DefensePowerTextBox;
        private System.Windows.Forms.TextBox _MoraleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label _ScaleLevelLabel;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.ComboBox _LocationComboBox;
        private System.Windows.Forms.Label label12;
    }
}