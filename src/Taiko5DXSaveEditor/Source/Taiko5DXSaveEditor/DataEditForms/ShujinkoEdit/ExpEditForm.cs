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

namespace Taiko5DXSaveEditor.DataEditForms.ShujinkoEdit
{
    /// <summary>
    /// 経験値編集フォーム
    /// </summary>
    public partial class ExpEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 主人公
        /// </summary>
        private Shujinko _Shujinko = null;

        /// <summary>
        /// データが編集されたかどうか
        /// </summary>
        private bool _IsDataEdited = false;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public ExpEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public ExpEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            _Shujinko = gameData.Shujinko;
            InitializeComponent();
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォームがロードされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void ExpEditForm_Load(object sender, EventArgs e)
        {
            // テキストボックスに初期値を入れる
            _ExpMedicalTextBox.Text = _Shujinko.ExpMedical.ToString();
            _NumOfFreeConsultationsTextBox.Text = _Shujinko.NumOfFreeConsultations.ToString();
            _DaysOfCompoundingTextBox.Text = _Shujinko.DaysOfCompounding.ToString();
            _DaysOfGettingHerbsTextBox.Text = _Shujinko.DaysOfGettingHerbs.ToString();
            _NumOfTeaCeremonysTextBox.Text = _Shujinko.NumOfTeaCeremonys.ToString();
            _ExpTeaSetCraftTextBox.Text = _Shujinko.ExpTeaSetCraft.ToString();
            _ExpGunpowderCraftTextBox.Text = _Shujinko.ExpGunpowderCraft.ToString();
            _ExpIronCraftTextBox.Text = _Shujinko.ExpIronCraft.ToString();
            _ExpWeaponCraftTextBox.Text = _Shujinko.ExpWeaponCraft.ToString();
            _ExpGunCraftTextBox.Text = _Shujinko.ExpGunCraft.ToString();
            _ExpMeditationTextBox.Text = _Shujinko.ExpMeditation.ToString();
            _ShogoExpDomesticAffairsTextBox.Text = _Shujinko.ShogoExpDomesticAffairs.ToString();
            _ShogoExpDiplomacyTextBox.Text = _Shujinko.ShogoExpDiplomacy.ToString();
            _ShogoNumOfWarWinTextBox.Text = _Shujinko.ShogoNumOfWarWin.ToString();
            _ShogoNumOfKillTextBox.Text = _Shujinko.ShogoNumOfKill.ToString();
            _ShogoNumOfRebellionTextBox.Text = _Shujinko.ShogoNumOfRebellion.ToString();
            _ShogoNumOfRecruitingTextBox.Text = _Shujinko.ShogoNumOfRecruiting.ToString();
            _ShogoNumOfAppraisalTextBox.Text = _Shujinko.ShogoNumOfAppraisal.ToString();
            _ShogoNumOfArtAcceptanceTextBox.Text = _Shujinko.ShogoNumOfArtAcceptance.ToString();
            _ShogoNumOfBetrayalTextBox.Text = _Shujinko.ShogoNumOfBetrayal.ToString();
            _ShogoNumOfDevelopmentTextBox.Text = _Shujinko.ShogoNumOfDevelopment.ToString();
            _ShogoNumOfWorkInBarTextBox.Text = _Shujinko.ShogoNumOfWorkInBar.ToString();
            _SkillExpInfantryTextBox.Text = _Shujinko.SkillExpInfantry.ToString();
            _SkillExpCavalryTextBox.Text = _Shujinko.SkillExpCavalry.ToString();
            _SkillExpGunTextBox.Text = _Shujinko.SkillExpGun.ToString();
            _SkillExpNavyTextBox.Text = _Shujinko.SkillExpNavy.ToString();
            _SkillExpArcheryTextBox.Text = _Shujinko.SkillExpArchery.ToString();
            _SkillExpMartialArtsTextBox.Text = _Shujinko.SkillExpMartialArts.ToString();
            _SkillExpTacticsTextBox.Text = _Shujinko.SkillExpTactics.ToString();
            _SkillExpNinjutsuTextBox.Text = _Shujinko.SkillExpNinjutsu.ToString();
            _SkillExpBuildingTextBox.Text = _Shujinko.SkillExpBuilding.ToString();
            _SkillExpAgricultureTextBox.Text = _Shujinko.SkillExpAgriculture.ToString();
            _SkillExpMineTextBox.Text = _Shujinko.SkillExpMine.ToString();
            _SkillExpMathTextBox.Text = _Shujinko.SkillExpMath.ToString();
            _SkillExpCourtesyTextBox.Text = _Shujinko.SkillExpCourtesy.ToString();
            _SkillExpSpeechTextBox.Text = _Shujinko.SkillExpSpeech.ToString();
            _SkillExpTeaCeremonyTextBox.Text = _Shujinko.SkillExpTeaCeremony.ToString();
            _SkillExpMedicalTextBox.Text = _Shujinko.SkillExpMedical.ToString();

            // テキストボックスの内容を保存しておくための変数を確保
            var textBoxs = from Control control in this.Controls
                           where control is TextBox
                           orderby control.TabIndex
                           select (TextBox)control;
            TextBox[] textBoxArray = textBoxs.ToArray();
            string[] beforeTexts = new string[textBoxArray.Length];
            for (int i = 0; i < textBoxArray.Length; ++i)
            {
                beforeTexts[i] = textBoxArray[i].Text;
            }
            // イベントハンドラの設定
            EventHandler checkTextCange = (sender2, e2) =>
            {
                TextBox tb = (TextBox)sender2;
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
                    _IsDataEdited = true;
                }
            };
            _ExpMedicalTextBox.TextChanged += checkTextCange;
            _NumOfFreeConsultationsTextBox.TextChanged += checkTextCange;
            _DaysOfCompoundingTextBox.TextChanged += checkTextCange;
            _DaysOfGettingHerbsTextBox.TextChanged += checkTextCange;
            _NumOfTeaCeremonysTextBox.TextChanged += checkTextCange;
            _ExpTeaSetCraftTextBox.TextChanged += checkTextCange;
            _ExpGunpowderCraftTextBox.TextChanged += checkTextCange;
            _ExpIronCraftTextBox.TextChanged += checkTextCange;
            _ExpWeaponCraftTextBox.TextChanged += checkTextCange;
            _ExpGunCraftTextBox.TextChanged += checkTextCange;
            _ExpMeditationTextBox.TextChanged += checkTextCange;
            _ShogoExpDomesticAffairsTextBox.TextChanged += checkTextCange;
            _ShogoExpDiplomacyTextBox.TextChanged += checkTextCange;
            _ShogoNumOfWarWinTextBox.TextChanged += checkTextCange;
            _ShogoNumOfKillTextBox.TextChanged += checkTextCange;
            _ShogoNumOfRebellionTextBox.TextChanged += checkTextCange;
            _ShogoNumOfRecruitingTextBox.TextChanged += checkTextCange;
            _ShogoNumOfAppraisalTextBox.TextChanged += checkTextCange;
            _ShogoNumOfArtAcceptanceTextBox.TextChanged += checkTextCange;
            _ShogoNumOfBetrayalTextBox.TextChanged += checkTextCange;
            _ShogoNumOfDevelopmentTextBox.TextChanged += checkTextCange;
            _ShogoNumOfWorkInBarTextBox.TextChanged += checkTextCange;
            _SkillExpInfantryTextBox.TextChanged += checkTextCange;
            _SkillExpCavalryTextBox.TextChanged += checkTextCange;
            _SkillExpGunTextBox.TextChanged += checkTextCange;
            _SkillExpNavyTextBox.TextChanged += checkTextCange;
            _SkillExpArcheryTextBox.TextChanged += checkTextCange;
            _SkillExpMartialArtsTextBox.TextChanged += checkTextCange;
            _SkillExpTacticsTextBox.TextChanged += checkTextCange;
            _SkillExpNinjutsuTextBox.TextChanged += checkTextCange;
            _SkillExpBuildingTextBox.TextChanged += checkTextCange;
            _SkillExpAgricultureTextBox.TextChanged += checkTextCange;
            _SkillExpMineTextBox.TextChanged += checkTextCange;
            _SkillExpMathTextBox.TextChanged += checkTextCange;
            _SkillExpCourtesyTextBox.TextChanged += checkTextCange;
            _SkillExpSpeechTextBox.TextChanged += checkTextCange;
            _SkillExpTeaCeremonyTextBox.TextChanged += checkTextCange;
            _SkillExpMedicalTextBox.TextChanged += checkTextCange;
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _OKButton_Click(object sender, EventArgs e)
        {
            // 変更がなければそのまま閉じる
            if (!_IsDataEdited)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // 一時退避用
            uint expMedical = 0;
            uint numOfFreeConsultations = 0;
            uint daysOfCompounding = 0;
            uint daysOfGettingHerbs = 0;
            uint numOfTeaCeremonys = 0;
            uint expTeaSetCraft = 0;
            ushort expGunpowderCraft = 0;
            ushort expIronCraft = 0;
            ushort expWeaponCraft = 0;
            ushort expGunCraft = 0;
            ushort expMeditation = 0;
            uint shogoExpDomesticAffairs = 0;
            uint shogoExpDiplomacy = 0;
            uint shogoNumOfWarWin = 0;
            byte shogoNumOfKill = 0;
            byte shogoNumOfRebellion = 0;
            byte shogoNumOfRecruiting = 0;
            byte shogoNumOfAppraisal = 0;
            byte shogoNumOfArtAcceptance = 0;
            byte shogoNumOfBetrayal = 0;
            byte shogoNumOfDevelopment = 0;
            byte shogoNumOfWorkInBar = 0;
            byte skillExpInfantry = 0;
            byte skillExpCavalry = 0;
            byte skillExpGun = 0;
            byte skillExpNavy = 0;
            byte skillExpArchery = 0;
            byte skillExpMartialArts = 0;
            byte skillExpTactics = 0;
            byte skillExpNinjutsu = 0;
            byte skillExpBuilding = 0;
            byte skillExpAgriculture = 0;
            byte skillExpMine = 0;
            byte skillExpMath = 0;
            byte skillExpCourtesy = 0;
            byte skillExpSpeech = 0;
            byte skillExpTeaCeremony = 0;
            byte skillExpMedical = 0;

            // UIから入力内容を読み取る
            try
            {
                // キャスト時にエラーが出ないか確認
                expMedical = uint.Parse(_ExpMedicalTextBox.Text);
                numOfFreeConsultations = uint.Parse(_NumOfFreeConsultationsTextBox.Text);
                daysOfCompounding = uint.Parse(_DaysOfCompoundingTextBox.Text);
                daysOfGettingHerbs = uint.Parse(_DaysOfGettingHerbsTextBox.Text);
                numOfTeaCeremonys = uint.Parse(_NumOfTeaCeremonysTextBox.Text);
                expTeaSetCraft = uint.Parse(_ExpTeaSetCraftTextBox.Text);
                expGunpowderCraft = ushort.Parse(_ExpGunpowderCraftTextBox.Text);
                expIronCraft = ushort.Parse(_ExpIronCraftTextBox.Text);
                expWeaponCraft = ushort.Parse(_ExpWeaponCraftTextBox.Text);
                expGunCraft = ushort.Parse(_ExpGunCraftTextBox.Text);
                expMeditation = ushort.Parse(_ExpMeditationTextBox.Text);
                shogoExpDomesticAffairs = uint.Parse(_ShogoExpDomesticAffairsTextBox.Text);
                shogoExpDiplomacy = uint.Parse(_ShogoExpDiplomacyTextBox.Text);
                shogoNumOfWarWin = uint.Parse(_ShogoNumOfWarWinTextBox.Text);
                shogoNumOfKill = byte.Parse(_ShogoNumOfKillTextBox.Text);
                shogoNumOfRebellion = byte.Parse(_ShogoNumOfRebellionTextBox.Text);
                shogoNumOfRecruiting = byte.Parse(_ShogoNumOfRecruitingTextBox.Text);
                shogoNumOfAppraisal = byte.Parse(_ShogoNumOfAppraisalTextBox.Text);
                shogoNumOfArtAcceptance = byte.Parse(_ShogoNumOfArtAcceptanceTextBox.Text);
                shogoNumOfBetrayal = byte.Parse(_ShogoNumOfBetrayalTextBox.Text);
                shogoNumOfDevelopment = byte.Parse(_ShogoNumOfDevelopmentTextBox.Text);
                shogoNumOfWorkInBar = byte.Parse(_ShogoNumOfWorkInBarTextBox.Text);
                skillExpInfantry = byte.Parse(_SkillExpInfantryTextBox.Text);
                skillExpCavalry = byte.Parse(_SkillExpCavalryTextBox.Text);
                skillExpGun = byte.Parse(_SkillExpGunTextBox.Text);
                skillExpNavy = byte.Parse(_SkillExpNavyTextBox.Text);
                skillExpArchery = byte.Parse(_SkillExpArcheryTextBox.Text);
                skillExpMartialArts = byte.Parse(_SkillExpMartialArtsTextBox.Text);
                skillExpTactics = byte.Parse(_SkillExpTacticsTextBox.Text);
                skillExpNinjutsu = byte.Parse(_SkillExpNinjutsuTextBox.Text);
                skillExpBuilding = byte.Parse(_SkillExpBuildingTextBox.Text);
                skillExpAgriculture = byte.Parse(_SkillExpAgricultureTextBox.Text);
                skillExpMine = byte.Parse(_SkillExpMineTextBox.Text);
                skillExpMath = byte.Parse(_SkillExpMathTextBox.Text);
                skillExpCourtesy = byte.Parse(_SkillExpCourtesyTextBox.Text);
                skillExpSpeech = byte.Parse(_SkillExpSpeechTextBox.Text);
                skillExpTeaCeremony = byte.Parse(_SkillExpTeaCeremonyTextBox.Text);
                skillExpMedical = byte.Parse(_SkillExpMedicalTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this, @"不正な入力が含まれています。内容を修正するか、一度このウィンドウを閉じてください。", @"エラー通知", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                _CloseCancelFlag = true;
                return;
            }

            // 内容の反映
            _Shujinko.ExpMedical = expMedical;
            _Shujinko.NumOfFreeConsultations = numOfFreeConsultations;
            _Shujinko.DaysOfCompounding = daysOfCompounding;
            _Shujinko.DaysOfGettingHerbs = daysOfGettingHerbs;
            _Shujinko.NumOfTeaCeremonys = numOfTeaCeremonys;
            _Shujinko.ExpTeaSetCraft = expTeaSetCraft;
            _Shujinko.ExpGunpowderCraft = expGunpowderCraft;
            _Shujinko.ExpIronCraft = expIronCraft;
            _Shujinko.ExpWeaponCraft = expWeaponCraft;
            _Shujinko.ExpGunCraft = expGunCraft;
            _Shujinko.ExpMeditation = expMeditation;
            _Shujinko.ShogoExpDomesticAffairs = shogoExpDomesticAffairs;
            _Shujinko.ShogoExpDiplomacy = shogoExpDiplomacy;
            _Shujinko.ShogoNumOfWarWin = shogoNumOfWarWin;
            _Shujinko.ShogoNumOfKill = shogoNumOfKill;
            _Shujinko.ShogoNumOfRebellion = shogoNumOfRebellion;
            _Shujinko.ShogoNumOfRecruiting = shogoNumOfRecruiting;
            _Shujinko.ShogoNumOfAppraisal = shogoNumOfAppraisal;
            _Shujinko.ShogoNumOfArtAcceptance = shogoNumOfArtAcceptance;
            _Shujinko.ShogoNumOfBetrayal = shogoNumOfBetrayal;
            _Shujinko.ShogoNumOfDevelopment = shogoNumOfDevelopment;
            _Shujinko.ShogoNumOfWorkInBar = shogoNumOfWorkInBar;
            _Shujinko.SkillExpInfantry = skillExpInfantry;
            _Shujinko.SkillExpCavalry = skillExpCavalry;
            _Shujinko.SkillExpGun = skillExpGun;
            _Shujinko.SkillExpNavy = skillExpNavy;
            _Shujinko.SkillExpArchery = skillExpArchery;
            _Shujinko.SkillExpMartialArts = skillExpMartialArts;
            _Shujinko.SkillExpTactics = skillExpTactics;
            _Shujinko.SkillExpNinjutsu = skillExpNinjutsu;
            _Shujinko.SkillExpBuilding = skillExpBuilding;
            _Shujinko.SkillExpAgriculture = skillExpAgriculture;
            _Shujinko.SkillExpMine = skillExpMine;
            _Shujinko.SkillExpMath = skillExpMath;
            _Shujinko.SkillExpCourtesy = skillExpCourtesy;
            _Shujinko.SkillExpSpeech = skillExpSpeech;
            _Shujinko.SkillExpTeaCeremony = skillExpTeaCeremony;
            _Shujinko.SkillExpMedical = skillExpMedical;

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
