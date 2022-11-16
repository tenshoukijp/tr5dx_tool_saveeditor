
namespace Taiko5DXSaveEditor.DataEditForms.KyotenEdit
{
    partial class KyotenImageEditForm
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
            this._KyotenImagePictureBox = new System.Windows.Forms.PictureBox();
            this._OKButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this._KyotenImageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._KyotenImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _KyotenImagePictureBox
            // 
            this._KyotenImagePictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this._KyotenImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this._KyotenImagePictureBox.Name = "_KyotenImagePictureBox";
            this._KyotenImagePictureBox.Size = new System.Drawing.Size(800, 450);
            this._KyotenImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._KyotenImagePictureBox.TabIndex = 0;
            this._KyotenImagePictureBox.TabStop = false;
            // 
            // _OKButton
            // 
            this._OKButton.Location = new System.Drawing.Point(639, 480);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _CancelButton
            // 
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(737, 480);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 101;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // _KyotenImageComboBox
            // 
            this._KyotenImageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._KyotenImageComboBox.FormattingEnabled = true;
            this._KyotenImageComboBox.Location = new System.Drawing.Point(73, 480);
            this._KyotenImageComboBox.Name = "_KyotenImageComboBox";
            this._KyotenImageComboBox.Size = new System.Drawing.Size(287, 23);
            this._KyotenImageComboBox.TabIndex = 0;
            this._KyotenImageComboBox.SelectedIndexChanged += new System.EventHandler(this._KyotenImageComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "画像選択";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "※城の場合は選べる画像が町より少なめです";
            // 
            // KyotenImageEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(824, 513);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._KyotenImageComboBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this._KyotenImagePictureBox);
            this.Name = "KyotenImageEditForm";
            this.Text = "：拠点画像の編集";
            this.Load += new System.EventHandler(this.KyotenImageEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._KyotenImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _KyotenImagePictureBox;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.ComboBox _KyotenImageComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}