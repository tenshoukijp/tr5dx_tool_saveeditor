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
    /// 町データテーブルの管理クラス
    /// </summary>
    public class MachiTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Machi; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 町データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public MachiTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Name", @"町名");
            _GameDataTable.Columns.Add("Scale", @"規模");
            _GameDataTable.Columns.Add("Money", @"投資金");
            _GameDataTable.Columns.Add("RiceMarketPrice", @"米買相場[貫]");
            _GameDataTable.Columns.Add("RiceInventory", @"米在庫[千石]");
            _GameDataTable.Columns.Add("HorseMarketPrice", @"馬買相場[貫]");
            _GameDataTable.Columns.Add("HorseInventory", @"馬在庫[10頭]");
            _GameDataTable.Columns.Add("TradeGoods1", @"特産品1");
            _GameDataTable.Columns.Add("TradeGoods2", @"特産品2");
            _GameDataTable.Columns.Add("TradeGoods3", @"特産品3");
            _GameDataTable.Columns.Add("TradeGoods4", @"特産品4");
            _GameDataTable.Columns.Add("TradeGoods5", @"特産品5");
            _GameDataTable.Columns.Add("TradeGoods6", @"特産品6");
            _GameDataTable.Columns.Add("TradeGoods7", @"特産品7");
            _GameDataTable.Columns.Add("TradeGoods8", @"特産品8");
            _GameDataTable.Columns.Add("TradeGoods9", @"特産品9");
            _GameDataTable.Columns.Add("TradeGoods10", @"特産品10");
            _GameDataTable.Columns.Add("RiceStore", @"米屋");
            _GameDataTable.Columns.Add("Stable", @"馬屋");
            _GameDataTable.Columns.Add("Bar", @"酒場");
            _GameDataTable.Columns.Add("Inn", @"宿屋");
            _GameDataTable.Columns.Add("PrivateHouse", @"民家");
            _GameDataTable.Columns.Add("Dojo1", @"道場1");
            _GameDataTable.Columns.Add("Dojo2", @"道場2");
            _GameDataTable.Columns.Add("DoctorHouse", @"医師宅");
            _GameDataTable.Columns.Add("TeaMasterHouse", @"茶人宅");
            _GameDataTable.Columns.Add("Blacksmith", @"鍛冶屋");
            _GameDataTable.Columns.Add("CraftsmanHouse", @"職人宅");
            _GameDataTable.Columns.Add("Temple", @"寺");
            _GameDataTable.Columns.Add("ForeignTemple", @"南蛮寺");
            _GameDataTable.Columns.Add("ForeignFirm", @"南蛮商館");
            _GameDataTable.Columns.Add("AristocraticHouse", @"公家宅");
            _GameDataTable.Columns.Add("ImperialPalace", @"御所");
            _GameDataTable.Columns.Add("Market", @"座");
            _GameDataTable.Columns.Add("TradingPost", @"交易所");
            _GameDataTable.Columns.Add("Location", @"立地");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["Scale"].Width = 60;
            _GameDataTable.Columns["Money"].Width = 100;
            _GameDataTable.Columns["RiceMarketPrice"].Width = 100;
            _GameDataTable.Columns["RiceInventory"].Width = 100;
            _GameDataTable.Columns["HorseMarketPrice"].Width = 100;
            _GameDataTable.Columns["HorseInventory"].Width = 100;
            _GameDataTable.Columns["TradeGoods1"].Width = 80;
            _GameDataTable.Columns["TradeGoods2"].Width = 80;
            _GameDataTable.Columns["TradeGoods3"].Width = 80;
            _GameDataTable.Columns["TradeGoods4"].Width = 80;
            _GameDataTable.Columns["TradeGoods5"].Width = 80;
            _GameDataTable.Columns["TradeGoods6"].Width = 80;
            _GameDataTable.Columns["TradeGoods7"].Width = 80;
            _GameDataTable.Columns["TradeGoods8"].Width = 80;
            _GameDataTable.Columns["TradeGoods9"].Width = 80;
            _GameDataTable.Columns["TradeGoods10"].Width = 80;
            _GameDataTable.Columns["RiceStore"].Width = 100;
            _GameDataTable.Columns["Stable"].Width = 100;
            _GameDataTable.Columns["Bar"].Width = 100;
            _GameDataTable.Columns["Inn"].Width = 100;
            _GameDataTable.Columns["PrivateHouse"].Width = 100;
            _GameDataTable.Columns["Dojo1"].Width = 100;
            _GameDataTable.Columns["Dojo2"].Width = 100;
            _GameDataTable.Columns["DoctorHouse"].Width = 100;
            _GameDataTable.Columns["TeaMasterHouse"].Width = 100;
            _GameDataTable.Columns["Blacksmith"].Width = 100;
            _GameDataTable.Columns["CraftsmanHouse"].Width = 100;
            _GameDataTable.Columns["Temple"].Width = 100;
            _GameDataTable.Columns["ForeignTemple"].Width = 100;
            _GameDataTable.Columns["ForeignFirm"].Width = 100;
            _GameDataTable.Columns["AristocraticHouse"].Width = 100;
            _GameDataTable.Columns["ImperialPalace"].Width = 100;
            _GameDataTable.Columns["Market"].Width = 100;
            _GameDataTable.Columns["TradingPost"].Width = 100;
            _GameDataTable.Columns["Location"].Width = 60;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfMachi;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = GameData.NumOfShiro + i;
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
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"特産品の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.KyotenEdit.TradeGoodsEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
            }));
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"施設の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.KyotenEdit.MachiShisetuEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
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
                Machi machi = (Machi)_GameData.KyotenList[id];
                var goodsNameList = _GameData.NameListDictionary["TradeGoods"];
                for (int i = 0; i < 10; ++i)
                {
                    var tradeGoods = GameDataTableCellValue.Empty;
                    if (machi.TradeGoods[i] != GameData.NoneTradeGoodsID)
                    {
                        tradeGoods.Text = goodsNameList[machi.TradeGoods[i]];
                        tradeGoods.SortValue = machi.TradeGoods[i];
                    }
                    row.Cells["TradeGoods" + (i + 1)].Value = tradeGoods;
                }
                var riceStore = GameDataTableCellValue.Empty;
                if (machi.RiceStore != GameData.NoneBushoID)
                {
                    riceStore.Text = _GameData.BushoList[machi.RiceStore].Name;
                    riceStore.SortValue = machi.RiceStore;
                }
                var stable = GameDataTableCellValue.Empty;
                if (machi.Stable != GameData.NoneBushoID)
                {
                    stable.Text = _GameData.BushoList[machi.Stable].Name;
                    stable.SortValue = machi.Stable;
                }
                var bar = GameDataTableCellValue.Empty;
                if (machi.Bar != GameData.NoneBushoID)
                {
                    bar.Text = _GameData.BushoList[machi.Bar].Name;
                    bar.SortValue = machi.Bar;
                }
                var inn = GameDataTableCellValue.Empty;
                if (machi.Inn != GameData.NoneBushoID)
                {
                    inn.Text = _GameData.BushoList[machi.Inn].Name;
                    inn.SortValue = machi.Inn;
                }
                var privateHouse = GameDataTableCellValue.Empty;
                if (machi.PrivateHouse != GameData.NoneBushoID)
                {
                    privateHouse.Text = _GameData.BushoList[machi.PrivateHouse].Name;
                    privateHouse.SortValue = machi.PrivateHouse;
                }
                var dojo1 = GameDataTableCellValue.Empty;
                if (machi.Dojo1 != GameData.NoneBushoID)
                {
                    dojo1.Text = _GameData.BushoList[machi.Dojo1].Name;
                    dojo1.SortValue = machi.Dojo1;
                }
                var dojo2 = GameDataTableCellValue.Empty;
                if (machi.Dojo2 != GameData.NoneBushoID)
                {
                    dojo2.Text = _GameData.BushoList[machi.Dojo2].Name;
                    dojo2.SortValue = machi.Dojo2;
                }
                var doctorHouse = GameDataTableCellValue.Empty;
                if (machi.DoctorHouse != GameData.NoneBushoID)
                {
                    doctorHouse.Text = _GameData.BushoList[machi.DoctorHouse].Name;
                    doctorHouse.SortValue = machi.DoctorHouse;
                }
                var teaMasterHouse = GameDataTableCellValue.Empty;
                if (machi.TeaMasterHouse != GameData.NoneBushoID)
                {
                    teaMasterHouse.Text = _GameData.BushoList[machi.TeaMasterHouse].Name;
                    teaMasterHouse.SortValue = machi.TeaMasterHouse;
                }
                var blacksmith = GameDataTableCellValue.Empty;
                if (machi.Blacksmith != GameData.NoneBushoID)
                {
                    blacksmith.Text = _GameData.BushoList[machi.Blacksmith].Name;
                    blacksmith.SortValue = machi.Blacksmith;
                }
                var craftsmanHouse = GameDataTableCellValue.Empty;
                if (machi.CraftsmanHouse != GameData.NoneBushoID)
                {
                    craftsmanHouse.Text = _GameData.BushoList[machi.CraftsmanHouse].Name;
                    craftsmanHouse.SortValue = machi.CraftsmanHouse;
                }
                var temple = GameDataTableCellValue.Empty;
                if (machi.Temple != GameData.NoneBushoID)
                {
                    temple.Text = _GameData.BushoList[machi.Temple].Name;
                    temple.SortValue = machi.Temple;
                }
                var foreignTemple = GameDataTableCellValue.Empty;
                if (machi.ForeignTemple != GameData.NoneBushoID)
                {
                    foreignTemple.Text = _GameData.BushoList[machi.ForeignTemple].Name;
                    foreignTemple.SortValue = machi.ForeignTemple;
                }
                var foreignFirm = GameDataTableCellValue.Empty;
                if (machi.ForeignFirm != GameData.NoneBushoID)
                {
                    foreignFirm.Text = _GameData.BushoList[machi.ForeignFirm].Name;
                    foreignFirm.SortValue = machi.ForeignFirm;
                }
                var aristocraticHouse = GameDataTableCellValue.Empty;
                if (machi.AristocraticHouse != GameData.NoneBushoID)
                {
                    aristocraticHouse.Text = _GameData.BushoList[machi.AristocraticHouse].Name;
                    aristocraticHouse.SortValue = machi.AristocraticHouse;
                }
                var imperialPalace = GameDataTableCellValue.Empty;
                if (machi.ImperialPalace != GameData.NoneBushoID)
                {
                    imperialPalace.Text = _GameData.BushoList[machi.ImperialPalace].Name;
                    imperialPalace.SortValue = machi.ImperialPalace;
                }
                var market = GameDataTableCellValue.Empty;
                if (machi.Market != GameData.NoneBushoID)
                {
                    market.Text = _GameData.BushoList[machi.Market].Name;
                    market.SortValue = machi.Market;
                }
                var tradingPost = GameDataTableCellValue.Empty;
                if (machi.TradingPost != GameData.NoneBushoID)
                {
                    tradingPost.Text = _GameData.BushoList[machi.TradingPost].Name;
                    tradingPost.SortValue = machi.TradingPost;
                }
                string location = "";
                if (machi.Location == 0) location = @"港湾";
                if (machi.Location == 1) location = @"平地";
                if (machi.Location == 2) location = @"山地";
                // 代入
                row.Cells["Name"].Value = machi.Name;
                row.Cells["Scale"].Value = machi.Scale;
                row.Cells["Money"].Value = machi.Money;
                row.Cells["RiceMarketPrice"].Value = machi.RiceMarketPrice;
                row.Cells["RiceInventory"].Value = machi.RiceInventory;
                row.Cells["HorseMarketPrice"].Value = machi.HorseMarketPrice;
                row.Cells["HorseInventory"].Value = machi.HorseInventory;
                row.Cells["RiceStore"].Value = riceStore;
                row.Cells["Stable"].Value = stable;
                row.Cells["Bar"].Value = bar;
                row.Cells["Inn"].Value = inn;
                row.Cells["PrivateHouse"].Value = privateHouse;
                row.Cells["Dojo1"].Value = dojo1;
                row.Cells["Dojo2"].Value = dojo2;
                row.Cells["DoctorHouse"].Value = doctorHouse;
                row.Cells["TeaMasterHouse"].Value = teaMasterHouse;
                row.Cells["Blacksmith"].Value = blacksmith;
                row.Cells["CraftsmanHouse"].Value = craftsmanHouse;
                row.Cells["Temple"].Value = temple;
                row.Cells["ForeignTemple"].Value = foreignTemple;
                row.Cells["ForeignFirm"].Value = foreignFirm;
                row.Cells["AristocraticHouse"].Value = aristocraticHouse;
                row.Cells["ImperialPalace"].Value = imperialPalace;
                row.Cells["Market"].Value = market;
                row.Cells["TradingPost"].Value = tradingPost;
                row.Cells["Location"].Value = location;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                (ids) => new DataEditForms.KyotenEdit.MachiEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
