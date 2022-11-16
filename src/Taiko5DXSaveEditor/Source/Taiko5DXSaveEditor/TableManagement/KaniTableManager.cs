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
    /// 官位データテーブルの管理クラス
    /// </summary>
    class KaniTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Kani; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 官位データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public KaniTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Kani", @"官位官職名");
            _GameDataTable.Columns.Add("Person", @"就任者");
            _GameDataTable.Columns.Add("Shozoku", @"所属");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Kani"].Width = 150;
            _GameDataTable.Columns["Person"].Width = 100;
            _GameDataTable.Columns["Shozoku"].Width = 100;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Kani"].Frozen = true;
            // データ追加
            int n = _GameData.KaniList.Count;
            var nameList = _GameData.NameListDictionary["Kan-i"];
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                Kani kani = _GameData.KaniList[i];
                int id = kani.ID;
                var name = new GameDataTableCellValue(nameList[id], id);
                _GameDataTable.Rows[i].Cells["ID"].Value = id;
                _GameDataTable.Rows[i].Cells["Kani"].Value = name;
            }
            UpdateTable(_GameDataTable.Rows.Cast<DataGridViewRow>());
            // 偉い順に並べる
            _GameDataTable.Sort(_GameDataTable.Columns["ID"], ListSortDirection.Descending);
            // 選択を外す
            _GameDataTable.CurrentCell = null;

            // コンテキストメニューの設定
            _ContextMenu.Items.Clear();
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"就任者の編集", null, (sender, e) =>
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
                Kani kani = _GameData.KaniList[id];
                ushort bushoId = kani.InauguratedPerson;
                var person = GameDataTableCellValue.Empty;
                var shozoku = GameDataTableCellValue.Empty;
                if (bushoId != GameData.NoneBushoID)
                {
                    Busho busho = _GameData.BushoList[bushoId];
                    person.Text = busho.Name;
                    person.SortValue = busho.ID;
                    if (busho.PeopleCategory <= PeopleCategory.GeneralPurpose)
                    {
                        if (busho.Seiryoku != GameData.NoneSeiryokuID)
                        {
                            shozoku.Text = _GameData.SeiryokuList[busho.Seiryoku].Name;
                        }
                        else
                        {
                            shozoku.Text = @"所属無し";
                        }
                        shozoku.SortValue = busho.Seiryoku;
                    }
                }
                // 代入
                row.Cells["Person"].Value = person;
                row.Cells["Shozoku"].Value = shozoku;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                (ids) => new DataEditForms.OtherEdit.KaniEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
