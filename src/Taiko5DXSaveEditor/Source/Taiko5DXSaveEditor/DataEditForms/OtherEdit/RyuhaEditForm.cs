using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.DataEditForms.OtherEdit
{
    /// <summary>
    /// 流派を設定するフォーム
    /// </summary>
    public partial class RyuhaEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の流派リスト
        /// </summary>
        private List<Ryuha> _RyuhaEditList = new List<Ryuha>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public RyuhaEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public RyuhaEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の流派を全て受け取る
            var ryuhas = from ryuha in gameData.RyuhaList
                         where selectedIDs.Contains(ryuha.ID)
                         select (Ryuha)ryuha;
            _RyuhaEditList.AddRange(ryuhas);

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
        private void RyuhaEditForm_Load(object sender, EventArgs e)
        {
            // データ編集確認用のbool型変数の配列を確保
            var controls = from Control control in Controls
                           where control.TabIndex < 100
                           orderby control.TabIndex
                           select control;
            Control[] controlsArray = controls.ToArray();
            foreach (var control in controlsArray)
            {
                control.Tag = false;
            }

            // コンボボックスとチェックリストの初期化
            InitComboBoxAndCheckLists();
            // 各コントロールの初期値設定
            SetFirstControlValues();
            // イベントハンドラの設定
            SetEventHandlers(controlsArray);
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _OKButton_Click(object sender, EventArgs e)
        {
            bool isDataEdited = false;

            // UIから入力内容を読み取る
            byte nameId = 0;
            ushort leader = 0;
            byte license = 0;
            byte dojoYaburi = 0;
            try
            {
                if ((bool)_NameComboBox.Tag)
                {
                    if (_NameComboBox.Text == "")
                        nameId = GameData.NoneShokaNameID;
                    else if (_NameComboBox.SelectedIndex == (_NameComboBox.Items.Count - 2))
                        nameId = GameData.MyRyuhaNameID;
                    else
                        nameId = (byte)_NameComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_LeaderComboBox.Tag)
                {
                    leader = ushort.Parse(_LeaderComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_LicenseComboBox.Tag)
                {
                    license = (byte)_LicenseComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_DojoYaburiComboBox.Tag)
                {
                    dojoYaburi = byte.Parse(_DojoYaburiComboBox.Text);
                    isDataEdited = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, @"不正な入力が含まれています。内容を修正するか、一度このウィンドウを閉じてください。", @"エラー通知", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                _CloseCancelFlag = true;
                return;
            }

            // 変更がなければ閉じる
            if (!isDataEdited)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            // 変更を反映
            int n = _RyuhaEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_LeaderComboBox.Tag)
                {
                    _RyuhaEditList[i].Leader = leader;
                    if (leader == GameData.NoneBushoID)
                    {
                        _RyuhaEditList[i].IsDestruction = true;
                        _RyuhaEditList[i].Name = "";
                    }
                    else
                        _RyuhaEditList[i].IsDestruction = false;
                }
                if ((bool)_NameComboBox.Tag)
                {
                    _RyuhaEditList[i].NameID = nameId;
                    if (_RyuhaEditList[i].IsDestruction)
                        _RyuhaEditList[i].Name = "";
                    else
                        _RyuhaEditList[i].Name = _NameComboBox.Text;
                }
                if ((bool)_LicenseComboBox.Tag)
                {
                    _RyuhaEditList[i].License = license;
                }
                if ((bool)_DojoYaburiComboBox.Tag)
                {
                    _RyuhaEditList[i].DojoYaburi = dojoYaburi;
                }
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

        #region メソッド
        /// <summary>
        /// コンボボックスとチェックリストの初期化
        /// </summary>
        private void InitComboBoxAndCheckLists()
        {
            // コンボボックスの作成
            StringBuilder sb = new StringBuilder();
            var nameList = _GameData.NameListDictionary["Ryuha"];
            _NameComboBox.Items.AddRange(nameList.ToArray());
            _NameComboBox.Items.Add(_GameData.Shujinko.NameOfMyRyuha + @"流");
            _NameComboBox.Items.Add("");

            int nbusho = _GameData.BushoList.Count;
            var bushoNames = new string[nbusho];
            for (int i = 0; i < nbusho; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                sb.Append(_GameData.BushoList[i].FamilyName);
                sb.Append(_GameData.BushoList[i].GivenName);
                bushoNames[i] = sb.ToString();
                sb.Clear();
            }
            _LeaderComboBox.Items.AddRange(bushoNames);
            _LeaderComboBox.Items.Add(GameData.NoneBushoID + ": なし");
        }

        /// <summary>
        /// 各コントロールの初期値を設定
        /// </summary>
        private void SetFirstControlValues()
        {
            // 初期値の設定
            byte nameId = _RyuhaEditList[0].NameID;
            ushort leader = _RyuhaEditList[0].Leader;
            byte license = _RyuhaEditList[0].License;
            byte dojoYaburi = _RyuhaEditList[0].DojoYaburi;

            // 他と一致するか確認
            bool notMatchedNameID = !_NameComboBox.Enabled;
            bool notMatchedLeader = !_LeaderComboBox.Enabled;
            bool notMatchedLicense = !_LicenseComboBox.Enabled;
            bool notMatchedDojoYaburi = !_DojoYaburiComboBox.Enabled;
            int nedits = _RyuhaEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (nameId != _RyuhaEditList[i].NameID)
                    notMatchedNameID = true;
                if (leader != _RyuhaEditList[i].Leader)
                    notMatchedLeader = true;
                if (license != _RyuhaEditList[i].License)
                    notMatchedLicense = true;
                if (dojoYaburi != _RyuhaEditList[i].DojoYaburi)
                    notMatchedDojoYaburi = true;
            }
            if (!notMatchedNameID)
            {
                if (nameId == GameData.MyRyuhaNameID)
                    _NameComboBox.SelectedIndex = _NameComboBox.Items.Count - 2;
                else if (nameId == GameData.NoneRyuhaNameID)
                    _NameComboBox.SelectedIndex = _NameComboBox.Items.Count - 1;
                else
                    _NameComboBox.SelectedIndex = nameId;
            }
            if (!notMatchedLeader)
            {
                if (leader == GameData.NoneBushoID)
                    _LeaderComboBox.SelectedIndex = _LeaderComboBox.Items.Count - 1;
                else
                    _LeaderComboBox.SelectedIndex = leader;
            }
            if (!notMatchedLicense)
            {
                _LicenseComboBox.SelectedIndex = license;
            }
            if (!notMatchedDojoYaburi)
            {
                _DojoYaburiComboBox.Text = dojoYaburi.ToString();
            }
        }

        /// <summary>
        /// イベントハンドラの設定
        /// </summary>
        /// <param name="controlsArray">設定対象のコントロール</param>
        private void SetEventHandlers(Control[] controlsArray)
        {
            // イベントハンドラの設定
            EventHandler checker = (sender, e) =>
            {
                if (sender is Control control)
                    control.Tag = true;
            };
            _NameComboBox.SelectedIndexChanged += checker;
            _LeaderComboBox.SelectedIndexChanged += checker;
            _LicenseComboBox.SelectedIndexChanged += checker;

            // コンボボックス(ドロップダウン)用のイベントハンドラ
            string[] beforeTexts = new string[controlsArray.Length];
            for (int i = 0; i < controlsArray.Length; ++i)
            {
                beforeTexts[i] = controlsArray[i].Text;
            }
            EventHandler checkerForDropDown = (sender, e) =>
            {
                ComboBox cb = (ComboBox)sender;
                if (cb.Text == beforeTexts[cb.TabIndex]) return;
                int start = cb.SelectionStart - 1;
                bool badTextFlg = System.Text.RegularExpressions.Regex.IsMatch(cb.Text, @"[^0-9]");
                if (badTextFlg)
                {
                    cb.Text = beforeTexts[cb.TabIndex];
                    cb.SelectionStart = start;
                }
                else
                {
                    beforeTexts[cb.TabIndex] = cb.Text;
                    cb.Tag = true;
                }
            };
            _DojoYaburiComboBox.TextChanged += checkerForDropDown;
        }

        #endregion

    }
}
