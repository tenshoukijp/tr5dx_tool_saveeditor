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
    /// 海賊砦関連の基本事項を設定するフォーム
    /// </summary>
    public partial class TorideEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の砦リスト
        /// </summary>
        private List<Toride> _TorideEditList = new List<Toride>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public TorideEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public TorideEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の町を全て受け取る
            var torides = from toride in gameData.KyotenList
                          where selectedIDs.Contains(toride.ID)
                          select (Toride)toride;
            _TorideEditList.AddRange(torides);
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
        private void TorideEditForm_Load(object sender, EventArgs e)
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
            int nameIndex = _TorideEditList[0].NameID;
            int leaderIndex = _TorideEditList[0].Leader;
            byte scale = _TorideEditList[0].Scale;
            byte location = _TorideEditList[0].Location;
            uint money = _TorideEditList[0].Money;
            uint militaryFood = _TorideEditList[0].MilitaryFood;
            byte degreeOfTraining = _TorideEditList[0].DegreeOfTraining;
            byte morale = _TorideEditList[0].Morale;
            byte defensePower = _TorideEditList[0].DefensePower;
            ushort numOfWeakWarships = _TorideEditList[0].NumOfWeakWarships;
            ushort numOfMiddleWarships = _TorideEditList[0].NumOfMiddleWarships;
            ushort numOfStrongWarships = _TorideEditList[0].NumOfStrongWarships;
            // 他と一致するか確認
            bool notMatchedNameIndex = false;
            bool notMatchedLeaderIndex = false;
            bool notMatchedScale = false;
            bool notMatchedLocation = false;
            bool notMatchedMoney = false;
            bool notMatchedMilitaryFood = false;
            bool notMatchedDegreeOfTraining = false;
            bool notMatchedMorale = false;
            bool notMatchedDefensePower = false;
            bool notMatchedNumOfWeakWarships = false;
            bool notMatchedNumOfMiddleWarships = false;
            bool notMatchedNumOfStrongWarships = false;
            int nedits = _TorideEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (nameIndex != _TorideEditList[i].NameID)
                    notMatchedNameIndex = true;
                if (leaderIndex != _TorideEditList[i].Leader)
                    notMatchedLeaderIndex = true;
                if (scale != _TorideEditList[i].Scale)
                    notMatchedScale = true;
                if (location != _TorideEditList[i].Location)
                    notMatchedLocation = true;
                if (money != _TorideEditList[i].Money)
                    notMatchedMoney = true;
                if (militaryFood != _TorideEditList[i].MilitaryFood)
                    notMatchedMilitaryFood = true;
                if (degreeOfTraining != _TorideEditList[i].DegreeOfTraining)
                    notMatchedDegreeOfTraining = true;
                if (morale != _TorideEditList[i].Morale)
                    notMatchedMorale = true;
                if (defensePower != _TorideEditList[i].DefensePower)
                    notMatchedDefensePower = true;
                if (numOfWeakWarships != _TorideEditList[i].NumOfWeakWarships)
                    notMatchedNumOfWeakWarships = true;
                if (numOfMiddleWarships != _TorideEditList[i].NumOfMiddleWarships)
                    notMatchedNumOfMiddleWarships = true;
                if (numOfStrongWarships != _TorideEditList[i].NumOfStrongWarships)
                    notMatchedNumOfStrongWarships = true;
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
            if (!notMatchedDegreeOfTraining)
                _DegreeOfTrainingTextBox.Text = degreeOfTraining.ToString();
            if (!notMatchedMorale)
                _MoraleTextBox.Text = morale.ToString();
            if (!notMatchedDefensePower)
                _DefensePowerTextBox.Text = defensePower.ToString();
            if (!notMatchedNumOfWeakWarships)
                _NumOfWeakWarshipsTextBox.Text = numOfWeakWarships.ToString();
            if (!notMatchedNumOfMiddleWarships)
                _NumOfMiddleWarshipsTextBox.Text = numOfMiddleWarships.ToString();
            if (!notMatchedNumOfStrongWarships)
                _NumOfStrongWarshipsTextBox.Text = numOfStrongWarships.ToString();

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
            _DegreeOfTrainingTextBox.TextChanged += checkerForTextBox;
            _MoraleTextBox.TextChanged += checkerForTextBox;
            _DefensePowerTextBox.TextChanged += checkerForTextBox;
            _NumOfWeakWarshipsTextBox.TextChanged += checkerForTextBox;
            _NumOfMiddleWarshipsTextBox.TextChanged += checkerForTextBox;
            _NumOfStrongWarshipsTextBox.TextChanged += checkerForTextBox;
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
            byte degreeOfTraining = 0;
            byte morale = 0;
            byte defensePower = 0;
            ushort numOfWeakWarships = 0;
            ushort numOfMiddleWarships = 0;
            ushort numOfStrongWarships = 0;
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
                if ((bool)_NumOfWeakWarshipsTextBox.Tag)
                {
                    numOfWeakWarships = ushort.Parse(_NumOfWeakWarshipsTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_NumOfMiddleWarshipsTextBox.Tag)
                {
                    numOfMiddleWarships = ushort.Parse(_NumOfMiddleWarshipsTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_NumOfStrongWarshipsTextBox.Tag)
                {
                    numOfStrongWarships = ushort.Parse(_NumOfStrongWarshipsTextBox.Text);
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
            int n = _TorideEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_NameComboBox.Tag)
                {
                    _TorideEditList[i].NameID = nameId;
                    _TorideEditList[i].Name = _GameData.NameListDictionary["Kyoten"][nameId];
                }
                if ((bool)_LeaderComboBox.Tag)
                {
                    _TorideEditList[i].Leader = leaderId;
                }
                if ((bool)_ScaleTextBox.Tag)
                {
                    _TorideEditList[i].Scale = scale;
                }
                if ((bool)_LocationComboBox.Tag)
                {
                    _TorideEditList[i].Location = location;
                }
                if ((bool)_MoneyTextBox.Tag)
                {
                    _TorideEditList[i].Money = money;
                }
                if ((bool)_MilitaryFoodTextBox.Tag)
                {
                    _TorideEditList[i].MilitaryFood = militaryFood;
                }
                if ((bool)_DegreeOfTrainingTextBox.Tag)
                {
                    _TorideEditList[i].DegreeOfTraining = degreeOfTraining;
                }
                if ((bool)_MoraleTextBox.Tag)
                {
                    _TorideEditList[i].Morale = morale;
                }
                if ((bool)_DefensePowerTextBox.Tag)
                {
                    _TorideEditList[i].DefensePower = defensePower;
                }
                if ((bool)_NumOfWeakWarshipsTextBox.Tag)
                {
                    _TorideEditList[i].NumOfWeakWarships = numOfWeakWarships;
                }
                if ((bool)_NumOfMiddleWarshipsTextBox.Tag)
                {
                    _TorideEditList[i].NumOfMiddleWarships = numOfMiddleWarships;
                }
                if ((bool)_NumOfStrongWarshipsTextBox.Tag)
                {
                    _TorideEditList[i].NumOfStrongWarships = numOfStrongWarships;
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
