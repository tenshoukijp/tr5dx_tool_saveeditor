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
    /// 忍びの里関連の基本事項を設定するフォーム
    /// </summary>
    public partial class SatoEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の里リスト
        /// </summary>
        private List<Sato> _SatoEditList = new List<Sato>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public SatoEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public SatoEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の町を全て受け取る
            var satos = from sato in gameData.KyotenList
                        where selectedIDs.Contains(sato.ID)
                        select (Sato)sato;
            _SatoEditList.AddRange(satos);
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
        private void SatoEditForm_Load(object sender, EventArgs e)
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
            int nameIndex = _SatoEditList[0].NameID;
            int leaderIndex = _SatoEditList[0].Leader;
            byte scale = _SatoEditList[0].Scale;
            byte location = _SatoEditList[0].Location;
            uint money = _SatoEditList[0].Money;
            uint militaryFood = _SatoEditList[0].MilitaryFood;
            byte defensePower = _SatoEditList[0].DefensePower;
            ushort numOfSoldiers = _SatoEditList[0].NumOfSoldiers;
            byte degreeOfTraining = _SatoEditList[0].DegreeOfTraining;
            byte morale = _SatoEditList[0].Morale;
            // 他と一致するか確認
            bool notMatchedNameIndex = false;
            bool notMatchedLeaderIndex = false;
            bool notMatchedScale = false;
            bool notMatchedLocation = false;
            bool notMatchedMoney = false;
            bool notMatchedMilitaryFood = false;
            bool notMatchedDefensePower = false;
            bool notMatchedNumOfSoldiers = false;
            bool notMatchedDegreeOfTraining = false;
            bool notMatchedMorale = false;
            int nedits = _SatoEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (nameIndex != _SatoEditList[i].NameID)
                    notMatchedNameIndex = true;
                if (leaderIndex != _SatoEditList[i].Leader)
                    notMatchedLeaderIndex = true;
                if (scale != _SatoEditList[i].Scale)
                    notMatchedScale = true;
                if (location != _SatoEditList[i].Location)
                    notMatchedLocation = true;
                if (money != _SatoEditList[i].Money)
                    notMatchedMoney = true;
                if (militaryFood != _SatoEditList[i].MilitaryFood)
                    notMatchedMilitaryFood = true;
                if (defensePower != _SatoEditList[i].DefensePower)
                    notMatchedDefensePower = true;
                if (numOfSoldiers != _SatoEditList[i].NumOfSoldiers)
                    notMatchedNumOfSoldiers = true;
                if (degreeOfTraining != _SatoEditList[i].DegreeOfTraining)
                    notMatchedDegreeOfTraining = true;
                if (morale != _SatoEditList[i].Morale)
                    notMatchedMorale = true;
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
                }
                else if (scale >= GameData.ScaleLevels[1])
                {
                    _ScaleLevelLabel.Text = @"(大)";
                }
                else if (scale >= GameData.ScaleLevels[2])
                {
                    _ScaleLevelLabel.Text = @"(中)";
                }
                else
                {
                    _ScaleLevelLabel.Text = @"(小)";
                }
            }
            if (!notMatchedLocation)
            {
                _LocationComboBox.SelectedIndex = location;
            }
            if (!notMatchedMoney)
                _MoneyTextBox.Text = money.ToString();
            if (!notMatchedMilitaryFood)
                _MilitaryFoodTextBox.Text = militaryFood.ToString();
            if (!notMatchedDefensePower)
                _DefensePowerTextBox.Text = defensePower.ToString();
            if (!notMatchedNumOfSoldiers)
                _NumOfSoldiersTextBox.Text = numOfSoldiers.ToString();
            if (!notMatchedDegreeOfTraining)
                _DegreeOfTrainingTextBox.Text = degreeOfTraining.ToString();
            if (!notMatchedMorale)
                _MoraleTextBox.Text = morale.ToString();

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
                        }
                        else if (newScale >= GameData.ScaleLevels[1])
                        {
                            _ScaleLevelLabel.Text = @"(大)";
                        }
                        else if (newScale >= GameData.ScaleLevels[2])
                        {
                            _ScaleLevelLabel.Text = @"(中)";
                        }
                        else
                        {
                            _ScaleLevelLabel.Text = @"(小)";
                        }
                    }
                }
            };
            _ScaleTextBox.TextChanged += checkerForTextBox;
            _MoneyTextBox.TextChanged += checkerForTextBox;
            _MilitaryFoodTextBox.TextChanged += checkerForTextBox;
            _DefensePowerTextBox.TextChanged += checkerForTextBox;
            _NumOfSoldiersTextBox.TextChanged += checkerForTextBox;
            _DegreeOfTrainingTextBox.TextChanged += checkerForTextBox;
            _MoraleTextBox.TextChanged += checkerForTextBox;
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
            uint money = 0;
            uint militaryFood = 0;
            byte defensePower = 0;
            ushort numOfSoldiers = 0;
            byte degreeOfTraining = 0;
            byte morale = 0;
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
                if ((bool)_DefensePowerTextBox.Tag)
                {
                    defensePower = byte.Parse(_DefensePowerTextBox.Text);
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
            int n = _SatoEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_NameComboBox.Tag)
                {
                    _SatoEditList[i].NameID = nameId;
                    _SatoEditList[i].Name = _GameData.NameListDictionary["Kyoten"][nameId];
                }
                if ((bool)_LeaderComboBox.Tag)
                {
                    _SatoEditList[i].Leader = leaderId;
                }
                if ((bool)_ScaleTextBox.Tag)
                {
                    _SatoEditList[i].Scale = scale;
                }
                if ((bool)_LocationComboBox.Tag)
                {
                    _SatoEditList[i].Location = location;
                }
                if ((bool)_MoneyTextBox.Tag)
                {
                    _SatoEditList[i].Money = money;
                }
                if ((bool)_MilitaryFoodTextBox.Tag)
                {
                    _SatoEditList[i].MilitaryFood = militaryFood;
                }
                if ((bool)_DefensePowerTextBox.Tag)
                {
                    _SatoEditList[i].DefensePower = defensePower;
                }
                if ((bool)_NumOfSoldiersTextBox.Tag)
                {
                    _SatoEditList[i].NumOfSoldiers = numOfSoldiers;
                }
                if ((bool)_DegreeOfTrainingTextBox.Tag)
                {
                    _SatoEditList[i].DegreeOfTraining = degreeOfTraining;
                }
                if ((bool)_MoraleTextBox.Tag)
                {
                    _SatoEditList[i].Morale = morale;
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
