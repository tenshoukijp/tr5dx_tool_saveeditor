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
    /// 町の交易品を設定するフォーム
    /// </summary>
    public partial class TradeGoodsEditForm : DataEditForm
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
        public TradeGoodsEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public TradeGoodsEditForm(int[] selectedIDs, GameData gameData)
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
        private void TradeGoodsEditForm_Load(object sender, EventArgs e)
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
            var nameList = _GameData.NameListDictionary["TradeGoods"];
            _TradeGoods1ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods2ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods3ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods4ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods5ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods6ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods7ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods8ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods9ComboBox.Items.AddRange(nameList.ToArray());
            _TradeGoods10ComboBox.Items.AddRange(nameList.ToArray());
            string none = @"なし";
            _TradeGoods1ComboBox.Items.Add(none);
            _TradeGoods2ComboBox.Items.Add(none);
            _TradeGoods3ComboBox.Items.Add(none);
            _TradeGoods4ComboBox.Items.Add(none);
            _TradeGoods5ComboBox.Items.Add(none);
            _TradeGoods6ComboBox.Items.Add(none);
            _TradeGoods7ComboBox.Items.Add(none);
            _TradeGoods8ComboBox.Items.Add(none);
            _TradeGoods9ComboBox.Items.Add(none);
            _TradeGoods10ComboBox.Items.Add(none);

            // 初期値の設定
            byte[] tradeGoods = new byte[10];
            byte[] tradeGoodsSupplyRate = new byte[10];
            for (int i = 0; i < 10; ++i)
            {
                tradeGoods[i] = _MachiEditList[0].TradeGoods[i];
                tradeGoodsSupplyRate[i] = _MachiEditList[0].TradeGoodsSupplyRate[i];
            }
            // 他と一致するか確認
            bool[] notMatchedTradeGoods = new bool[10];
            bool[] notMatchedTradeGoodsSupplyRate = new bool[10];
            int nedits = _MachiEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if (tradeGoods[j] != _MachiEditList[i].TradeGoods[j])
                        notMatchedTradeGoods[j] = true;
                    if (tradeGoodsSupplyRate[j] != _MachiEditList[i].TradeGoodsSupplyRate[j])
                        notMatchedTradeGoodsSupplyRate[j] = true;
                }
            }
            ComboBox[] comboBoxs = new ComboBox[10] { _TradeGoods1ComboBox, _TradeGoods2ComboBox, _TradeGoods3ComboBox, _TradeGoods4ComboBox, _TradeGoods5ComboBox, _TradeGoods6ComboBox, _TradeGoods7ComboBox, _TradeGoods8ComboBox, _TradeGoods9ComboBox, _TradeGoods10ComboBox };
            TextBox[] textBoxs = new TextBox[10] { _TradeGoodsSupplyRate1TextBox, _TradeGoodsSupplyRate2TextBox, _TradeGoodsSupplyRate3TextBox, _TradeGoodsSupplyRate4TextBox, _TradeGoodsSupplyRate5TextBox, _TradeGoodsSupplyRate6TextBox, _TradeGoodsSupplyRate7TextBox, _TradeGoodsSupplyRate8TextBox, _TradeGoodsSupplyRate9TextBox, _TradeGoodsSupplyRate10TextBox };
            for (int i = 0; i < 10; ++i)
            {
                if (!notMatchedTradeGoods[i])
                {
                    if (tradeGoods[i] != GameData.NoneTradeGoodsID)
                        comboBoxs[i].SelectedIndex = tradeGoods[i];
                    else
                        comboBoxs[i].SelectedIndex = comboBoxs[i].Items.Count - 1;
                }
                if (!notMatchedTradeGoodsSupplyRate[i])
                {
                    textBoxs[i].Text = tradeGoodsSupplyRate[i].ToString();
                }
            }

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
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
                }
            };
            for (int i = 0; i < 10; ++i)
            {
                comboBoxs[i].SelectedIndexChanged += checker;
                textBoxs[i].TextChanged += checkerForTextBox;
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

            // UIから入力内容を読み取る
            byte[] tradeGoods = new byte[10];
            byte[] tradeGoodsSupplyRate = new byte[10];
            ComboBox[] comboBoxs = new ComboBox[10] { _TradeGoods1ComboBox, _TradeGoods2ComboBox, _TradeGoods3ComboBox, _TradeGoods4ComboBox, _TradeGoods5ComboBox, _TradeGoods6ComboBox, _TradeGoods7ComboBox, _TradeGoods8ComboBox, _TradeGoods9ComboBox, _TradeGoods10ComboBox };
            TextBox[] textBoxs = new TextBox[10] { _TradeGoodsSupplyRate1TextBox, _TradeGoodsSupplyRate2TextBox, _TradeGoodsSupplyRate3TextBox, _TradeGoodsSupplyRate4TextBox, _TradeGoodsSupplyRate5TextBox, _TradeGoodsSupplyRate6TextBox, _TradeGoodsSupplyRate7TextBox, _TradeGoodsSupplyRate8TextBox, _TradeGoodsSupplyRate9TextBox, _TradeGoodsSupplyRate10TextBox };
            try
            {
                for (int i = 0; i < 10; ++i)
                {
                    if ((bool)comboBoxs[i].Tag)
                    {
                        if (comboBoxs[i].SelectedIndex != (comboBoxs[i].Items.Count - 1))
                            tradeGoods[i] = (byte)comboBoxs[i].SelectedIndex;
                        else
                            tradeGoods[i] = GameData.NoneTradeGoodsID;
                        isDataEdited = true;
                    }
                    if ((bool)textBoxs[i].Tag)
                    {
                        tradeGoodsSupplyRate[i] = byte.Parse(textBoxs[i].Text);
                        isDataEdited = true;
                    }
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
                for (int j = 0; j < 10; ++j)
                {
                    if ((bool)comboBoxs[j].Tag)
                    {
                        _MachiEditList[i].TradeGoods[j] = tradeGoods[j];
                    }
                    if ((bool)textBoxs[j].Tag)
                    {
                        _MachiEditList[i].TradeGoodsSupplyRate[j] = tradeGoodsSupplyRate[j];
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

    }
}
