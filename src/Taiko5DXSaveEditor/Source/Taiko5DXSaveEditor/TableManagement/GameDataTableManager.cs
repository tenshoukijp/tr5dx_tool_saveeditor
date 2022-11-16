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
    /// ゲームデータ表示用テーブルの管理を行うクラス
    /// </summary>
    public abstract class GameDataTableManager
    {
        #region フィールド
        /// <summary>
        /// ゲームデータを表示するための表
        /// </summary>
        protected DataGridView _GameDataTable;

        /// <summary>
        /// 表示対象のゲームデータ
        /// </summary>
        protected GameData _GameData;

        /// <summary>
        /// メインフォーム
        /// </summary>
        protected MainForm _MainForm;

        /// <summary>
        /// コンテキストメニュー
        /// </summary>
        protected ContextMenuStrip _ContextMenu;

        #endregion

        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public virtual TableType TableType { get { return TableType.None; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// ゲームデータ表示用テーブルの管理を行うクラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public GameDataTableManager(DataGridView gameDataTable, GameData gameData)
        {
            _GameDataTable = gameDataTable;
            _GameData = gameData;
            _MainForm = (MainForm)_GameDataTable.Parent;
            _ContextMenu = _GameDataTable.ContextMenuStrip;
        }

        #endregion

        #region メソッド
        /// <summary>
        /// テーブルの初期化
        /// </summary>
        public abstract void InitializeTable();

        /// <summary>
        /// テーブルのアップデート
        /// </summary>
        /// <param name="selectedRows">選択されている行</param>
        public abstract void UpdateTable(IEnumerable<DataGridViewRow> selectedRows);

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public abstract void OpenBasicEditForm();

        /// <summary>
        /// 編集フォームを開く
        /// </summary>
        /// <param name="editFormCreater">編集フォーム生成のためのデリゲート</param>
        protected void OpenEditForm(Func<int[], DataEditForms.DataEditForm> editFormCreater)
        {
            // データが選ばれてなければ抜ける
            if (_GameDataTable.SelectedRows.Count <= 0) return;
            // 選択項目のID
            int[] ids = null;
            if (_GameDataTable.Columns.Contains("ID"))
            {
                var idData = from DataGridViewRow row in _GameDataTable.SelectedRows
                             select (int)row.Cells["ID"].Value;
                ids = idData.ToArray();
            }
            // 編集画面を開く
            var editForm = editFormCreater(ids);
            var result = editForm.ShowDialog(_MainForm);
            if (result == DialogResult.OK)
            {
                _MainForm.IsEnabledSaveFile = true;
                UpdateTable(_GameDataTable.SelectedRows.Cast<DataGridViewRow>());
            }
            // 後始末
            editForm.Dispose();
        }

        #endregion

    }
}
