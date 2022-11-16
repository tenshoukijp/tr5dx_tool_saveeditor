
namespace Taiko5DXSaveEditor.DataEditForms.KyotenEdit
{
    partial class MachiEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._NameComboBox = new System.Windows.Forms.ComboBox();
            this._ScaleTextBox = new System.Windows.Forms.TextBox();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._ScaleLevelLabel = new System.Windows.Forms.Label();
            this._LocationComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._MoneyTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._RiceMarketPriceTextBox = new System.Windows.Forms.TextBox();
            this._RiceInventoryTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._HorseMarketPriceTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._HorseInventoryTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(157, 206);
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
            this._CancelButton.Location = new System.Drawing.Point(247, 206);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 102;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "町名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "規模";
            // 
            // _NameComboBox
            // 
            this._NameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._NameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._NameComboBox.FormattingEnabled = true;
            this._NameComboBox.Location = new System.Drawing.Point(62, 15);
            this._NameComboBox.Name = "_NameComboBox";
            this._NameComboBox.Size = new System.Drawing.Size(260, 23);
            this._NameComboBox.TabIndex = 0;
            // 
            // _ScaleTextBox
            // 
            this._ScaleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ScaleTextBox.Location = new System.Drawing.Point(62, 54);
            this._ScaleTextBox.MaxLength = 3;
            this._ScaleTextBox.Name = "_ScaleTextBox";
            this._ScaleTextBox.Size = new System.Drawing.Size(75, 23);
            this._ScaleTextBox.TabIndex = 1;
            this._ToolTip.SetToolTip(this._ScaleTextBox, "0-255\r\nゲーム中の最大値は30");
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // _ScaleLevelLabel
            // 
            this._ScaleLevelLabel.AutoSize = true;
            this._ScaleLevelLabel.Location = new System.Drawing.Point(140, 57);
            this._ScaleLevelLabel.Name = "_ScaleLevelLabel";
            this._ScaleLevelLabel.Size = new System.Drawing.Size(27, 15);
            this._ScaleLevelLabel.TabIndex = 200;
            this._ScaleLevelLabel.Text = "(？)";
            // 
            // _LocationComboBox
            // 
            this._LocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LocationComboBox.FormattingEnabled = true;
            this._LocationComboBox.Items.AddRange(new object[] {
            "港湾",
            "平地",
            "山地"});
            this._LocationComboBox.Location = new System.Drawing.Point(217, 54);
            this._LocationComboBox.Name = "_LocationComboBox";
            this._LocationComboBox.Size = new System.Drawing.Size(105, 23);
            this._LocationComboBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "立地";
            // 
            // _MoneyTextBox
            // 
            this._MoneyTextBox.Location = new System.Drawing.Point(62, 89);
            this._MoneyTextBox.MaxLength = 10;
            this._MoneyTextBox.Name = "_MoneyTextBox";
            this._MoneyTextBox.Size = new System.Drawing.Size(100, 23);
            this._MoneyTextBox.TabIndex = 3;
            this._ToolTip.SetToolTip(this._MoneyTextBox, "0-4294967295");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "投資金";
            // 
            // _RiceMarketPriceTextBox
            // 
            this._RiceMarketPriceTextBox.Location = new System.Drawing.Point(62, 124);
            this._RiceMarketPriceTextBox.MaxLength = 3;
            this._RiceMarketPriceTextBox.Name = "_RiceMarketPriceTextBox";
            this._RiceMarketPriceTextBox.Size = new System.Drawing.Size(75, 23);
            this._RiceMarketPriceTextBox.TabIndex = 4;
            this._ToolTip.SetToolTip(this._RiceMarketPriceTextBox, "0-255");
            // 
            // _RiceInventoryTextBox
            // 
            this._RiceInventoryTextBox.Location = new System.Drawing.Point(217, 124);
            this._RiceInventoryTextBox.MaxLength = 3;
            this._RiceInventoryTextBox.Name = "_RiceInventoryTextBox";
            this._RiceInventoryTextBox.Size = new System.Drawing.Size(70, 23);
            this._RiceInventoryTextBox.TabIndex = 5;
            this._ToolTip.SetToolTip(this._RiceInventoryTextBox, "0-255");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "米相場";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "米在庫";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 15);
            this.label7.TabIndex = 207;
            this.label7.Text = "貫";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "千石";
            // 
            // _HorseMarketPriceTextBox
            // 
            this._HorseMarketPriceTextBox.Location = new System.Drawing.Point(62, 159);
            this._HorseMarketPriceTextBox.MaxLength = 3;
            this._HorseMarketPriceTextBox.Name = "_HorseMarketPriceTextBox";
            this._HorseMarketPriceTextBox.Size = new System.Drawing.Size(75, 23);
            this._HorseMarketPriceTextBox.TabIndex = 6;
            this._ToolTip.SetToolTip(this._HorseMarketPriceTextBox, "0-255");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 15);
            this.label9.TabIndex = 210;
            this.label9.Text = "貫";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 200;
            this.label10.Text = "馬相場";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(168, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 200;
            this.label11.Text = "馬在庫";
            // 
            // _HorseInventoryTextBox
            // 
            this._HorseInventoryTextBox.Location = new System.Drawing.Point(217, 159);
            this._HorseInventoryTextBox.MaxLength = 3;
            this._HorseInventoryTextBox.Name = "_HorseInventoryTextBox";
            this._HorseInventoryTextBox.Size = new System.Drawing.Size(70, 23);
            this._HorseInventoryTextBox.TabIndex = 7;
            this._ToolTip.SetToolTip(this._HorseInventoryTextBox, "0-255");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(291, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 200;
            this.label12.Text = "10頭";
            // 
            // MachiEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(334, 241);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._HorseInventoryTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._HorseMarketPriceTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._RiceInventoryTextBox);
            this.Controls.Add(this._RiceMarketPriceTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._MoneyTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._LocationComboBox);
            this.Controls.Add(this._ScaleLevelLabel);
            this.Controls.Add(this._ScaleTextBox);
            this.Controls.Add(this._NameComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "MachiEditForm";
            this.Text = "町：主要項目の編集";
            this.Load += new System.EventHandler(this.MachiEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _NameComboBox;
        private System.Windows.Forms.TextBox _ScaleTextBox;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.Label _ScaleLevelLabel;
        private System.Windows.Forms.ComboBox _LocationComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _MoneyTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _RiceMarketPriceTextBox;
        private System.Windows.Forms.TextBox _RiceInventoryTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _HorseMarketPriceTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _HorseInventoryTextBox;
        private System.Windows.Forms.Label label12;
    }
}