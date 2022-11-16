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
    /// 武将の所属情報を設定するフォーム
    /// </summary>
    public partial class AffiliationEditForm : DataEditForm
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
        public AffiliationEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public AffiliationEditForm(int[] selectedIDs, GameData gameData)
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
        private void AffiliationEditForm_Load(object sender, EventArgs e)
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
            byte seiryoku = 0;
            ushort kyoten = 0;
            byte mibun = 0;
            byte tachiba = 0;
            ushort boss = 0;
            byte loyalty = 0;
            ushort salary = 0;
            ushort bushiAchievement = 0;
            ushort shoninAchievement = 0;
            ushort ninjaAchievement = 0;
            ushort kaizokuAchievement = 0;
            bool tojoFlag = false;
            bool deadFlag = false;
            bool kamikakushiFlag1 = false;
            bool kamikakushiFlag2 = false;
            bool menshikiFlag = false;
            bool konomiFlag = false;
            bool genpukuFlag = false;
            bool yamaiFlag = false;
            bool uramiFlag = false;
            bool huzaiFlag = false;
            bool shutujinFlag = false;
            bool gaishutuKinshiFlag = false;

            try
            {
                if ((bool)_SeiryokuComboBox.Tag)
                {
                    seiryoku = byte.Parse(_SeiryokuComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_KyotenComboBox.Tag)
                {
                    kyoten = ushort.Parse(_KyotenComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_MibunComboBox.Tag)
                {
                    if (_MibunComboBox.SelectedIndex < (_MibunComboBox.Items.Count - 1)) mibun = (byte)_MibunComboBox.SelectedIndex;
                    else mibun = GameData.NoneMibunID;
                    isDataEdited = true;
                }
                if ((bool)_TachibaComboBox.Tag)
                {
                    tachiba = (byte)_TachibaComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_BossComboBox.Tag)
                {
                    if (_BossComboBox.SelectedIndex < (_BossComboBox.Items.Count - 1)) boss = (ushort)_BossComboBox.SelectedIndex;
                    else boss = GameData.NoneBushoID;
                    isDataEdited = true;
                }
                if ((bool)_LoyaltyTextBox.Tag)
                {
                    loyalty = byte.Parse(_LoyaltyTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_SalaryTextBox.Tag)
                {
                    salary = ushort.Parse(_SalaryTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_BushiAchievementTextBox.Tag)
                {
                    bushiAchievement = ushort.Parse(_BushiAchievementTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_ShoninAchievementTextBox.Tag)
                {
                    shoninAchievement = ushort.Parse(_ShoninAchievementTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_NinjaAchievementTextBox.Tag)
                {
                    ninjaAchievement = ushort.Parse(_NinjaAchievementTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_KaizokuAchievementTextBox.Tag)
                {
                    kaizokuAchievement = ushort.Parse(_KaizokuAchievementTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_TojoFlagCheckBox.Tag)
                {
                    tojoFlag = _TojoFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_DeadFlagCheckBox.Tag)
                {
                    deadFlag = _DeadFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_KamikakushiFlag1CheckBox.Tag)
                {
                    kamikakushiFlag1 = _KamikakushiFlag1CheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_KamikakushiFlag2CheckBox.Tag)
                {
                    kamikakushiFlag2 = _KamikakushiFlag2CheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_MenshikiFlagCheckBox.Tag)
                {
                    menshikiFlag = _MenshikiFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_KonomiFlagCheckBox.Tag)
                {
                    konomiFlag = _KonomiFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_GenpukuFlagCheckBox.Tag)
                {
                    genpukuFlag = _GenpukuFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_YamaiFlagCheckBox.Tag)
                {
                    yamaiFlag = _YamaiFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_UramiFlagCheckBox.Tag)
                {
                    uramiFlag = _UramiFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_HuzaiFlagCheckBox.Tag)
                {
                    huzaiFlag = _HuzaiFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_ShutujinFlagCheckBox.Tag)
                {
                    shutujinFlag = _ShutujinFlagCheckBox.Checked;
                    isDataEdited = true;
                }
                if ((bool)_GaishutuKinshiFlagCheckBox.Tag)
                {
                    gaishutuKinshiFlag = _GaishutuKinshiFlagCheckBox.Checked;
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
                if ((bool)_SeiryokuComboBox.Tag)
                {
                    _BushoEditList[i].Seiryoku = seiryoku;
                }
                if ((bool)_KyotenComboBox.Tag)
                {
                    _BushoEditList[i].Kyoten = kyoten;
                }
                if ((bool)_MibunComboBox.Tag)
                {
                    _BushoEditList[i].Mibun = mibun;
                }
                if ((bool)_TachibaComboBox.Tag)
                {
                    _BushoEditList[i].Tachiba = tachiba;
                }
                if ((bool)_BossComboBox.Tag)
                {
                    _BushoEditList[i].Boss = boss;
                }
                if ((bool)_LoyaltyTextBox.Tag)
                {
                    _BushoEditList[i].Loyalty = loyalty;
                }
                if ((bool)_SalaryTextBox.Tag)
                {
                    _BushoEditList[i].Salary = salary;
                }
                if ((bool)_BushiAchievementTextBox.Tag)
                {
                    _BushoEditList[i].BushiAchievement = bushiAchievement;
                }
                if ((bool)_ShoninAchievementTextBox.Tag)
                {
                    _BushoEditList[i].ShoninAchievement = shoninAchievement;
                }
                if ((bool)_NinjaAchievementTextBox.Tag)
                {
                    _BushoEditList[i].NinjaAchievement = ninjaAchievement;
                }
                if ((bool)_KaizokuAchievementTextBox.Tag)
                {
                    _BushoEditList[i].KaizokuAchievement = kaizokuAchievement;
                }
                if ((bool)_TojoFlagCheckBox.Tag)
                {
                    _BushoEditList[i].TojoFlag = tojoFlag;
                }
                if ((bool)_DeadFlagCheckBox.Tag)
                {
                    _BushoEditList[i].DeadFlag = deadFlag;
                }
                if ((bool)_KamikakushiFlag1CheckBox.Tag)
                {
                    _BushoEditList[i].KamikakushiFlag1 = kamikakushiFlag1;
                }
                if ((bool)_KamikakushiFlag2CheckBox.Tag)
                {
                    _BushoEditList[i].KamikakushiFlag2 = kamikakushiFlag2;
                }
                if ((bool)_MenshikiFlagCheckBox.Tag)
                {
                    _BushoEditList[i].MenshikiFlag = menshikiFlag;
                }
                if ((bool)_KonomiFlagCheckBox.Tag)
                {
                    _BushoEditList[i].KonomiFlag = konomiFlag;
                }
                if ((bool)_GenpukuFlagCheckBox.Tag)
                {
                    _BushoEditList[i].GenpukuFlag = genpukuFlag;
                }
                if ((bool)_YamaiFlagCheckBox.Tag)
                {
                    _BushoEditList[i].YamaiFlag = yamaiFlag;
                }
                if ((bool)_UramiFlagCheckBox.Tag)
                {
                    _BushoEditList[i].UramiFlag = uramiFlag;
                }
                if ((bool)_HuzaiFlagCheckBox.Tag)
                {
                    _BushoEditList[i].HuzaiFlag = huzaiFlag;
                }
                if ((bool)_ShutujinFlagCheckBox.Tag)
                {
                    _BushoEditList[i].ShutujinFlag = shutujinFlag;
                }
                if ((bool)_GaishutuKinshiFlagCheckBox.Tag)
                {
                    _BushoEditList[i].GaishutuKinshiFlag = gaishutuKinshiFlag;
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
                _KyotenComboBox.Enabled = false;
                _TojoFlagCheckBox.Enabled = false;
                _DeadFlagCheckBox.Enabled = false;
                _KamikakushiFlag1CheckBox.Enabled = false;
                _KamikakushiFlag2CheckBox.Enabled = false;
                _MenshikiFlagCheckBox.Enabled = false;
                _KonomiFlagCheckBox.Enabled = false;
                _GenpukuFlagCheckBox.Enabled = false;
                _YamaiFlagCheckBox.Enabled = false;
                _UramiFlagCheckBox.Enabled = false;
                _HuzaiFlagCheckBox.Enabled = false;
                _GaishutuKinshiFlagCheckBox.Enabled = false;
            }
            if (_EditMode >= PeopleCategory.EventPerson)
            {
                _SeiryokuComboBox.Enabled = false;
                _TachibaComboBox.Enabled = false;
                _BossComboBox.Enabled = false;
                _LoyaltyTextBox.Enabled = false;
                _SalaryTextBox.Enabled = false;
                _ShoninAchievementTextBox.Enabled = false;
                _NinjaAchievementTextBox.Enabled = false;
                _KaizokuAchievementTextBox.Enabled = false;
                _ShutujinFlagCheckBox.Enabled = false;
            }
            if (_EditMode >= PeopleCategory.GeneralPurpose)
            {
                _BushiAchievementTextBox.Enabled = false;
            }
        }

        /// <summary>
        /// コンボボックスとチェックリストの初期化
        /// </summary>
        private void InitComboBoxAndCheckLists()
        {
            // コンボボックスの作成
            StringBuilder sb = new StringBuilder();
            int nseiryoku = _GameData.SeiryokuList.Count;
            var seiryokuNames = new string[nseiryoku];
            for (int i = 0; i < nseiryoku; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                sb.Append(_GameData.SeiryokuList[i].Name);
                seiryokuNames[i] = sb.ToString();
                sb.Clear();
            }
            _SeiryokuComboBox.Items.AddRange(seiryokuNames);
            _SeiryokuComboBox.Items.Add(GameData.NoneSeiryokuID + ": 所属なし");

            int nkyoten = _GameData.KyotenList.Count;
            var kyotenNames = new string[nkyoten];
            for (int i = 0; i < nkyoten; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                sb.Append(_GameData.KyotenList[i].Name);
                kyotenNames[i] = sb.ToString();
                sb.Clear();
            }
            _KyotenComboBox.Items.AddRange(kyotenNames);
            _KyotenComboBox.Items.Add(GameData.NoneKyotenIDForDead + ": 所属なし");

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
            _BossComboBox.Items.AddRange(bushoNames);
            _BossComboBox.Items.Add(GameData.NoneBushoID + ": なし");

            var mibunList = _GameData.NameListDictionary["Mibun"];
            _MibunComboBox.Items.AddRange(mibunList.ToArray());
            _MibunComboBox.Items.Add("死亡");

            var tachibaList = _GameData.NameListDictionary["Tachiba"];
            _TachibaComboBox.Items.AddRange(tachibaList.ToArray());
        }

        /// <summary>
        /// 各コントロールの初期値を設定
        /// </summary>
        private void SetFirstControlValues()
        {
            // 初期値の設定
            byte seiryoku = _BushoEditList[0].Seiryoku;
            ushort kyoten = _BushoEditList[0].Kyoten;
            byte mibun = _BushoEditList[0].Mibun;
            byte tachiba = _BushoEditList[0].Tachiba;
            ushort boss = _BushoEditList[0].Boss;
            byte loyalty = _BushoEditList[0].Loyalty;
            ushort salary = _BushoEditList[0].Salary;
            ushort bushiAchievement = _BushoEditList[0].BushiAchievement;
            ushort shoninAchievement = _BushoEditList[0].ShoninAchievement;
            ushort ninjaAchievement = _BushoEditList[0].NinjaAchievement;
            ushort kaizokuAchievement = _BushoEditList[0].KaizokuAchievement;
            bool tojoFlag = _BushoEditList[0].TojoFlag;
            bool deadFlag = _BushoEditList[0].DeadFlag;
            bool kamikakushiFlag1 = _BushoEditList[0].KamikakushiFlag1;
            bool kamikakushiFlag2 = _BushoEditList[0].KamikakushiFlag2;
            bool menshikiFlag = _BushoEditList[0].MenshikiFlag;
            bool konomiFlag = _BushoEditList[0].KonomiFlag;
            bool genpukuFlag = _BushoEditList[0].GenpukuFlag;
            bool yamaiFlag = _BushoEditList[0].YamaiFlag;
            bool uramiFlag = _BushoEditList[0].UramiFlag;
            bool huzaiFlag = _BushoEditList[0].HuzaiFlag;
            bool shutujinFlag = _BushoEditList[0].ShutujinFlag;
            bool gaishutuKinshiFlag = _BushoEditList[0].GaishutuKinshiFlag;

            // 他と一致するか確認
            bool notMatchedSeiryoku = !_SeiryokuComboBox.Enabled;
            bool notMatchedKyoten = !_KyotenComboBox.Enabled;
            bool notMatchedMibun = !_MibunComboBox.Enabled;
            bool notMatchedTachiba = !_TachibaComboBox.Enabled;
            bool notMatchedBoss = !_BossComboBox.Enabled;
            bool notMatchedLoyalty = !_LoyaltyTextBox.Enabled;
            bool notMatchedSalary = !_SalaryTextBox.Enabled;
            bool notMatchedBushiAchievement = !_BushiAchievementTextBox.Enabled;
            bool notMatchedShoninAchievement = !_ShoninAchievementTextBox.Enabled;
            bool notMatchedNinjaAchievement = !_NinjaAchievementTextBox.Enabled;
            bool notMatchedKaizokuAchievement = !_KaizokuAchievementTextBox.Enabled;
            bool notMatchedTojoFlag = !_TojoFlagCheckBox.Enabled;
            bool notMatchedDeadFlag = !_DeadFlagCheckBox.Enabled;
            bool notMatchedKamikakushiFlag1 = !_KamikakushiFlag1CheckBox.Enabled;
            bool notMatchedKamikakushiFlag2 = !_KamikakushiFlag2CheckBox.Enabled;
            bool notMatchedMenshikiFlag = !_MenshikiFlagCheckBox.Enabled;
            bool notMatchedKonomiFlag = !_KonomiFlagCheckBox.Enabled;
            bool notMatchedGenpukuFlag = !_GenpukuFlagCheckBox.Enabled;
            bool notMatchedYamaiFlag = !_YamaiFlagCheckBox.Enabled;
            bool notMatchedUramiFlag = !_UramiFlagCheckBox.Enabled;
            bool notMatchedHuzaiFlag = !_HuzaiFlagCheckBox.Enabled;
            bool notMatchedShutujinFlag = !_ShutujinFlagCheckBox.Enabled;
            bool notMatchedGaishutuKinshi = !_GaishutuKinshiFlagCheckBox.Enabled;
            int nedits = _BushoEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (seiryoku != _BushoEditList[i].Seiryoku)
                    notMatchedSeiryoku = true;
                if (kyoten != _BushoEditList[i].Kyoten)
                    notMatchedKyoten = true;
                if (mibun != _BushoEditList[i].Mibun)
                    notMatchedMibun = true;
                if (tachiba != _BushoEditList[i].Tachiba)
                    notMatchedTachiba = true;
                if (boss != _BushoEditList[i].Boss)
                    notMatchedBoss = true;
                if (loyalty != _BushoEditList[i].Loyalty)
                    notMatchedLoyalty = true;
                if (salary != _BushoEditList[i].Salary)
                    notMatchedSalary = true;
                if (bushiAchievement != _BushoEditList[i].BushiAchievement)
                    notMatchedBushiAchievement = true;
                if (shoninAchievement != _BushoEditList[i].ShoninAchievement)
                    notMatchedShoninAchievement = true;
                if (ninjaAchievement != _BushoEditList[i].NinjaAchievement)
                    notMatchedNinjaAchievement = true;
                if (kaizokuAchievement != _BushoEditList[i].KaizokuAchievement)
                    notMatchedKaizokuAchievement = true;
                if (tojoFlag != _BushoEditList[i].TojoFlag)
                    notMatchedTojoFlag = true;
                if (deadFlag != _BushoEditList[i].DeadFlag)
                    notMatchedDeadFlag = true;
                if (kamikakushiFlag1 != _BushoEditList[i].KamikakushiFlag1)
                    notMatchedKamikakushiFlag1 = true;
                if (kamikakushiFlag2 != _BushoEditList[i].KamikakushiFlag2)
                    notMatchedKamikakushiFlag2 = true;
                if (menshikiFlag != _BushoEditList[i].MenshikiFlag)
                    notMatchedMenshikiFlag = true;
                if (konomiFlag != _BushoEditList[i].KonomiFlag)
                    notMatchedKonomiFlag = true;
                if (genpukuFlag != _BushoEditList[i].GenpukuFlag)
                    notMatchedGenpukuFlag = true;
                if (yamaiFlag != _BushoEditList[i].YamaiFlag)
                    notMatchedYamaiFlag = true;
                if (uramiFlag != _BushoEditList[i].UramiFlag)
                    notMatchedUramiFlag = true;
                if (huzaiFlag != _BushoEditList[i].HuzaiFlag)
                    notMatchedHuzaiFlag = true;
                if (shutujinFlag != _BushoEditList[i].ShutujinFlag)
                    notMatchedShutujinFlag = true;
                if (gaishutuKinshiFlag != _BushoEditList[i].GaishutuKinshiFlag)
                    notMatchedGaishutuKinshi = true;
            }
            if (!notMatchedSeiryoku)
            {
                if (seiryoku != GameData.NoneSeiryokuID) _SeiryokuComboBox.SelectedIndex = seiryoku;
                else _SeiryokuComboBox.SelectedIndex = _SeiryokuComboBox.Items.Count - 1;
            }
            if (!notMatchedKyoten)
            {
                if (kyoten != GameData.NoneKyotenIDForDead) _KyotenComboBox.SelectedIndex = kyoten;
                else _KyotenComboBox.SelectedIndex = _KyotenComboBox.Items.Count - 1;
            }
            if (!notMatchedMibun)
            {
                if (mibun != GameData.NoneMibunID) _MibunComboBox.SelectedIndex = mibun;
                else _MibunComboBox.SelectedIndex = _MibunComboBox.Items.Count - 1;
            }
            if (!notMatchedTachiba)
            {
                _TachibaComboBox.SelectedIndex = tachiba;
            }
            if (!notMatchedBoss)
            {
                if (boss != GameData.NoneBushoID) _BossComboBox.SelectedIndex = boss;
                else _BossComboBox.SelectedIndex = _BossComboBox.Items.Count - 1;
            }
            if (!notMatchedLoyalty)
            {
                _LoyaltyTextBox.Text = loyalty.ToString();
            }
            if (!notMatchedSalary)
            {
                _SalaryTextBox.Text = salary.ToString();
            }
            if (!notMatchedBushiAchievement)
            {
                _BushiAchievementTextBox.Text = bushiAchievement.ToString();
            }
            if (!notMatchedShoninAchievement)
            {
                _ShoninAchievementTextBox.Text = shoninAchievement.ToString();
            }
            if (!notMatchedNinjaAchievement)
            {
                _NinjaAchievementTextBox.Text = ninjaAchievement.ToString();
            }
            if (!notMatchedKaizokuAchievement)
            {
                _KaizokuAchievementTextBox.Text = kaizokuAchievement.ToString();
            }
            if (!notMatchedTojoFlag)
            {
                _TojoFlagCheckBox.Checked = tojoFlag;
            }
            if (!notMatchedDeadFlag)
            {
                _DeadFlagCheckBox.Checked = deadFlag;
            }
            if (!notMatchedKamikakushiFlag1)
            {
                _KamikakushiFlag1CheckBox.Checked = kamikakushiFlag1;
            }
            if (!notMatchedKamikakushiFlag2)
            {
                _KamikakushiFlag2CheckBox.Checked = kamikakushiFlag2;
            }
            if (!notMatchedMenshikiFlag)
            {
                _MenshikiFlagCheckBox.Checked = menshikiFlag;
            }
            if (!notMatchedKonomiFlag)
            {
                _KonomiFlagCheckBox.Checked = konomiFlag;
            }
            if (!notMatchedGenpukuFlag)
            {
                _GenpukuFlagCheckBox.Checked = genpukuFlag;
            }
            if (!notMatchedYamaiFlag)
            {
                _YamaiFlagCheckBox.Checked = yamaiFlag;
            }
            if (!notMatchedUramiFlag)
            {
                _UramiFlagCheckBox.Checked = uramiFlag;
            }
            if (!notMatchedHuzaiFlag)
            {
                _HuzaiFlagCheckBox.Checked = huzaiFlag;
            }
            if (!notMatchedShutujinFlag)
            {
                _ShutujinFlagCheckBox.Checked = shutujinFlag;
            }
            if (!notMatchedGaishutuKinshi)
            {
                _GaishutuKinshiFlagCheckBox.Checked = gaishutuKinshiFlag;
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
            _SeiryokuComboBox.SelectedIndexChanged += checker;
            _KyotenComboBox.SelectedIndexChanged += checker;
            _MibunComboBox.SelectedIndexChanged += checker;
            _TachibaComboBox.SelectedIndexChanged += checker;
            _BossComboBox.SelectedIndexChanged += checker;
            _TojoFlagCheckBox.CheckedChanged += checker;
            _DeadFlagCheckBox.CheckedChanged += checker;
            _KamikakushiFlag1CheckBox.CheckedChanged += checker;
            _KamikakushiFlag2CheckBox.CheckedChanged += checker;
            _MenshikiFlagCheckBox.CheckedChanged += checker;
            _KonomiFlagCheckBox.CheckedChanged += checker;
            _GenpukuFlagCheckBox.CheckedChanged += checker;
            _YamaiFlagCheckBox.CheckedChanged += checker;
            _UramiFlagCheckBox.CheckedChanged += checker;
            _HuzaiFlagCheckBox.CheckedChanged += checker;
            _ShutujinFlagCheckBox.CheckedChanged += checker;
            _GaishutuKinshiFlagCheckBox.CheckedChanged += checker;
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
            _LoyaltyTextBox.TextChanged += checkerForTextBox;
            _SalaryTextBox.TextChanged += checkerForTextBox;
            _BushiAchievementTextBox.TextChanged += checkerForTextBox;
            _ShoninAchievementTextBox.TextChanged += checkerForTextBox;
            _NinjaAchievementTextBox.TextChanged += checkerForTextBox;
            _KaizokuAchievementTextBox.TextChanged += checkerForTextBox;
        }

        #endregion

    }
}
