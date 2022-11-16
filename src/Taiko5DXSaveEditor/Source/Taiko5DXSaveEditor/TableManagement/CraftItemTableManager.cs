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
    /// 制作アイテムデータテーブルの管理クラス
    /// </summary>
    public class CraftItemTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.CraftItem; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 制作アイテムデータテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public CraftItemTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Name", @"アイテム名");
            _GameDataTable.Columns.Add("ItemType", @"種類");
            _GameDataTable.Columns.Add("AbilityType", @"能力");
            _GameDataTable.Columns.Add("AbilityScores", @"増加量");
            _GameDataTable.Columns.Add("Rarity", @"価値");
            _GameDataTable.Columns.Add("Price", @"価格");
            _GameDataTable.Columns.Add("Owner", @"所有者");
            _GameDataTable.Columns.Add("Number", @"所持数");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["ItemType"].Width = 80;
            _GameDataTable.Columns["AbilityType"].Width = 80;
            _GameDataTable.Columns["AbilityScores"].Width = 80;
            _GameDataTable.Columns["Rarity"].Width = 80;
            _GameDataTable.Columns["Price"].Width = 80;
            _GameDataTable.Columns["Owner"].Width = 100;
            _GameDataTable.Columns["Number"].Width = 80;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            _GameDataTable.Rows.Add(GameData.NumOfCraftItems);
            for (int i = 0; i < GameData.NumOfCraftItems; ++i)
            {
                int index = GameData.NumOfNormalItems + i;
                Item item = _GameData.ItemList[index];
                int id = item.ID;
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
                Item item = _GameData.ItemList[id];
                string name = "";
                var itemType = GameDataTableCellValue.Empty;
                var abilityType = GameDataTableCellValue.Empty;
                var abilityScores = GameDataTableCellValue.Empty;
                var rarity = GameDataTableCellValue.Empty;
                var price = GameDataTableCellValue.Empty;
                var owner = GameDataTableCellValue.Empty;
                var number = GameDataTableCellValue.Empty;
                if (item.IsCrafted)
                {
                    name = item.Name;
                    itemType.Text = _GameData.NameListDictionary["ItemType"][item.ItemType];
                    itemType.SortValue = item.ItemType;
                    abilityType.SortValue = item.AbilityType;
                    if (item.AbilityType == 0) abilityType.Text = @"統率";
                    else if (item.AbilityType == 1) abilityType.Text = @"武力";
                    else if (item.AbilityType == 2) abilityType.Text = @"政務";
                    else if (item.AbilityType == 3) abilityType.Text = @"知謀";
                    else if (item.AbilityType == 4) abilityType.Text = @"魅力";
                    abilityScores.Text = item.AbilityScores.ToString();
                    abilityScores.SortValue = item.AbilityScores;
                    rarity.Text = item.Rarity.ToString();
                    rarity.SortValue = item.Rarity;
                    price.Text = item.Price.ToString();
                    price.SortValue = item.Price;
                    if (item.Owner != GameData.NoneBushoID)
                    {
                        owner.Text = _GameData.BushoList[item.Owner].Name;
                    }
                    owner.SortValue = item.Owner;
                    number.Text = item.Number.ToString();
                    number.SortValue = item.Number;
                }
                // 代入
                row.Cells["Name"].Value = name;
                row.Cells["ItemType"].Value = itemType;
                row.Cells["AbilityType"].Value = abilityType;
                row.Cells["AbilityScores"].Value = abilityScores;
                row.Cells["Rarity"].Value = rarity;
                row.Cells["Price"].Value = price;
                row.Cells["Owner"].Value = owner;
                row.Cells["Number"].Value = number;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.ItemEdit.ItemEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
