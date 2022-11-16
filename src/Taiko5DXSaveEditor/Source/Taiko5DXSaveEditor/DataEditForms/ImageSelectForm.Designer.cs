
namespace Taiko5DXSaveEditor.DataEditForms
{
    partial class ImageSelectForm
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
            this._ImageListView = new System.Windows.Forms.ListView();
            this._ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // _ImageListView
            // 
            this._ImageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ImageListView.HideSelection = false;
            this._ImageListView.LargeImageList = this._ImageList;
            this._ImageListView.Location = new System.Drawing.Point(0, 0);
            this._ImageListView.MultiSelect = false;
            this._ImageListView.Name = "_ImageListView";
            this._ImageListView.Size = new System.Drawing.Size(694, 461);
            this._ImageListView.TabIndex = 0;
            this._ImageListView.UseCompatibleStateImageBehavior = false;
            this._ImageListView.DoubleClick += new System.EventHandler(this._ImageListView_DoubleClick);
            this._ImageListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this._ImageListView_KeyDown);
            // 
            // _ImageList
            // 
            this._ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._ImageList.ImageSize = new System.Drawing.Size(16, 16);
            this._ImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImageSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(694, 461);
            this.Controls.Add(this._ImageListView);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageSelectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "画像をダブルクリックで選択";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _ImageListView;
        private System.Windows.Forms.ImageList _ImageList;
    }
}