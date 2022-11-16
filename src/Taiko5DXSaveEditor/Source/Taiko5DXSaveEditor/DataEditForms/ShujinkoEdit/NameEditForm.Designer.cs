
namespace Taiko5DXSaveEditor.DataEditForms.ShujinkoEdit
{
    partial class NameEditForm
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
            this._NameOfMyRyuhaTextBox = new System.Windows.Forms.TextBox();
            this._KanaOfMyRyuhaTextBox = new System.Windows.Forms.TextBox();
            this._NameOfMyShokaTextBox = new System.Windows.Forms.TextBox();
            this._KanaOfMyShokaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(162, 156);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 4;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(257, 156);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 5;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // _NameOfMyRyuhaTextBox
            // 
            this._NameOfMyRyuhaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._NameOfMyRyuhaTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this._NameOfMyRyuhaTextBox.Location = new System.Drawing.Point(162, 20);
            this._NameOfMyRyuhaTextBox.MaxLength = 4;
            this._NameOfMyRyuhaTextBox.Name = "_NameOfMyRyuhaTextBox";
            this._NameOfMyRyuhaTextBox.Size = new System.Drawing.Size(139, 23);
            this._NameOfMyRyuhaTextBox.TabIndex = 0;
            this._ToolTip.SetToolTip(this._NameOfMyRyuhaTextBox, "Shift JIS 全角4文字");
            // 
            // _KanaOfMyRyuhaTextBox
            // 
            this._KanaOfMyRyuhaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._KanaOfMyRyuhaTextBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this._KanaOfMyRyuhaTextBox.Location = new System.Drawing.Point(162, 50);
            this._KanaOfMyRyuhaTextBox.MaxLength = 13;
            this._KanaOfMyRyuhaTextBox.Name = "_KanaOfMyRyuhaTextBox";
            this._KanaOfMyRyuhaTextBox.Size = new System.Drawing.Size(139, 23);
            this._KanaOfMyRyuhaTextBox.TabIndex = 1;
            this._ToolTip.SetToolTip(this._KanaOfMyRyuhaTextBox, "Shift JIS 半角カタカナ13文字");
            // 
            // _NameOfMyShokaTextBox
            // 
            this._NameOfMyShokaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._NameOfMyShokaTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this._NameOfMyShokaTextBox.Location = new System.Drawing.Point(162, 80);
            this._NameOfMyShokaTextBox.MaxLength = 3;
            this._NameOfMyShokaTextBox.Name = "_NameOfMyShokaTextBox";
            this._NameOfMyShokaTextBox.Size = new System.Drawing.Size(139, 23);
            this._NameOfMyShokaTextBox.TabIndex = 2;
            this._ToolTip.SetToolTip(this._NameOfMyShokaTextBox, "Shift JIS 全角3文字");
            // 
            // _KanaOfMyShokaTextBox
            // 
            this._KanaOfMyShokaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._KanaOfMyShokaTextBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this._KanaOfMyShokaTextBox.Location = new System.Drawing.Point(162, 110);
            this._KanaOfMyShokaTextBox.MaxLength = 11;
            this._KanaOfMyShokaTextBox.Name = "_KanaOfMyShokaTextBox";
            this._KanaOfMyShokaTextBox.Size = new System.Drawing.Size(139, 23);
            this._KanaOfMyShokaTextBox.TabIndex = 3;
            this._ToolTip.SetToolTip(this._KanaOfMyShokaTextBox, "Shift JIS 半角カタカナ11文字");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "主人公流派の名前";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "主人公流派の名前（読み）";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "流";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "ﾘｭｳ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "主人公商家の屋号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "主人公商家の屋号（読み）";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "屋";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "ﾔ";
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // NameEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(344, 191);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._KanaOfMyShokaTextBox);
            this.Controls.Add(this._NameOfMyShokaTextBox);
            this.Controls.Add(this._KanaOfMyRyuhaTextBox);
            this.Controls.Add(this._NameOfMyRyuhaTextBox);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "NameEditForm";
            this.Text = "主人公：流派名・屋号の編集";
            this.Load += new System.EventHandler(this.NameEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.TextBox _NameOfMyRyuhaTextBox;
        private System.Windows.Forms.TextBox _KanaOfMyRyuhaTextBox;
        private System.Windows.Forms.TextBox _NameOfMyShokaTextBox;
        private System.Windows.Forms.TextBox _KanaOfMyShokaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip _ToolTip;
    }
}