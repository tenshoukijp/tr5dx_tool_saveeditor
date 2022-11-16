
namespace Taiko5DXSaveEditor.ImportingAndExporting
{
    partial class EditingDataExportForm
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
            this._PropertiesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this._ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._ContextMenu_All = new System.Windows.Forms.ToolStripMenuItem();
            this._ContextMenu_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this._OKButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _PropertiesCheckedListBox
            // 
            this._PropertiesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._PropertiesCheckedListBox.CheckOnClick = true;
            this._PropertiesCheckedListBox.ContextMenuStrip = this._ContextMenu;
            this._PropertiesCheckedListBox.FormattingEnabled = true;
            this._PropertiesCheckedListBox.Location = new System.Drawing.Point(12, 12);
            this._PropertiesCheckedListBox.Name = "_PropertiesCheckedListBox";
            this._PropertiesCheckedListBox.ScrollAlwaysVisible = true;
            this._PropertiesCheckedListBox.Size = new System.Drawing.Size(390, 382);
            this._PropertiesCheckedListBox.TabIndex = 0;
            // 
            // _ContextMenu
            // 
            this._ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ContextMenu_All,
            this._ContextMenu_Clear});
            this._ContextMenu.Name = "_ContextMenu";
            this._ContextMenu.Size = new System.Drawing.Size(120, 48);
            // 
            // _ContextMenu_All
            // 
            this._ContextMenu_All.Name = "_ContextMenu_All";
            this._ContextMenu_All.Size = new System.Drawing.Size(119, 22);
            this._ContextMenu_All.Text = "全チェック";
            this._ContextMenu_All.Click += new System.EventHandler(this._ContextMenu_All_Click);
            // 
            // _ContextMenu_Clear
            // 
            this._ContextMenu_Clear.Name = "_ContextMenu_Clear";
            this._ContextMenu_Clear.Size = new System.Drawing.Size(119, 22);
            this._ContextMenu_Clear.Text = "全解除";
            this._ContextMenu_Clear.Click += new System.EventHandler(this._ContextMenu_Clear_Click);
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(235, 406);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 1;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(327, 406);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 2;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "※ 右クリックで全選択、全解除";
            // 
            // EditingDataExportForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(414, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this._PropertiesCheckedListBox);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditingDataExportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "エクスポート項目の選択";
            this.Load += new System.EventHandler(this.EditingDataExportForm_Load);
            this._ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox _PropertiesCheckedListBox;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.ContextMenuStrip _ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem _ContextMenu_All;
        private System.Windows.Forms.ToolStripMenuItem _ContextMenu_Clear;
        private System.Windows.Forms.Label label1;
    }
}