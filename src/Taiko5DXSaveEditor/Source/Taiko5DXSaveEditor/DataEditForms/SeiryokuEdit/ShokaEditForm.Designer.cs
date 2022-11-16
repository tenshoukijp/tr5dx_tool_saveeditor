
namespace Taiko5DXSaveEditor.DataEditForms.SeiryokuEdit
{
    partial class ShokaEditForm
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
            this._NameComboBox = new System.Windows.Forms.ComboBox();
            this._LeaderComboBox = new System.Windows.Forms.ComboBox();
            this._HomeComboBox = new System.Windows.Forms.ComboBox();
            this._RelationshipWithShujinkoComboBox = new System.Windows.Forms.ComboBox();
            this._DepartureCounterComboBox = new System.Windows.Forms.ComboBox();
            this._OKButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // _HomeComboBox
            // 
            this._HomeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._HomeComboBox.FormattingEnabled = true;
            this._HomeComboBox.Location = new System.Drawing.Point(67, 79);
            this._HomeComboBox.Name = "_HomeComboBox";
            this._HomeComboBox.Size = new System.Drawing.Size(275, 23);
            this._HomeComboBox.TabIndex = 2;
            // 
            // _RelationshipWithShujinkoComboBox
            // 
            this._RelationshipWithShujinkoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._RelationshipWithShujinkoComboBox.FormattingEnabled = true;
            this._RelationshipWithShujinkoComboBox.Items.AddRange(new object[] {
            "無関係",
            "以前仕えていた",
            "裏切った",
            "謀反した"});
            this._RelationshipWithShujinkoComboBox.Location = new System.Drawing.Point(67, 111);
            this._RelationshipWithShujinkoComboBox.Name = "_RelationshipWithShujinkoComboBox";
            this._RelationshipWithShujinkoComboBox.Size = new System.Drawing.Size(120, 23);
            this._RelationshipWithShujinkoComboBox.TabIndex = 3;
            // 
            // _DepartureCounterComboBox
            // 
            this._DepartureCounterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._DepartureCounterComboBox.FormattingEnabled = true;
            this._DepartureCounterComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this._DepartureCounterComboBox.Location = new System.Drawing.Point(267, 111);
            this._DepartureCounterComboBox.Name = "_DepartureCounterComboBox";
            this._DepartureCounterComboBox.Size = new System.Drawing.Size(75, 23);
            this._DepartureCounterComboBox.TabIndex = 4;
            // 
            // _OKButton
            // 
            this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OKButton.Location = new System.Drawing.Point(172, 155);
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
            this._CancelButton.Location = new System.Drawing.Point(267, 155);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 101;
            this._CancelButton.Text = "キャンセル";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this._CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "商家名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "当主";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "本店";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 30);
            this.label4.TabIndex = 200;
            this.label4.Text = "主人公\r\nとの関係";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 200;
            this.label5.Text = "出奔カウンタ";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 15);
            this.label6.TabIndex = 200;
            this.label6.Text = "※当主無し勢力は滅亡";
            // 
            // ShokaEditForm
            // 
            this.AcceptButton = this._OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(354, 191);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this._DepartureCounterComboBox);
            this.Controls.Add(this._RelationshipWithShujinkoComboBox);
            this.Controls.Add(this._HomeComboBox);
            this.Controls.Add(this._LeaderComboBox);
            this.Controls.Add(this._NameComboBox);
            this.Name = "ShokaEditForm";
            this.Text = "商家：主要項目の編集";
            this.Load += new System.EventHandler(this.ShokaEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _NameComboBox;
        private System.Windows.Forms.ComboBox _LeaderComboBox;
        private System.Windows.Forms.ComboBox _HomeComboBox;
        private System.Windows.Forms.ComboBox _RelationshipWithShujinkoComboBox;
        private System.Windows.Forms.ComboBox _DepartureCounterComboBox;
        private System.Windows.Forms.Button _OKButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}