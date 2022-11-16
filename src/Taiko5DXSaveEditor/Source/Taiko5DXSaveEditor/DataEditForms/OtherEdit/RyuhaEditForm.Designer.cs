
namespace Taiko5DXSaveEditor.DataEditForms.OtherEdit
{
    partial class RyuhaEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._NameComboBox = new System.Windows.Forms.ComboBox();
            this._LeaderComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._LicenseComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._DojoYaburiComboBox = new System.Windows.Forms.ComboBox();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(267, 126);
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
            this._OKButton.Location = new System.Drawing.Point(171, 126);
            this._OKButton.Name = "_OKButton";
            this._OKButton.Size = new System.Drawing.Size(75, 23);
            this._OKButton.TabIndex = 100;
            this._OKButton.Text = "OK";
            this._OKButton.UseVisualStyleBackColor = true;
            this._OKButton.Click += new System.EventHandler(this._OKButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "流派名";
            // 
            // _NameComboBox
            // 
            this._NameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._NameComboBox.FormattingEnabled = true;
            this._NameComboBox.Location = new System.Drawing.Point(67, 16);
            this._NameComboBox.Name = "_NameComboBox";
            this._NameComboBox.Size = new System.Drawing.Size(275, 23);
            this._NameComboBox.TabIndex = 0;
            // 
            // _LeaderComboBox
            // 
            this._LeaderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LeaderComboBox.FormattingEnabled = true;
            this._LeaderComboBox.Location = new System.Drawing.Point(67, 47);
            this._LeaderComboBox.Name = "_LeaderComboBox";
            this._LeaderComboBox.Size = new System.Drawing.Size(275, 23);
            this._LeaderComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "宗家";
            // 
            // _LicenseComboBox
            // 
            this._LicenseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._LicenseComboBox.FormattingEnabled = true;
            this._LicenseComboBox.Items.AddRange(new object[] {
            "所持していない",
            "所持している"});
            this._LicenseComboBox.Location = new System.Drawing.Point(67, 79);
            this._LicenseComboBox.Name = "_LicenseComboBox";
            this._LicenseComboBox.Size = new System.Drawing.Size(120, 23);
            this._LicenseComboBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "印可状";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "道場破り";
            // 
            // _DojoYaburiComboBox
            // 
            this._DojoYaburiComboBox.FormattingEnabled = true;
            this._DojoYaburiComboBox.Items.AddRange(new object[] {
            "0",
            "6"});
            this._DojoYaburiComboBox.Location = new System.Drawing.Point(260, 79);
            this._DojoYaburiComboBox.MaxLength = 3;
            this._DojoYaburiComboBox.Name = "_DojoYaburiComboBox";
            this._DojoYaburiComboBox.Size = new System.Drawing.Size(82, 23);
            this._DojoYaburiComboBox.TabIndex = 3;
            this._ToolTip.SetToolTip(this._DojoYaburiComboBox, "0-255\r\n通常は道場破りしてないと0していると6となる");
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // RyuhaEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(354, 161);
            this.Controls.Add(this._DojoYaburiComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._LicenseComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._LeaderComboBox);
            this.Controls.Add(this._NameComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "RyuhaEditForm";
            this.Text = "流派：主要項目の編集";
            this.Load += new System.EventHandler(this.RyuhaEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _NameComboBox;
        private System.Windows.Forms.ComboBox _LeaderComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _LicenseComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _DojoYaburiComboBox;
        private System.Windows.Forms.ToolTip _ToolTip;
    }
}