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

namespace Taiko5DXSaveEditor.DataEditForms.OtherEdit
{
    /// <summary>
    /// 官位就任者を設定するフォーム
    /// </summary>
    public partial class KaniEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の官位リスト
        /// </summary>
        private List<Kani> _KaniEditList = new List<Kani>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public KaniEditForm()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public KaniEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の官位を全て受け取る
            var kanis = from kani in gameData.KaniList
                         where selectedIDs.Contains(kani.ID)
                         select kani;
            _KaniEditList.AddRange(kanis);

            // コンポーネントの初期化
            InitializeComponent();
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォームがロードされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void KaniEditForm_Load(object sender, EventArgs e)
        {
            _InauguratedPersonComboBox.Tag = false;

            StringBuilder stringBuilder = new StringBuilder();
            var bushoNames = new string[GameData.NumOfPeople];
            for (int i = 0; i < GameData.NumOfPeople; ++i)
            {
                stringBuilder.Append(i);
                stringBuilder.Append(": ");
                stringBuilder.Append(_GameData.BushoList[i].FamilyName);
                stringBuilder.Append(_GameData.BushoList[i].GivenName);
                bushoNames[i] = stringBuilder.ToString();
                stringBuilder.Clear();
            }
            _InauguratedPersonComboBox.Items.AddRange(bushoNames);
            _InauguratedPersonComboBox.Items.Add(GameData.NoneBushoID + ": なし");

            ushort bushoId = _KaniEditList[0].InauguratedPerson;
            bool notMatch = false;
            for (int i = 1; i < _SelectedIDs.Length; ++i)
            {
                if (bushoId != _KaniEditList[i].InauguratedPerson)
                {
                    notMatch = true;
                    break;
                }
            }
            if (!notMatch)
            {
                if (bushoId != GameData.NoneBushoID) _InauguratedPersonComboBox.SelectedIndex = bushoId;
                else _InauguratedPersonComboBox.SelectedIndex = _InauguratedPersonComboBox.Items.Count - 1;
            }

            _InauguratedPersonComboBox.SelectedIndexChanged += (sender2, e2) => _InauguratedPersonComboBox.Tag = true;
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _OKButton_Click(object sender, EventArgs e)
        {
            // 変更がなければ閉じる
            if (!(bool)_InauguratedPersonComboBox.Tag)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            ushort bushoId = 0;
            try
            {
                bushoId = ushort.Parse(_InauguratedPersonComboBox.Text.Split(':')[0]);
            }
            catch (Exception)
            {
                MessageBox.Show(this, @"不正な入力が含まれています。内容を修正するか、一度このウィンドウを閉じてください。", @"エラー通知", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                _CloseCancelFlag = true;
                return;
            }

            foreach (Kani kani in _KaniEditList)
            {
                kani.InauguratedPerson = bushoId;
            }

            // 画面を閉じる
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// キャンセルボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _CancelButton_Click(object sender, EventArgs e)
        {
            // 画面を閉じる
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
