
namespace Taiko5DXSaveEditor.DataEditForms.OtherEdit
{
    partial class HanroEditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._StoppingTextBox = new System.Windows.Forms.TextBox();
            this._MaintenanceCostsTextBox = new System.Windows.Forms.TextBox();
            this._KanjoTextBox = new System.Windows.Forms.TextBox();
            this._Machi2ComboBox = new System.Windows.Forms.ComboBox();
            this._GuardComboBox = new System.Windows.Forms.ComboBox();
            this._AdministratorComboBox = new System.Windows.Forms.ComboBox();
            this._Machi1ComboBox = new System.Windows.Forms.ComboBox();
            this._TypeComboBox = new System.Windows.Forms.ComboBox();
            this._ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(347, 176);
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
            this._OKButton.Location = new System.Drawing.Point(250, 176);
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
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "町1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "町2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "管理者";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 200;
            this.label4.Text = "護衛";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "勘定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "維持費";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 200;
            this.label7.Text = "販路種類";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "荷留め期間";
            // 
            // _StoppingTextBox
            // 
            this._StoppingTextBox.Location = new System.Drawing.Point(301, 119);
            this._StoppingTextBox.MaxLength = 3;
            this._StoppingTextBox.Name = "_StoppingTextBox";
            this._StoppingTextBox.Size = new System.Drawing.Size(87, 23);
            this._StoppingTextBox.TabIndex = 7;
            this._ToolTip.SetToolTip(this._StoppingTextBox, "0-255");
            // 
            // _MaintenanceCostsTextBox
            // 
            this._MaintenanceCostsTextBox.Location = new System.Drawing.Point(301, 85);
            this._MaintenanceCostsTextBox.MaxLength = 5;
            this._MaintenanceCostsTextBox.Name = "_MaintenanceCostsTextBox";
            this._MaintenanceCostsTextBox.Size = new System.Drawing.Size(121, 23);
            this._MaintenanceCostsTextBox.TabIndex = 5;
            this._ToolTip.SetToolTip(this._MaintenanceCostsTextBox, "0-65535");
            // 
            // _KanjoTextBox
            // 
            this._KanjoTextBox.Location = new System.Drawing.Point(77, 85);
            this._KanjoTextBox.MaxLength = 11;
            this._KanjoTextBox.Name = "_KanjoTextBox";
            this._KanjoTextBox.Size = new System.Drawing.Size(121, 23);
            this._KanjoTextBox.TabIndex = 4;
            this._ToolTip.SetToolTip(this._KanjoTextBox, "-2147483648-2147483647");
            // 
            // _Machi2ComboBox
            // 
            this._Machi2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Machi2ComboBox.FormattingEnabled = true;
            this._Machi2ComboBox.Location = new System.Drawing.Point(301, 17);
            this._Machi2ComboBox.Name = "_Machi2ComboBox";
            this._Machi2ComboBox.Size = new System.Drawing.Size(121, 23);
            this._Machi2ComboBox.TabIndex = 1;
            // 
            // _GuardComboBox
            // 
            this._GuardComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._GuardComboBox.FormattingEnabled = true;
            this._GuardComboBox.Location = new System.Drawing.Point(301, 51);
            this._GuardComboBox.Name = "_GuardComboBox";
            this._GuardComboBox.Size = new System.Drawing.Size(121, 23);
            this._GuardComboBox.TabIndex = 3;
            // 
            // _AdministratorComboBox
            // 
            this._AdministratorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._AdministratorComboBox.FormattingEnabled = true;
            this._AdministratorComboBox.Location = new System.Drawing.Point(77, 51);
            this._AdministratorComboBox.Name = "_AdministratorComboBox";
            this._AdministratorComboBox.Size = new System.Drawing.Size(121, 23);
            this._AdministratorComboBox.TabIndex = 2;
            // 
            // _Machi1ComboBox
            // 
            this._Machi1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Machi1ComboBox.FormattingEnabled = true;
            this._Machi1ComboBox.Location = new System.Drawing.Point(77, 17);
            this._Machi1ComboBox.Name = "_Machi1ComboBox";
            this._Machi1ComboBox.Size = new System.Drawing.Size(121, 23);
            this._Machi1ComboBox.TabIndex = 0;
            // 
            // _TypeComboBox
            // 
            this._TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._TypeComboBox.FormattingEnabled = true;
            this._TypeComboBox.Items.AddRange(new object[] {
            "陸路",
            "海路"});
            this._TypeComboBox.Location = new System.Drawing.Point(77, 119);
            this._TypeComboBox.Name = "_TypeComboBox";
            this._TypeComboBox.Size = new System.Drawing.Size(121, 23);
            this._TypeComboBox.TabIndex = 6;
            // 
            // _ToolTip
            // 
            this._ToolTip.AutoPopDelay = 5000;
            this._ToolTip.InitialDelay = 100;
            this._ToolTip.ReshowDelay = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(394, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 15);
            this.label9.TabIndex = 200;
            this.label9.Text = "カ月";
            // 
            // HanroEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._TypeComboBox);
            this.Controls.Add(this._Machi1ComboBox);
            this.Controls.Add(this._AdministratorComboBox);
            this.Controls.Add(this._GuardComboBox);
            this.Controls.Add(this._Machi2ComboBox);
            this.Controls.Add(this._KanjoTextBox);
            this.Controls.Add(this._MaintenanceCostsTextBox);
            this.Controls.Add(this._StoppingTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Name = "HanroEditForm";
            this.Text = "販路：主要項目の編集";
            this.Load += new System.EventHandler(this.HanroEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _StoppingTextBox;
        private System.Windows.Forms.TextBox _MaintenanceCostsTextBox;
        private System.Windows.Forms.TextBox _KanjoTextBox;
        private System.Windows.Forms.ComboBox _Machi2ComboBox;
        private System.Windows.Forms.ComboBox _GuardComboBox;
        private System.Windows.Forms.ComboBox _AdministratorComboBox;
        private System.Windows.Forms.ComboBox _Machi1ComboBox;
        private System.Windows.Forms.ComboBox _TypeComboBox;
        private System.Windows.Forms.ToolTip _ToolTip;
        private System.Windows.Forms.Label label9;
    }
}