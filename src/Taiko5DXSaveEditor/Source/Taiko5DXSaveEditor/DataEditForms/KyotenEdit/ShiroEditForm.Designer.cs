
namespace Taiko5DXSaveEditor.DataEditForms.KyotenEdit
{
    partial class ShiroEditForm
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
            this._PopulationTextBox = new System.Windows.Forms.TextBox();
            this._MaxKokudakaTextBox = new System.Windows.Forms.TextBox();
            this._NumOfSoldiersTextBox = new System.Windows.Forms.TextBox();
            this._MilitaryFoodTextBox = new System.Windows.Forms.TextBox();
            this._DegreeOfTrainingTextBox = new System.Windows.Forms.TextBox();
            this._ResidentSupportTextBox = new System.Windows.Forms.TextBox();
            this._MineTextBox = new System.Windows.Forms.TextBox();
            this._DefensePowerTextBox = new System.Windows.Forms.TextBox();
            this._MoraleTextBox = new System.Windows.Forms.TextBox();
            this._NumOfWarHorsesTextBox = new System.Windows.Forms.TextBox();
            this._ScaleTextBox = new System.Windows.Forms.TextBox();
            this._KokudakaTextBox = new System.Windows.Forms.TextBox();
            this._MaxMineTextBox = new System.Windows.Forms.TextBox();
            this._MoneyTextBox = new System.Windows.Forms.TextBox();
            this._NumOfGunsTextBox = new System.Windows.Forms.TextBox();
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
            this._NumOfCannonsTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this._BaseKokudakaLabel = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this._ScaleLevelLabel = new System.Windows.Forms.Label();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._LocationComboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(170, 366);
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
            this._CancelButton.Location = new System.Drawing.Point(267, 366);
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
            // _PopulationTextBox
            // 
            this._PopulationTextBox.Location = new System.Drawing.Point(67, 110);
            this._PopulationTextBox.MaxLength = 3;
            this._PopulationTextBox.Name = "_PopulationTextBox";
            this._PopulationTextBox.Size = new System.Drawing.Size(80, 23);
            this._PopulationTextBox.TabIndex = 4;
            this._ToolTip.SetToolTip(this._PopulationTextBox, "0-255");
            // 
            // _MaxKokudakaTextBox
            // 
            this._MaxKokudakaTextBox.Location = new System.Drawing.Point(173, 139);
            this._MaxKokudakaTextBox.MaxLength = 3;
            this._MaxKokudakaTextBox.Name = "_MaxKokudakaTextBox";
            this._MaxKokudakaTextBox.Size = new System.Drawing.Size(80, 23);
            this._MaxKokudakaTextBox.TabIndex = 6;
            this._ToolTip.SetToolTip(this._MaxKokudakaTextBox, "0-255\r\n城の規模によって、これに掛ける値が変わる");
            // 
            // _NumOfSoldiersTextBox
            // 
            this._NumOfSoldiersTextBox.Location = new System.Drawing.Point(242, 208);
            this._NumOfSoldiersTextBox.MaxLength = 5;
            this._NumOfSoldiersTextBox.Name = "_NumOfSoldiersTextBox";
            this._NumOfSoldiersTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfSoldiersTextBox.TabIndex = 14;
            this._ToolTip.SetToolTip(this._NumOfSoldiersTextBox, "0-65535");
            // 
            // _MilitaryFoodTextBox
            // 
            this._MilitaryFoodTextBox.Location = new System.Drawing.Point(67, 237);
            this._MilitaryFoodTextBox.MaxLength = 10;
            this._MilitaryFoodTextBox.Name = "_MilitaryFoodTextBox";
            this._MilitaryFoodTextBox.Size = new System.Drawing.Size(100, 23);
            this._MilitaryFoodTextBox.TabIndex = 10;
            this._ToolTip.SetToolTip(this._MilitaryFoodTextBox, "0-4294967295");
            // 
            // _DegreeOfTrainingTextBox
            // 
            this._DegreeOfTrainingTextBox.Location = new System.Drawing.Point(242, 237);
            this._DegreeOfTrainingTextBox.MaxLength = 3;
            this._DegreeOfTrainingTextBox.Name = "_DegreeOfTrainingTextBox";
            this._DegreeOfTrainingTextBox.Size = new System.Drawing.Size(100, 23);
            this._DegreeOfTrainingTextBox.TabIndex = 15;
            this._ToolTip.SetToolTip(this._DegreeOfTrainingTextBox, "0-255");
            // 
            // _ResidentSupportTextBox
            // 
            this._ResidentSupportTextBox.Location = new System.Drawing.Point(242, 324);
            this._ResidentSupportTextBox.MaxLength = 3;
            this._ResidentSupportTextBox.Name = "_ResidentSupportTextBox";
            this._ResidentSupportTextBox.Size = new System.Drawing.Size(100, 23);
            this._ResidentSupportTextBox.TabIndex = 18;
            this._ToolTip.SetToolTip(this._ResidentSupportTextBox, "0-255");
            // 
            // _MineTextBox
            // 
            this._MineTextBox.Location = new System.Drawing.Point(67, 168);
            this._MineTextBox.MaxLength = 3;
            this._MineTextBox.Name = "_MineTextBox";
            this._MineTextBox.Size = new System.Drawing.Size(80, 23);
            this._MineTextBox.TabIndex = 7;
            this._ToolTip.SetToolTip(this._MineTextBox, "0-255");
            // 
            // _DefensePowerTextBox
            // 
            this._DefensePowerTextBox.Location = new System.Drawing.Point(242, 295);
            this._DefensePowerTextBox.MaxLength = 3;
            this._DefensePowerTextBox.Name = "_DefensePowerTextBox";
            this._DefensePowerTextBox.Size = new System.Drawing.Size(100, 23);
            this._DefensePowerTextBox.TabIndex = 17;
            this._ToolTip.SetToolTip(this._DefensePowerTextBox, "0-255");
            // 
            // _MoraleTextBox
            // 
            this._MoraleTextBox.Location = new System.Drawing.Point(242, 266);
            this._MoraleTextBox.MaxLength = 3;
            this._MoraleTextBox.Name = "_MoraleTextBox";
            this._MoraleTextBox.Size = new System.Drawing.Size(100, 23);
            this._MoraleTextBox.TabIndex = 16;
            this._ToolTip.SetToolTip(this._MoraleTextBox, "0-255");
            // 
            // _NumOfWarHorsesTextBox
            // 
            this._NumOfWarHorsesTextBox.Location = new System.Drawing.Point(67, 266);
            this._NumOfWarHorsesTextBox.MaxLength = 5;
            this._NumOfWarHorsesTextBox.Name = "_NumOfWarHorsesTextBox";
            this._NumOfWarHorsesTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfWarHorsesTextBox.TabIndex = 11;
            this._ToolTip.SetToolTip(this._NumOfWarHorsesTextBox, "0-65535");
            // 
            // _ScaleTextBox
            // 
            this._ScaleTextBox.Location = new System.Drawing.Point(67, 81);
            this._ScaleTextBox.MaxLength = 3;
            this._ScaleTextBox.Name = "_ScaleTextBox";
            this._ScaleTextBox.Size = new System.Drawing.Size(80, 23);
            this._ScaleTextBox.TabIndex = 2;
            this._ToolTip.SetToolTip(this._ScaleTextBox, "0-255\r\nゲーム中の最大値は30");
            // 
            // _KokudakaTextBox
            // 
            this._KokudakaTextBox.Location = new System.Drawing.Point(67, 139);
            this._KokudakaTextBox.MaxLength = 5;
            this._KokudakaTextBox.Name = "_KokudakaTextBox";
            this._KokudakaTextBox.Size = new System.Drawing.Size(80, 23);
            this._KokudakaTextBox.TabIndex = 5;
            this._ToolTip.SetToolTip(this._KokudakaTextBox, "0-65535");
            // 
            // _MaxMineTextBox
            // 
            this._MaxMineTextBox.Location = new System.Drawing.Point(173, 168);
            this._MaxMineTextBox.MaxLength = 3;
            this._MaxMineTextBox.Name = "_MaxMineTextBox";
            this._MaxMineTextBox.Size = new System.Drawing.Size(80, 23);
            this._MaxMineTextBox.TabIndex = 8;
            this._ToolTip.SetToolTip(this._MaxMineTextBox, "0-255");
            // 
            // _MoneyTextBox
            // 
            this._MoneyTextBox.Location = new System.Drawing.Point(67, 208);
            this._MoneyTextBox.MaxLength = 10;
            this._MoneyTextBox.Name = "_MoneyTextBox";
            this._MoneyTextBox.Size = new System.Drawing.Size(100, 23);
            this._MoneyTextBox.TabIndex = 9;
            this._ToolTip.SetToolTip(this._MoneyTextBox, "0-4294967295");
            // 
            // _NumOfGunsTextBox
            // 
            this._NumOfGunsTextBox.Location = new System.Drawing.Point(67, 295);
            this._NumOfGunsTextBox.MaxLength = 5;
            this._NumOfGunsTextBox.Name = "_NumOfGunsTextBox";
            this._NumOfGunsTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfGunsTextBox.TabIndex = 12;
            this._ToolTip.SetToolTip(this._NumOfGunsTextBox, "0-65535");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "城名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "城主";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "規模";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "石高";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "鉱山";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "人口";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "軍資金";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "兵糧";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 200;
            this.label9.Text = "兵士数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(183, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 200;
            this.label10.Text = "防御度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(183, 327);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 200;
            this.label11.Text = "住民安定";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(183, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 15);
            this.label12.TabIndex = 200;
            this.label12.Text = "訓練度";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(183, 269);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 200;
            this.label13.Text = "士気";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 200;
            this.label14.Text = "軍馬";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 298);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 15);
            this.label15.TabIndex = 200;
            this.label15.Text = "鉄砲";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 327);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 15);
            this.label16.TabIndex = 200;
            this.label16.Text = "大筒";
            // 
            // _NumOfCannonsTextBox
            // 
            this._NumOfCannonsTextBox.Location = new System.Drawing.Point(67, 324);
            this._NumOfCannonsTextBox.MaxLength = 5;
            this._NumOfCannonsTextBox.Name = "_NumOfCannonsTextBox";
            this._NumOfCannonsTextBox.Size = new System.Drawing.Size(100, 23);
            this._NumOfCannonsTextBox.TabIndex = 13;
            this._ToolTip.SetToolTip(this._NumOfCannonsTextBox, "0-65535");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(155, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(12, 15);
            this.label17.TabIndex = 200;
            this.label17.Text = "/";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(155, 171);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 15);
            this.label18.TabIndex = 200;
            this.label18.Text = "/";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(153, 113);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 15);
            this.label19.TabIndex = 200;
            this.label19.Text = "+ 50 千人";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(259, 142);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 15);
            this.label20.TabIndex = 200;
            this.label20.Text = "×";
            // 
            // _BaseKokudakaLabel
            // 
            this._BaseKokudakaLabel.AutoSize = true;
            this._BaseKokudakaLabel.Location = new System.Drawing.Point(280, 142);
            this._BaseKokudakaLabel.Name = "_BaseKokudakaLabel";
            this._BaseKokudakaLabel.Size = new System.Drawing.Size(17, 15);
            this._BaseKokudakaLabel.TabIndex = 200;
            this._BaseKokudakaLabel.Text = "??";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(303, 142);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 15);
            this.label22.TabIndex = 200;
            this.label22.Text = "千石";
            // 
            // _ScaleLevelLabel
            // 
            this._ScaleLevelLabel.AutoSize = true;
            this._ScaleLevelLabel.Location = new System.Drawing.Point(153, 84);
            this._ScaleLevelLabel.Name = "_ScaleLevelLabel";
            this._ScaleLevelLabel.Size = new System.Drawing.Size(27, 15);
            this._ScaleLevelLabel.TabIndex = 201;
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
            this._LocationComboBox.Location = new System.Drawing.Point(242, 81);
            this._LocationComboBox.Name = "_LocationComboBox";
            this._LocationComboBox.Size = new System.Drawing.Size(100, 23);
            this._LocationComboBox.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(195, 84);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 15);
            this.label21.TabIndex = 200;
            this.label21.Text = "立地";
            // 
            // ShiroEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(354, 401);
            this.Controls.Add(this.label21);
            this.Controls.Add(this._LocationComboBox);
            this.Controls.Add(this._ScaleLevelLabel);
            this.Controls.Add(this.label22);
            this.Controls.Add(this._BaseKokudakaLabel);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this._NumOfCannonsTextBox);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._NumOfGunsTextBox);
            this.Controls.Add(this._MoneyTextBox);
            this.Controls.Add(this._MaxMineTextBox);
            this.Controls.Add(this._KokudakaTextBox);
            this.Controls.Add(this._ScaleTextBox);
            this.Controls.Add(this._NumOfWarHorsesTextBox);
            this.Controls.Add(this._MoraleTextBox);
            this.Controls.Add(this._DefensePowerTextBox);
            this.Controls.Add(this._MineTextBox);
            this.Controls.Add(this._ResidentSupportTextBox);
            this.Controls.Add(this._DegreeOfTrainingTextBox);
            this.Controls.Add(this._MilitaryFoodTextBox);
            this.Controls.Add(this._NumOfSoldiersTextBox);
            this.Controls.Add(this._MaxKokudakaTextBox);
            this.Controls.Add(this._PopulationTextBox);
            this.Controls.Add(this._LeaderComboBox);
            this.Controls.Add(this._NameComboBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "ShiroEditForm";
            this.Text = "城：主要項目の編集";
            this.Load += new System.EventHandler(this.ShiroEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.ComboBox _NameComboBox;
        private System.Windows.Forms.ComboBox _LeaderComboBox;
        private System.Windows.Forms.TextBox _PopulationTextBox;
        private System.Windows.Forms.TextBox _MaxKokudakaTextBox;
        private System.Windows.Forms.TextBox _NumOfSoldiersTextBox;
        private System.Windows.Forms.TextBox _MilitaryFoodTextBox;
        private System.Windows.Forms.TextBox _DegreeOfTrainingTextBox;
        private System.Windows.Forms.TextBox _ResidentSupportTextBox;
        private System.Windows.Forms.TextBox _MineTextBox;
        private System.Windows.Forms.TextBox _DefensePowerTextBox;
        private System.Windows.Forms.TextBox _MoraleTextBox;
        private System.Windows.Forms.TextBox _NumOfWarHorsesTextBox;
        private System.Windows.Forms.TextBox _ScaleTextBox;
        private System.Windows.Forms.TextBox _KokudakaTextBox;
        private System.Windows.Forms.TextBox _MaxMineTextBox;
        private System.Windows.Forms.TextBox _MoneyTextBox;
        private System.Windows.Forms.TextBox _NumOfGunsTextBox;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox _NumOfCannonsTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label _BaseKokudakaLabel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label _ScaleLevelLabel;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.ComboBox _LocationComboBox;
        private System.Windows.Forms.Label label21;
    }
}