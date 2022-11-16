
namespace Taiko5DXSaveEditor.DataEditForms.OtherEdit
{
    partial class ShokenEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._CancelButton = new System.Windows.Forms.Button();
            this._OKButton = new System.Windows.Forms.Button();
            this._DaimyokeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._ShoninTukasaComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "有力大名";
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(207, 106);
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
            this._OKButton.Location = new System.Drawing.Point(117, 106);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _DaimyokeComboBox
            // 
            this._DaimyokeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._DaimyokeComboBox.FormattingEnabled = true;
            this._DaimyokeComboBox.Location = new System.Drawing.Point(82, 15);
            this._DaimyokeComboBox.Name = "_DaimyokeComboBox";
            this._DaimyokeComboBox.Size = new System.Drawing.Size(200, 23);
            this._DaimyokeComboBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "商人司";
            // 
            // _ShoninTukasaComboBox
            // 
            this._ShoninTukasaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ShoninTukasaComboBox.FormattingEnabled = true;
            this._ShoninTukasaComboBox.Location = new System.Drawing.Point(82, 54);
            this._ShoninTukasaComboBox.Name = "_ShoninTukasaComboBox";
            this._ShoninTukasaComboBox.Size = new System.Drawing.Size(200, 23);
            this._ShoninTukasaComboBox.TabIndex = 1;
            // 
            // ShokenEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(295, 141);
            this.Controls.Add(this._ShoninTukasaComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._DaimyokeComboBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this.label1);
            this.Name = "ShokenEditForm";
            this.Text = "商圏：主要項目の編集";
            this.Load += new System.EventHandler(this.ShokenEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.ComboBox _DaimyokeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _ShoninTukasaComboBox;
    }
}