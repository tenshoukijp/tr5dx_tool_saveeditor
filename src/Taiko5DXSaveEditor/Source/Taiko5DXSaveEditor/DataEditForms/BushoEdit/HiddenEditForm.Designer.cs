
namespace Taiko5DXSaveEditor.DataEditForms.BushoEdit
{
    partial class HiddenEditForm
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
            this._Face1TextBox = new System.Windows.Forms.TextBox();
            this._Face2TextBox = new System.Windows.Forms.TextBox();
            this._CauseOfDeathComboBox = new System.Windows.Forms.ComboBox();
            this._OriginComboBox = new System.Windows.Forms.ComboBox();
            this._WeaponTypeComboBox = new System.Windows.Forms.ComboBox();
            this._TemperComboBox = new System.Windows.Forms.ComboBox();
            this._SpiritComboBox = new System.Windows.Forms.ComboBox();
            this._IsmComboBox = new System.Windows.Forms.ComboBox();
            this._PreferenceComboBox = new System.Windows.Forms.ComboBox();
            this._BehaviorComboBox = new System.Windows.Forms.ComboBox();
            this._AmbitionTextBox = new System.Windows.Forms.TextBox();
            this._OccupationComboBox = new System.Windows.Forms.ComboBox();
            this._HonorComboBox = new System.Windows.Forms.ComboBox();
            this._DesireComboBox = new System.Windows.Forms.ComboBox();
            this._WifePersonalityComboBox = new System.Windows.Forms.ComboBox();
            this._FormationComboBox = new System.Windows.Forms.ComboBox();
            this._DrinkingComboBox = new System.Windows.Forms.ComboBox();
            this._CompatibilityTextBox = new System.Windows.Forms.TextBox();
            this._SeiryokuCompatibilityTextBox = new System.Windows.Forms.TextBox();
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
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._LuckComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(327, 356);
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
            this._OKButton.Location = new System.Drawing.Point(231, 356);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _Face1TextBox
            // 
            this._Face1TextBox.Location = new System.Drawing.Point(75, 15);
            this._Face1TextBox.MaxLength = 5;
            this._Face1TextBox.Name = "_Face1TextBox";
            this._Face1TextBox.Size = new System.Drawing.Size(120, 23);
            this._Face1TextBox.TabIndex = 0;
            this._ToolTip.SetToolTip(this._Face1TextBox, "0-65535");
            // 
            // _Face2TextBox
            // 
            this._Face2TextBox.Location = new System.Drawing.Point(75, 48);
            this._Face2TextBox.MaxLength = 5;
            this._Face2TextBox.Name = "_Face2TextBox";
            this._Face2TextBox.Size = new System.Drawing.Size(120, 23);
            this._Face2TextBox.TabIndex = 1;
            this._ToolTip.SetToolTip(this._Face2TextBox, "0-65535");
            // 
            // _CauseOfDeathComboBox
            // 
            this._CauseOfDeathComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CauseOfDeathComboBox.FormattingEnabled = true;
            this._CauseOfDeathComboBox.Items.AddRange(new object[] {
            "戦死",
            "病死"});
            this._CauseOfDeathComboBox.Location = new System.Drawing.Point(75, 213);
            this._CauseOfDeathComboBox.Name = "_CauseOfDeathComboBox";
            this._CauseOfDeathComboBox.Size = new System.Drawing.Size(120, 23);
            this._CauseOfDeathComboBox.TabIndex = 6;
            // 
            // _OriginComboBox
            // 
            this._OriginComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._OriginComboBox.FormattingEnabled = true;
            this._OriginComboBox.Items.AddRange(new object[] {
            "源氏",
            "平氏",
            "藤原氏",
            "その他"});
            this._OriginComboBox.Location = new System.Drawing.Point(75, 246);
            this._OriginComboBox.Name = "_OriginComboBox";
            this._OriginComboBox.Size = new System.Drawing.Size(120, 23);
            this._OriginComboBox.TabIndex = 7;
            // 
            // _WeaponTypeComboBox
            // 
            this._WeaponTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._WeaponTypeComboBox.FormattingEnabled = true;
            this._WeaponTypeComboBox.Items.AddRange(new object[] {
            "刀剣",
            "槍",
            "苦無",
            "鎖鎌",
            "火縄銃",
            "弓"});
            this._WeaponTypeComboBox.Location = new System.Drawing.Point(75, 279);
            this._WeaponTypeComboBox.Name = "_WeaponTypeComboBox";
            this._WeaponTypeComboBox.Size = new System.Drawing.Size(120, 23);
            this._WeaponTypeComboBox.TabIndex = 8;
            // 
            // _TemperComboBox
            // 
            this._TemperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._TemperComboBox.FormattingEnabled = true;
            this._TemperComboBox.Items.AddRange(new object[] {
            "短気",
            "普通",
            "温厚"});
            this._TemperComboBox.Location = new System.Drawing.Point(75, 312);
            this._TemperComboBox.Name = "_TemperComboBox";
            this._TemperComboBox.Size = new System.Drawing.Size(120, 23);
            this._TemperComboBox.TabIndex = 9;
            // 
            // _SpiritComboBox
            // 
            this._SpiritComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._SpiritComboBox.FormattingEnabled = true;
            this._SpiritComboBox.Items.AddRange(new object[] {
            "小心",
            "普通",
            "剛胆"});
            this._SpiritComboBox.Location = new System.Drawing.Point(282, 15);
            this._SpiritComboBox.Name = "_SpiritComboBox";
            this._SpiritComboBox.Size = new System.Drawing.Size(120, 23);
            this._SpiritComboBox.TabIndex = 10;
            // 
            // _IsmComboBox
            // 
            this._IsmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._IsmComboBox.FormattingEnabled = true;
            this._IsmComboBox.Items.AddRange(new object[] {
            "現実",
            "普通",
            "理想"});
            this._IsmComboBox.Location = new System.Drawing.Point(282, 48);
            this._IsmComboBox.Name = "_IsmComboBox";
            this._IsmComboBox.Size = new System.Drawing.Size(120, 23);
            this._IsmComboBox.TabIndex = 11;
            // 
            // _PreferenceComboBox
            // 
            this._PreferenceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._PreferenceComboBox.FormattingEnabled = true;
            this._PreferenceComboBox.Items.AddRange(new object[] {
            "武具",
            "芸術品",
            "書物",
            "南蛮物"});
            this._PreferenceComboBox.Location = new System.Drawing.Point(282, 180);
            this._PreferenceComboBox.Name = "_PreferenceComboBox";
            this._PreferenceComboBox.Size = new System.Drawing.Size(120, 23);
            this._PreferenceComboBox.TabIndex = 15;
            // 
            // _BehaviorComboBox
            // 
            this._BehaviorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._BehaviorComboBox.FormattingEnabled = true;
            this._BehaviorComboBox.Items.AddRange(new object[] {
            "軽率",
            "普通",
            "慎重"});
            this._BehaviorComboBox.Location = new System.Drawing.Point(282, 81);
            this._BehaviorComboBox.Name = "_BehaviorComboBox";
            this._BehaviorComboBox.Size = new System.Drawing.Size(120, 23);
            this._BehaviorComboBox.TabIndex = 12;
            // 
            // _AmbitionTextBox
            // 
            this._AmbitionTextBox.Location = new System.Drawing.Point(282, 147);
            this._AmbitionTextBox.MaxLength = 3;
            this._AmbitionTextBox.Name = "_AmbitionTextBox";
            this._AmbitionTextBox.Size = new System.Drawing.Size(120, 23);
            this._AmbitionTextBox.TabIndex = 14;
            // 
            // _OccupationComboBox
            // 
            this._OccupationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._OccupationComboBox.FormattingEnabled = true;
            this._OccupationComboBox.Items.AddRange(new object[] {
            "武将のみ",
            "全職種",
            "武将以外優先",
            "その気なし"});
            this._OccupationComboBox.Location = new System.Drawing.Point(282, 279);
            this._OccupationComboBox.Name = "_OccupationComboBox";
            this._OccupationComboBox.Size = new System.Drawing.Size(120, 23);
            this._OccupationComboBox.TabIndex = 18;
            // 
            // _HonorComboBox
            // 
            this._HonorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._HonorComboBox.FormattingEnabled = true;
            this._HonorComboBox.Items.AddRange(new object[] {
            "不義理",
            "普通",
            "義理堅い"});
            this._HonorComboBox.Location = new System.Drawing.Point(282, 114);
            this._HonorComboBox.Name = "_HonorComboBox";
            this._HonorComboBox.Size = new System.Drawing.Size(120, 23);
            this._HonorComboBox.TabIndex = 13;
            // 
            // _DesireComboBox
            // 
            this._DesireComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._DesireComboBox.FormattingEnabled = true;
            this._DesireComboBox.Items.AddRange(new object[] {
            "欲張り",
            "普通",
            "無欲"});
            this._DesireComboBox.Location = new System.Drawing.Point(282, 213);
            this._DesireComboBox.Name = "_DesireComboBox";
            this._DesireComboBox.Size = new System.Drawing.Size(120, 23);
            this._DesireComboBox.TabIndex = 16;
            // 
            // _WifePersonalityComboBox
            // 
            this._WifePersonalityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._WifePersonalityComboBox.FormattingEnabled = true;
            this._WifePersonalityComboBox.Items.AddRange(new object[] {
            "普通",
            "高飛車",
            "おしとやか",
            "お転婆"});
            this._WifePersonalityComboBox.Location = new System.Drawing.Point(282, 312);
            this._WifePersonalityComboBox.Name = "_WifePersonalityComboBox";
            this._WifePersonalityComboBox.Size = new System.Drawing.Size(120, 23);
            this._WifePersonalityComboBox.TabIndex = 19;
            // 
            // _FormationComboBox
            // 
            this._FormationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._FormationComboBox.FormattingEnabled = true;
            this._FormationComboBox.Items.AddRange(new object[] {
            "戦闘力",
            "やや身分",
            "親密相性",
            "身分+気分"});
            this._FormationComboBox.Location = new System.Drawing.Point(75, 147);
            this._FormationComboBox.Name = "_FormationComboBox";
            this._FormationComboBox.Size = new System.Drawing.Size(120, 23);
            this._FormationComboBox.TabIndex = 4;
            // 
            // _DrinkingComboBox
            // 
            this._DrinkingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._DrinkingComboBox.FormattingEnabled = true;
            this._DrinkingComboBox.Items.AddRange(new object[] {
            "下戸",
            "普通",
            "上戸"});
            this._DrinkingComboBox.Location = new System.Drawing.Point(282, 246);
            this._DrinkingComboBox.Name = "_DrinkingComboBox";
            this._DrinkingComboBox.Size = new System.Drawing.Size(120, 23);
            this._DrinkingComboBox.TabIndex = 17;
            // 
            // _CompatibilityTextBox
            // 
            this._CompatibilityTextBox.Location = new System.Drawing.Point(75, 81);
            this._CompatibilityTextBox.MaxLength = 2;
            this._CompatibilityTextBox.Name = "_CompatibilityTextBox";
            this._CompatibilityTextBox.Size = new System.Drawing.Size(120, 23);
            this._CompatibilityTextBox.TabIndex = 2;
            this._ToolTip.SetToolTip(this._CompatibilityTextBox, "0-99 でループ\r\n数字が近いほど親密度が上がりやすい");
            // 
            // _SeiryokuCompatibilityTextBox
            // 
            this._SeiryokuCompatibilityTextBox.Location = new System.Drawing.Point(75, 114);
            this._SeiryokuCompatibilityTextBox.MaxLength = 2;
            this._SeiryokuCompatibilityTextBox.Name = "_SeiryokuCompatibilityTextBox";
            this._SeiryokuCompatibilityTextBox.Size = new System.Drawing.Size(120, 23);
            this._SeiryokuCompatibilityTextBox.TabIndex = 3;
            this._ToolTip.SetToolTip(this._SeiryokuCompatibilityTextBox, "0-99 でループ\r\n数字が近いほど裏切りにくい");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "顔グラ1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "顔グラ2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "死因";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "出自";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "武具";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "気性";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "精神";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "主義";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(224, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 200;
            this.label9.Text = "行動";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 200;
            this.label10.Text = "義理";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(224, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 200;
            this.label11.Text = "野心";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(224, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 15);
            this.label12.TabIndex = 200;
            this.label12.Text = "好み";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(224, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 200;
            this.label13.Text = "物欲";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(224, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 200;
            this.label14.Text = "飲酒";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(224, 282);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 15);
            this.label15.TabIndex = 200;
            this.label15.Text = "士官";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(224, 315);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 15);
            this.label16.TabIndex = 200;
            this.label16.Text = "妻性格";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 15);
            this.label17.TabIndex = 200;
            this.label17.Text = "親密相性";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 15);
            this.label18.TabIndex = 200;
            this.label18.Text = "士官相性";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 183);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 15);
            this.label19.TabIndex = 200;
            this.label19.Text = "運";
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // _LuckComboBox
            // 
            this._LuckComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LuckComboBox.FormattingEnabled = true;
            this._LuckComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this._LuckComboBox.Location = new System.Drawing.Point(75, 180);
            this._LuckComboBox.Name = "_LuckComboBox";
            this._LuckComboBox.Size = new System.Drawing.Size(120, 23);
            this._LuckComboBox.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 150);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 15);
            this.label20.TabIndex = 200;
            this.label20.Text = "編制重視";
            // 
            // HiddenEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(414, 391);
            this.Controls.Add(this.label20);
            this.Controls.Add(this._LuckComboBox);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._SeiryokuCompatibilityTextBox);
            this.Controls.Add(this._CompatibilityTextBox);
            this.Controls.Add(this._DrinkingComboBox);
            this.Controls.Add(this._FormationComboBox);
            this.Controls.Add(this._WifePersonalityComboBox);
            this.Controls.Add(this._DesireComboBox);
            this.Controls.Add(this._HonorComboBox);
            this.Controls.Add(this._OccupationComboBox);
            this.Controls.Add(this._AmbitionTextBox);
            this.Controls.Add(this._BehaviorComboBox);
            this.Controls.Add(this._PreferenceComboBox);
            this.Controls.Add(this._IsmComboBox);
            this.Controls.Add(this._SpiritComboBox);
            this.Controls.Add(this._TemperComboBox);
            this.Controls.Add(this._WeaponTypeComboBox);
            this.Controls.Add(this._OriginComboBox);
            this.Controls.Add(this._CauseOfDeathComboBox);
            this.Controls.Add(this._Face2TextBox);
            this.Controls.Add(this._Face1TextBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "HiddenEditForm";
            this.Text = "人物：隠し項目の編集";
            this.Load += new System.EventHandler(this.HiddenEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.TextBox _Face1TextBox;
        private System.Windows.Forms.TextBox _Face2TextBox;
        private System.Windows.Forms.ComboBox _CauseOfDeathComboBox;
        private System.Windows.Forms.ComboBox _OriginComboBox;
        private System.Windows.Forms.ComboBox _WeaponTypeComboBox;
        private System.Windows.Forms.ComboBox _TemperComboBox;
        private System.Windows.Forms.ComboBox _SpiritComboBox;
        private System.Windows.Forms.ComboBox _IsmComboBox;
        private System.Windows.Forms.ComboBox _PreferenceComboBox;
        private System.Windows.Forms.ComboBox _BehaviorComboBox;
        private System.Windows.Forms.TextBox _AmbitionTextBox;
        private System.Windows.Forms.ComboBox _OccupationComboBox;
        private System.Windows.Forms.ComboBox _HonorComboBox;
        private System.Windows.Forms.ComboBox _DesireComboBox;
        private System.Windows.Forms.ComboBox _WifePersonalityComboBox;
        private System.Windows.Forms.ComboBox _FormationComboBox;
        private System.Windows.Forms.ComboBox _DrinkingComboBox;
        private System.Windows.Forms.TextBox _CompatibilityTextBox;
        private System.Windows.Forms.TextBox _SeiryokuCompatibilityTextBox;
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.ComboBox _LuckComboBox;
        private System.Windows.Forms.Label label20;
    }
}