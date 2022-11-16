
namespace Taiko5DXSaveEditor
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_World = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Shujinko = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Game_Busho = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_General = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_EventPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Citizen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Game_Daimyoke = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Shoka = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_NinjaShu = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_KaizokuShu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Game_Shiro = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Machi = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Sato = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Toride = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Game_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_CraftItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Game_Hanro = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Shoken = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Ryuha = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Game_Kani = new System.Windows.Forms.ToolStripMenuItem();
            this.GameDataTable = new System.Windows.Forms.DataGridView();
            this.ContextMenuForEditing = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_File_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Game});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1008, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // Menu_File
            // 
            this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File_Open,
            this.Menu_File_Save,
            this.Menu_File_SaveAs,
            this.toolStripSeparator6,
            this.Menu_File_Import,
            this.Menu_File_Export,
            this.toolStripSeparator7,
            this.Menu_File_Exit});
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(67, 20);
            this.Menu_File.Text = "ファイル(&F)";
            // 
            // Menu_File_Open
            // 
            this.Menu_File_Open.Image = global::Taiko5DXSaveEditor.Properties.Resources.OpenFileIcon;
            this.Menu_File_Open.Name = "Menu_File_Open";
            this.Menu_File_Open.Size = new System.Drawing.Size(244, 22);
            this.Menu_File_Open.Text = "開く(&O)";
            this.Menu_File_Open.Click += new System.EventHandler(this.Menu_File_Open_Click);
            // 
            // Menu_File_Save
            // 
            this.Menu_File_Save.Enabled = false;
            this.Menu_File_Save.Image = global::Taiko5DXSaveEditor.Properties.Resources.SaveIcon;
            this.Menu_File_Save.Name = "Menu_File_Save";
            this.Menu_File_Save.Size = new System.Drawing.Size(244, 22);
            this.Menu_File_Save.Text = "上書き保存(&S)";
            this.Menu_File_Save.Click += new System.EventHandler(this.Menu_File_Save_Click);
            // 
            // Menu_File_SaveAs
            // 
            this.Menu_File_SaveAs.Enabled = false;
            this.Menu_File_SaveAs.Name = "Menu_File_SaveAs";
            this.Menu_File_SaveAs.Size = new System.Drawing.Size(244, 22);
            this.Menu_File_SaveAs.Text = "名前を付けて保存(&A)";
            this.Menu_File_SaveAs.Click += new System.EventHandler(this.Menu_File_SaveAs_Click);
            // 
            // Menu_File_Exit
            // 
            this.Menu_File_Exit.Name = "Menu_File_Exit";
            this.Menu_File_Exit.Size = new System.Drawing.Size(244, 22);
            this.Menu_File_Exit.Text = "終了(&X)";
            this.Menu_File_Exit.Click += new System.EventHandler(this.Menu_File_Exit_Click);
            // 
            // Menu_Game
            // 
            this.Menu_Game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Game_World,
            this.Menu_Game_Shujinko,
            this.toolStripSeparator5,
            this.Menu_Game_Busho,
            this.Menu_Game_General,
            this.Menu_Game_EventPerson,
            this.Menu_Game_Citizen,
            this.toolStripSeparator1,
            this.Menu_Game_Daimyoke,
            this.Menu_Game_Shoka,
            this.Menu_Game_NinjaShu,
            this.Menu_Game_KaizokuShu,
            this.toolStripSeparator2,
            this.Menu_Game_Shiro,
            this.Menu_Game_Machi,
            this.Menu_Game_Sato,
            this.Menu_Game_Toride,
            this.toolStripSeparator3,
            this.Menu_Game_Item,
            this.Menu_Game_CraftItem,
            this.toolStripSeparator4,
            this.Menu_Game_Hanro,
            this.Menu_Game_Shoken,
            this.Menu_Game_Ryuha,
            this.Menu_Game_Kani});
            this.Menu_Game.Name = "Menu_Game";
            this.Menu_Game.Size = new System.Drawing.Size(88, 20);
            this.Menu_Game.Text = "ゲームデータ(&G)";
            // 
            // Menu_Game_World
            // 
            this.Menu_Game_World.Enabled = false;
            this.Menu_Game_World.Name = "Menu_Game_World";
            this.Menu_Game_World.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_World.Text = "世界(&W)";
            this.Menu_Game_World.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Shujinko
            // 
            this.Menu_Game_Shujinko.Enabled = false;
            this.Menu_Game_Shujinko.Name = "Menu_Game_Shujinko";
            this.Menu_Game_Shujinko.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Shujinko.Text = "主人公(&P)";
            this.Menu_Game_Shujinko.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // Menu_Game_Busho
            // 
            this.Menu_Game_Busho.Enabled = false;
            this.Menu_Game_Busho.Name = "Menu_Game_Busho";
            this.Menu_Game_Busho.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Busho.Text = "武将(&B)";
            this.Menu_Game_Busho.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_General
            // 
            this.Menu_Game_General.Enabled = false;
            this.Menu_Game_General.Name = "Menu_Game_General";
            this.Menu_Game_General.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_General.Text = "汎用ライバル(&G)";
            this.Menu_Game_General.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_EventPerson
            // 
            this.Menu_Game_EventPerson.Enabled = false;
            this.Menu_Game_EventPerson.Name = "Menu_Game_EventPerson";
            this.Menu_Game_EventPerson.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_EventPerson.Text = "イベント人物(&E)";
            this.Menu_Game_EventPerson.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Citizen
            // 
            this.Menu_Game_Citizen.Enabled = false;
            this.Menu_Game_Citizen.Name = "Menu_Game_Citizen";
            this.Menu_Game_Citizen.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Citizen.Text = "町人、その他(&Y)";
            this.Menu_Game_Citizen.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // Menu_Game_Daimyoke
            // 
            this.Menu_Game_Daimyoke.Enabled = false;
            this.Menu_Game_Daimyoke.Name = "Menu_Game_Daimyoke";
            this.Menu_Game_Daimyoke.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Daimyoke.Text = "大名家(&D)";
            this.Menu_Game_Daimyoke.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Shoka
            // 
            this.Menu_Game_Shoka.Enabled = false;
            this.Menu_Game_Shoka.Name = "Menu_Game_Shoka";
            this.Menu_Game_Shoka.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Shoka.Text = "商家(&S)";
            this.Menu_Game_Shoka.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_NinjaShu
            // 
            this.Menu_Game_NinjaShu.Enabled = false;
            this.Menu_Game_NinjaShu.Name = "Menu_Game_NinjaShu";
            this.Menu_Game_NinjaShu.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_NinjaShu.Text = "忍者衆(&N)";
            this.Menu_Game_NinjaShu.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_KaizokuShu
            // 
            this.Menu_Game_KaizokuShu.Enabled = false;
            this.Menu_Game_KaizokuShu.Name = "Menu_Game_KaizokuShu";
            this.Menu_Game_KaizokuShu.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_KaizokuShu.Text = "海賊衆(&K)";
            this.Menu_Game_KaizokuShu.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // Menu_Game_Shiro
            // 
            this.Menu_Game_Shiro.Enabled = false;
            this.Menu_Game_Shiro.Name = "Menu_Game_Shiro";
            this.Menu_Game_Shiro.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Shiro.Text = "城(&C)";
            this.Menu_Game_Shiro.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Machi
            // 
            this.Menu_Game_Machi.Enabled = false;
            this.Menu_Game_Machi.Name = "Menu_Game_Machi";
            this.Menu_Game_Machi.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Machi.Text = "町(&T)";
            this.Menu_Game_Machi.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Sato
            // 
            this.Menu_Game_Sato.Enabled = false;
            this.Menu_Game_Sato.Name = "Menu_Game_Sato";
            this.Menu_Game_Sato.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Sato.Text = "忍びの里(&V)";
            this.Menu_Game_Sato.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Toride
            // 
            this.Menu_Game_Toride.Enabled = false;
            this.Menu_Game_Toride.Name = "Menu_Game_Toride";
            this.Menu_Game_Toride.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Toride.Text = "海賊砦(&F)";
            this.Menu_Game_Toride.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // Menu_Game_Item
            // 
            this.Menu_Game_Item.Enabled = false;
            this.Menu_Game_Item.Name = "Menu_Game_Item";
            this.Menu_Game_Item.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Item.Text = "既製アイテム(&I)";
            this.Menu_Game_Item.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_CraftItem
            // 
            this.Menu_Game_CraftItem.Enabled = false;
            this.Menu_Game_CraftItem.Name = "Menu_Game_CraftItem";
            this.Menu_Game_CraftItem.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_CraftItem.Text = "製作アイテム(&M)";
            this.Menu_Game_CraftItem.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // Menu_Game_Hanro
            // 
            this.Menu_Game_Hanro.Enabled = false;
            this.Menu_Game_Hanro.Name = "Menu_Game_Hanro";
            this.Menu_Game_Hanro.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Hanro.Text = "販路(&H)";
            this.Menu_Game_Hanro.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Shoken
            // 
            this.Menu_Game_Shoken.Enabled = false;
            this.Menu_Game_Shoken.Name = "Menu_Game_Shoken";
            this.Menu_Game_Shoken.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Shoken.Text = "商圏(&A)";
            this.Menu_Game_Shoken.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Ryuha
            // 
            this.Menu_Game_Ryuha.Enabled = false;
            this.Menu_Game_Ryuha.Name = "Menu_Game_Ryuha";
            this.Menu_Game_Ryuha.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Ryuha.Text = "流派(&R)";
            this.Menu_Game_Ryuha.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // Menu_Game_Kani
            // 
            this.Menu_Game_Kani.Enabled = false;
            this.Menu_Game_Kani.Name = "Menu_Game_Kani";
            this.Menu_Game_Kani.Size = new System.Drawing.Size(180, 22);
            this.Menu_Game_Kani.Text = "官位(&O)";
            this.Menu_Game_Kani.Click += new System.EventHandler(this.Menu_Game_Click);
            // 
            // GameDataTable
            // 
            this.GameDataTable.AllowUserToAddRows = false;
            this.GameDataTable.AllowUserToDeleteRows = false;
            this.GameDataTable.AllowUserToResizeRows = false;
            this.GameDataTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GameDataTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GameDataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GameDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GameDataTable.ContextMenuStrip = this.ContextMenuForEditing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GameDataTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.GameDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameDataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GameDataTable.EnableHeadersVisualStyles = false;
            this.GameDataTable.Location = new System.Drawing.Point(0, 24);
            this.GameDataTable.Name = "GameDataTable";
            this.GameDataTable.ReadOnly = true;
            this.GameDataTable.RowHeadersVisible = false;
            this.GameDataTable.RowTemplate.Height = 21;
            this.GameDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GameDataTable.Size = new System.Drawing.Size(1008, 705);
            this.GameDataTable.TabIndex = 1;
            this.GameDataTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GameDataTable_CellMouseDoubleClick);
            this.GameDataTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GameDataTable_CellMouseDown);
            this.GameDataTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GameDataTable_ColumnHeaderMouseClick);
            this.GameDataTable.SelectionChanged += new System.EventHandler(this.GameDataTable_SelectionChanged);
            this.GameDataTable.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.GameDataTable_SortCompare);
            this.GameDataTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameDataTable_KeyDown);
            // 
            // ContextMenuForEditing
            // 
            this.ContextMenuForEditing.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ContextMenuForEditing.Name = "ContextMenuForEditing";
            this.ContextMenuForEditing.Size = new System.Drawing.Size(61, 4);
            this.ContextMenuForEditing.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuForEditing_Opening);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(241, 6);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(241, 6);
            // 
            // Menu_File_Export
            // 
            this.Menu_File_Export.Enabled = false;
            this.Menu_File_Export.Name = "Menu_File_Export";
            this.Menu_File_Export.Size = new System.Drawing.Size(244, 22);
            this.Menu_File_Export.Text = "選択行の編集内容をエクスポート(&E)";
            this.Menu_File_Export.Click += new System.EventHandler(this.Menu_File_Export_Click);
            // 
            // Menu_File_Import
            // 
            this.Menu_File_Import.Enabled = false;
            this.Menu_File_Import.Name = "Menu_File_Import";
            this.Menu_File_Import.Size = new System.Drawing.Size(244, 22);
            this.Menu_File_Import.Text = "編集内容をインポート(&I)";
            this.Menu_File_Import.Click += new System.EventHandler(this.Menu_File_Import_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.GameDataTable);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = global::Taiko5DXSaveEditor.Properties.Resources.Hideyoshi;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Taiko5 DX Save Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.DataGridView GameDataTable;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_File_Open;
        private System.Windows.Forms.ToolStripMenuItem Menu_File_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu_File_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem Menu_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Shujinko;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Busho;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Daimyoke;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Shoka;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_NinjaShu;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_KaizokuShu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Shiro;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Machi;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Sato;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Toride;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Item;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_CraftItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Ryuha;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Kani;
        private System.Windows.Forms.ContextMenuStrip ContextMenuForEditing;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_World;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_General;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_EventPerson;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Citizen;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Hanro;
        private System.Windows.Forms.ToolStripMenuItem Menu_Game_Shoken;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem Menu_File_Import;
        private System.Windows.Forms.ToolStripMenuItem Menu_File_Export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

