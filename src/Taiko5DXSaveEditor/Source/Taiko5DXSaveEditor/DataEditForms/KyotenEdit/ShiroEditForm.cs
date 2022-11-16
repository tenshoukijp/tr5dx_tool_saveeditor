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

namespace Taiko5DXSaveEditor.DataEditForms.KyotenEdit
{
    /// <summary>
    /// 城関連の基本事項を設定するフォーム
    /// </summary>
    public partial class ShiroEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の城リスト
        /// </summary>
        private List<Shiro> _ShiroEditList = new List<Shiro>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public ShiroEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public ShiroEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の町を全て受け取る
            var shiros = from shiro in gameData.KyotenList
                         where selectedIDs.Contains(shiro.ID)
                         select (Shiro)shiro;
            _ShiroEditList.AddRange(shiros);
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
        private void ShiroEditForm_Load(object sender, EventArgs e)
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

            // コンボボックスの作成
            var nameList = _GameData.NameListDictionary["Kyoten"];
            _NameComboBox.Items.AddRange(nameList.ToArray());
            StringBuilder sb = new StringBuilder();
            var nbusho = GameData.NumOfBusho + GameData.NumOfGeneralPurpose;
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
            // 初期値の設定
            int nameIndex = _ShiroEditList[0].NameID;
            int leaderIndex = _ShiroEditList[0].Leader;
            byte scale = _ShiroEditList[0].Scale;
            byte location = _ShiroEditList[0].Location;
            byte population = _ShiroEditList[0].Population;
            ushort kokudaka = _ShiroEditList[0].Kokudaka;
            byte maxKokudaka = _ShiroEditList[0].MaxKokudaka;
            byte mine = _ShiroEditList[0].Mine;
            byte maxMine = _ShiroEditList[0].MaxMine;
            uint money = _ShiroEditList[0].Money;
            uint militaryFood = _ShiroEditList[0].MilitaryFood;
            ushort numOfWarHorses = _ShiroEditList[0].NumOfWarHorses;
            ushort numOfGuns = _ShiroEditList[0].NumOfGuns;
            ushort numOfCannons = _ShiroEditList[0].NumOfCannons;
            ushort numOfSoldiers = _ShiroEditList[0].NumOfSoldiers;
            byte degreeOfTraining = _ShiroEditList[0].DegreeOfTraining;
            byte morale = _ShiroEditList[0].Morale;
            byte defensePower = _ShiroEditList[0].DefensePower;
            byte residentSupport = _ShiroEditList[0].ResidentSupport;
            // 他と一致するか確認
            bool notMatchedNameIndex = false;
            bool notMatchedLeaderIndex = false;
            bool notMatchedScale = false;
            bool notMatchedLocation = false;
            bool notMatchedPopulation = false;
            bool notMatchedKokudaka = false;
            bool notMatchedMaxKokudaka = false;
            bool notMatchedMine = false;
            bool notMatchedMaxMine = false;
            bool notMatchedMoney = false;
            bool notMatchedMilitaryFood = false;
            bool notMatchedNumOfWarHorses = false;
            bool notMatchedNumOfGuns = false;
            bool notMatchedNumOfCannons = false;
            bool notMatchedNumOfSoldiers = false;
            bool notMatchedDegreeOfTraining = false;
            bool notMatchedMorale = false;
            bool notMatchedDefensePower = false;
            bool notMatchedResidentSupport = false;
            int nedits = _ShiroEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (nameIndex != _ShiroEditList[i].NameID)
                    notMatchedNameIndex = true;
                if (leaderIndex != _ShiroEditList[i].Leader)
                    notMatchedLeaderIndex = true;
                if (scale != _ShiroEditList[i].Scale)
                    notMatchedScale = true;
                if (location != _ShiroEditList[i].Location)
                    notMatchedLocation = true;
                if (population != _ShiroEditList[i].Population)
                    notMatchedPopulation = true;
                if (kokudaka != _ShiroEditList[i].Kokudaka)
                    notMatchedKokudaka = true;
                if (maxKokudaka != _ShiroEditList[i].MaxKokudaka)
                    notMatchedMaxKokudaka = true;
                if (mine != _ShiroEditList[i].Mine)
                    notMatchedMine = true;
                if (maxMine != _ShiroEditList[i].MaxMine)
                    notMatchedMaxMine = true;
                if (money != _ShiroEditList[i].Money)
                    notMatchedMoney = true;
                if (militaryFood != _ShiroEditList[i].MilitaryFood)
                    notMatchedMilitaryFood = true;
                if (numOfWarHorses != _ShiroEditList[i].NumOfWarHorses)
                    notMatchedNumOfWarHorses = true;
                if (numOfGuns != _ShiroEditList[i].NumOfGuns)
                    notMatchedNumOfGuns = true;
                if (numOfCannons != _ShiroEditList[i].NumOfCannons)
                    notMatchedNumOfCannons = true;
                if (numOfSoldiers != _ShiroEditList[i].NumOfSoldiers)
                    notMatchedNumOfSoldiers = true;
                if (degreeOfTraining != _ShiroEditList[i].DegreeOfTraining)
                    notMatchedDegreeOfTraining = true;
                if (morale != _ShiroEditList[i].Morale)
                    notMatchedMorale = true;
                if (defensePower != _ShiroEditList[i].DefensePower)
                    notMatchedDefensePower = true;
                if (residentSupport != _ShiroEditList[i].ResidentSupport)
                    notMatchedResidentSupport = true;
            }
            if (!notMatchedNameIndex)
                _NameComboBox.SelectedIndex = nameIndex;
            if (!notMatchedLeaderIndex)
            {
                if (leaderIndex >= nbusho) _LeaderComboBox.SelectedIndex = nbusho;
                else _LeaderComboBox.SelectedIndex = leaderIndex;
            }
            if (!notMatchedScale)
            {
                _ScaleTextBox.Text = scale.ToString();
                if (scale >= GameData.ScaleLevels[0])
                {
                    _ScaleLevelLabel.Text = @"(巨)";
                    _BaseKokudakaLabel.Text = "40";
                }
                else if (scale >= GameData.ScaleLevels[1])
                {
                    _ScaleLevelLabel.Text = @"(大)";
                    _BaseKokudakaLabel.Text = "30";
                }
                else if (scale >= GameData.ScaleLevels[2])
                {
                    _ScaleLevelLabel.Text = @"(中)";
                    _BaseKokudakaLabel.Text = "20";
                }
                else
                {
                    _ScaleLevelLabel.Text = @"(小)";
                    _BaseKokudakaLabel.Text = "10";
                }
            }
            if (!notMatchedLocation)
            {
                _LocationComboBox.SelectedIndex = location;
            }
            if (!notMatchedPopulation)
                _PopulationTextBox.Text = population.ToString();
            if (!notMatchedKokudaka)
                _KokudakaTextBox.Text = kokudaka.ToString();
            if (!notMatchedMaxKokudaka)
                _MaxKokudakaTextBox.Text = maxKokudaka.ToString();
            if (!notMatchedMine)
                _MineTextBox.Text = mine.ToString();
            if (!notMatchedMaxMine)
                _MaxMineTextBox.Text = maxMine.ToString();
            if (!notMatchedMoney)
                _MoneyTextBox.Text = money.ToString();
            if (!notMatchedMilitaryFood)
                _MilitaryFoodTextBox.Text = militaryFood.ToString();
            if (!notMatchedNumOfWarHorses)
                _NumOfWarHorsesTextBox.Text = numOfWarHorses.ToString();
            if (!notMatchedNumOfGuns)
                _NumOfGunsTextBox.Text = numOfGuns.ToString();
            if (!notMatchedNumOfCannons)
                _NumOfCannonsTextBox.Text = numOfCannons.ToString();
            if (!notMatchedNumOfSoldiers)
                _NumOfSoldiersTextBox.Text = numOfSoldiers.ToString();
            if (!notMatchedDegreeOfTraining)
                _DegreeOfTrainingTextBox.Text = degreeOfTraining.ToString();
            if (!notMatchedMorale)
                _MoraleTextBox.Text = morale.ToString();
            if (!notMatchedDefensePower)
                _DefensePowerTextBox.Text = defensePower.ToString();
            if (!notMatchedResidentSupport)
                _ResidentSupportTextBox.Text = residentSupport.ToString();

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _NameComboBox.SelectedIndexChanged += checker;
            _LeaderComboBox.SelectedIndexChanged += checker;
            _LocationComboBox.SelectedIndexChanged += checker;
            // テキストボックス用のイベントハンドラ
            string[] beforeTexts = new string[controlsArray.Length];
            for (int i = 0; i < controlsArray.Length; ++i)
            {
                beforeTexts[i] = controlsArray[i].Text;
            }
            EventHandler checkerForTextBox = (sender2, e2) =>
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
                    tb.Tag = true;
                    if (tb.Name == "_ScaleTextBox")
                    {
                        int newScale = int.Parse(tb.Text);
                        if (newScale >= GameData.ScaleLevels[0])
                        {
                            _ScaleLevelLabel.Text = @"(巨)";
                            _BaseKokudakaLabel.Text = "40";
                        }
                        else if (newScale >= GameData.ScaleLevels[1])
                        {
                            _ScaleLevelLabel.Text = @"(大)";
                            _BaseKokudakaLabel.Text = "30";
                        }
                        else if (newScale >= GameData.ScaleLevels[2])
                        {
                            _ScaleLevelLabel.Text = @"(中)";
                            _BaseKokudakaLabel.Text = "20";
                        }
                        else
                        {
                            _ScaleLevelLabel.Text = @"(小)";
                            _BaseKokudakaLabel.Text = "10";
                        }
                    }
                }
            };
            _ScaleTextBox.TextChanged += checkerForTextBox;
            _PopulationTextBox.TextChanged += checkerForTextBox;
            _KokudakaTextBox.TextChanged += checkerForTextBox;
            _MaxKokudakaTextBox.TextChanged += checkerForTextBox;
            _MineTextBox.TextChanged += checkerForTextBox;
            _MaxMineTextBox.TextChanged += checkerForTextBox;
            _MoneyTextBox.TextChanged += checkerForTextBox;
            _MilitaryFoodTextBox.TextChanged += checkerForTextBox;
            _NumOfWarHorsesTextBox.TextChanged += checkerForTextBox;
            _NumOfGunsTextBox.TextChanged += checkerForTextBox;
            _NumOfCannonsTextBox.TextChanged += checkerForTextBox;
            _NumOfSoldiersTextBox.TextChanged += checkerForTextBox;
            _DegreeOfTrainingTextBox.TextChanged += checkerForTextBox;
            _MoraleTextBox.TextChanged += checkerForTextBox;
            _DefensePowerTextBox.TextChanged += checkerForTextBox;
            _ResidentSupportTextBox.TextChanged += checkerForTextBox;
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
            ushort nameId = 0;
            ushort leaderId = 0;
            byte scale = 0;
            byte location = 0;
            byte population = 0;
            ushort kokudaka = 0;
            byte maxKokudaka = 0;
            byte mine = 0;
            byte maxMine = 0;
            uint money = 0;
            uint militaryFood = 0;
            ushort numOfWarHorses = 0;
            ushort numOfGuns = 0;
            ushort numOfCannons = 0;
            ushort numOfSoldiers = 0;
            byte degreeOfTraining = 0;
            byte morale = 0;
            byte defensePower = 0;
            byte residentSupport = 0;
            try
            {
                if ((bool)_NameComboBox.Tag)
                {
                    nameId = (ushort)_NameComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_LeaderComboBox.Tag)
                {
                    leaderId = ushort.Parse(_LeaderComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_ScaleTextBox.Tag)
                {
                    scale = byte.Parse(_ScaleTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_LocationComboBox.Tag)
                {
                    location = (byte)_LocationComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_PopulationTextBox.Tag)
                {
                    population = byte.Parse(_PopulationTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_KokudakaTextBox.Tag)
                {
                    kokudaka = ushort.Parse(_KokudakaTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_MaxKokudakaTextBox.Tag)
                {
                    maxKokudaka = byte.Parse(_MaxKokudakaTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_MineTextBox.Tag)
                {
                    mine = byte.Parse(_MineTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_MaxMineTextBox.Tag)
                {
                    maxMine = byte.Parse(_MaxMineTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_MoneyTextBox.Tag)
                {
                    money = uint.Parse(_MoneyTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_MilitaryFoodTextBox.Tag)
                {
                    militaryFood = uint.Parse(_MilitaryFoodTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_NumOfWarHorsesTextBox.Tag)
                {
                    numOfWarHorses = ushort.Parse(_NumOfWarHorsesTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_NumOfGunsTextBox.Tag)
                {
                    numOfGuns = ushort.Parse(_NumOfGunsTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_NumOfCannonsTextBox.Tag)
                {
                    numOfCannons = ushort.Parse(_NumOfCannonsTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_NumOfSoldiersTextBox.Tag)
                {
                    numOfSoldiers = ushort.Parse(_NumOfSoldiersTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_DegreeOfTrainingTextBox.Tag)
                {
                    degreeOfTraining = byte.Parse(_DegreeOfTrainingTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_MoraleTextBox.Tag)
                {
                    morale = byte.Parse(_MoraleTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_DefensePowerTextBox.Tag)
                {
                    defensePower = byte.Parse(_DefensePowerTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_ResidentSupportTextBox.Tag)
                {
                    residentSupport = byte.Parse(_ResidentSupportTextBox.Text);
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
            int n = _ShiroEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_NameComboBox.Tag)
                {
                    _ShiroEditList[i].NameID = nameId;
                    _ShiroEditList[i].Name = _GameData.NameListDictionary["Kyoten"][nameId];
                }
                if ((bool)_LeaderComboBox.Tag)
                {
                    _ShiroEditList[i].Leader = leaderId;
                }
                if ((bool)_ScaleTextBox.Tag)
                {
                    _ShiroEditList[i].Scale = scale;
                }
                if ((bool)_LocationComboBox.Tag)
                {
                    _ShiroEditList[i].Location = location;
                }
                if ((bool)_PopulationTextBox.Tag)
                {
                    _ShiroEditList[i].Population = population;
                }
                if ((bool)_KokudakaTextBox.Tag)
                {
                    _ShiroEditList[i].Kokudaka = kokudaka;
                }
                if ((bool)_MaxKokudakaTextBox.Tag)
                {
                    _ShiroEditList[i].MaxKokudaka = maxKokudaka;
                }
                if ((bool)_MineTextBox.Tag)
                {
                    _ShiroEditList[i].Mine = mine;
                }
                if ((bool)_MaxMineTextBox.Tag)
                {
                    _ShiroEditList[i].MaxMine = maxMine;
                }
                if ((bool)_MoneyTextBox.Tag)
                {
                    _ShiroEditList[i].Money = money;
                }
                if ((bool)_MilitaryFoodTextBox.Tag)
                {
                    _ShiroEditList[i].MilitaryFood = militaryFood;
                }
                if ((bool)_NumOfWarHorsesTextBox.Tag)
                {
                    _ShiroEditList[i].NumOfWarHorses = numOfWarHorses;
                }
                if ((bool)_NumOfGunsTextBox.Tag)
                {
                    _ShiroEditList[i].NumOfGuns = numOfGuns;
                }
                if ((bool)_NumOfCannonsTextBox.Tag)
                {
                    _ShiroEditList[i].NumOfCannons = numOfCannons;
                }
                if ((bool)_NumOfSoldiersTextBox.Tag)
                {
                    _ShiroEditList[i].NumOfSoldiers = numOfSoldiers;
                }
                if ((bool)_DegreeOfTrainingTextBox.Tag)
                {
                    _ShiroEditList[i].DegreeOfTraining = degreeOfTraining;
                }
                if ((bool)_MoraleTextBox.Tag)
                {
                    _ShiroEditList[i].Morale = morale;
                }
                if ((bool)_DefensePowerTextBox.Tag)
                {
                    _ShiroEditList[i].DefensePower = defensePower;
                }
                if ((bool)_ResidentSupportTextBox.Tag)
                {
                    _ShiroEditList[i].ResidentSupport = residentSupport;
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

    }
}
