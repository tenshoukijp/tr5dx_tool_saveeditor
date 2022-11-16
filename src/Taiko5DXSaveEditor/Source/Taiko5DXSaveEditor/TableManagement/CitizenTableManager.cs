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
    /// 町人データテーブルの管理クラス
    /// </summary>
    public class CitizenTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Citizen; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 町人データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public CitizenTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Name", @"名前");
            _GameDataTable.Columns.Add("Mibun", @"身分");
            _GameDataTable.Columns.Add("Sex", @"性別");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["Mibun"].Width = 80;
            _GameDataTable.Columns["Sex"].Width = 60;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfCitizen + GameData.NumOfInvalid;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = GameData.NumOfBusho + GameData.NumOfGeneralPurpose + GameData.NumOfEventPerson + i;
                Busho busho = _GameData.BushoList[index];
                int id = busho.ID;
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
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"隠し項目の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.BushoEdit.HiddenEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
            }));
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"所属・状態の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.BushoEdit.AffiliationEditForm(ids, _GameData);
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
                Busho busho = _GameData.BushoList[id];
                // 値の取得
                string name = busho.Name;
                var mibun = new GameDataTableCellValue("", busho.Mibun);
                if (busho.Mibun != GameData.NoneMibunID)
                    mibun.Text = _GameData.NameListDictionary["Mibun"][busho.Mibun];
                else
                    mibun.Text = @"死亡";
                var sex = new GameDataTableCellValue(busho.Sex == 0 ? @"男" : @"女", busho.Sex);
                // 代入
                row.Cells["Name"].Value = name;
                row.Cells["Mibun"].Value = mibun;
                row.Cells["Sex"].Value = sex;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.BushoEdit.BasicEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion
    }
}
