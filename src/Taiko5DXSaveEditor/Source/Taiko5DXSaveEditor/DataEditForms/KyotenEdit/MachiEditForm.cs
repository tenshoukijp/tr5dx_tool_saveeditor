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
    /// 町関連の基本事項を設定するフォーム
    /// </summary>
    public partial class MachiEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の町リスト
        /// </summary>
        private List<Machi> _MachiEditList = new List<Machi>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public MachiEditForm()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public MachiEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の町を全て受け取る
            var machis = from machi in gameData.KyotenList
                         where selectedIDs.Contains(machi.ID)
                         select (Machi)machi;
            _MachiEditList.AddRange(machis);
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
        private void MachiEditForm_Load(object sender, EventArgs e)
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
            // 初期値の設定
            int nameIndex = _MachiEditList[0].NameID;
            byte scale = _MachiEditList[0].Scale;
            byte location = _MachiEditList[0].Location;
            uint money = _MachiEditList[0].Money;
            byte riceMarketPrice = _MachiEditList[0].RiceMarketPrice;
            byte riceInventory = _MachiEditList[0].RiceInventory;
            byte horseMarketPrice = _MachiEditList[0].HorseMarketPrice;
            byte horseInventory = _MachiEditList[0].HorseInventory;
            // 他と一致するか確認
            bool notMatchedNameIndex = false;
            bool notMatchedScale = false;
            bool notMatchedLocation = false;
            bool notMatchedMoney = false;
            bool notMatchedRiceMarketPrice = false;
            bool notMatchedRiceInventory = false;
            bool notMatchedHorseMarketPrice = false;
            bool notMatchedHorseInventory = false;
            int nedits = _MachiEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (nameIndex != _MachiEditList[i].NameID)
                    notMatchedNameIndex = true;
                if (scale != _MachiEditList[i].Scale)
                    notMatchedScale = true;
                if (location != _MachiEditList[i].Location)
                    notMatchedLocation = true;
                if (money != _MachiEditList[i].Money)
                    notMatchedMoney = true;
                if (riceMarketPrice != _MachiEditList[i].RiceMarketPrice)
                    notMatchedRiceMarketPrice = true;
                if (riceInventory != _MachiEditList[i].RiceInventory)
                    notMatchedRiceInventory = true;
                if (horseMarketPrice != _MachiEditList[i].HorseMarketPrice)
                    notMatchedHorseMarketPrice = true;
                if (horseInventory != _MachiEditList[i].HorseInventory)
                    notMatchedHorseInventory = true;
            }
            if (!notMatchedNameIndex)
                _NameComboBox.SelectedIndex = nameIndex;
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
            {
                _MoneyTextBox.Text = money.ToString();
            }
            if (!notMatchedRiceMarketPrice)
            {
                _RiceMarketPriceTextBox.Text = riceMarketPrice.ToString();
            }
            if (!notMatchedRiceInventory)
            {
                _RiceInventoryTextBox.Text = riceInventory.ToString();
            }
            if (!notMatchedHorseMarketPrice)
            {
                _HorseMarketPriceTextBox.Text = horseMarketPrice.ToString();
            }
            if (!notMatchedHorseInventory)
            {
                _HorseInventoryTextBox.Text = horseInventory.ToString();
            }

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _NameComboBox.SelectedIndexChanged += checker;
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
            _RiceMarketPriceTextBox.TextChanged += checkerForTextBox;
            _RiceInventoryTextBox.TextChanged += checkerForTextBox;
            _HorseMarketPriceTextBox.TextChanged += checkerForTextBox;
            _HorseInventoryTextBox.TextChanged += checkerForTextBox;
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
            byte scale = 0;
            byte location = 0;
            uint money = 0;
            byte riceMarketPrice = 0;
            byte riceInventory = 0;
            byte horseMarketPrice = 0;
            byte horseInventory = 0;
            try
            {
                if ((bool)_NameComboBox.Tag)
                {
                    nameId = (ushort)_NameComboBox.SelectedIndex;
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
                if ((bool)_RiceMarketPriceTextBox.Tag)
                {
                    riceMarketPrice = byte.Parse(_RiceMarketPriceTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_RiceInventoryTextBox.Tag)
                {
                    riceInventory = byte.Parse(_RiceInventoryTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_HorseMarketPriceTextBox.Tag)
                {
                    horseMarketPrice = byte.Parse(_HorseMarketPriceTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_HorseInventoryTextBox.Tag)
                {
                    horseInventory = byte.Parse(_HorseInventoryTextBox.Text);
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
            int n = _MachiEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_NameComboBox.Tag)
                {
                    _MachiEditList[i].NameID = nameId;
                    _MachiEditList[i].Name = _GameData.NameListDictionary["Kyoten"][nameId];
                }
                if ((bool)_ScaleTextBox.Tag)
                {
                    _MachiEditList[i].Scale = scale;
                }
                if ((bool)_LocationComboBox.Tag)
                {
                    _MachiEditList[i].Location = location;
                }
                if ((bool)_MoneyTextBox.Tag)
                {
                    _MachiEditList[i].Money = money;
                }
                if ((bool)_RiceMarketPriceTextBox.Tag)
                {
                    _MachiEditList[i].RiceMarketPrice = riceMarketPrice;
                }
                if ((bool)_RiceInventoryTextBox.Tag)
                {
                    _MachiEditList[i].RiceInventory = riceInventory;
                }
                if ((bool)_HorseMarketPriceTextBox.Tag)
                {
                    _MachiEditList[i].HorseMarketPrice = horseMarketPrice;
                }
                if ((bool)_HorseInventoryTextBox.Tag)
                {
                    _MachiEditList[i].HorseInventory = horseInventory;
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
