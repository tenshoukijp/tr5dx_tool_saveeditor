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
    /// 忍びの里データテーブルの管理クラス
    /// </summary>
    public class SatoTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Sato; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 忍びの里データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public SatoTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Name", @"里名");
            _GameDataTable.Columns.Add("NinjaShu", @"忍者衆");
            _GameDataTable.Columns.Add("Leader", @"拠点主");
            _GameDataTable.Columns.Add("Type", @"区分");
            _GameDataTable.Columns.Add("Scale", @"規模");
            _GameDataTable.Columns.Add("Money", @"資金");
            _GameDataTable.Columns.Add("Food", @"兵糧");
            _GameDataTable.Columns.Add("Soldiers", @"兵数");
            _GameDataTable.Columns.Add("Training", @"訓練");
            _GameDataTable.Columns.Add("Morale", @"士気");
            _GameDataTable.Columns.Add("Defense", @"防御");
            _GameDataTable.Columns.Add("Location", @"立地");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["NinjaShu"].Width = 100;
            _GameDataTable.Columns["Leader"].Width = 100;
            _GameDataTable.Columns["Type"].Width = 60;
            _GameDataTable.Columns["Scale"].Width = 60;
            _GameDataTable.Columns["Money"].Width = 80;
            _GameDataTable.Columns["Food"].Width = 80;
            _GameDataTable.Columns["Soldiers"].Width = 60;
            _GameDataTable.Columns["Training"].Width = 60;
            _GameDataTable.Columns["Morale"].Width = 60;
            _GameDataTable.Columns["Defense"].Width = 60;
            _GameDataTable.Columns["Location"].Width = 60;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfSato;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = GameData.NumOfShiro + GameData.NumOfMachi + i;
                var kyoten = _GameData.KyotenList[index];
                int id = kyoten.ID;
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
                Sato sato = (Sato)_GameData.KyotenList[id];
                var ninjaShu = GameDataTableCellValue.Empty;
                var leader = GameDataTableCellValue.Empty;
                var type = new GameDataTableCellValue(@"直轄", 0);
                if (sato.Leader != GameData.NoneBushoID)
                {
                    Busho busho = _GameData.BushoList[sato.Leader];
                    leader.Text = busho.Name;
                    leader.SortValue = busho.ID;
                    if (busho.Seiryoku != GameData.NoneSeiryokuID)
                    {
                        ninjaShu.Text = _GameData.SeiryokuList[busho.Seiryoku].Name;
                        ninjaShu.SortValue = busho.Seiryoku;
                    }
                    if (sato.ID == busho.Kyoten)
                    {
                        type.Text = @"居住";
                        type.SortValue = 1;
                    }
                }
                string location = "";
                if (sato.Location == 0) location = @"港湾";
                if (sato.Location == 1) location = @"平地";
                if (sato.Location == 2) location = @"山地";
                // 代入
                row.Cells["Name"].Value = sato.Name;
                row.Cells["NinjaShu"].Value = ninjaShu;
                row.Cells["Leader"].Value = leader;
                row.Cells["Type"].Value = type;
                row.Cells["Scale"].Value = sato.Scale;
                row.Cells["Money"].Value = sato.Money;
                row.Cells["Food"].Value = sato.MilitaryFood;
                row.Cells["Soldiers"].Value = sato.NumOfSoldiers;
                row.Cells["Training"].Value = sato.DegreeOfTraining;
                row.Cells["Morale"].Value = sato.Morale;
                row.Cells["Defense"].Value = sato.DefensePower;
                row.Cells["Location"].Value = location;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.KyotenEdit.SatoEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
