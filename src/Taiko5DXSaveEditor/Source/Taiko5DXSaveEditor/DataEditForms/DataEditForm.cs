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

namespace Taiko5DXSaveEditor.DataEditForms
{
    /// <summary>
    /// データ編集用の共通フォーム
    /// </summary>
    public partial class DataEditForm : Form
    {
        #region フィールド
        /// <summary>
        /// 選択されたデータのID
        /// </summary>
        protected int[] _SelectedIDs = null;

        /// <summary>
        /// ゲームデータ
        /// </summary>
        protected GameData _GameData = null;

        /// <summary>
        /// これが真ならフォームを閉じるのをやめる
        /// </summary>
        protected bool _CloseCancelFlag = false; 

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public DataEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public DataEditForm(int[] selectedIDs, GameData gameData)
        {
            _SelectedIDs = selectedIDs;
            _GameData = gameData;
            InitializeComponent();
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォームが閉じられる際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void DataEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_CloseCancelFlag)
            {
                e.Cancel = true;
                _CloseCancelFlag = false;
            }
        }

        #endregion

    }
}
