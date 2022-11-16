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
    /// 主人公データテーブルの管理クラス
    /// </summary>
    public class ShujinkoTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Shujinko; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 主人公データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public ShujinkoTableManager(DataGridView gameDataTable, GameData gameData)
            : base (gameDataTable, gameData)
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
            _GameDataTable.Columns.Add("Name", @"名前");
            _GameDataTable.Columns.Add("HP", @"体力");
            _GameDataTable.Columns.Add("Money", @"所持金");
            _GameDataTable.Columns.Add("Bank", @"預金");
            _GameDataTable.Columns.Add("Weapon", @"装備武器");
            _GameDataTable.Columns.Add("Armor", @"装備防具");
            _GameDataTable.Columns.Add("IronSands", @"砂鉄所持数");
            _GameDataTable.Columns.Add("Herbs", @"薬草所持数");
            _GameDataTable.Columns.Add("WifeAffection", @"妻愛情");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["HP"].Width = 60;
            _GameDataTable.Columns["Money"].Width = 80;
            _GameDataTable.Columns["Bank"].Width = 80;
            _GameDataTable.Columns["Weapon"].Width = 100;
            _GameDataTable.Columns["Armor"].Width = 100;
            _GameDataTable.Columns["IronSands"].Width = 100;
            _GameDataTable.Columns["WifeAffection"].Width = 60;
            _GameDataTable.Columns["Herbs"].Width = 100;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            _GameDataTable.Rows.Add(1);
            UpdateTable(_GameDataTable.Rows.Cast<DataGridViewRow>());
            // 選択を外す
            _GameDataTable.CurrentCell = null;

            // コンテキストメニューの設定
            _ContextMenu.Items.Clear();
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"主要項目の編集", null, (sender, e) =>
            {
                OpenBasicEditForm();
            }));
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"経験関連の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.ShujinkoEdit.ExpEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
            }));
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"流派名・屋号の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.ShujinkoEdit.NameEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
            }));
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"戦績、その他の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.ShujinkoEdit.OtherEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
            }));
        }

        /// <summary>
        /// テーブルのアップデート
        /// </summary>
        /// <param name="selectedRows">選択されている行</param>
        public override void UpdateTable(IEnumerable<DataGridViewRow> selectedRows)
        {
            var shujinko = _GameData.Shujinko;
            string weapon = "";
            if (shujinko.Weapon != GameData.NoneItemID)
                weapon = _GameData.ItemList[shujinko.Weapon].Name;
            string armor = "";
            if (shujinko.Armor != GameData.NoneItemID)
                armor = _GameData.ItemList[shujinko.Armor].Name;
            _GameDataTable.Rows[0].Cells["ID"].Value = (int)shujinko.ShujinkoID;
            _GameDataTable.Rows[0].Cells["Name"].Value = _GameData.BushoList[shujinko.ShujinkoID].Name;
            _GameDataTable.Rows[0].Cells["HP"].Value = shujinko.HitPoint;
            _GameDataTable.Rows[0].Cells["Money"].Value = shujinko.Money;
            _GameDataTable.Rows[0].Cells["Bank"].Value = shujinko.Bank;
            _GameDataTable.Rows[0].Cells["Weapon"].Value = weapon;
            _GameDataTable.Rows[0].Cells["Armor"].Value = armor;
            _GameDataTable.Rows[0].Cells["IronSands"].Value = shujinko.IronSands;
            _GameDataTable.Rows[0].Cells["Herbs"].Value = shujinko.Herbs;
            _GameDataTable.Rows[0].Cells["WifeAffection"].Value = shujinko.WifeAffection;
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.ShujinkoEdit.BasicEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
