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
using Microsoft.International.Converters;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.DataEditForms.BushoEdit
{
    /// <summary>
    /// 武将関連の基本事項を設定するフォーム
    /// </summary>
    public partial class BasicEditForm : DataEditForm
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
        public BasicEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public BasicEditForm(int[] selectedIDs, GameData gameData)
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
        private void BasicEditForm_Load(object sender, EventArgs e)
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
        /// カードチェックリストのコンテキストメニューで「全チェック」をクリックした際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _CardContextMenu_All_Click(object sender, EventArgs e)
        {
            var contextMenu = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            // 秘技
            if (contextMenu.SourceControl == _HigiCardCheckedListBox)
            {
                int n = _HigiCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _HigiCardCheckedListBox.SetItemChecked(i, true);
                    ((bool[])_HigiCardCheckedListBox.Tag)[i] = true;
                }
            }
            // 称号
            else if (contextMenu.SourceControl == _ShogoCardCheckedListBox)
            {
                int n = _ShogoCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _ShogoCardCheckedListBox.SetItemChecked(i, true);
                    ((bool[])_ShogoCardCheckedListBox.Tag)[i] = true;
                }
            }
            // 合戦
            else if (contextMenu.SourceControl == _KassenCardCheckedListBox)
            {
                int n = _KassenCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _KassenCardCheckedListBox.SetItemChecked(i, true);
                    ((bool[])_KassenCardCheckedListBox.Tag)[i] = true;
                }
            }
        }

        /// <summary>
        /// カードチェックリストのコンテキストメニューで「全解除」をクリックした際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _CardContextMenu_Clear_Click(object sender, EventArgs e)
        {
            var contextMenu = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            // 秘技
            if (contextMenu.SourceControl == _HigiCardCheckedListBox)
            {
                int n = _HigiCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _HigiCardCheckedListBox.SetItemChecked(i, false);
                    ((bool[])_HigiCardCheckedListBox.Tag)[i] = true;
                }
            }
            // 称号
            else if (contextMenu.SourceControl == _ShogoCardCheckedListBox)
            {
                int n = _ShogoCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _ShogoCardCheckedListBox.SetItemChecked(i, false);
                    ((bool[])_ShogoCardCheckedListBox.Tag)[i] = true;
                }
            }
            // 合戦
            else if (contextMenu.SourceControl == _KassenCardCheckedListBox)
            {
                int n = _KassenCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _KassenCardCheckedListBox.SetItemChecked(i, false);
                    ((bool[])_KassenCardCheckedListBox.Tag)[i] = true;
                }
            }
        }

        /// <summary>
        /// 称号カードチェックリストのコンテキストメニューで「悪名称号以外チェック」をクリックした際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _ShogoCardContextMenu_WithoutBadShogo_Click(object sender, EventArgs e)
        {
            int n = _ShogoCardCheckedListBox.Items.Count;
            for (int i = 0; i < n; ++i)
            {
                if (53 >= i  && i >= 48)
                    _ShogoCardCheckedListBox.SetItemChecked(i, false);
                else
                    _ShogoCardCheckedListBox.SetItemChecked(i, true);
                ((bool[])_ShogoCardCheckedListBox.Tag)[i] = true;
            }
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _OKButton_Click(object sender, EventArgs e)
        {
            bool isDataEdited = false;

            // 名前の前処理を行い入力ミスをなるべく解消する
            Func<string, string> halfToFull = (str) =>
            {
                string result = KanaConverter.HalfwidthKatakanaToKatakana(str);
                result = Regex.Replace(result, "[0-9]", p => ((char)(p.Value[0] - '0' + '０')).ToString());
                result = Regex.Replace(result, "[a-z]", p => ((char)(p.Value[0] - 'a' + 'ａ')).ToString());
                result = Regex.Replace(result, "[A-Z]", p => ((char)(p.Value[0] - 'A' + 'Ａ')).ToString());
                return result;
            };
            Func<string, string> fullToHalf = (str) =>
            {
                string result = KanaConverter.HiraganaToHalfwidthKatakana(str);
                result = KanaConverter.KatakanaToHalfwidthKatakana(result);
                return result;
            };
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            // UIから入力内容を読み取る
            string familyName = "";
            string givenName = "";
            string kanaOfFamilyName = "";
            string kanaOfGivenName = "";
            byte sex = 0;
            byte kani = 0;
            byte closeness = 0;
            byte fame = 0;
            byte notorious = 0;
            byte leadership = 0;
            byte combatPower = 0;
            byte politics = 0;
            byte intellect = 0;
            byte charm = 0;
            byte skillInfantry = 0;
            byte skillCavalry = 0;
            byte skillGun = 0;
            byte skillNavy = 0;
            byte skillArchery = 0;
            byte skillMartialArts = 0;
            byte skillTactics = 0;
            byte skillNinjutsu = 0;
            byte skillBuilding = 0;
            byte skillAgriculture = 0;
            byte skillMine = 0;
            byte skillMath = 0;
            byte skillCourtesy = 0;
            byte skillSpeech = 0;
            byte skillTeaCeremony = 0;
            byte skillMedical = 0;

            try
            {
                if ((bool)_FamilyNameTextBox.Tag)
                {
                    familyName = halfToFull(_FamilyNameTextBox.Text);
                    byte[] bytes = sjisEnc.GetBytes(familyName);
                    if (bytes.Length > 8)
                        throw new Exception();
                    isDataEdited = true;
                }
                if ((bool)_GivenNameTextBox.Tag)
                {
                    givenName = halfToFull(_GivenNameTextBox.Text);
                    byte[] bytes = sjisEnc.GetBytes(givenName);
                    if (bytes.Length > 8)
                        throw new Exception();
                    isDataEdited = true;
                }
                if ((bool)_KanaOfFamilyNameTextBox.Tag)
                {
                    kanaOfFamilyName = fullToHalf(_KanaOfFamilyNameTextBox.Text);
                    byte[] bytes = sjisEnc.GetBytes(kanaOfFamilyName);
                    if (bytes.Length > 9)
                        throw new Exception();
                    isDataEdited = true;
                }
                if ((bool)_KanaOfGivenNameTextBox.Tag)
                {
                    kanaOfGivenName = fullToHalf(_KanaOfGivenNameTextBox.Text);
                    byte[] bytes = sjisEnc.GetBytes(kanaOfGivenName);
                    if (bytes.Length > 9)
                        throw new Exception();
                    isDataEdited = true;
                }
                if ((bool)_SexComboBox.Tag)
                {
                    sex = (byte)_SexComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_KaniComboBox.Tag)
                {
                    kani = byte.Parse(_KaniComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_ClosenessTextBox.Tag)
                {
                    closeness = byte.Parse(_ClosenessTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_FameTextBox.Tag)
                {
                    fame = byte.Parse(_FameTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_NotoriousTextBox.Tag)
                {
                    notorious = byte.Parse(_NotoriousTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_LeadershipTextBox.Tag)
                {
                    leadership = byte.Parse(_LeadershipTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_CombatPowerTextBox.Tag)
                {
                    combatPower = byte.Parse(_CombatPowerTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_PoliticsTextBox.Tag)
                {
                    politics = byte.Parse(_PoliticsTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_IntellectTextBox.Tag)
                {
                    intellect = byte.Parse(_IntellectTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_CharmTextBox.Tag)
                {
                    charm = byte.Parse(_CharmTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_SkillInfantryComboBox.Tag)
                {
                    skillInfantry = (byte)_SkillInfantryComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillCavalryComboBox.Tag)
                {
                    skillCavalry = (byte)_SkillCavalryComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillGunComboBox.Tag)
                {
                    skillGun = (byte)_SkillGunComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillNavyComboBox.Tag)
                {
                    skillNavy = (byte)_SkillNavyComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillArcheryComboBox.Tag)
                {
                    skillArchery = (byte)_SkillArcheryComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillMartialArtsComboBox.Tag)
                {
                    skillMartialArts = (byte)_SkillMartialArtsComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillTacticsComboBox.Tag)
                {
                    skillTactics = (byte)_SkillTacticsComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillNinjutsuComboBox.Tag)
                {
                    skillNinjutsu = (byte)_SkillNinjutsuComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillBuildingComboBox.Tag)
                {
                    skillBuilding = (byte)_SkillBuildingComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillAgricultureComboBox.Tag)
                {
                    skillAgriculture = (byte)_SkillAgricultureComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillMineComboBox.Tag)
                {
                    skillMine = (byte)_SkillMineComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillMathComboBox.Tag)
                {
                    skillMath = (byte)_SkillMathComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillCourtesyComboBox.Tag)
                {
                    skillCourtesy = (byte)_SkillCourtesyComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillSpeechComboBox.Tag)
                {
                    skillSpeech = (byte)_SkillSpeechComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillTeaCeremonyComboBox.Tag)
                {
                    skillTeaCeremony = (byte)_SkillTeaCeremonyComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SkillMedicalComboBox.Tag)
                {
                    skillMedical = (byte)_SkillMedicalComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if (((bool[])_HigiCardCheckedListBox.Tag).Contains(true))
                {
                    isDataEdited = true;
                }
                if (((bool[])_ShogoCardCheckedListBox.Tag).Contains(true))
                {
                    isDataEdited = true;
                }
                if (((bool[])_KassenCardCheckedListBox.Tag).Contains(true))
                {
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
                if ((bool)_FamilyNameTextBox.Tag)
                {
                    _BushoEditList[i].FamilyName = familyName;
                }
                if ((bool)_GivenNameTextBox.Tag)
                {
                    _BushoEditList[i].GivenName = givenName;
                }
                if ((bool)_KanaOfFamilyNameTextBox.Tag)
                {
                    _BushoEditList[i].KanaOfFamilyName = kanaOfFamilyName;
                }
                if ((bool)_KanaOfGivenNameTextBox.Tag)
                {
                    _BushoEditList[i].KanaOfGivenName = kanaOfGivenName;
                }
                if ((bool)_SexComboBox.Tag)
                {
                    _BushoEditList[i].Sex = sex;
                }
                if ((bool)_KaniComboBox.Tag)
                {
                    _BushoEditList[i].Kani = kani;
                }
                if ((bool)_ClosenessTextBox.Tag)
                {
                    _BushoEditList[i].Closeness = closeness;
                }
                if ((bool)_FameTextBox.Tag)
                {
                    _BushoEditList[i].Fame = fame;
                }
                if ((bool)_NotoriousTextBox.Tag)
                {
                    _BushoEditList[i].Notorious = notorious;
                }
                if ((bool)_LeadershipTextBox.Tag)
                {
                    _BushoEditList[i].Leadership = leadership;
                }
                if ((bool)_CombatPowerTextBox.Tag)
                {
                    _BushoEditList[i].CombatPower = combatPower;
                }
                if ((bool)_PoliticsTextBox.Tag)
                {
                    _BushoEditList[i].Politics = politics;
                }
                if ((bool)_IntellectTextBox.Tag)
                {
                    _BushoEditList[i].Intellect = intellect;
                }
                if ((bool)_CharmTextBox.Tag)
                {
                    _BushoEditList[i].Charm = charm;
                }
                if ((bool)_SkillInfantryComboBox.Tag)
                {
                    _BushoEditList[i].SkillInfantry = skillInfantry;
                }
                if ((bool)_SkillCavalryComboBox.Tag)
                {
                    _BushoEditList[i].SkillCavalry = skillCavalry;
                }
                if ((bool)_SkillGunComboBox.Tag)
                {
                    _BushoEditList[i].SkillGun = skillGun;
                }
                if ((bool)_SkillNavyComboBox.Tag)
                {
                    _BushoEditList[i].SkillNavy = skillNavy;
                }
                if ((bool)_SkillArcheryComboBox.Tag)
                {
                    _BushoEditList[i].SkillArchery = skillArchery;
                }
                if ((bool)_SkillMartialArtsComboBox.Tag)
                {
                    _BushoEditList[i].SkillMartialArts = skillMartialArts;
                }
                if ((bool)_SkillTacticsComboBox.Tag)
                {
                    _BushoEditList[i].SkillTactics = skillTactics;
                }
                if ((bool)_SkillNinjutsuComboBox.Tag)
                {
                    _BushoEditList[i].SkillNinjutsu = skillNinjutsu;
                }
                if ((bool)_SkillBuildingComboBox.Tag)
                {
                    _BushoEditList[i].SkillBuilding = skillBuilding;
                }
                if ((bool)_SkillAgricultureComboBox.Tag)
                {
                    _BushoEditList[i].SkillAgriculture = skillAgriculture;
                }
                if ((bool)_SkillMineComboBox.Tag)
                {
                    _BushoEditList[i].SkillMine = skillMine;
                }
                if ((bool)_SkillMathComboBox.Tag)
                {
                    _BushoEditList[i].SkillMath = skillMath;
                }
                if ((bool)_SkillCourtesyComboBox.Tag)
                {
                    _BushoEditList[i].SkillCourtesy = skillCourtesy;
                }
                if ((bool)_SkillSpeechComboBox.Tag)
                {
                    _BushoEditList[i].SkillSpeech = skillSpeech;
                }
                if ((bool)_SkillTeaCeremonyComboBox.Tag)
                {
                    _BushoEditList[i].SkillTeaCeremony = skillTeaCeremony;
                }
                if ((bool)_SkillMedicalComboBox.Tag)
                {
                    _BushoEditList[i].SkillMedical = skillMedical;
                }
                if (_HigiCardCheckedListBox.Enabled)
                {
                    bool[] updated = (bool[])_HigiCardCheckedListBox.Tag;
                    int ncards = _HigiCardCheckedListBox.Items.Count;
                    for (int j = 0; j < ncards; ++j)
                    {
                        if (!updated[j])
                            continue;
                        int index = j / 8;
                        int bit = j % 8;
                        byte mask = (byte)(0xFF ^ (0x01 << bit));
                        byte maskedData = (byte)(_BushoEditList[i].HigiCardFlags[index] & mask);
                        _BushoEditList[i].HigiCardFlags[index] = (byte)(maskedData | ((_HigiCardCheckedListBox.GetItemChecked(j) ? 1 : 0) << bit));
                    }
                }
                if (_ShogoCardCheckedListBox.Enabled)
                {
                    bool[] updated = (bool[])_ShogoCardCheckedListBox.Tag;
                    int ncards = _ShogoCardCheckedListBox.Items.Count;
                    for (int j = 0; j < ncards; ++j)
                    {
                        if (!updated[j])
                            continue;
                        int index = j / 8;
                        int bit = j % 8;
                        byte mask = (byte)(0xFF ^ (0x01 << bit));
                        byte maskedData = (byte)(_BushoEditList[i].ShogoCardFlags[index] & mask);
                        _BushoEditList[i].ShogoCardFlags[index] = (byte)(maskedData | ((_ShogoCardCheckedListBox.GetItemChecked(j) ? 1 : 0) << bit));
                    }
                }
                if (_KassenCardCheckedListBox.Enabled)
                {
                    bool[] updated = (bool[])_KassenCardCheckedListBox.Tag;
                    int ncards = _KassenCardCheckedListBox.Items.Count;
                    for (int j = 0; j < ncards; ++j)
                    {
                        if (!updated[j])
                            continue;
                        int index = j / 8;
                        int bit = j % 8;
                        byte mask = (byte)(0xFF ^ (0x01 << bit));
                        byte maskedData = (byte)(_BushoEditList[i].KassenCardFlags[index] & mask);
                        _BushoEditList[i].KassenCardFlags[index] = (byte)(maskedData | ((_KassenCardCheckedListBox.GetItemChecked(j) ? 1 : 0) << bit));
                    }
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
                _KanaOfFamilyNameTextBox.Enabled = false;
                _KanaOfGivenNameTextBox.Enabled = false;
                _ClosenessTextBox.Enabled = false;
                _SkillInfantryComboBox.Enabled = false;
                _SkillCavalryComboBox.Enabled = false;
                _SkillGunComboBox.Enabled = false;
                _SkillNavyComboBox.Enabled = false;
                _SkillArcheryComboBox.Enabled = false;
                _SkillMartialArtsComboBox.Enabled = false;
                _SkillTacticsComboBox.Enabled = false;
                _SkillNinjutsuComboBox.Enabled = false;
                _SkillBuildingComboBox.Enabled = false;
                _SkillAgricultureComboBox.Enabled = false;
                _SkillMineComboBox.Enabled = false;
                _SkillMathComboBox.Enabled = false;
                _SkillCourtesyComboBox.Enabled = false;
                _SkillSpeechComboBox.Enabled = false;
                _SkillTeaCeremonyComboBox.Enabled = false;
                _SkillMedicalComboBox.Enabled = false;
            }
            if (_EditMode >= PeopleCategory.EventPerson)
            {
                _FameTextBox.Enabled = false;
                _NotoriousTextBox.Enabled = false;
                _LeadershipTextBox.Enabled = false;
                _CombatPowerTextBox.Enabled = false;
                _PoliticsTextBox.Enabled = false;
                _IntellectTextBox.Enabled = false;
                _CharmTextBox.Enabled = false;
                _HigiCardCheckedListBox.Enabled = false;
                _ShogoCardCheckedListBox.Enabled = false;
                _KassenCardCheckedListBox.Enabled = false;
            }
            if (_EditMode >= PeopleCategory.GeneralPurpose)
            {
                _KaniComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// コンボボックスとチェックリストの初期化
        /// </summary>
        private void InitComboBoxAndCheckLists()
        {
            // コンボボックスの作成
            StringBuilder sb = new StringBuilder();
            var kaniList = _GameData.NameListDictionary["Kan-i"];
            int nkani = kaniList.Count;
            var kaniNames = new string[nkani];
            for (int i = 0; i < nkani; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                sb.Append(kaniList[i]);
                kaniNames[i] = sb.ToString();
                sb.Clear();
            }
            _KaniComboBox.Items.AddRange(kaniNames);
            _KaniComboBox.Items.Add(GameData.NoneKaniID + ": なし");

            // 秘技カードの設定
            var higiCardList = _GameData.NameListDictionary["HigiCard"];
            _HigiCardCheckedListBox.Items.AddRange(higiCardList.ToArray());
            _HigiCardCheckedListBox.Tag = new bool[higiCardList.Count];
            // 称号カードの設定
            var shogoCardList = _GameData.NameListDictionary["ShogoCard"];
            _ShogoCardCheckedListBox.Items.AddRange(shogoCardList.ToArray());
            _ShogoCardCheckedListBox.Tag = new bool[shogoCardList.Count];
            // 合戦カードの設定
            var kassenCardList = _GameData.NameListDictionary["KassenCard"];
            _KassenCardCheckedListBox.Items.AddRange(kassenCardList.ToArray());
            _KassenCardCheckedListBox.Tag = new bool[kassenCardList.Count];
        }

        /// <summary>
        /// 各コントロールの初期値を設定
        /// </summary>
        private void SetFirstControlValues()
        {
            // 初期値の設定
            string familyName = _BushoEditList[0].FamilyName;
            string givenName = _BushoEditList[0].GivenName;
            string kanaOfFamilyName = _BushoEditList[0].KanaOfFamilyName;
            string kanaOfGivenName = _BushoEditList[0].KanaOfGivenName;
            byte sex = _BushoEditList[0].Sex;
            byte kani = _BushoEditList[0].Kani;
            byte closeness = _BushoEditList[0].Closeness;
            byte fame = _BushoEditList[0].Fame;
            byte notorious = _BushoEditList[0].Notorious;
            byte leadership = _BushoEditList[0].Leadership;
            byte combatPower = _BushoEditList[0].CombatPower;
            byte politics = _BushoEditList[0].Politics;
            byte intellect = _BushoEditList[0].Intellect;
            byte charm = _BushoEditList[0].Charm;
            byte skillInfantry = _BushoEditList[0].SkillInfantry;
            byte skillCavalry = _BushoEditList[0].SkillCavalry;
            byte skillGun = _BushoEditList[0].SkillGun;
            byte skillNavy = _BushoEditList[0].SkillNavy;
            byte skillArchery = _BushoEditList[0].SkillArchery;
            byte skillMartialArts = _BushoEditList[0].SkillMartialArts;
            byte skillTactics = _BushoEditList[0].SkillTactics;
            byte skillNinjutsu = _BushoEditList[0].SkillNinjutsu;
            byte skillBuilding = _BushoEditList[0].SkillBuilding;
            byte skillAgriculture = _BushoEditList[0].SkillAgriculture;
            byte skillMine = _BushoEditList[0].SkillMine;
            byte skillMath = _BushoEditList[0].SkillMath;
            byte skillCourtesy = _BushoEditList[0].SkillCourtesy;
            byte skillSpeech = _BushoEditList[0].SkillSpeech;
            byte skillTeaCeremony = _BushoEditList[0].SkillTeaCeremony;
            byte skillMedical = _BushoEditList[0].SkillMedical;
            byte[] higiCardFlags = null;
            if (_HigiCardCheckedListBox.Enabled)
                higiCardFlags = (byte[])_BushoEditList[0].HigiCardFlags.Clone();
            byte[] shogoCardFlags = null;
            if (_ShogoCardCheckedListBox.Enabled)
                shogoCardFlags = (byte[])_BushoEditList[0].ShogoCardFlags.Clone();
            byte[] kassenCardFlags = null;
            if (_KassenCardCheckedListBox.Enabled)
                kassenCardFlags = (byte[])_BushoEditList[0].KassenCardFlags.Clone();

            // 他と一致するか確認
            bool notMatchedFamilyName = !_FamilyNameTextBox.Enabled;
            bool notMatchedGivenName = !_GivenNameTextBox.Enabled;
            bool notMatchedKanaOfFamilyName = !_KanaOfFamilyNameTextBox.Enabled;
            bool notMatchedKanaOfGivenName = !_KanaOfGivenNameTextBox.Enabled;
            bool notMatchedSex = !_SexComboBox.Enabled;
            bool notMatchedKani = !_KaniComboBox.Enabled;
            bool notMatchedCloseness = !_ClosenessTextBox.Enabled;
            bool notMatchedFame = !_FameTextBox.Enabled;
            bool notMatchedNotorious = !_NotoriousTextBox.Enabled;
            bool notMatchedLeadership = !_LeadershipTextBox.Enabled;
            bool notMatchedCombatPower = !_CombatPowerTextBox.Enabled;
            bool notMatchedPolitics = !_PoliticsTextBox.Enabled;
            bool notMatchedIntellect = !_IntellectTextBox.Enabled;
            bool notMatchedCharm = !_CharmTextBox.Enabled;
            bool notMatchedSkillInfantry = !_SkillInfantryComboBox.Enabled;
            bool notMatchedSkillCavalry = !_SkillCavalryComboBox.Enabled;
            bool notMatchedSkillGun = !_SkillGunComboBox.Enabled;
            bool notMatchedSkillNavy = !_SkillNavyComboBox.Enabled;
            bool notMatchedSkillArchery = !_SkillArcheryComboBox.Enabled;
            bool notMatchedSkillMartialArts = !_SkillMartialArtsComboBox.Enabled;
            bool notMatchedSkillTactics = !_SkillTacticsComboBox.Enabled;
            bool notMatchedSkillNinjutsu = !_SkillNinjutsuComboBox.Enabled;
            bool notMatchedSkillBuilding = !_SkillBuildingComboBox.Enabled;
            bool notMatchedSkillAgriculture = !_SkillAgricultureComboBox.Enabled;
            bool notMatchedSkillMine = !_SkillMineComboBox.Enabled;
            bool notMatchedSkillMath = !_SkillMathComboBox.Enabled;
            bool notMatchedSkillCourtesy = !_SkillCourtesyComboBox.Enabled;
            bool notMatchedSkillSpeech = !_SkillSpeechComboBox.Enabled;
            bool notMatchedSkillTeaCeremony = !_SkillTeaCeremonyComboBox.Enabled;
            bool notMatchedSkillMedical = !_SkillMedicalComboBox.Enabled;
            int nedits = _BushoEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (familyName != _BushoEditList[i].FamilyName)
                    notMatchedFamilyName = true;
                if (givenName != _BushoEditList[i].GivenName)
                    notMatchedGivenName = true;
                if (kanaOfFamilyName != _BushoEditList[i].KanaOfFamilyName)
                    notMatchedKanaOfFamilyName = true;
                if (kanaOfGivenName != _BushoEditList[i].KanaOfGivenName)
                    notMatchedKanaOfGivenName = true;
                if (sex != _BushoEditList[i].Sex)
                    notMatchedSex = true;
                if (kani != _BushoEditList[i].Kani)
                    notMatchedKani = true;
                if (closeness != _BushoEditList[i].Closeness)
                    notMatchedCloseness = true;
                if (fame != _BushoEditList[i].Fame)
                    notMatchedFame = true;
                if (notorious != _BushoEditList[i].Notorious)
                    notMatchedNotorious = true;
                if (leadership != _BushoEditList[i].Leadership)
                    notMatchedLeadership = true;
                if (combatPower != _BushoEditList[i].CombatPower)
                    notMatchedCombatPower = true;
                if (politics != _BushoEditList[i].Politics)
                    notMatchedPolitics = true;
                if (intellect != _BushoEditList[i].Intellect)
                    notMatchedIntellect = true;
                if (charm != _BushoEditList[i].Charm)
                    notMatchedCharm = true;
                if (skillInfantry != _BushoEditList[i].SkillInfantry)
                    notMatchedSkillInfantry = true;
                if (skillCavalry != _BushoEditList[i].SkillCavalry)
                    notMatchedSkillCavalry = true;
                if (skillGun != _BushoEditList[i].SkillGun)
                    notMatchedSkillGun = true;
                if (skillNavy != _BushoEditList[i].SkillNavy)
                    notMatchedSkillNavy = true;
                if (skillArchery != _BushoEditList[i].SkillArchery)
                    notMatchedSkillArchery = true;
                if (skillMartialArts != _BushoEditList[i].SkillMartialArts)
                    notMatchedSkillMartialArts = true;
                if (skillTactics != _BushoEditList[i].SkillTactics)
                    notMatchedSkillTactics = true;
                if (skillNinjutsu != _BushoEditList[i].SkillNinjutsu)
                    notMatchedSkillNinjutsu = true;
                if (skillBuilding != _BushoEditList[i].SkillBuilding)
                    notMatchedSkillBuilding = true;
                if (skillAgriculture != _BushoEditList[i].SkillAgriculture)
                    notMatchedSkillAgriculture = true;
                if (skillMine != _BushoEditList[i].SkillMine)
                    notMatchedSkillMine = true;
                if (skillMath != _BushoEditList[i].SkillMath)
                    notMatchedSkillMath = true;
                if (skillCourtesy != _BushoEditList[i].SkillCourtesy)
                    notMatchedSkillCourtesy = true;
                if (skillSpeech != _BushoEditList[i].SkillSpeech)
                    notMatchedSkillSpeech = true;
                if (skillTeaCeremony != _BushoEditList[i].SkillTeaCeremony)
                    notMatchedSkillTeaCeremony = true;
                if (skillMedical != _BushoEditList[i].SkillMedical)
                    notMatchedSkillMedical = true;
                if (_HigiCardCheckedListBox.Enabled)
                {
                    for (int j = 0; j < higiCardFlags.Length; ++j)
                    {
                        higiCardFlags[j] &= _BushoEditList[i].HigiCardFlags[j];
                    }
                }
                if (_ShogoCardCheckedListBox.Enabled)
                {
                    for (int j = 0; j < shogoCardFlags.Length; ++j)
                    {
                        shogoCardFlags[j] &= _BushoEditList[i].ShogoCardFlags[j];
                    }
                }
                if (_KassenCardCheckedListBox.Enabled)
                {
                    for (int j = 0; j < kassenCardFlags.Length; ++j)
                    {
                        kassenCardFlags[j] &= _BushoEditList[i].KassenCardFlags[j];
                    }
                }
            }
            if (!notMatchedFamilyName)
            {
                _FamilyNameTextBox.Text = familyName;
            }
            if (!notMatchedGivenName)
            {
                _GivenNameTextBox.Text = givenName;
            }
            if (!notMatchedKanaOfFamilyName)
            {
                _KanaOfFamilyNameTextBox.Text = kanaOfFamilyName;
            }
            if (!notMatchedKanaOfGivenName)
            {
                _KanaOfGivenNameTextBox.Text = kanaOfGivenName;
            }
            if (!notMatchedSex)
            {
                _SexComboBox.SelectedIndex = sex;
            }
            if (!notMatchedKani)
            {
                if (kani != GameData.NoneKaniID) _KaniComboBox.SelectedIndex = kani;
                else _KaniComboBox.SelectedIndex = _KaniComboBox.Items.Count - 1;
            }
            if (!notMatchedCloseness)
            {
                _ClosenessTextBox.Text = closeness.ToString();
            }
            if (!notMatchedFame)
            {
                _FameTextBox.Text = fame.ToString();
            }
            if (!notMatchedNotorious)
            {
                _NotoriousTextBox.Text = notorious.ToString();
            }
            if (!notMatchedLeadership)
            {
                _LeadershipTextBox.Text = leadership.ToString();
            }
            if (!notMatchedCombatPower)
            {
                _CombatPowerTextBox.Text = combatPower.ToString();
            }
            if (!notMatchedPolitics)
            {
                _PoliticsTextBox.Text = politics.ToString();
            }
            if (!notMatchedIntellect)
            {
                _IntellectTextBox.Text = intellect.ToString();
            }
            if (!notMatchedCharm)
            {
                _CharmTextBox.Text = charm.ToString();
            }
            if (!notMatchedSkillInfantry)
            {
                _SkillInfantryComboBox.SelectedIndex = skillInfantry;
            }
            if (!notMatchedSkillCavalry)
            {
                _SkillCavalryComboBox.SelectedIndex = skillCavalry;
            }
            if (!notMatchedSkillGun)
            {
                _SkillGunComboBox.SelectedIndex = skillGun;
            }
            if (!notMatchedSkillNavy)
            {
                _SkillNavyComboBox.SelectedIndex = skillNavy;
            }
            if (!notMatchedSkillArchery)
            {
                _SkillArcheryComboBox.SelectedIndex = skillArchery;
            }
            if (!notMatchedSkillMartialArts)
            {
                _SkillMartialArtsComboBox.SelectedIndex = skillMartialArts;
            }
            if (!notMatchedSkillTactics)
            {
                _SkillTacticsComboBox.SelectedIndex = skillTactics;
            }
            if (!notMatchedSkillNinjutsu)
            {
                _SkillNinjutsuComboBox.SelectedIndex = skillNinjutsu;
            }
            if (!notMatchedSkillBuilding)
            {
                _SkillBuildingComboBox.SelectedIndex = skillBuilding;
            }
            if (!notMatchedSkillAgriculture)
            {
                _SkillAgricultureComboBox.SelectedIndex = skillAgriculture;
            }
            if (!notMatchedSkillMine)
            {
                _SkillMineComboBox.SelectedIndex = skillMine;
            }
            if (!notMatchedSkillMath)
            {
                _SkillMathComboBox.SelectedIndex = skillMath;
            }
            if (!notMatchedSkillCourtesy)
            {
                _SkillCourtesyComboBox.SelectedIndex = skillCourtesy;
            }
            if (!notMatchedSkillSpeech)
            {
                _SkillSpeechComboBox.SelectedIndex = skillSpeech;
            }
            if (!notMatchedSkillTeaCeremony)
            {
                _SkillTeaCeremonyComboBox.SelectedIndex = skillTeaCeremony;
            }
            if (!notMatchedSkillMedical)
            {
                _SkillMedicalComboBox.SelectedIndex = skillMedical;
            }
            // カード
            if (_HigiCardCheckedListBox.Enabled)
            {
                int ncards1 = _HigiCardCheckedListBox.Items.Count;
                for (int i = 0; i < ncards1; ++i)
                {
                    int index = i / 8;
                    int bit = i % 8;
                    bool flag = (higiCardFlags[index] & (0x01 << bit)) != 0;
                    _HigiCardCheckedListBox.SetItemChecked(i, flag);
                }
            }
            if (_ShogoCardCheckedListBox.Enabled)
            {
                int ncards2 = _ShogoCardCheckedListBox.Items.Count;
                for (int i = 0; i < ncards2; ++i)
                {
                    int index = i / 8;
                    int bit = i % 8;
                    bool flag = (shogoCardFlags[index] & (0x01 << bit)) != 0;
                    _ShogoCardCheckedListBox.SetItemChecked(i, flag);
                }
            }
            if (_KassenCardCheckedListBox.Enabled)
            {
                int ncards3 = _KassenCardCheckedListBox.Items.Count;
                for (int i = 0; i < ncards3; ++i)
                {
                    int index = i / 8;
                    int bit = i % 8;
                    bool flag = (kassenCardFlags[index] & (0x01 << bit)) != 0;
                    _KassenCardCheckedListBox.SetItemChecked(i, flag);
                }
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
            _FamilyNameTextBox.TextChanged += checker;
            _GivenNameTextBox.TextChanged += checker;
            _KanaOfFamilyNameTextBox.TextChanged += checker;
            _KanaOfGivenNameTextBox.TextChanged += checker;
            _SexComboBox.SelectedIndexChanged += checker;
            _KaniComboBox.SelectedIndexChanged += checker;
            _SkillInfantryComboBox.SelectedIndexChanged += checker;
            _SkillCavalryComboBox.SelectedIndexChanged += checker;
            _SkillGunComboBox.SelectedIndexChanged += checker;
            _SkillNavyComboBox.SelectedIndexChanged += checker;
            _SkillArcheryComboBox.SelectedIndexChanged += checker;
            _SkillMartialArtsComboBox.SelectedIndexChanged += checker;
            _SkillTacticsComboBox.SelectedIndexChanged += checker;
            _SkillNinjutsuComboBox.SelectedIndexChanged += checker;
            _SkillBuildingComboBox.SelectedIndexChanged += checker;
            _SkillAgricultureComboBox.SelectedIndexChanged += checker;
            _SkillMineComboBox.SelectedIndexChanged += checker;
            _SkillMathComboBox.SelectedIndexChanged += checker;
            _SkillCourtesyComboBox.SelectedIndexChanged += checker;
            _SkillSpeechComboBox.SelectedIndexChanged += checker;
            _SkillTeaCeremonyComboBox.SelectedIndexChanged += checker;
            _SkillMedicalComboBox.SelectedIndexChanged += checker;
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
            _ClosenessTextBox.TextChanged += checkerForTextBox;
            _FameTextBox.TextChanged += checkerForTextBox;
            _NotoriousTextBox.TextChanged += checkerForTextBox;
            _LeadershipTextBox.TextChanged += checkerForTextBox;
            _CombatPowerTextBox.TextChanged += checkerForTextBox;
            _PoliticsTextBox.TextChanged += checkerForTextBox;
            _IntellectTextBox.TextChanged += checkerForTextBox;
            _CharmTextBox.TextChanged += checkerForTextBox;
            // カードのイベントハンドラ
            ItemCheckEventHandler checkerForCards = (sender, e) =>
            {
                CheckedListBox checkedList = (CheckedListBox)sender;
                ((bool[])checkedList.Tag)[e.Index] = true;
            };
            _HigiCardCheckedListBox.ItemCheck += checkerForCards;
            _ShogoCardCheckedListBox.ItemCheck += checkerForCards;
            _KassenCardCheckedListBox.ItemCheck += checkerForCards;
        }

        #endregion

    }
}
