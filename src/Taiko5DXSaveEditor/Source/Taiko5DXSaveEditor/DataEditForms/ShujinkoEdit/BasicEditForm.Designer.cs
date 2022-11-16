
namespace Taiko5DXSaveEditor.DataEditForms.ShujinkoEdit
{
    partial class BasicEditForm
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
            this._CardContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._CardContextMenu_All = new System.Windows.Forms.ToolStripMenuItem();
            this._CardContextMenu_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._HerbsTextBox = new System.Windows.Forms.TextBox();
            this._IronSandsTextBox = new System.Windows.Forms.TextBox();
            this._BankTextBox = new System.Windows.Forms.TextBox();
            this._MoneyTextBox = new System.Windows.Forms.TextBox();
            this._HPTextBox = new System.Windows.Forms.TextBox();
            this._Face4TextBox = new System.Windows.Forms.TextBox();
            this._Face3TextBox = new System.Windows.Forms.TextBox();
            this._Face2TextBox = new System.Windows.Forms.TextBox();
            this._Face1TextBox = new System.Windows.Forms.TextBox();
            this._OKButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this._OtherCardCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this._MeishoCardCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._ArmorComboBox = new System.Windows.Forms.ComboBox();
            this._WeaponComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._IDComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this._WifeAffectionTextBox = new System.Windows.Forms.TextBox();
            this._CardContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _CardContextMenu
            // 
            this._CardContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._CardContextMenu_All,
            this._CardContextMenu_Clear});
            this._CardContextMenu.Name = "CardContextMenu";
            this._CardContextMenu.Size = new System.Drawing.Size(120, 48);
            // 
            // _CardContextMenu_All
            // 
            this._CardContextMenu_All.Name = "_CardContextMenu_All";
            this._CardContextMenu_All.Size = new System.Drawing.Size(119, 22);
            this._CardContextMenu_All.Text = "全チェック";
            this._CardContextMenu_All.Click += new System.EventHandler(this.CardContextMenu_All_Click);
            // 
            // _CardContextMenu_Clear
            // 
            this._CardContextMenu_Clear.Name = "_CardContextMenu_Clear";
            this._CardContextMenu_Clear.Size = new System.Drawing.Size(119, 22);
            this._CardContextMenu_Clear.Text = "全解除";
            this._CardContextMenu_Clear.Click += new System.EventHandler(this.CardContextMenu_Clear_Click);
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // _HerbsTextBox
            // 
            this._HerbsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._HerbsTextBox.Location = new System.Drawing.Point(295, 118);
            this._HerbsTextBox.MaxLength = 5;
            this._HerbsTextBox.Name = "_HerbsTextBox";
            this._HerbsTextBox.Size = new System.Drawing.Size(70, 23);
            this._HerbsTextBox.TabIndex = 8;
            this._ToolTip.SetToolTip(this._HerbsTextBox, "0-65535");
            // 
            // _IronSandsTextBox
            // 
            this._IronSandsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._IronSandsTextBox.Location = new System.Drawing.Point(295, 85);
            this._IronSandsTextBox.MaxLength = 5;
            this._IronSandsTextBox.Name = "_IronSandsTextBox";
            this._IronSandsTextBox.Size = new System.Drawing.Size(70, 23);
            this._IronSandsTextBox.TabIndex = 7;
            this._ToolTip.SetToolTip(this._IronSandsTextBox, "0-65535");
            // 
            // _BankTextBox
            // 
            this._BankTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._BankTextBox.Location = new System.Drawing.Point(295, 52);
            this._BankTextBox.MaxLength = 10;
            this._BankTextBox.Name = "_BankTextBox";
            this._BankTextBox.Size = new System.Drawing.Size(70, 23);
            this._BankTextBox.TabIndex = 4;
            this._ToolTip.SetToolTip(this._BankTextBox, "0-4294967295\r\nゲーム内最高値は9999990\r\n一桁目は100文単位");
            // 
            // _MoneyTextBox
            // 
            this._MoneyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._MoneyTextBox.Location = new System.Drawing.Point(169, 52);
            this._MoneyTextBox.MaxLength = 10;
            this._MoneyTextBox.Name = "_MoneyTextBox";
            this._MoneyTextBox.Size = new System.Drawing.Size(70, 23);
            this._MoneyTextBox.TabIndex = 3;
            this._ToolTip.SetToolTip(this._MoneyTextBox, "0-4294967295\r\nゲーム中最高値は1000000\r\n一桁目は100文単位");
            // 
            // _HPTextBox
            // 
            this._HPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._HPTextBox.Location = new System.Drawing.Point(60, 52);
            this._HPTextBox.MaxLength = 3;
            this._HPTextBox.Name = "_HPTextBox";
            this._HPTextBox.Size = new System.Drawing.Size(60, 23);
            this._HPTextBox.TabIndex = 2;
            this._ToolTip.SetToolTip(this._HPTextBox, "0-255\r\nゲーム中最高値は100");
            // 
            // _Face4TextBox
            // 
            this._Face4TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Face4TextBox.Location = new System.Drawing.Point(429, 118);
            this._Face4TextBox.MaxLength = 5;
            this._Face4TextBox.Name = "_Face4TextBox";
            this._Face4TextBox.Size = new System.Drawing.Size(43, 23);
            this._Face4TextBox.TabIndex = 12;
            this._ToolTip.SetToolTip(this._Face4TextBox, "0-65535");
            // 
            // _Face3TextBox
            // 
            this._Face3TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Face3TextBox.Location = new System.Drawing.Point(429, 85);
            this._Face3TextBox.MaxLength = 5;
            this._Face3TextBox.Name = "_Face3TextBox";
            this._Face3TextBox.Size = new System.Drawing.Size(43, 23);
            this._Face3TextBox.TabIndex = 11;
            this._ToolTip.SetToolTip(this._Face3TextBox, "0-65535");
            // 
            // _Face2TextBox
            // 
            this._Face2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Face2TextBox.Location = new System.Drawing.Point(429, 52);
            this._Face2TextBox.MaxLength = 5;
            this._Face2TextBox.Name = "_Face2TextBox";
            this._Face2TextBox.Size = new System.Drawing.Size(43, 23);
            this._Face2TextBox.TabIndex = 10;
            this._ToolTip.SetToolTip(this._Face2TextBox, "0-65535");
            // 
            // _Face1TextBox
            // 
            this._Face1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Face1TextBox.Location = new System.Drawing.Point(429, 18);
            this._Face1TextBox.MaxLength = 5;
            this._Face1TextBox.Name = "_Face1TextBox";
            this._Face1TextBox.Size = new System.Drawing.Size(43, 23);
            this._Face1TextBox.TabIndex = 9;
            this._ToolTip.SetToolTip(this._Face1TextBox, "0-65535");
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(307, 376);
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
            this._CancelButton.Location = new System.Drawing.Point(397, 376);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 101;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 381);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(200, 15);
            this.label15.TabIndex = 200;
            this.label15.Text = "※右クリックで全チェック・全解除できます";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(245, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 15);
            this.label14.TabIndex = 200;
            this.label14.Text = "その他カード";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 200;
            this.label13.Text = "名所カード";
            // 
            // _OtherCardCheckedListBox
            // 
            this._OtherCardCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._OtherCardCheckedListBox.CheckOnClick = true;
            this._OtherCardCheckedListBox.ContextMenuStrip = this._CardContextMenu;
            this._OtherCardCheckedListBox.FormattingEnabled = true;
            this._OtherCardCheckedListBox.Location = new System.Drawing.Point(247, 174);
            this._OtherCardCheckedListBox.Name = "_OtherCardCheckedListBox";
            this._OtherCardCheckedListBox.ScrollAlwaysVisible = true;
            this._OtherCardCheckedListBox.Size = new System.Drawing.Size(225, 184);
            this._OtherCardCheckedListBox.TabIndex = 14;
            // 
            // _MeishoCardCheckedListBox
            // 
            this._MeishoCardCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._MeishoCardCheckedListBox.CheckOnClick = true;
            this._MeishoCardCheckedListBox.ContextMenuStrip = this._CardContextMenu;
            this._MeishoCardCheckedListBox.FormattingEnabled = true;
            this._MeishoCardCheckedListBox.Location = new System.Drawing.Point(14, 174);
            this._MeishoCardCheckedListBox.Name = "_MeishoCardCheckedListBox";
            this._MeishoCardCheckedListBox.ScrollAlwaysVisible = true;
            this._MeishoCardCheckedListBox.Size = new System.Drawing.Size(225, 184);
            this._MeishoCardCheckedListBox.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(249, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 200;
            this.label12.Text = "砂鉄数";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(249, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 200;
            this.label11.Text = "薬草数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 200;
            this.label10.Text = "防具";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 200;
            this.label9.Text = "武器";
            // 
            // _ArmorComboBox
            // 
            this._ArmorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ArmorComboBox.DropDownHeight = 200;
            this._ArmorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ArmorComboBox.FormattingEnabled = true;
            this._ArmorComboBox.IntegralHeight = false;
            this._ArmorComboBox.Location = new System.Drawing.Point(60, 118);
            this._ArmorComboBox.Name = "_ArmorComboBox";
            this._ArmorComboBox.Size = new System.Drawing.Size(179, 23);
            this._ArmorComboBox.TabIndex = 6;
            // 
            // _WeaponComboBox
            // 
            this._WeaponComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._WeaponComboBox.DropDownHeight = 200;
            this._WeaponComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._WeaponComboBox.FormattingEnabled = true;
            this._WeaponComboBox.IntegralHeight = false;
            this._WeaponComboBox.Location = new System.Drawing.Point(60, 85);
            this._WeaponComboBox.Name = "_WeaponComboBox";
            this._WeaponComboBox.Size = new System.Drawing.Size(179, 23);
            this._WeaponComboBox.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "預金";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "所持金";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "体力";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "顔グラ4";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "顔グラ3";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "顔グラ2";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "顔グラ1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "主人公";
            // 
            // _IDComboBox
            // 
            this._IDComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._IDComboBox.DropDownHeight = 200;
            this._IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._IDComboBox.FormattingEnabled = true;
            this._IDComboBox.IntegralHeight = false;
            this._IDComboBox.Location = new System.Drawing.Point(60, 17);
            this._IDComboBox.Name = "_IDComboBox";
            this._IDComboBox.Size = new System.Drawing.Size(179, 23);
            this._IDComboBox.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(373, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1, 130);
            this.label16.TabIndex = 201;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(249, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 15);
            this.label17.TabIndex = 200;
            this.label17.Text = "妻愛情";
            // 
            // _WifeAffectionTextBox
            // 
            this._WifeAffectionTextBox.Location = new System.Drawing.Point(295, 17);
            this._WifeAffectionTextBox.MaxLength = 3;
            this._WifeAffectionTextBox.Name = "_WifeAffectionTextBox";
            this._WifeAffectionTextBox.Size = new System.Drawing.Size(70, 23);
            this._WifeAffectionTextBox.TabIndex = 1;
            // 
            // BasicEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this._WifeAffectionTextBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this._OtherCardCheckedListBox);
            this.Controls.Add(this._MeishoCardCheckedListBox);
            this.Controls.Add(this._HerbsTextBox);
            this.Controls.Add(this._IronSandsTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._ArmorComboBox);
            this.Controls.Add(this._WeaponComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._BankTextBox);
            this.Controls.Add(this._MoneyTextBox);
            this.Controls.Add(this._HPTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._Face4TextBox);
            this.Controls.Add(this._Face3TextBox);
            this.Controls.Add(this._Face2TextBox);
            this.Controls.Add(this._Face1TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._IDComboBox);
            this.Name = "BasicEditForm";
            this.Text = "主人公：主要項目の編集";
            this.Load += new System.EventHandler(this.BasicEditForm_Load);
            this._CardContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _IDComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Face1TextBox;
        private System.Windows.Forms.TextBox _Face2TextBox;
        private System.Windows.Forms.TextBox _Face3TextBox;
        private System.Windows.Forms.TextBox _Face4TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _HPTextBox;
        private System.Windows.Forms.TextBox _MoneyTextBox;
        private System.Windows.Forms.TextBox _BankTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox _WeaponComboBox;
        private System.Windows.Forms.ComboBox _ArmorComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _IronSandsTextBox;
        private System.Windows.Forms.TextBox _HerbsTextBox;
        private System.Windows.Forms.CheckedListBox _MeishoCardCheckedListBox;
        private System.Windows.Forms.CheckedListBox _OtherCardCheckedListBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ContextMenuStrip _CardContextMenu;
        private System.Windows.Forms.ToolStripMenuItem _CardContextMenu_All;
        private System.Windows.Forms.ToolStripMenuItem _CardContextMenu_Clear;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox _WifeAffectionTextBox;
    }
}