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
    /// 城データテーブルの管理クラス
    /// </summary>
    public class ShiroTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Shiro; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 城データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public ShiroTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Name", @"城名");
            _GameDataTable.Columns.Add("Daimyoke", @"所属大名家");
            _GameDataTable.Columns.Add("Leader", @"城主");
            _GameDataTable.Columns.Add("Type", @"区分");
            _GameDataTable.Columns.Add("Scale", @"規模");
            _GameDataTable.Columns.Add("Money", @"資金");
            _GameDataTable.Columns.Add("Food", @"兵糧");
            _GameDataTable.Columns.Add("Soldiers", @"兵数");
            _GameDataTable.Columns.Add("Training", @"訓練");
            _GameDataTable.Columns.Add("Morale", @"士気");
            _GameDataTable.Columns.Add("Horses", @"軍馬");
            _GameDataTable.Columns.Add("Guns", @"鉄砲");
            _GameDataTable.Columns.Add("Cannons", @"大筒");
            _GameDataTable.Columns.Add("Population", @"人口[千人]");
            _GameDataTable.Columns.Add("Kokudaka", @"石高[千石]");
            _GameDataTable.Columns.Add("MaxKokudaka", @"石高上限[千石]");
            _GameDataTable.Columns.Add("Mine", @"鉱山");
            _GameDataTable.Columns.Add("MaxMine", @"鉱山上限");
            _GameDataTable.Columns.Add("Defense", @"防御");
            _GameDataTable.Columns.Add("ResidentSupport", @"住安");
            _GameDataTable.Columns.Add("Location", @"立地");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["Daimyoke"].Width = 100;
            _GameDataTable.Columns["Leader"].Width = 100;
            _GameDataTable.Columns["Type"].Width = 60;
            _GameDataTable.Columns["Scale"].Width = 60;
            _GameDataTable.Columns["Money"].Width = 80;
            _GameDataTable.Columns["Food"].Width = 80;
            _GameDataTable.Columns["Soldiers"].Width = 60;
            _GameDataTable.Columns["Training"].Width = 60;
            _GameDataTable.Columns["Morale"].Width = 60;
            _GameDataTable.Columns["Horses"].Width = 60;
            _GameDataTable.Columns["Guns"].Width = 60;
            _GameDataTable.Columns["Cannons"].Width = 60;
            _GameDataTable.Columns["Population"].Width = 90;
            _GameDataTable.Columns["Kokudaka"].Width = 90;
            _GameDataTable.Columns["MaxKokudaka"].Width = 110;
            _GameDataTable.Columns["Mine"].Width = 60;
            _GameDataTable.Columns["MaxMine"].Width = 70;
            _GameDataTable.Columns["Defense"].Width = 60;
            _GameDataTable.Columns["ResidentSupport"].Width = 60;
            _GameDataTable.Columns["Location"].Width = 60;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfShiro;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = i;
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
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"拠点画像の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.KyotenEdit.KyotenImageEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
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
                Shiro shiro = (Shiro)_GameData.KyotenList[id];
                var daimyoke = GameDataTableCellValue.Empty;
                var leader = GameDataTableCellValue.Empty;
                var type = new GameDataTableCellValue(@"直轄", 0);
                if (shiro.Leader != GameData.NoneBushoID)
                {
                    Busho busho = _GameData.BushoList[shiro.Leader];
                    leader.Text = busho.Name;
                    leader.SortValue = busho.ID;
                    if (busho.Seiryoku != GameData.NoneSeiryokuID)
                    {
                        daimyoke.Text = _GameData.SeiryokuList[busho.Seiryoku].Name;
                        daimyoke.SortValue = busho.Seiryoku;
                    }
                    if (shiro.ID == busho.Kyoten)
                    {
                        type.Text = @"居城";
                        type.SortValue = 1;
                    }
                }
                int population = shiro.Population + 50;
                int maxKokudaka = shiro.MaxKokudaka;
                if (shiro.Scale >= GameData.ScaleLevels[0]) maxKokudaka *= 40;
                else if (shiro.Scale >= GameData.ScaleLevels[1]) maxKokudaka *= 30;
                else if (shiro.Scale >= GameData.ScaleLevels[2]) maxKokudaka *= 20;
                else maxKokudaka *= 10;
                string location = "";
                if (shiro.Location == 0) location = @"港湾";
                if (shiro.Location == 1) location = @"平地";
                if (shiro.Location == 2) location = @"山地";
                // 代入
                row.Cells["Name"].Value = shiro.Name;
                row.Cells["Daimyoke"].Value = daimyoke;
                row.Cells["Leader"].Value = leader;
                row.Cells["Type"].Value = type;
                row.Cells["Scale"].Value = shiro.Scale;
                row.Cells["Money"].Value = shiro.Money;
                row.Cells["Food"].Value = shiro.MilitaryFood;
                row.Cells["Soldiers"].Value = shiro.NumOfSoldiers;
                row.Cells["Training"].Value = shiro.DegreeOfTraining;
                row.Cells["Morale"].Value = shiro.Morale;
                row.Cells["Horses"].Value = shiro.NumOfWarHorses;
                row.Cells["Guns"].Value = shiro.NumOfGuns;
                row.Cells["Cannons"].Value = shiro.NumOfCannons;
                row.Cells["Population"].Value = population;
                row.Cells["Kokudaka"].Value = shiro.Kokudaka;
                row.Cells["MaxKokudaka"].Value = maxKokudaka;
                row.Cells["Mine"].Value = shiro.Mine;
                row.Cells["MaxMine"].Value = shiro.MaxMine;
                row.Cells["Defense"].Value = shiro.DefensePower;
                row.Cells["ResidentSupport"].Value = shiro.ResidentSupport;
                row.Cells["Location"].Value = location;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.KyotenEdit.ShiroEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion
    }
}
