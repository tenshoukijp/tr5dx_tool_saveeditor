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
using System.IO;
using DDS;
using Microsoft.International.Converters;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.DataEditForms.ItemEdit
{
    /// <summary>
    /// アイテム関連の基本事項を設定するフォーム
    /// </summary>
    public partial class ItemEditForm : DataEditForm
    {
        #region 定数
        /// <summary>
        /// 拠点画像のフォルダのパス
        /// </summary>
        private static readonly string IMAGE_DIRECTORY_PATH = @"Image/Item/";

        #endregion

        #region フィールド
        /// <summary>
        /// 編集対象のアイテムリスト
        /// </summary>
        private List<Item> _ItemEditList = new List<Item>();

        /// <summary>
        /// 読み込んだ画像リスト
        /// </summary>
        private List<Image> _ImageList = new List<Image>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public ItemEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public ItemEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象のアイテムを全て受け取る
            var items = from item in gameData.ItemList
                         where selectedIDs.Contains(item.ID)
                         select item;
            _ItemEditList.AddRange(items);
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
        private void ItemEditForm_Load(object sender, EventArgs e)
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
            var imageList = _GameData.NameListDictionary["ItemImage"];
            _ImageComboBox.Items.AddRange(imageList.ToArray());
            var typeList = _GameData.NameListDictionary["ItemType"];
            _ItemTypeComboBox.Items.AddRange(typeList.ToArray());
            StringBuilder sb = new StringBuilder();
            var nbusho = GameData.NumOfPeople;
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
            _OwnerComboBox.Items.AddRange(bushoNames);
            _OwnerComboBox.Items.Add(GameData.NoneBushoID + ": なし");

            // 拠点画像の読み込み
            int nimages = imageList.Count;
            for (int i = 0; i < nimages; ++i)
            {
                string fileName = i + ".dds";
                string filePath = IMAGE_DIRECTORY_PATH + fileName;
                if (!File.Exists(filePath))
                {
                    _ImageList.Add(null);
                    continue;
                }
                var ddsImage = DDSImage.Load(filePath);
                _ImageList.Add(ddsImage.Images[0]);
            }

            // 初期値の設定
            string name = _ItemEditList[0].Name;
            string kana = _ItemEditList[0].Kana;
            byte image = _ItemEditList[0].Image;
            ushort price = _ItemEditList[0].Price;
            byte rarity = _ItemEditList[0].Rarity;
            byte itemType = _ItemEditList[0].ItemType;
            byte abilityScores = _ItemEditList[0].AbilityScores;
            byte abilityType = _ItemEditList[0].AbilityType;
            ushort owner = _ItemEditList[0].Owner;
            byte number = _ItemEditList[0].Number;
            byte secretFlag = _ItemEditList[0].SecretFlag;
            // 他と一致するか確認
            bool notMatchedName = false;
            bool notMatchedKana = false;
            bool notMatchedImage = false;
            bool notMatchedPrice = false;
            bool notMatchedRarity = false;
            bool notMatchedItemType = false;
            bool notMatchedAbilityScores = false;
            bool notMatchedAbilityType = false;
            bool notMatchedOwner = false;
            bool notMatchedNumber = false;
            bool notMatchedSecretFlag = false;
            int nedits = _ItemEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (name != _ItemEditList[i].Name)
                    notMatchedName = true;
                if (kana != _ItemEditList[i].Kana)
                    notMatchedKana = true;
                if (image != _ItemEditList[i].Image)
                    notMatchedImage = true;
                if (price != _ItemEditList[i].Price)
                    notMatchedPrice = true;
                if (rarity != _ItemEditList[i].Rarity)
                    notMatchedRarity = true;
                if (itemType != _ItemEditList[i].ItemType)
                    notMatchedItemType = true;
                if (abilityScores != _ItemEditList[i].AbilityScores)
                    notMatchedAbilityScores = true;
                if (abilityType != _ItemEditList[i].AbilityType)
                    notMatchedAbilityType = true;
                if (owner != _ItemEditList[i].Owner)
                    notMatchedOwner = true;
                if (number != _ItemEditList[i].Number)
                    notMatchedNumber = true;
                if (secretFlag != _ItemEditList[i].SecretFlag)
                    notMatchedSecretFlag = true;
            }
            if (!notMatchedName)
            {
                _NameTextBox.Text = name;
            }
            if (!notMatchedKana)
            {
                _KanaTextBox.Text = kana;
            }
            if (!notMatchedImage)
            {
                _ImageComboBox.SelectedIndex = image;
                _ImagePictureBox.Image = _ImageList[image];
            }
            if (!notMatchedPrice)
            {
                _PriceTextBox.Text = price.ToString();
            }
            if (!notMatchedRarity)
            {
                _RarityComboBox.SelectedIndex = rarity;
            }
            if (!notMatchedItemType)
            {
                _ItemTypeComboBox.SelectedIndex = itemType;
            }
            if (!notMatchedAbilityScores)
            {
                _AbilityScoresTextBox.Text = abilityScores.ToString();
            }
            if (!notMatchedAbilityType)
            {
                _AbilityTypeComboBox.SelectedIndex = abilityType;
            }
            if (!notMatchedOwner)
            {
                if (owner != GameData.NoneBushoID)
                    _OwnerComboBox.SelectedIndex = owner;
                else
                    _OwnerComboBox.SelectedIndex = nbusho;
            }
            if (!notMatchedNumber)
            {
                _NumberTextBox.Text = number.ToString();
            }
            if (!notMatchedSecretFlag)
            {
                _SecretFlagCheckBox.Checked = secretFlag != 0;
            }

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _NameTextBox.TextChanged += checker;
            _KanaTextBox.TextChanged += checker;
            _RarityComboBox.SelectedIndexChanged += checker;
            _ItemTypeComboBox.SelectedIndexChanged += checker;
            _AbilityTypeComboBox.SelectedIndexChanged += checker;
            _OwnerComboBox.SelectedIndexChanged += checker;
            _SecretFlagCheckBox.CheckedChanged += checker;
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
                bool badTextFlg = Regex.IsMatch(tb.Text, @"[^0-9]");
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
            _PriceTextBox.TextChanged += checkerForTextBox;
            _AbilityScoresTextBox.TextChanged += checkerForTextBox;
            _NumberTextBox.TextChanged += checkerForTextBox;
            // 画像切替のイベントハンドラ
            _ImageComboBox.SelectedIndexChanged += (sender2, e2) =>
            {
                int index = _ImageComboBox.SelectedIndex;
                _ImagePictureBox.Image = _ImageList[index];
                _ImageComboBox.Tag = true;
            };

            // 既製アイテムなら所有情報以外は変更できないようにする
            if (!_ItemEditList[0].IsCraftItem)
            {
                _NameTextBox.Enabled = false;
                _KanaTextBox.Enabled = false;
                _ImageComboBox.Enabled = false;
                _PriceTextBox.Enabled = false;
                _RarityComboBox.Enabled = false;
                _ItemTypeComboBox.Enabled = false;
                _AbilityTypeComboBox.Enabled = false;
                _AbilityScoresTextBox.Enabled = false;
            }
            else
            {
                _ToolTip.SetToolTip(_ImagePictureBox, @"クリックすると画像一覧から選択");
            }
        }

        /// <summary>
        /// アイテム画像が押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _ImagePictureBox_Click(object sender, EventArgs e)
        {
            if (!_ImageComboBox.Enabled) return;

            // 例外は握りつぶす
            try
            {
                string[] names = new string[_ImageComboBox.Items.Count];
                for (int i = 0; i < names.Length; ++i)
                {
                    names[i] = _ImageComboBox.Items[i].ToString();
                }
                int selected = _ImageComboBox.SelectedIndex;
                if (selected == -1) selected = 0;
                var form = new ImageSelectForm(100, 100, _ImageList.ToArray(), names, selected);
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    _ImageComboBox.SelectedIndex = form.SelectedImageIndex;
                }
                form.Dispose();
            }
            catch { }
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
            string name = "";
            string kana = "";
            byte image = 0;
            ushort price = 0;
            byte rarity = 0;
            byte itemType = 0;
            byte abilityScores = 0;
            byte abilityType = 0;
            ushort owner = 0;
            byte number = 0;
            byte secretFlag = 0;
            try
            {
                if ((bool)_NameTextBox.Tag)
                {
                    name = halfToFull(_NameTextBox.Text);
                    byte[] bytes = sjisEnc.GetBytes(name);
                    if (bytes.Length > 14)
                        throw new Exception();
                    isDataEdited = true;
                }
                if ((bool)_KanaTextBox.Tag)
                {
                    kana = fullToHalf(_KanaTextBox.Text);
                    byte[] bytes = sjisEnc.GetBytes(name);
                    if (bytes.Length > 17)
                        throw new Exception();
                    isDataEdited = true;
                }
                if ((bool)_ImageComboBox.Tag)
                {
                    image = (byte)_ImageComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_PriceTextBox.Tag)
                {
                    price = ushort.Parse(_PriceTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_RarityComboBox.Tag)
                {
                    rarity = (byte)_RarityComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_ItemTypeComboBox.Tag)
                {
                    itemType = (byte)_ItemTypeComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_AbilityScoresTextBox.Tag)
                {
                    abilityScores = byte.Parse(_AbilityScoresTextBox.Text);
                    if (abilityScores > 0x1F)
                        throw new Exception();
                    isDataEdited = true;
                }
                if ((bool)_AbilityTypeComboBox.Tag)
                {
                    abilityType = (byte)_AbilityTypeComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_OwnerComboBox.Tag)
                {
                    owner = ushort.Parse(_OwnerComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_NumberTextBox.Tag)
                {
                    number = byte.Parse(_NumberTextBox.Text);
                    if (number > 0x7F)
                        throw new Exception();
                    isDataEdited = true;
                }
                if ((bool)_SecretFlagCheckBox.Tag)
                {
                    secretFlag = (byte)(_SecretFlagCheckBox.Checked ? 1 : 0);
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
            int n = _ItemEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_NameTextBox.Tag)
                {
                    _ItemEditList[i].Name = name;
                }
                if ((bool)_KanaTextBox.Tag)
                {
                    _ItemEditList[i].Kana = kana;
                }
                if ((bool)_ImageComboBox.Tag)
                {
                    _ItemEditList[i].Image = image;
                }
                if ((bool)_PriceTextBox.Tag)
                {
                    _ItemEditList[i].Price = price;
                    if (price == 0xFFFF)
                    {
                        _ItemEditList[i].IsCrafted = false;
                    }
                    else
                    {
                        _ItemEditList[i].IsCrafted = true;
                    }
                }
                if ((bool)_RarityComboBox.Tag)
                {
                    _ItemEditList[i].Rarity = rarity;
                }
                if ((bool)_ItemTypeComboBox.Tag)
                {
                    _ItemEditList[i].ItemType = itemType;
                }
                if ((bool)_AbilityScoresTextBox.Tag)
                {
                    _ItemEditList[i].AbilityScores = abilityScores;
                }
                if ((bool)_AbilityTypeComboBox.Tag)
                {
                    _ItemEditList[i].AbilityType = abilityType;
                }
                if ((bool)_OwnerComboBox.Tag)
                {
                    _ItemEditList[i].Owner = owner;
                }
                if ((bool)_NumberTextBox.Tag)
                {
                    _ItemEditList[i].Number = number;
                }
                if ((bool)_SecretFlagCheckBox.Tag)
                {
                    _ItemEditList[i].SecretFlag = secretFlag;
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
