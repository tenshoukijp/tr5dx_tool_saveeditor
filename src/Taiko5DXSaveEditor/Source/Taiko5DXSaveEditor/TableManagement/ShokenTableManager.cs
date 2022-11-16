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
    /// 商圏データテーブルの管理クラス
    /// </summary>
    public class ShokenTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Shoken; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 商圏データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public ShokenTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Name", @"商圏名");
            _GameDataTable.Columns.Add("Daimyoke", @"有力大名");
            _GameDataTable.Columns.Add("ShoninTukasa", @"商人司");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["Daimyoke"].Width = 100;
            _GameDataTable.Columns["ShoninTukasa"].Width = 80;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfShoken;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = i;
                var shoken = _GameData.ShokenList[index];
                int id = shoken.ID;
                _GameDataTable.Rows[i].Cells["ID"].Value = id;
                _GameDataTable.Rows[i].Cells["Name"].Value = shoken.Name;
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
                Shoken shoken = _GameData.ShokenList[id];
                var daimyoke = GameDataTableCellValue.Empty;
                var shoninTukasa = GameDataTableCellValue.Empty;
                if (shoken.Daimyoke != GameData.NoneSeiryokuID)
                {
                    var seiryoku = _GameData.SeiryokuList[shoken.Daimyoke];
                    daimyoke.Text = seiryoku.Name;
                    daimyoke.SortValue = seiryoku.ID;
                }
                if (shoken.ShoninTukasa != GameData.NoneSeiryokuID)
                {
                    var seiryoku = _GameData.SeiryokuList[shoken.ShoninTukasa];
                    shoninTukasa.Text = seiryoku.Name;
                    shoninTukasa.SortValue = seiryoku.ID;
                }
                // 代入
                row.Cells["Daimyoke"].Value = daimyoke;
                row.Cells["ShoninTukasa"].Value = shoninTukasa;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.OtherEdit.ShokenEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion
    }
}
