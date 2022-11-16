
namespace Taiko5DXSaveEditor.DataEditForms.SeiryokuEdit
{
    partial class StoreEditForm
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
            this._StoreListBox = new System.Windows.Forms.ListBox();
            this._StoreListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._HomeStoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._LeaderComboBox = new System.Windows.Forms.ComboBox();
            this._KyotenComboBox = new System.Windows.Forms.ComboBox();
            this._MoneyTextBox = new System.Windows.Forms.TextBox();
            this._GunsTextBox = new System.Windows.Forms.TextBox();
            this._AdvertisementTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._StoreListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(317, 256);
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
            this._OKButton.Location = new System.Drawing.Point(223, 256);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _StoreListBox
            // 
            this._StoreListBox.ContextMenuStrip = this._StoreListContextMenu;
            this._StoreListBox.FormattingEnabled = true;
            this._StoreListBox.ItemHeight = 15;
            this._StoreListBox.Location = new System.Drawing.Point(12, 12);
            this._StoreListBox.Name = "_StoreListBox";
            this._StoreListBox.ScrollAlwaysVisible = true;
            this._StoreListBox.Size = new System.Drawing.Size(173, 229);
            this._StoreListBox.TabIndex = 0;
            this._StoreListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this._StoreListBox_MouseDown);
            // 
            // _StoreListContextMenu
            // 
            this._StoreListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._HomeStoreMenuItem});
            this._StoreListContextMenu.Name = "_StoreListContextMenu";
            this._StoreListContextMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // _HomeStoreMenuItem
            // 
            this._HomeStoreMenuItem.Name = "_HomeStoreMenuItem";
            this._HomeStoreMenuItem.Size = new System.Drawing.Size(180, 22);
            this._HomeStoreMenuItem.Text = "本店に設定する";
            this._HomeStoreMenuItem.Click += new System.EventHandler(this._HomeStoreMenuItem_Click);
            // 
            // _LeaderComboBox
            // 
            this._LeaderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LeaderComboBox.FormattingEnabled = true;
            this._LeaderComboBox.Location = new System.Drawing.Point(262, 15);
            this._LeaderComboBox.Name = "_LeaderComboBox";
            this._LeaderComboBox.Size = new System.Drawing.Size(130, 23);
            this._LeaderComboBox.TabIndex = 1;
            // 
            // _KyotenComboBox
            // 
            this._KyotenComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._KyotenComboBox.FormattingEnabled = true;
            this._KyotenComboBox.Location = new System.Drawing.Point(262, 50);
            this._KyotenComboBox.Name = "_KyotenComboBox";
            this._KyotenComboBox.Size = new System.Drawing.Size(130, 23);
            this._KyotenComboBox.TabIndex = 2;
            // 
            // _MoneyTextBox
            // 
            this._MoneyTextBox.Location = new System.Drawing.Point(262, 85);
            this._MoneyTextBox.MaxLength = 10;
            this._MoneyTextBox.Name = "_MoneyTextBox";
            this._MoneyTextBox.Size = new System.Drawing.Size(130, 23);
            this._MoneyTextBox.TabIndex = 3;
            this._ToolTip.SetToolTip(this._MoneyTextBox, "0-4294967295");
            // 
            // _GunsTextBox
            // 
            this._GunsTextBox.Location = new System.Drawing.Point(262, 120);
            this._GunsTextBox.MaxLength = 10;
            this._GunsTextBox.Name = "_GunsTextBox";
            this._GunsTextBox.Size = new System.Drawing.Size(130, 23);
            this._GunsTextBox.TabIndex = 4;
            this._ToolTip.SetToolTip(this._GunsTextBox, "0-4294967295");
            // 
            // _AdvertisementTextBox
            // 
            this._AdvertisementTextBox.Location = new System.Drawing.Point(262, 155);
            this._AdvertisementTextBox.MaxLength = 3;
            this._AdvertisementTextBox.Name = "_AdvertisementTextBox";
            this._AdvertisementTextBox.Size = new System.Drawing.Size(100, 23);
            this._AdvertisementTextBox.TabIndex = 5;
            this._ToolTip.SetToolTip(this._AdvertisementTextBox, "0-255");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "※ リストを右クリックで本店変更可能";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "店長";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "拠点";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "資金";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "鉄砲在庫";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "宣伝効果";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "カ月";
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // StoreEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(404, 291);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._AdvertisementTextBox);
            this.Controls.Add(this._GunsTextBox);
            this.Controls.Add(this._MoneyTextBox);
            this.Controls.Add(this._KyotenComboBox);
            this.Controls.Add(this._LeaderComboBox);
            this.Controls.Add(this._StoreListBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "StoreEditForm";
            this.Text = "商家：店舗の編集";
            this.Load += new System.EventHandler(this.StoreEditForm_Load);
            this._StoreListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.ListBox _StoreListBox;
        private System.Windows.Forms.ComboBox _LeaderComboBox;
        private System.Windows.Forms.ComboBox _KyotenComboBox;
        private System.Windows.Forms.TextBox _MoneyTextBox;
        private System.Windows.Forms.TextBox _GunsTextBox;
        private System.Windows.Forms.TextBox _AdvertisementTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.ContextMenuStrip _StoreListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem _HomeStoreMenuItem;
    }
}