using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Taiko5DXSaveEditor.GameObjects;
using Taiko5DXSaveEditor.TableManagement;
using Taiko5DXSaveEditor.ImportingAndExporting;

namespace Taiko5DXSaveEditor
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        #region 定数
        /// <summary>
        /// デフォルトのセーブフォルダ
        /// </summary>
        private static readonly string DEFAULT_SAVE_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\KoeiTecmo\Taiko5DX\SaveData";

        /// <summary>
        /// ウィンドウタイトル
        /// </summary>
        private static readonly string WINDOW_TITLE = "{0} - Taiko5 DX Save Editor";

        #endregion

        #region フィールド
        /// <summary>
        /// セーブファイルのパス
        /// </summary>
        private string _FilePath = "";

        /// <summary>
        /// セーブファイル管理者
        /// </summary>
        private SaveFileManager _SaveFileManager = new SaveFileManager();

        /// <summary>
        /// ゲームデータ
        /// </summary>
        private GameData _GameData;

        /// <summary>
        /// ゲームデータテーブル管理者
        /// </summary>
        private GameDataTableManager _GameDataTableManager;

        /// <summary>
        /// ファイル更新の監視
        /// </summary>
        private FileSystemWatcher _FileSystemWatcher;

        /// <summary>
        /// ファイル更新されたことを確認したフラグ
        /// </summary>
        private bool _FileChangedFlag = false;

        /// <summary>
        /// 前回のソート情報
        /// </summary>
        private SortInfo _PrevSortInfo = null;

        #endregion

        #region プロパティ
        /// <summary>
        /// 上書き保存が許可されているか
        /// </summary>
        public bool IsEnabledSaveFile
        {
            get { return Menu_File_Save.Enabled; }
            set { Menu_File_Save.Enabled = value; }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// メインフォームのコンストラクタ
        /// </summary>
        public MainForm()
        {
            // コンポーネントの初期化
            InitializeComponent();

            // ダブルバッファリングの有効化
            Type dgvType = GameDataTable.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(GameDataTable, true, null);

            // メニュー設定
            Menu_Game_World.Tag = new Func<GameDataTableManager>(() => new WorldTableManager(GameDataTable, _GameData));
            Menu_Game_Shujinko.Tag = new Func<GameDataTableManager>(() => new ShujinkoTableManager(GameDataTable, _GameData));
            Menu_Game_Busho.Tag = new Func<GameDataTableManager>(() => new BushoTableManager(GameDataTable, _GameData));
            Menu_Game_General.Tag = new Func<GameDataTableManager>(() => new GeneralPurposeTableManager(GameDataTable, _GameData));
            Menu_Game_EventPerson.Tag = new Func<GameDataTableManager>(() => new EventPersonTableManager(GameDataTable, _GameData));
            Menu_Game_Citizen.Tag = new Func<GameDataTableManager>(() => new CitizenTableManager(GameDataTable, _GameData));
            Menu_Game_Daimyoke.Tag = new Func<GameDataTableManager>(() => new DaimyokeTableManager(GameDataTable, _GameData));
            Menu_Game_Shoka.Tag = new Func<GameDataTableManager>(() => new ShokaTableManager(GameDataTable, _GameData));
            Menu_Game_NinjaShu.Tag = new Func<GameDataTableManager>(() => new NinjaShuTableManager(GameDataTable, _GameData));
            Menu_Game_KaizokuShu.Tag = new Func<GameDataTableManager>(() => new KaizokuShuTableManager(GameDataTable, _GameData));
            Menu_Game_Shiro.Tag = new Func<GameDataTableManager>(() => new ShiroTableManager(GameDataTable, _GameData));
            Menu_Game_Machi.Tag = new Func<GameDataTableManager>(() => new MachiTableManager(GameDataTable, _GameData));
            Menu_Game_Sato.Tag = new Func<GameDataTableManager>(() => new SatoTableManager(GameDataTable, _GameData));
            Menu_Game_Toride.Tag = new Func<GameDataTableManager>(() => new TorideTableManager(GameDataTable, _GameData));
            Menu_Game_Item.Tag = new Func<GameDataTableManager>(() => new ItemTableManager(GameDataTable, _GameData));
            Menu_Game_CraftItem.Tag = new Func<GameDataTableManager>(() => new CraftItemTableManager(GameDataTable, _GameData));
            Menu_Game_Shoken.Tag = new Func<GameDataTableManager>(() => new ShokenTableManager(GameDataTable, _GameData));
            Menu_Game_Hanro.Tag = new Func<GameDataTableManager>(() => new HanroTableManager(GameDataTable, _GameData));
            Menu_Game_Ryuha.Tag = new Func<GameDataTableManager>(() => new RyuhaTableManager(GameDataTable, _GameData));
            Menu_Game_Kani.Tag = new Func<GameDataTableManager>(() => new KaniTableManager(GameDataTable, _GameData));
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォーム読み込み時のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 前回のウィンドウ位置、サイズを復元
            WindowState = Properties.Settings.Default.FormState;
            if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;

            Location = Properties.Settings.Default.FormLocation;
            Size = Properties.Settings.Default.FormSize;
        }

        /// <summary>
        /// フォームが閉じられる直前のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 監視終了
            if (_FileSystemWatcher != null)
            {
                _FileSystemWatcher.EnableRaisingEvents = false;
                _FileSystemWatcher.Changed -= _FileSystemWatcher_Changed;
                _FileSystemWatcher.Dispose();
                _FileSystemWatcher = null;
            }

            // 最後に開いたセーブファイルのパス
            if (_FilePath != "")
            {
                Properties.Settings.Default.SaveFileDirectory = Path.GetDirectoryName(_FilePath);
            }
            // ウィンドウ位置、サイズの保存
            Properties.Settings.Default.FormState = WindowState;
            // ウインドウステートがNormalな場合には位置（location）とサイズ（size）を記憶する
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.FormLocation = Location;
                Properties.Settings.Default.FormSize = Size;
            }
            // 最小化（minimized）や最大化（maximized）の場合には、RestoreBoundsを記憶する
            else
            {
                Properties.Settings.Default.FormLocation = RestoreBounds.Location;
                Properties.Settings.Default.FormSize = RestoreBounds.Size;
            }
            // 設定を保存する
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 表の上でマウスボタンを押した際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void GameDataTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // データ上でない場合は抜ける
            if (e.RowIndex == -1) return;
            // CtrlまたはShiftが押されていれば抜ける
            if ((Control.ModifierKeys & (Keys.Control | Keys.Shift)) != 0) return;

            // 右クリック時に選択中の行で無ければ左クリックと同様に、マウス位置の行を選択する
            var clickedRow = GameDataTable.Rows[e.RowIndex];
            if ((e.Button == MouseButtons.Right) && (!GameDataTable.SelectedRows.Contains(clickedRow)))
            {
                GameDataTable.ClearSelection();
                clickedRow.Selected = true;
                GameDataTable.CurrentCell = GameDataTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        /// <summary>
        /// 表でダブルクリックされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void GameDataTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // データ上でない場合は抜ける
            if (e.RowIndex == -1) return;
            // データが選ばれてなければ抜ける
            if (GameDataTable.SelectedRows.Count <= 0) return;

            // 左クリックの場合に実行
            if (e.Button == MouseButtons.Left)
            {
                if (_GameDataTableManager != null)
                {
                    _GameDataTableManager.OpenBasicEditForm();
                }
            }
        }

        /// <summary>
        /// 表でキーボードのキーが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void GameDataTable_KeyDown(object sender, KeyEventArgs e)
        {
            // データが選ばれてなければ抜ける
            if (GameDataTable.SelectedRows.Count <= 0) return;

            // エンターが押された場合に実行
            if (e.KeyCode == Keys.Enter)
            {
                if (_GameDataTableManager != null)
                {
                    _GameDataTableManager.OpenBasicEditForm();
                }
            }
        }

        /// <summary>
        /// 表の選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void GameDataTable_SelectionChanged(object sender, EventArgs e)
        {
            Menu_File_Export.Enabled = (GameDataTable.SelectedRows.Count > 0);
        }

        /// <summary>
        /// 表でコンテキストメニューが表示される際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void ContextMenuForEditing_Opening(object sender, CancelEventArgs e)
        {
            // データが選ばれてなければ表示を行わない
            if (GameDataTable.SelectedRows.Count <= 0)
                e.Cancel = true;
        }

        /// <summary>
        /// 表のソートのために比較が行われる際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void GameDataTable_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            Func<object, object, SortOrder, SortInfo, int> compare = null;
            compare = (val1, val2, order, prevSort) =>
            {
                int result = 0;
                // GameDataTableCellValue型の場合
                if ((val1 is GameDataTableCellValue value1) && (val2 is GameDataTableCellValue value2))
                {
                    result = value1.CompareTo(value2);
                    // 空の要素は下に行くようにする
                    if (((value1 == GameDataTableCellValue.Empty) || (value2 == GameDataTableCellValue.Empty))
                        && (order == SortOrder.Descending))
                    {
                        result = -result;
                    }
                }
                // 文字列の場合
                else if ((val1 is string str1) && (val2 is string str2))
                {
                    result = str1.CompareTo(str2);
                    // 空の要素は下に行くようにする
                    if (((str1 == "") || (str2 == ""))
                        && (order == SortOrder.Ascending))
                    {
                        result = -result;
                    }
                }
                // それ以外
                else
                {
                    IComparable valcmp = (IComparable)val1;
                    result = valcmp.CompareTo(val2);
                }
                // 一致していなければそのまま結果を返す
                if (result != 0)
                {
                    if (order != GameDataTable.SortOrder)
                    {
                        result = -result;
                    }
                    return result;
                }
                // 一致していればさらに詳しく調べる
                else
                {
                    if (prevSort != null)
                    {
                        object newVal1 = GameDataTable.Rows[e.RowIndex1].Cells[prevSort.ColumnIndex].Value;
                        object newVal2 = GameDataTable.Rows[e.RowIndex2].Cells[prevSort.ColumnIndex].Value;
                        var prevPrevSort = (SortInfo)GameDataTable.Columns[prevSort.ColumnIndex].Tag;
                        return compare(newVal1, newVal2, prevSort.SortOrder, prevPrevSort);
                    }
                    else
                    {
                        int id1 = (int)GameDataTable.Rows[e.RowIndex1].Cells[0].Value;
                        int id2 = (int)GameDataTable.Rows[e.RowIndex2].Cells[0].Value;
                        return compare(id1, id2, SortOrder.Ascending, null);
                    }
                }
            };
            e.SortResult = compare(e.CellValue1, e.CellValue2, GameDataTable.SortOrder, _PrevSortInfo);
            e.Handled = true;
        }

        /// <summary>
        /// 表のヘッダがクリックされた際のイベントハンドラ。
        /// ソート完了後に実行される
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void GameDataTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            if ((_PrevSortInfo != null) && (columnIndex != 0) && (_PrevSortInfo.ColumnIndex != columnIndex))
            {
                GameDataTable.Columns[columnIndex].Tag = _PrevSortInfo;
                int n = GameDataTable.Columns.Count;
                for (int i = 1; i < n; ++i)
                {
                    var sortInfo = (SortInfo)GameDataTable.Columns[i].Tag;
                    if (sortInfo?.ColumnIndex == columnIndex)
                    {
                        GameDataTable.Columns[i].Tag = null;
                    }
                }
            }
            SortInfo info = new SortInfo();
            info.ColumnIndex = columnIndex;
            info.SortOrder = GameDataTable.SortOrder;
            _PrevSortInfo = info;
        }

        /// <summary>
        /// セーブファイルが外部から更新された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (_FileChangedFlag) return;
            _FileChangedFlag = true;

            // 読み込み直すか確認する
            var result = MessageBox.Show(this, @"編集中のセーブファイルが更新されました。最新のファイルを読み込み直しますか？（現在の編集内容は失われます）", "Taiko5 DX Save Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                _GameData = _SaveFileManager.ReadSaveFile(_FilePath);
                _GameDataTableManager = new WorldTableManager(GameDataTable, _GameData);
                _GameDataTableManager.InitializeTable();
                _PrevSortInfo = null;
            }

            _FileChangedFlag = false;
        }

        /// <summary>
        /// 「メニュー」 ⇒ 「ファイル」 ⇒ 「開く」のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void Menu_File_Open_Click(object sender, EventArgs e)
        {
            // ファイル選択のダイアログの設定
            var openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = Properties.Settings.Default.SaveFileDirectory;
            if (openFileDialog.InitialDirectory == "")
            {
                openFileDialog.InitialDirectory = DEFAULT_SAVE_FOLDER;
            }
            openFileDialog.Filter = @"太閤立志伝Ⅴ DX セーブファイル(*.bin)|*.bin";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = @"ファイルを開く";
            openFileDialog.RestoreDirectory = true;
            //ダイアログを表示する
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 選択したファイルを開く
                    string filePath = openFileDialog.FileName;
                    _GameData = _SaveFileManager.ReadSaveFile(filePath);
                    _FilePath = filePath;
                    // 初期画面に移る（世界編集）
                    _GameDataTableManager = new WorldTableManager(GameDataTable, _GameData);
                    _GameDataTableManager.InitializeTable();
                    _PrevSortInfo = null;

                    // メニューの有効設定を更新
                    Menu_File_Save.Enabled = false;
                    Menu_File_SaveAs.Enabled = true;
                    Menu_File_Import.Enabled = true;
                    Menu_Game_World.Enabled = true;
                    Menu_Game_Shujinko.Enabled = true;
                    Menu_Game_Busho.Enabled = true;
                    Menu_Game_General.Enabled = true;
                    Menu_Game_EventPerson.Enabled = true;
                    Menu_Game_Citizen.Enabled = true;
                    Menu_Game_Daimyoke.Enabled = true;
                    Menu_Game_Shoka.Enabled = true;
                    Menu_Game_NinjaShu.Enabled = true;
                    Menu_Game_KaizokuShu.Enabled = true;
                    Menu_Game_Shiro.Enabled = true;
                    Menu_Game_Machi.Enabled = true;
                    Menu_Game_Sato.Enabled = true;
                    Menu_Game_Toride.Enabled = true;
                    Menu_Game_Item.Enabled = true;
                    Menu_Game_CraftItem.Enabled = true;
                    Menu_Game_Hanro.Enabled = true;
                    Menu_Game_Shoken.Enabled = true;
                    Menu_Game_Ryuha.Enabled = true;
                    Menu_Game_Kani.Enabled = true;

                    // ウィンドウのタイトルを変更
                    string fileName = Path.GetFileName(_FilePath);
                    Text = string.Format(WINDOW_TITLE, fileName);

                    // ファイル監視を開始
                    if (_FileSystemWatcher != null)
                    {
                        _FileSystemWatcher.EnableRaisingEvents = false;
                        _FileSystemWatcher.Changed -= _FileSystemWatcher_Changed;
                        _FileSystemWatcher.Dispose();
                        _FileSystemWatcher = null;
                    }
                    _FileSystemWatcher = new FileSystemWatcher();
                    _FileSystemWatcher.Path = Path.GetDirectoryName(_FilePath);
                    _FileSystemWatcher.Filter = fileName;
                    _FileSystemWatcher.SynchronizingObject = this;
                    _FileSystemWatcher.Changed += _FileSystemWatcher_Changed;
                    _FileSystemWatcher.EnableRaisingEvents = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, @"ファイル読み込みの失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 後始末
            openFileDialog.Dispose();
        }

        /// <summary>
        /// 「メニュー」 ⇒ 「ファイル」 ⇒ 「上書き保存」のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void Menu_File_Save_Click(object sender, EventArgs e)
        {
            // ファイル監視を一旦やめる
            _FileSystemWatcher.EnableRaisingEvents = false;

            // 上書き保存
            _SaveFileManager.WriteSaveFile(_FilePath, _GameData);
            // メニューの有効設定を更新
            Menu_File_Save.Enabled = false;

            // ファイル監視再開
            _FileSystemWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// 「メニュー」 ⇒ 「ファイル」 ⇒ 「名前を付けて保存」のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void Menu_File_SaveAs_Click(object sender, EventArgs e)
        {
            // ファイル監視を一旦やめる
            _FileSystemWatcher.EnableRaisingEvents = false;

            // ファイル保存ダイアログの設定
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "";
            saveFileDialog.InitialDirectory = Properties.Settings.Default.SaveFileDirectory;
            if (saveFileDialog.InitialDirectory == "")
            {
                saveFileDialog.InitialDirectory = DEFAULT_SAVE_FOLDER;
            }
            saveFileDialog.Filter = @"太閤立志伝Ⅴ DX セーブファイル(*.bin)|*.bin";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = @"ファイルを保存する";
            saveFileDialog.RestoreDirectory = true;
            //ダイアログを表示する
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                _SaveFileManager.WriteSaveFile(filePath, _GameData);
                _FilePath = filePath;
                // ウィンドウのタイトルを変更
                string fileName = Path.GetFileName(_FilePath);
                this.Text = string.Format(WINDOW_TITLE, fileName);
                // 監視先の変更
                _FileSystemWatcher.Path = Path.GetDirectoryName(_FilePath);
                _FileSystemWatcher.Filter = fileName;
            }
            // 後始末
            saveFileDialog.Dispose();

            // メニューの有効設定を更新
            Menu_File_Save.Enabled = false;

            // ファイル監視再開
            _FileSystemWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// 「メニュー」 ⇒ 「ファイル」 ⇒ 「インポート」のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void Menu_File_Import_Click(object sender, EventArgs e)
        {
            // ファイル選択のダイアログの設定
            var openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = Properties.Settings.Default.ExportFileDirectory;
            if (openFileDialog.InitialDirectory == "")
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            }
            openFileDialog.Filter = @"セーブ編集ファイル(*.json)|*.json";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = @"編集内容のインポート (複数選択可)";
            openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;
            //ダイアログを表示する
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var importer = new EditingDataImporter(openFileDialog.FileNames);
                importer.Apply(_GameData);
                _GameDataTableManager.InitializeTable();
                Menu_File_Save.Enabled = true;
                Properties.Settings.Default.ExportFileDirectory = Path.GetDirectoryName(openFileDialog.FileNames[0]);
                Properties.Settings.Default.Save();
            }
            // 後始末
            openFileDialog.Dispose();
        }

        /// <summary>
        /// 「メニュー」 ⇒ 「ファイル」 ⇒ 「エクスポート」のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void Menu_File_Export_Click(object sender, EventArgs e)
        {
            var form = new EditingDataExportForm(_GameData, GameDataTable.SelectedRows.Cast<DataGridViewRow>(), _GameDataTableManager.TableType);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
            }
            form.Dispose();
        }

        /// <summary>
        /// 「メニュー」 ⇒ 「ファイル」 ⇒ 「閉じる」のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void Menu_File_Exit_Click(object sender, EventArgs e)
        {
            // フォームを閉じる
            Close();
        }

        /// <summary>
        /// 「メニュー」 ⇒ 「ゲームデータ」 ⇒ 「??」のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void Menu_Game_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                if (menuItem.Tag != null)
                {
                    var func = (Func<GameDataTableManager>)menuItem.Tag;
                    _GameDataTableManager = func();
                    _GameDataTableManager.InitializeTable();
                    _PrevSortInfo = null;
                }
            }
        }

        #endregion

        #region ソート情報
        /// <summary>
        /// ソート情報
        /// </summary>
        private class SortInfo
        {
            /// <summary>列インデックス</summary>
            public int ColumnIndex { get; set; }
            /// <summary>昇順か降順か</summary>
            public SortOrder SortOrder { get; set; }
        }

        #endregion

    }
}
