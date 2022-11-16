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
    /// 忍者衆データテーブルの管理クラス
    /// </summary>
    public class NinjaShuTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.NinjaShu; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 忍者衆データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public NinjaShuTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Name", @"忍者衆名");
            _GameDataTable.Columns.Add("Leader", @"当主名");
            _GameDataTable.Columns.Add("Senryaku", @"戦略");
            _GameDataTable.Columns.Add("SenryakuTarget", @"戦略ターゲット");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["Leader"].Width = 100;
            _GameDataTable.Columns["Senryaku"].Width = 100;
            _GameDataTable.Columns["SenryakuTarget"].Width = 100;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfNinjaShu;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = GameData.NumOfDaimyoke + GameData.NumOfShoka + i;
                var seiryoku = _GameData.SeiryokuList[index];
                int id = seiryoku.ID;
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
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"外交関係の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.SeiryokuEdit.DiplomacyEditForm(ids, _GameData);
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
                NinjaShu ninjaShu = (NinjaShu)_GameData.SeiryokuList[id];
                var leader = GameDataTableCellValue.Empty;
                var senryaku = GameDataTableCellValue.Empty;
                var senryakuTarget = GameDataTableCellValue.Empty;
                if (!ninjaShu.IsDestruction)
                {
                    leader.Text = _GameData.BushoList[ninjaShu.Leader].Name;
                    leader.SortValue = ninjaShu.Leader;
                    senryaku.Text = _GameData.NameListDictionary["SenryakuNinja"][ninjaShu.Senryaku];
                    senryaku.SortValue = ninjaShu.Senryaku;
                    if ((ninjaShu.Senryaku == 2) || (ninjaShu.Senryaku == 3))
                    {
                        if ((ninjaShu.SenryakuTarget != GameData.NoneSeiryokuID) && (ninjaShu.SenryakuTarget != 65535))
                        {
                            senryakuTarget.Text = _GameData.SeiryokuList[ninjaShu.SenryakuTarget].Name;
                            senryakuTarget.SortValue = ninjaShu.SenryakuTarget;
                        }
                    }
                }
                row.Cells["Name"].Value = ninjaShu.Name;
                row.Cells["Leader"].Value = leader;
                row.Cells["Senryaku"].Value = senryaku;
                row.Cells["SenryakuTarget"].Value = senryakuTarget;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.SeiryokuEdit.NinjaShuEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
