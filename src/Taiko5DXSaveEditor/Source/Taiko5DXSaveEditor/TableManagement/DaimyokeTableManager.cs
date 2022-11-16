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
    /// 大名家データテーブルの管理クラス
    /// </summary>
    public class DaimyokeTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.Daimyoke; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 大名家データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public DaimyokeTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Name", @"大名家名");
            _GameDataTable.Columns.Add("Leader", @"当主名");
            _GameDataTable.Columns.Add("Imperial", @"朝廷貢献");
            _GameDataTable.Columns.Add("Inactive", @"不活性");
            _GameDataTable.Columns.Add("Daihoshin", @"大方針");
            _GameDataTable.Columns.Add("Senryaku", @"戦略");
            _GameDataTable.Columns.Add("SenryakuTarget", @"戦略ターゲット");
            _GameDataTable.Columns.Add("GoyoShonin1", @"御用商人1");
            _GameDataTable.Columns.Add("GoyoShonin2", @"御用商人2");
            _GameDataTable.Columns.Add("GoyoShonin3", @"御用商人3");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["Leader"].Width = 100;
            _GameDataTable.Columns["Imperial"].Width = 80;
            _GameDataTable.Columns["Inactive"].Width = 80;
            _GameDataTable.Columns["Daihoshin"].Width = 100;
            _GameDataTable.Columns["Senryaku"].Width = 100;
            _GameDataTable.Columns["SenryakuTarget"].Width = 100;
            _GameDataTable.Columns["GoyoShonin1"].Width = 100;
            _GameDataTable.Columns["GoyoShonin2"].Width = 100;
            _GameDataTable.Columns["GoyoShonin3"].Width = 100;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfDaimyoke;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = i;
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
                Daimyoke daimyoke = (Daimyoke)_GameData.SeiryokuList[id];
                var leader = GameDataTableCellValue.Empty;
                var imperial = GameDataTableCellValue.Empty;
                var inactive = GameDataTableCellValue.Empty;
                var daihoshin = GameDataTableCellValue.Empty;
                var senryaku = GameDataTableCellValue.Empty;
                var senryakuTarget = GameDataTableCellValue.Empty;
                var goyoShonin1 = GameDataTableCellValue.Empty;
                var goyoShonin2 = GameDataTableCellValue.Empty;
                var goyoShonin3 = GameDataTableCellValue.Empty;
                if (!daimyoke.IsDestruction)
                {
                    leader.Text = _GameData.BushoList[daimyoke.Leader].Name;
                    leader.SortValue = daimyoke.Leader;
                    imperial.Text = daimyoke.ImperialCourtContribution.ToString();
                    imperial.SortValue = daimyoke.ImperialCourtContribution;
                    inactive.Text = daimyoke.InactivationFlag == 0 ? @"攻め込む" : @"攻め込まない";
                    inactive.SortValue = daimyoke.InactivationFlag;
                    daihoshin.Text = _GameData.NameListDictionary["Daihoshin"][daimyoke.Daihoshin];
                    daihoshin.SortValue = daimyoke.Daihoshin;
                    senryaku.Text = _GameData.NameListDictionary["Senryaku"][daimyoke.Senryaku];
                    senryaku.SortValue = daimyoke.Senryaku;
                    if (daimyoke.Senryaku == 2)
                    {
                        if (daimyoke.SenryakuTarget != GameData.NoneKyotenID)
                        {
                            senryakuTarget.Text = _GameData.KyotenList[daimyoke.SenryakuTarget].Name;
                            senryakuTarget.SortValue = daimyoke.SenryakuTarget;
                        }
                    }
                    else if (daimyoke.Senryaku == 3)
                    {
                        if (daimyoke.SenryakuTarget != GameData.NoneSeiryokuID)
                        {
                            senryakuTarget.Text = _GameData.SeiryokuList[daimyoke.SenryakuTarget].Name;
                            senryakuTarget.SortValue = daimyoke.SenryakuTarget + 10000;
                        }
                    }
                    else if ((daimyoke.Senryaku == 4) || (daimyoke.Senryaku == 5))
                    {
                        if (daimyoke.SenryakuTarget != GameData.NoneKuniID)
                        {
                            senryakuTarget.Text = _GameData.NameListDictionary["Kuni"][daimyoke.SenryakuTarget];
                            senryakuTarget.SortValue = daimyoke.SenryakuTarget + 20000;
                        }
                    }
                    else if ((daimyoke.Senryaku == 6) || (daimyoke.Senryaku == 7))
                    {
                        if (daimyoke.SenryakuTarget != GameData.NoneChihoID)
                        {
                            senryakuTarget.Text = _GameData.NameListDictionary["Chiho"][daimyoke.SenryakuTarget];
                            senryakuTarget.SortValue = daimyoke.SenryakuTarget + 30000;
                        }
                    }
                    if (daimyoke.GoyoShonin1 != GameData.NoneSeiryokuID)
                    {
                        goyoShonin1.Text = _GameData.SeiryokuList[daimyoke.GoyoShonin1].Name;
                        goyoShonin1.SortValue = daimyoke.GoyoShonin1;
                    }
                    if (daimyoke.GoyoShonin2 != GameData.NoneSeiryokuID)
                    {
                        goyoShonin2.Text = _GameData.SeiryokuList[daimyoke.GoyoShonin2].Name;
                        goyoShonin2.SortValue = daimyoke.GoyoShonin2;
                    }
                    if (daimyoke.GoyoShonin3 != GameData.NoneSeiryokuID)
                    {
                        goyoShonin3.Text = _GameData.SeiryokuList[daimyoke.GoyoShonin3].Name;
                        goyoShonin3.SortValue = daimyoke.GoyoShonin3;
                    }
                }
                // 代入
                row.Cells["Name"].Value = daimyoke.Name;
                row.Cells["Leader"].Value = leader;
                row.Cells["Imperial"].Value = imperial;
                row.Cells["Inactive"].Value = inactive;
                row.Cells["Daihoshin"].Value = daihoshin;
                row.Cells["Senryaku"].Value = senryaku;
                row.Cells["SenryakuTarget"].Value = senryakuTarget;
                row.Cells["GoyoShonin1"].Value = goyoShonin1;
                row.Cells["GoyoShonin2"].Value = goyoShonin2;
                row.Cells["GoyoShonin3"].Value = goyoShonin3;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.SeiryokuEdit.DaimyokeEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
