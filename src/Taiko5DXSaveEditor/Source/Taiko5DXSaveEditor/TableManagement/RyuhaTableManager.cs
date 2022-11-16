using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.TableManagement
{
    /// <summary>
    /// 流派データテーブルの管理クラス
    /// </summary>
    class RyuhaTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Ryuha; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 流派データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public RyuhaTableManager(DataGridView gameDataTable, GameData gameData)
            : base(gameDataTable, gameData)
        {
        }

        #endregion

        #region メソッド
        /// <summary>
        /// テーブルの初期化
        /// </summary>
        public override void InitializeTable()
        {
            // 表のリセット
            _GameDataTable.Columns.Clear();
            // 項目設定
            _GameDataTable.Columns.Add("ID", @"ID");
            _GameDataTable.Columns.Add("Name", @"流派名");
            _GameDataTable.Columns.Add("Leader", @"宗家");
            _GameDataTable.Columns.Add("License", @"印可状");
            _GameDataTable.Columns.Add("DojoYaburi", @"道場破り");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["Leader"].Width = 100;
            _GameDataTable.Columns["License"].Width = 60;
            _GameDataTable.Columns["License"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _GameDataTable.Columns["DojoYaburi"].Width = 60;
            _GameDataTable.Columns["DojoYaburi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfRyuha;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                Ryuha ryuha = _GameData.RyuhaList[i];
                int id = ryuha.ID;
                _GameDataTable.Rows[i].Cells["ID"].Value = id;
            }
            UpdateTable(_GameDataTable.Rows.Cast<DataGridViewRow>());
            // 選択を外す
            _GameDataTable.CurrentCell = null;

            // コンテキストメニューの設定
            _ContextMenu.Items.Clear();
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"主要項目の編集", null, (sender, e) =>
            {
                OpenBasicEditForm();
            }));
        }

        /// <summary>
        /// テーブルのアップデート
        /// </summary>
        /// <param name="selectedRows">選択されている行</param>
        public override void UpdateTable(IEnumerable<DataGridViewRow> selectedRows)
        {
            foreach (DataGridViewRow row in selectedRows)
            {
                int id = (int)row.Cells["ID"].Value;
                Ryuha ryuha = _GameData.RyuhaList[id];
                var leader = GameDataTableCellValue.Empty;
                var license = GameDataTableCellValue.Empty;
                var dojoYaburi = GameDataTableCellValue.Empty;
                if (ryuha.Leader != GameData.NoneBushoID)
                {
                    Busho busho = _GameData.BushoList[ryuha.Leader];
                    leader.Text = busho.Name;
                    leader.SortValue = busho.ID;
                    license.SortValue = 0;
                    dojoYaburi.SortValue = 0;
                    if (ryuha.License == 1)
                    {
                        license.Text = @"〇";
                        license.SortValue = 1;
                    }
                    if (ryuha.DojoYaburi != 0)
                    {
                        dojoYaburi.Text = @"〇";
                        dojoYaburi.SortValue = 1;
                    }
                }
                row.Cells["Name"].Value = ryuha.Name;
                row.Cells["Leader"].Value = leader;
                row.Cells["License"].Value = license;
                row.Cells["DojoYaburi"].Value = dojoYaburi;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.OtherEdit.RyuhaEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
