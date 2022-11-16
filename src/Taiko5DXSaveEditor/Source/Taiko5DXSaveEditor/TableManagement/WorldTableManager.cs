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
    /// 世界データテーブルの管理クラス
    /// </summary>
    public class WorldTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.World; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 世界データテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public WorldTableManager(DataGridView gameDataTable, GameData gameData)
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
            _GameDataTable.Columns.Add("Scenario", @"シナリオ");
            _GameDataTable.Columns.Add("Nengappi", @"年月日");
            _GameDataTable.Columns.Add("PlayDays", @"経過日数");
            _GameDataTable.Columns.Add("NextMeetingDays", @"次回評定までの日数");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["Scenario"].Width = 120;
            _GameDataTable.Columns["Nengappi"].Width = 120;
            _GameDataTable.Columns["PlayDays"].Width = 120;
            _GameDataTable.Columns["NextMeetingDays"].Width = 120;
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
        }

        /// <summary>
        /// テーブルのアップデート
        /// </summary>
        /// <param name="selectedRows">選択されている行</param>
        public override void UpdateTable(IEnumerable<DataGridViewRow> selectedRows)
        {
            var world = _GameData.World;
            string scenario = _GameData.NameListDictionary["Scenario"][world.ScenarioNumber];
            int year = 1500 + world.Year;
            int month = world.Month + 1;
            int day = world.Day + 1;
            string nengappi = year + @"年" + month + @"月" + day + @"日";
            int playDays = world.PlayDays;
            string nextMeetingDays = @"開催予定なし";
            if (world.NextMeetingDays != 255)
                nextMeetingDays = world.NextMeetingDays.ToString();
            _GameDataTable.Rows[0].Cells["Scenario"].Value = scenario;
            _GameDataTable.Rows[0].Cells["Nengappi"].Value = nengappi;
            _GameDataTable.Rows[0].Cells["PlayDays"].Value = playDays;
            _GameDataTable.Rows[0].Cells["NextMeetingDays"].Value = nextMeetingDays;
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater = 
                (ids) => new DataEditForms.WorldEdit.WorldEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion

    }
}
