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
    /// 販路データテーブルの管理クラス
    /// </summary>
    public class HanroTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Hanro; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 販路データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public HanroTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Machi1", @"町1");
            _GameDataTable.Columns.Add("Machi2", @"町2");
            _GameDataTable.Columns.Add("Administrator", @"管理者");
            _GameDataTable.Columns.Add("Guard", @"護衛");
            _GameDataTable.Columns.Add("Kanjo", @"勘定");
            _GameDataTable.Columns.Add("MaintenanceCosts", @"維持費");
            _GameDataTable.Columns.Add("Stopping", @"荷留め期間");
            _GameDataTable.Columns.Add("Type", @"種類");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Machi1"].Width = 100;
            _GameDataTable.Columns["Machi2"].Width = 100;
            _GameDataTable.Columns["Administrator"].Width = 100;
            _GameDataTable.Columns["Guard"].Width = 100;
            _GameDataTable.Columns["Kanjo"].Width = 80;
            _GameDataTable.Columns["MaintenanceCosts"].Width = 80;
            _GameDataTable.Columns["Stopping"].Width = 80;
            _GameDataTable.Columns["Type"].Width = 60;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Machi1"].Frozen = true;
            _GameDataTable.Columns["Machi2"].Frozen = true;
            // データ追加
            int n = GameData.NumOfHanro;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = i;
                var hanro = _GameData.HanroList[index];
                int id = hanro.ID;
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
                Hanro hanro = _GameData.HanroList[id];
                var machi1 = GameDataTableCellValue.Empty;
                var machi2 = GameDataTableCellValue.Empty;
                var administrator = GameDataTableCellValue.Empty;
                var guard = GameDataTableCellValue.Empty;
                var kanjo = GameDataTableCellValue.Empty;
                var maintenanceCosts = GameDataTableCellValue.Empty;
                var stopping = GameDataTableCellValue.Empty;
                var type = GameDataTableCellValue.Empty;
                if ((hanro.Machi1 != GameData.NoneKyotenID) && (hanro.Machi1 != GameData.NoneKyotenIDForDead))
                {
                    var kyoten = _GameData.KyotenList[hanro.Machi1];
                    machi1.Text = kyoten.Name;
                    machi1.SortValue = kyoten.ID;
                }
                if ((hanro.Machi2 != GameData.NoneKyotenID) && (hanro.Machi2 != GameData.NoneKyotenIDForDead))
                {
                    var kyoten = _GameData.KyotenList[hanro.Machi2];
                    machi2.Text = kyoten.Name;
                    machi2.SortValue = kyoten.ID;
                }
                if (hanro.Administrator != GameData.NoneBushoID)
                {
                    var busho = _GameData.BushoList[hanro.Administrator];
                    administrator.Text = busho.Name;
                    administrator.SortValue = busho.ID;
                }
                if (hanro.Guard != GameData.NoneSeiryokuID)
                {
                    var seiryoku = _GameData.SeiryokuList[hanro.Guard];
                    guard.Text = seiryoku.Name;
                    guard.SortValue = seiryoku.ID;
                }
                if ((hanro.Machi1 != GameData.NoneKyotenIDForDead) && (hanro.Machi1 != GameData.NoneKyotenID)
                    && (hanro.Machi2 != GameData.NoneKyotenIDForDead) && (hanro.Machi2 != GameData.NoneKyotenID)
                    && (hanro.Administrator != GameData.NoneBushoID))
                {
                    kanjo.Text = hanro.Kanjo.ToString();
                    kanjo.SortValue = hanro.Kanjo;
                    maintenanceCosts.Text = hanro.MaintenanceCosts.ToString();
                    maintenanceCosts.SortValue = hanro.MaintenanceCosts;
                    stopping.Text = hanro.Stopping.ToString();
                    stopping.SortValue = hanro.Stopping;
                    type.Text = hanro.Type == 0 ? @"陸路" : @"海路";
                    type.SortValue = hanro.Type;
                }
                // 代入
                row.Cells["Machi1"].Value = machi1;
                row.Cells["Machi2"].Value = machi2;
                row.Cells["Administrator"].Value = administrator;
                row.Cells["Guard"].Value = guard;
                row.Cells["Kanjo"].Value = kanjo;
                row.Cells["MaintenanceCosts"].Value = maintenanceCosts;
                row.Cells["Stopping"].Value = stopping;
                row.Cells["Type"].Value = type;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.OtherEdit.HanroEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
