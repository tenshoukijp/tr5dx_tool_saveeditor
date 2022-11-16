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
    /// 武将関連の隠し項目を設定するフォーム
    /// </summary>
    public partial class HiddenEditForm : DataEditForm
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
        public HiddenEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public HiddenEditForm(int[] selectedIDs, GameData gameData)
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
        private void HiddenEditForm_Load(object sender, EventArgs e)
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
            ushort face1 = 0;
            ushort face2 = 0;
            byte compatibility = 0;
            byte seiryokuCompatibility = 0;
            byte formation = 0;
            byte luck = 0;
            byte causeOfDeath = 0;
            byte origin = 0;
            byte weaponType = 0;
            byte temper = 0;
            byte spirit = 0;
            byte ism = 0;
            byte behavior = 0;
            byte honor = 0;
            byte ambition = 0;
            byte preference = 0;
            byte desire = 0;
            byte drinking = 0;
            byte occupation = 0;
            byte wifePersonality = 0;

            try
            {
                if ((bool)_Face1TextBox.Tag)
                {
                    face1 = ushort.Parse(_Face1TextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_Face2TextBox.Tag)
                {
                    face2 = ushort.Parse(_Face2TextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_CompatibilityTextBox.Tag)
                {
                    compatibility = byte.Parse(_CompatibilityTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_SeiryokuCompatibilityTextBox.Tag)
                {
                    seiryokuCompatibility = byte.Parse(_SeiryokuCompatibilityTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_FormationComboBox.Tag)
                {
                    formation = (byte)_FormationComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_LuckComboBox.Tag)
                {
                    luck = (byte)_LuckComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_CauseOfDeathComboBox.Tag)
                {
                    causeOfDeath = (byte)_CauseOfDeathComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_OriginComboBox.Tag)
                {
                    origin = (byte)_OriginComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_WeaponTypeComboBox.Tag)
                {
                    weaponType = (byte)_WeaponTypeComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_TemperComboBox.Tag)
                {
                    temper = (byte)_TemperComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SpiritComboBox.Tag)
                {
                    spirit = (byte)_SpiritComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_IsmComboBox.Tag)
                {
                    ism = (byte)_IsmComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_BehaviorComboBox.Tag)
                {
                    behavior = (byte)_BehaviorComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_HonorComboBox.Tag)
                {
                    honor = (byte)_HonorComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_AmbitionTextBox.Tag)
                {
                    ambition = byte.Parse(_AmbitionTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_PreferenceComboBox.Tag)
                {
                    preference = (byte)_PreferenceComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_DesireComboBox.Tag)
                {
                    desire = (byte)_DesireComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_DrinkingComboBox.Tag)
                {
                    drinking = (byte)_DrinkingComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_OccupationComboBox.Tag)
                {
                    occupation = (byte)_OccupationComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_WifePersonalityComboBox.Tag)
                {
                    wifePersonality = (byte)_WifePersonalityComboBox.SelectedIndex;
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
                if ((bool)_Face1TextBox.Tag)
                {
                    _BushoEditList[i].Face1 = face1;
                }
                if ((bool)_Face2TextBox.Tag)
                {
                    _BushoEditList[i].Face2 = face2;
                }
                if ((bool)_CompatibilityTextBox.Tag)
                {
                    _BushoEditList[i].Compatibility = compatibility;
                }
                if ((bool)_SeiryokuCompatibilityTextBox.Tag)
                {
                    _BushoEditList[i].SeiryokuCompatibility = seiryokuCompatibility;
                }
                if ((bool)_FormationComboBox.Tag)
                {
                    _BushoEditList[i].Formation = formation;
                }
                if ((bool)_LuckComboBox.Tag)
                {
                    _BushoEditList[i].Luck = luck;
                }
                if ((bool)_CauseOfDeathComboBox.Tag)
                {
                    _BushoEditList[i].CauseOfDeath = causeOfDeath;
                }
                if ((bool)_OriginComboBox.Tag)
                {
                    _BushoEditList[i].Origin = origin;
                }
                if ((bool)_WeaponTypeComboBox.Tag)
                {
                    _BushoEditList[i].WeaponType = weaponType;
                }
                if ((bool)_TemperComboBox.Tag)
                {
                    _BushoEditList[i].Temper = temper;
                }
                if ((bool)_SpiritComboBox.Tag)
                {
                    _BushoEditList[i].Spirit = spirit;
                }
                if ((bool)_IsmComboBox.Tag)
                {
                    _BushoEditList[i].Ism = ism;
                }
                if ((bool)_BehaviorComboBox.Tag)
                {
                    _BushoEditList[i].Behavior = behavior;
                }
                if ((bool)_HonorComboBox.Tag)
                {
                    _BushoEditList[i].Honor = honor;
                }
                if ((bool)_AmbitionTextBox.Tag)
                {
                    _BushoEditList[i].Ambition = ambition;
                }
                if ((bool)_PreferenceComboBox.Tag)
                {
                    _BushoEditList[i].Preference = preference;
                }
                if ((bool)_DesireComboBox.Tag)
                {
                    _BushoEditList[i].Desire = desire;
                }
                if ((bool)_DrinkingComboBox.Tag)
                {
                    _BushoEditList[i].Drinking = drinking;
                }
                if ((bool)_OccupationComboBox.Tag)
                {
                    _BushoEditList[i].Occupation = occupation;
                }
                if ((bool)_WifePersonalityComboBox.Tag)
                {
                    _BushoEditList[i].WifePersonality = wifePersonality;
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
            if (_EditMode >= PeopleCategory.EventPerson)
            {
                _CompatibilityTextBox.Enabled = false;
                _SeiryokuCompatibilityTextBox.Enabled = false;
                _FormationComboBox.Enabled = false;
                _LuckComboBox.Enabled = false;
                _CauseOfDeathComboBox.Enabled = false;
                _OriginComboBox.Enabled = false;
                _WeaponTypeComboBox.Enabled = false;
                _TemperComboBox.Enabled = false;
                _SpiritComboBox.Enabled = false;
                _IsmComboBox.Enabled = false;
                _BehaviorComboBox.Enabled = false;
                _HonorComboBox.Enabled = false;
                _AmbitionTextBox.Enabled = false;
                _PreferenceComboBox.Enabled = false;
                _DesireComboBox.Enabled = false;
                _DrinkingComboBox.Enabled = false;
                _OccupationComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// 各コントロールの初期値を設定
        /// </summary>
        private void SetFirstControlValues()
        {
            // 初期値の設定
            ushort face1 = _BushoEditList[0].Face1;
            ushort face2 = _BushoEditList[0].Face2;
            byte compatibility = _BushoEditList[0].Compatibility;
            byte seiryokuCompatibility = _BushoEditList[0].SeiryokuCompatibility;
            byte formation = _BushoEditList[0].Formation;
            byte luck = _BushoEditList[0].Luck;
            byte causeOfDeath = _BushoEditList[0].CauseOfDeath;
            byte origin = _BushoEditList[0].Origin;
            byte weaponType = _BushoEditList[0].WeaponType;
            byte temper = _BushoEditList[0].Temper;
            byte spirit = _BushoEditList[0].Spirit;
            byte ism = _BushoEditList[0].Ism;
            byte behavior = _BushoEditList[0].Behavior;
            byte honor = _BushoEditList[0].Honor;
            byte ambition = _BushoEditList[0].Ambition;
            byte preference = _BushoEditList[0].Preference;
            byte desire = _BushoEditList[0].Desire;
            byte drinking = _BushoEditList[0].Drinking;
            byte occupation = _BushoEditList[0].Occupation;
            byte wifePersonality = _BushoEditList[0].WifePersonality;

            // 他と一致するか確認
            bool notMatchedFace1 = !_Face1TextBox.Enabled;
            bool notMatchedFace2 = !_Face2TextBox.Enabled;
            bool notMatchedCompatibility = !_CompatibilityTextBox.Enabled;
            bool notMatchedSeiryokuCompatibility = !_SeiryokuCompatibilityTextBox.Enabled;
            bool notMatchedFormation = !_FormationComboBox.Enabled;
            bool notMatchedLuck = !_LuckComboBox.Enabled;
            bool notMatchedCauseOfDeath = !_CauseOfDeathComboBox.Enabled;
            bool notMatchedOrigin = !_OriginComboBox.Enabled;
            bool notMatchedWeaponType = !_WeaponTypeComboBox.Enabled;
            bool notMatchedTemper = !_TemperComboBox.Enabled;
            bool notMatchedSpirit = !_SpiritComboBox.Enabled;
            bool notMatchedIsm = !_IsmComboBox.Enabled;
            bool notMatchedBehavior = !_BehaviorComboBox.Enabled;
            bool notMatchedHonor = !_HonorComboBox.Enabled;
            bool notMatchedAmbition = !_AmbitionTextBox.Enabled;
            bool notMatchedPreference = !_PreferenceComboBox.Enabled;
            bool notMatchedDesire = !_DesireComboBox.Enabled;
            bool notMatchedDrinking = !_DrinkingComboBox.Enabled;
            bool notMatchedOccupation = !_OccupationComboBox.Enabled;
            bool notMatchedWifePersonality = !_WifePersonalityComboBox.Enabled;
            int nedits = _BushoEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (face1 != _BushoEditList[i].Face1)
                    notMatchedFace1 = true;
                if (face2 != _BushoEditList[i].Face2)
                    notMatchedFace2 = true;
                if (compatibility != _BushoEditList[i].Compatibility)
                    notMatchedCompatibility = true;
                if (seiryokuCompatibility != _BushoEditList[i].SeiryokuCompatibility)
                    notMatchedSeiryokuCompatibility = true;
                if (formation != _BushoEditList[i].Formation)
                    notMatchedFormation = true;
                if (luck != _BushoEditList[i].Luck)
                    notMatchedLuck = true;
                if (causeOfDeath != _BushoEditList[i].CauseOfDeath)
                    notMatchedCauseOfDeath = true;
                if (origin != _BushoEditList[i].Origin)
                    notMatchedOrigin = true;
                if (weaponType != _BushoEditList[i].WeaponType)
                    notMatchedWeaponType = true;
                if (temper != _BushoEditList[i].Temper)
                    notMatchedTemper = true;
                if (spirit != _BushoEditList[i].Spirit)
                    notMatchedSpirit = true;
                if (ism != _BushoEditList[i].Ism)
                    notMatchedIsm = true;
                if (behavior != _BushoEditList[i].Behavior)
                    notMatchedBehavior = true;
                if (honor != _BushoEditList[i].Honor)
                    notMatchedHonor = true;
                if (ambition != _BushoEditList[i].Ambition)
                    notMatchedAmbition = true;
                if (preference != _BushoEditList[i].Preference)
                    notMatchedPreference = true;
                if (desire != _BushoEditList[i].Desire)
                    notMatchedDesire = true;
                if (drinking != _BushoEditList[i].Drinking)
                    notMatchedDrinking = true;
                if (occupation != _BushoEditList[i].Occupation)
                    notMatchedOccupation = true;
                if (wifePersonality != _BushoEditList[i].WifePersonality)
                    notMatchedWifePersonality = true;
            }
            if (!notMatchedFace1)
            {
                _Face1TextBox.Text = face1.ToString();
            }
            if (!notMatchedFace2)
            {
                _Face2TextBox.Text = face2.ToString();
            }
            if (!notMatchedCompatibility)
            {
                _CompatibilityTextBox.Text = compatibility.ToString();
            }
            if (!notMatchedSeiryokuCompatibility)
            {
                _SeiryokuCompatibilityTextBox.Text = seiryokuCompatibility.ToString();
            }
            if (!notMatchedFormation)
            {
                _FormationComboBox.SelectedIndex = formation;
            }
            if (!notMatchedLuck)
            {
                _LuckComboBox.SelectedIndex = luck;
            }
            if (!notMatchedCauseOfDeath)
            {
                _CauseOfDeathComboBox.SelectedIndex = causeOfDeath;
            }
            if (!notMatchedOrigin)
            {
                _OriginComboBox.SelectedIndex = origin;
            }
            if (!notMatchedWeaponType)
            {
                _WeaponTypeComboBox.SelectedIndex = weaponType;
            }
            if (!notMatchedTemper)
            {
                _TemperComboBox.SelectedIndex = temper;
            }
            if (!notMatchedSpirit)
            {
                _SpiritComboBox.SelectedIndex = spirit;
            }
            if (!notMatchedIsm)
            {
                _IsmComboBox.SelectedIndex = ism;
            }
            if (!notMatchedBehavior)
            {
                _BehaviorComboBox.SelectedIndex = behavior;
            }
            if (!notMatchedHonor)
            {
                _HonorComboBox.SelectedIndex = honor;
            }
            if (!notMatchedAmbition)
            {
                _AmbitionTextBox.Text = ambition.ToString();
            }
            if (!notMatchedPreference)
            {
                _PreferenceComboBox.SelectedIndex = preference;
            }
            if (!notMatchedDesire)
            {
                _DesireComboBox.SelectedIndex = desire;
            }
            if (!notMatchedDrinking)
            {
                _DrinkingComboBox.SelectedIndex = drinking;
            }
            if (!notMatchedOccupation)
            {
                _OccupationComboBox.SelectedIndex = occupation;
            }
            if (!notMatchedWifePersonality)
            {
                _WifePersonalityComboBox.SelectedIndex = wifePersonality;
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
            _FormationComboBox.SelectedIndexChanged += checker;
            _LuckComboBox.SelectedIndexChanged += checker;
            _CauseOfDeathComboBox.SelectedIndexChanged += checker;
            _OriginComboBox.SelectedIndexChanged += checker;
            _WeaponTypeComboBox.SelectedIndexChanged += checker;
            _TemperComboBox.SelectedIndexChanged += checker;
            _SpiritComboBox.SelectedIndexChanged += checker;
            _IsmComboBox.SelectedIndexChanged += checker;
            _BehaviorComboBox.SelectedIndexChanged += checker;
            _HonorComboBox.SelectedIndexChanged += checker;
            _PreferenceComboBox.SelectedIndexChanged += checker;
            _DesireComboBox.SelectedIndexChanged += checker;
            _DrinkingComboBox.SelectedIndexChanged += checker;
            _OccupationComboBox.SelectedIndexChanged += checker;
            _WifePersonalityComboBox.SelectedIndexChanged += checker;
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
            _Face1TextBox.TextChanged += checkerForTextBox;
            _Face2TextBox.TextChanged += checkerForTextBox;
            _CompatibilityTextBox.TextChanged += checkerForTextBox;
            _SeiryokuCompatibilityTextBox.TextChanged += checkerForTextBox;
            _AmbitionTextBox.TextChanged += checkerForTextBox;
        }

        #endregion

    }
}
