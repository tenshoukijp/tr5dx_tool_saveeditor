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

namespace Taiko5DXSaveEditor.DataEditForms.BushoEdit
{
    /// <summary>
    /// 武将の人間関係を設定するフォーム
    /// </summary>
    public partial class RelationshipEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の武将リスト
        /// </summary>
        private List<Busho> _BushoEditList = new List<Busho>();

        /// <summary>
        /// 人物カテゴリによって編集できる項目が異なる
        /// </summary>
        private PeopleCategory _EditMode = PeopleCategory.Busho;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public RelationshipEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public RelationshipEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の武将を全て受け取る
            var bushos = from busho in gameData.BushoList
                         where selectedIDs.Contains(busho.ID)
                         select (Busho)busho;
            _BushoEditList.AddRange(bushos);

            // コンポーネントの初期化
            InitializeComponent();

            // 人物カテゴリに応じて編集モードを変える
            InitEditMode();
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォームがロードされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void RelationshipEditForm_Load(object sender, EventArgs e)
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

            // モードごとの制限を付ける
            ApplyModeLimits();
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
            ushort parents = 0;
            ushort grandparents = 0;
            ushort spouse = 0;
            ushort master = 0;
            byte yearOfBirth = 0;
            byte yearOfAdult = 0;
            byte yearOfDeath = 0;
            byte ryuha = 0;
            byte license = 0;
            byte betrayalFlag = 0;
            byte previousRelationship = 0;

            try
            {
                if ((bool)_ParentsComboBox.Tag)
                {
                    parents = ushort.Parse(_ParentsComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_GrandparentsComboBox.Tag)
                {
                    grandparents = ushort.Parse(_GrandparentsComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_SpouseComboBox.Tag)
                {
                    spouse = ushort.Parse(_SpouseComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_MasterComboBox.Tag)
                {
                    master = ushort.Parse(_MasterComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_YearOfBirthTextBox.Tag)
                {
                    int val = int.Parse(_YearOfBirthTextBox.Text) - 1460;
                    if ((val < 0) || (255 < val))
                        throw new Exception();
                    yearOfBirth = (byte)val;
                    isDataEdited = true;
                }
                if ((bool)_YearOfAdultTextBox.Tag)
                {
                    int val = int.Parse(_YearOfAdultTextBox.Text) - 1500;
                    if ((val < 0) || (255 < val))
                        throw new Exception();
                    yearOfAdult = (byte)val;
                    isDataEdited = true;
                }
                if ((bool)_YearOfDeathTextBox.Tag)
                {
                    int val = int.Parse(_YearOfDeathTextBox.Text) - 1500;
                    if ((val < 0) || (255 < val))
                        throw new Exception();
                    yearOfDeath = (byte)val;
                    isDataEdited = true;
                }
                if ((bool)_RyuhaComboBox.Tag)
                {
                    ryuha = byte.Parse(_RyuhaComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_LicenseComboBox.Tag)
                {
                    license = (byte)_LicenseComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_BetrayalFlagComboBox.Tag)
                {
                    betrayalFlag = (byte)_BetrayalFlagComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_PreviousRelationshipComboBox.Tag)
                {
                    previousRelationship = (byte)_PreviousRelationshipComboBox.SelectedIndex;
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
            int n = _BushoEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_ParentsComboBox.Tag)
                {
                    _BushoEditList[i].Parents = parents;
                }
                if ((bool)_GrandparentsComboBox.Tag)
                {
                    _BushoEditList[i].Grandparents = grandparents;
                }
                if ((bool)_SpouseComboBox.Tag)
                {
                    _BushoEditList[i].Spouse = spouse;
                }
                if ((bool)_MasterComboBox.Tag)
                {
                    _BushoEditList[i].Master = master;
                }
                if ((bool)_YearOfBirthTextBox.Tag)
                {
                    _BushoEditList[i].YearOfBirth = yearOfBirth;
                }
                if ((bool)_YearOfAdultTextBox.Tag)
                {
                    _BushoEditList[i].YearOfAdult = yearOfAdult;
                }
                if ((bool)_YearOfDeathTextBox.Tag)
                {
                    _BushoEditList[i].YearOfDeath = yearOfDeath;
                }
                if ((bool)_RyuhaComboBox.Tag)
                {
                    _BushoEditList[i].Ryuha = ryuha;
                }
                if ((bool)_LicenseComboBox.Tag)
                {
                    _BushoEditList[i].License = license;
                }
                if ((bool)_BetrayalFlagComboBox.Tag)
                {
                    _BushoEditList[i].BetrayalFlag = betrayalFlag;
                }
                if ((bool)_PreviousRelationshipComboBox.Tag)
                {
                    _BushoEditList[i].PreviousRelationship = previousRelationship;
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
        /// 編集モードの初期化
        /// </summary>
        private void InitEditMode()
        {
            // 編集対象の人物カテゴリに応じて編集モードを切り替える
            foreach (Busho busho in _BushoEditList)
            {
                if ((busho.PeopleCategory == PeopleCategory.Invalid) || (busho.PeopleCategory == PeopleCategory.Citizen))
                {
                    _EditMode = PeopleCategory.Citizen;
                    break;
                }
                else if ((busho.PeopleCategory == PeopleCategory.EventPerson) && (_EditMode < PeopleCategory.EventPerson))
                {
                    _EditMode = PeopleCategory.EventPerson;
                }
                else if ((busho.PeopleCategory == PeopleCategory.GeneralPurpose) && (_EditMode < PeopleCategory.GeneralPurpose))
                {
                    _EditMode = PeopleCategory.GeneralPurpose;
                }
            }
            // モードに応じて、ウィンドウのタイトルを変更
            switch (_EditMode)
            {
                case PeopleCategory.Busho:
                    Text += " - 武将編集モード";
                    break;
                case PeopleCategory.GeneralPurpose:
                    Text += " - 汎用ライバル編集モード";
                    break;
                case PeopleCategory.EventPerson:
                    Text += " - イベント人物編集モード";
                    break;
                case PeopleCategory.Citizen:
                    Text += " - 町人編集モード";
                    break;
            }
        }

        /// <summary>
        /// モード制限を適用
        /// </summary>
        private void ApplyModeLimits()
        {
            // モードによる編集項目の切替
            if (_EditMode >= PeopleCategory.Citizen)
            {
                _ParentsComboBox.Enabled = false;
                _GrandparentsComboBox.Enabled = false;
                _YearOfBirthTextBox.Enabled = false;
                _YearOfAdultTextBox.Enabled = false;
            }
            if (_EditMode >= PeopleCategory.EventPerson)
            {
                _LicenseComboBox.Enabled = false;
                _BetrayalFlagComboBox.Enabled = false;
                _PreviousRelationshipComboBox.Enabled = false;
            }
            if (_EditMode >= PeopleCategory.GeneralPurpose)
            {
                _SpouseComboBox.Enabled = false;
                _MasterComboBox.Enabled = false;
                _RyuhaComboBox.Enabled = false;
                _YearOfDeathTextBox.Enabled = false;
            }
        }

        /// <summary>
        /// コンボボックスとチェックリストの初期化
        /// </summary>
        private void InitComboBoxAndCheckLists()
        {
            // コンボボックスの作成
            StringBuilder sb = new StringBuilder();
            int nbusho = _GameData.BushoList.Count;
            var names = new string[nbusho];
            for (int i = 0; i < nbusho; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                sb.Append(_GameData.BushoList[i].FamilyName);
                sb.Append(_GameData.BushoList[i].GivenName);
                string text = sb.ToString();
                names[i] = text;
                sb.Clear();
            }
            _ParentsComboBox.Items.AddRange(names);
            _GrandparentsComboBox.Items.AddRange(names);
            _SpouseComboBox.Items.AddRange(names);
            _MasterComboBox.Items.AddRange(names);

            var parentsNameList = _GameData.NameListDictionary["Parents"];
            int nparents = parentsNameList.Count;
            var names2 = new string[nparents];
            for (int i = 0; i < nparents; ++i)
            {
                int id = nbusho + i;
                sb.Append(id);
                sb.Append(": ");
                sb.Append(parentsNameList[i]);
                string text = sb.ToString();
                names2[i] = text;
                sb.Clear();
            }
            _ParentsComboBox.Items.AddRange(names2);
            _GrandparentsComboBox.Items.AddRange(names2);
            string none = GameData.NoneBushoID + ": なし";
            _SpouseComboBox.Items.Add(none);
            _MasterComboBox.Items.Add(none);

            int nryuha = _GameData.RyuhaList.Count;
            var ryuhaNames = new string[nryuha];
            for (int i = 0; i < nryuha; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                sb.Append(_GameData.RyuhaList[i].Name);
                ryuhaNames[i] = sb.ToString();
                sb.Clear();
            }
            _RyuhaComboBox.Items.AddRange(ryuhaNames);
            _RyuhaComboBox.Items.Add(GameData.NoneRyuhaID + ": なし");
        }

        /// <summary>
        /// 各コントロールの初期値を設定
        /// </summary>
        private void SetFirstControlValues()
        {
            // 初期値の設定
            ushort parents = _BushoEditList[0].Parents;
            ushort grandparents = _BushoEditList[0].Grandparents;
            ushort spouse = _BushoEditList[0].Spouse;
            ushort master = _BushoEditList[0].Master;
            byte yearOfBirth = _BushoEditList[0].YearOfBirth;
            byte yearOfAdult = _BushoEditList[0].YearOfAdult;
            byte yearOfDeath = _BushoEditList[0].YearOfDeath;
            byte ryuha = _BushoEditList[0].Ryuha;
            byte license = _BushoEditList[0].License;
            byte betrayalFlag = _BushoEditList[0].BetrayalFlag;
            byte previousRelationship = _BushoEditList[0].PreviousRelationship;

            // 他と一致するか確認
            bool notMatchedParents = !_ParentsComboBox.Enabled;
            bool notMatchedGrandparents = !_GrandparentsComboBox.Enabled;
            bool notMatchedSpouse = !_SpouseComboBox.Enabled;
            bool notMatchedMaster = !_MasterComboBox.Enabled;
            bool notMatchedYearOfBirth = !_YearOfBirthTextBox.Enabled;
            bool notMatchedYearOfAdult = !_YearOfAdultTextBox.Enabled;
            bool notMatchedYearOfDeath = !_YearOfDeathTextBox.Enabled;
            bool notMatchedRyuha = !_RyuhaComboBox.Enabled;
            bool notMatchedLicense = !_LicenseComboBox.Enabled;
            bool notMatchedBetrayalFlag = !_BetrayalFlagComboBox.Enabled;
            bool notMatchedPreviousRelationship = !_PreviousRelationshipComboBox.Enabled;
            int nedits = _BushoEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (parents != _BushoEditList[i].Parents)
                    notMatchedParents = true;
                if (grandparents != _BushoEditList[i].Grandparents)
                    notMatchedGrandparents = true;
                if (spouse != _BushoEditList[i].Spouse)
                    notMatchedSpouse = true;
                if (master != _BushoEditList[i].Master)
                    notMatchedMaster = true;
                if (yearOfBirth != _BushoEditList[i].YearOfBirth)
                    notMatchedYearOfBirth = true;
                if (yearOfAdult != _BushoEditList[i].YearOfAdult)
                    notMatchedYearOfAdult = true;
                if (yearOfDeath != _BushoEditList[i].YearOfDeath)
                    notMatchedYearOfDeath = true;
                if (ryuha != _BushoEditList[i].Ryuha)
                    notMatchedRyuha = true;
                if (license != _BushoEditList[i].License)
                    notMatchedLicense = true;
                if (betrayalFlag != _BushoEditList[i].BetrayalFlag)
                    notMatchedBetrayalFlag = true;
                if (previousRelationship != _BushoEditList[i].PreviousRelationship)
                    notMatchedPreviousRelationship = true;
            }
            if (!notMatchedParents)
            {
                _ParentsComboBox.SelectedIndex = parents;
            }
            if (!notMatchedGrandparents)
            {
                _GrandparentsComboBox.SelectedIndex = grandparents;
            }
            if (!notMatchedSpouse)
            {
                if (spouse != GameData.NoneBushoID) _SpouseComboBox.SelectedIndex = spouse;
                else _SpouseComboBox.SelectedIndex = _SpouseComboBox.Items.Count - 1;
            }
            if (!notMatchedMaster)
            {
                if (master != GameData.NoneBushoID) _MasterComboBox.SelectedIndex = master;
                else _MasterComboBox.SelectedIndex = _MasterComboBox.Items.Count - 1;
            }
            if (!notMatchedYearOfBirth)
            {
                _YearOfBirthTextBox.Text = (yearOfBirth + 1460).ToString();
            }
            if (!notMatchedYearOfAdult)
            {
                _YearOfAdultTextBox.Text = (yearOfAdult + 1500).ToString();
            }
            if (!notMatchedYearOfDeath)
            {
                _YearOfDeathTextBox.Text = (yearOfDeath + 1500).ToString();
            }
            if (!notMatchedRyuha)
            {
                if (ryuha != GameData.NoneRyuhaID) _RyuhaComboBox.SelectedIndex = ryuha;
                else _RyuhaComboBox.SelectedIndex = _RyuhaComboBox.Items.Count - 1;
            }
            if (!notMatchedLicense)
            {
                _LicenseComboBox.SelectedIndex = license;
            }
            if (!notMatchedBetrayalFlag)
            {
                _BetrayalFlagComboBox.SelectedIndex = betrayalFlag;
            }
            if (!notMatchedPreviousRelationship)
            {
                _PreviousRelationshipComboBox.SelectedIndex = previousRelationship;
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
            _ParentsComboBox.SelectedIndexChanged += checker;
            _GrandparentsComboBox.SelectedIndexChanged += checker;
            _SpouseComboBox.SelectedIndexChanged += checker;
            _MasterComboBox.SelectedIndexChanged += checker;
            _RyuhaComboBox.SelectedIndexChanged += checker;
            _LicenseComboBox.SelectedIndexChanged += checker;
            _BetrayalFlagComboBox.SelectedIndexChanged += checker;
            _PreviousRelationshipComboBox.SelectedIndexChanged += checker;
            // テキストボックス用のイベントハンドラ
            string[] beforeTexts = new string[controlsArray.Length];
            for (int i = 0; i < controlsArray.Length; ++i)
            {
                beforeTexts[i] = controlsArray[i].Text;
            }
            EventHandler checkerForTextBox = (sender, e) =>
            {
                TextBox tb = (TextBox)sender;
                if (tb.Text == beforeTexts[tb.TabIndex]) return;
                int start = tb.SelectionStart - 1;
                bool badTextFlg = System.Text.RegularExpressions.Regex.IsMatch(tb.Text, @"[^0-9]");
                if (badTextFlg)
                {
                    tb.Text = beforeTexts[tb.TabIndex];
                    tb.SelectionStart = start;
                }
                else
                {
                    beforeTexts[tb.TabIndex] = tb.Text;
                    tb.Tag = true;
                }
            };
            _YearOfBirthTextBox.TextChanged += checkerForTextBox;
            _YearOfAdultTextBox.TextChanged += checkerForTextBox;
            _YearOfDeathTextBox.TextChanged += checkerForTextBox;
        }

        #endregion

    }
}
