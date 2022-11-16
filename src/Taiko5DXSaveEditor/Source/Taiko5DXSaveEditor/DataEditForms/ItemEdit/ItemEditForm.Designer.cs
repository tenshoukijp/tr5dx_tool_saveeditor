
namespace Taiko5DXSaveEditor.DataEditForms.ItemEdit
{
    partial class ItemEditForm
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
            this._NameTextBox = new System.Windows.Forms.TextBox();
            this._KanaTextBox = new System.Windows.Forms.TextBox();
            this._ImageComboBox = new System.Windows.Forms.ComboBox();
            this._PriceTextBox = new System.Windows.Forms.TextBox();
            this._ItemTypeComboBox = new System.Windows.Forms.ComboBox();
            this._RarityComboBox = new System.Windows.Forms.ComboBox();
            this._AbilityScoresTextBox = new System.Windows.Forms.TextBox();
            this._AbilityTypeComboBox = new System.Windows.Forms.ComboBox();
            this._OwnerComboBox = new System.Windows.Forms.ComboBox();
            this._NumberTextBox = new System.Windows.Forms.TextBox();
            this._SecretFlagCheckBox = new System.Windows.Forms.CheckBox();
            this._ImagePictureBox = new System.Windows.Forms.PictureBox();
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
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._ImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(300, 226);
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
            this._CancelButton.Location = new System.Drawing.Point(397, 226);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 101;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // _NameTextBox
            // 
            this._NameTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this._NameTextBox.Location = new System.Drawing.Point(74, 12);
            this._NameTextBox.MaxLength = 7;
            this._NameTextBox.Name = "_NameTextBox";
            this._NameTextBox.Size = new System.Drawing.Size(120, 23);
            this._NameTextBox.TabIndex = 0;
            this._ToolTip.SetToolTip(this._NameTextBox, "Shift JIS 全角7文字");
            // 
            // _KanaTextBox
            // 
            this._KanaTextBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this._KanaTextBox.Location = new System.Drawing.Point(74, 50);
            this._KanaTextBox.MaxLength = 17;
            this._KanaTextBox.Name = "_KanaTextBox";
            this._KanaTextBox.Size = new System.Drawing.Size(120, 23);
            this._KanaTextBox.TabIndex = 1;
            this._ToolTip.SetToolTip(this._KanaTextBox, "Shift JIS 半角カタカナ17文字");
            // 
            // _ImageComboBox
            // 
            this._ImageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ImageComboBox.FormattingEnabled = true;
            this._ImageComboBox.Location = new System.Drawing.Point(259, 12);
            this._ImageComboBox.Name = "_ImageComboBox";
            this._ImageComboBox.Size = new System.Drawing.Size(103, 23);
            this._ImageComboBox.TabIndex = 3;
            // 
            // _PriceTextBox
            // 
            this._PriceTextBox.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this._PriceTextBox.Location = new System.Drawing.Point(74, 89);
            this._PriceTextBox.MaxLength = 5;
            this._PriceTextBox.Name = "_PriceTextBox";
            this._PriceTextBox.Size = new System.Drawing.Size(120, 23);
            this._PriceTextBox.TabIndex = 2;
            this._ToolTip.SetToolTip(this._PriceTextBox, "0-65535\r\n65535を入れると未製作扱いとなる\r\nアイテムを消したい場合は、ここに65535を入れること");
            // 
            // _ItemTypeComboBox
            // 
            this._ItemTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ItemTypeComboBox.FormattingEnabled = true;
            this._ItemTypeComboBox.Location = new System.Drawing.Point(259, 50);
            this._ItemTypeComboBox.Name = "_ItemTypeComboBox";
            this._ItemTypeComboBox.Size = new System.Drawing.Size(103, 23);
            this._ItemTypeComboBox.TabIndex = 4;
            // 
            // _RarityComboBox
            // 
            this._RarityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._RarityComboBox.FormattingEnabled = true;
            this._RarityComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this._RarityComboBox.Location = new System.Drawing.Point(259, 89);
            this._RarityComboBox.Name = "_RarityComboBox";
            this._RarityComboBox.Size = new System.Drawing.Size(103, 23);
            this._RarityComboBox.TabIndex = 5;
            // 
            // _AbilityScoresTextBox
            // 
            this._AbilityScoresTextBox.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this._AbilityScoresTextBox.Location = new System.Drawing.Point(259, 128);
            this._AbilityScoresTextBox.MaxLength = 2;
            this._AbilityScoresTextBox.Name = "_AbilityScoresTextBox";
            this._AbilityScoresTextBox.Size = new System.Drawing.Size(103, 23);
            this._AbilityScoresTextBox.TabIndex = 7;
            this._ToolTip.SetToolTip(this._AbilityScoresTextBox, "0-31\r\nゲーム上の最大値は20");
            // 
            // _AbilityTypeComboBox
            // 
            this._AbilityTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._AbilityTypeComboBox.FormattingEnabled = true;
            this._AbilityTypeComboBox.Items.AddRange(new object[] {
            "統率",
            "武力",
            "政務",
            "知謀",
            "魅力"});
            this._AbilityTypeComboBox.Location = new System.Drawing.Point(74, 128);
            this._AbilityTypeComboBox.Name = "_AbilityTypeComboBox";
            this._AbilityTypeComboBox.Size = new System.Drawing.Size(120, 23);
            this._AbilityTypeComboBox.TabIndex = 6;
            // 
            // _OwnerComboBox
            // 
            this._OwnerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._OwnerComboBox.FormattingEnabled = true;
            this._OwnerComboBox.Location = new System.Drawing.Point(74, 183);
            this._OwnerComboBox.Name = "_OwnerComboBox";
            this._OwnerComboBox.Size = new System.Drawing.Size(120, 23);
            this._OwnerComboBox.TabIndex = 8;
            // 
            // _NumberTextBox
            // 
            this._NumberTextBox.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this._NumberTextBox.Location = new System.Drawing.Point(259, 183);
            this._NumberTextBox.MaxLength = 2;
            this._NumberTextBox.Name = "_NumberTextBox";
            this._NumberTextBox.Size = new System.Drawing.Size(103, 23);
            this._NumberTextBox.TabIndex = 9;
            this._ToolTip.SetToolTip(this._NumberTextBox, "0-127\r\nゲーム上の最大値は99");
            // 
            // _SecretFlagCheckBox
            // 
            this._SecretFlagCheckBox.AutoSize = true;
            this._SecretFlagCheckBox.Location = new System.Drawing.Point(385, 185);
            this._SecretFlagCheckBox.Name = "_SecretFlagCheckBox";
            this._SecretFlagCheckBox.Size = new System.Drawing.Size(87, 19);
            this._SecretFlagCheckBox.TabIndex = 10;
            this._SecretFlagCheckBox.Text = "未鑑定フラグ";
            this._SecretFlagCheckBox.UseVisualStyleBackColor = true;
            // 
            // _ImagePictureBox
            // 
            this._ImagePictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._ImagePictureBox.Location = new System.Drawing.Point(372, 12);
            this._ImagePictureBox.Name = "_ImagePictureBox";
            this._ImagePictureBox.Size = new System.Drawing.Size(100, 100);
            this._ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._ImagePictureBox.TabIndex = 13;
            this._ImagePictureBox.TabStop = false;
            this._ImagePictureBox.Click += new System.EventHandler(this._ImagePictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "名前";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "読み";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "画像";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "種類";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "価格";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "価値";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "上昇能力";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "上昇値";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(15, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(457, 1);
            this.label9.TabIndex = 200;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 200;
            this.label10.Text = "所有者";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 200;
            this.label11.Text = "所持数";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(373, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 45);
            this.label12.TabIndex = 200;
            this.label12.Text = "※ 製作アイテムの\r\n　 価格が65535の\r\n　 場合は未製作";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 230);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(222, 15);
            this.label13.TabIndex = 200;
            this.label13.Text = "※ 既製アイテムは所有情報以外は編集不可";
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // ItemEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(484, 261);
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
            this.Controls.Add(this._ImagePictureBox);
            this.Controls.Add(this._SecretFlagCheckBox);
            this.Controls.Add(this._NumberTextBox);
            this.Controls.Add(this._OwnerComboBox);
            this.Controls.Add(this._AbilityTypeComboBox);
            this.Controls.Add(this._AbilityScoresTextBox);
            this.Controls.Add(this._RarityComboBox);
            this.Controls.Add(this._ItemTypeComboBox);
            this.Controls.Add(this._PriceTextBox);
            this.Controls.Add(this._ImageComboBox);
            this.Controls.Add(this._KanaTextBox);
            this.Controls.Add(this._NameTextBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "ItemEditForm";
            this.Text = "アイテム：主要項目の編集";
            this.Load += new System.EventHandler(this.ItemEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._ImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.TextBox _NameTextBox;
        private System.Windows.Forms.TextBox _KanaTextBox;
        private System.Windows.Forms.ComboBox _ImageComboBox;
        private System.Windows.Forms.TextBox _PriceTextBox;
        private System.Windows.Forms.ComboBox _ItemTypeComboBox;
        private System.Windows.Forms.ComboBox _RarityComboBox;
        private System.Windows.Forms.TextBox _AbilityScoresTextBox;
        private System.Windows.Forms.ComboBox _AbilityTypeComboBox;
        private System.Windows.Forms.ComboBox _OwnerComboBox;
        private System.Windows.Forms.TextBox _NumberTextBox;
        private System.Windows.Forms.CheckBox _SecretFlagCheckBox;
        private System.Windows.Forms.PictureBox _ImagePictureBox;
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
        private System.Windows.Forms.ToolTip _ToolTip;
    }
}