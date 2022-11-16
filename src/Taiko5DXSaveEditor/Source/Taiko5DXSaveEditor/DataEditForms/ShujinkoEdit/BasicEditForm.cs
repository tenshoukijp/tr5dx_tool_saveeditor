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
    /// 主人公関連の基本事項を設定するフォーム
    /// </summary>
    public partial class BasicEditForm : DataEditForm
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
        private void BasicEditForm_Load(object sender, EventArgs e)
        {
            // 文字列結合用
            StringBuilder stringBuilder = new StringBuilder();
            // 武将一覧を作り、主人公IDを設定する
            var bushoNames = new string[GameData.NumOfBusho];
            for (int i = 0; i < GameData.NumOfBusho; ++i)
            {
                stringBuilder.Append(i);
                stringBuilder.Append(": ");
                stringBuilder.Append(_GameData.BushoList[i].FamilyName);
                stringBuilder.Append(_GameData.BushoList[i].GivenName);
                bushoNames[i] = stringBuilder.ToString();
                stringBuilder.Clear();
            }
            _IDComboBox.Items.AddRange(bushoNames);
            _IDComboBox.SelectedIndex = _Shujinko.ShujinkoID;
            
            // 武器一覧をコンボボックスに設定
            var weapons = from item in _GameData.ItemList
                          where item.ItemType <= 5
                          where !(item.IsCraftItem && !item.IsCrafted)
                          orderby item.ID
                          select item;
            foreach (var weapon in weapons)
            {
                stringBuilder.Append(weapon.ID);
                stringBuilder.Append(": ");
                stringBuilder.Append(weapon.Name);
                string text = stringBuilder.ToString();
                _WeaponComboBox.Items.Add(text);
                stringBuilder.Clear();
            }
            if (_Shujinko.Weapon != GameData.NoneItemID)
            {
                string search = _Shujinko.Weapon + ": " + _GameData.ItemList[_Shujinko.Weapon].Name;
                int index = _WeaponComboBox.Items.IndexOf(search);
                if (index != -1)
                    _WeaponComboBox.SelectedIndex = index;
            }
            // 防具一覧をコンボボックスに設定
            var armors = from item in _GameData.ItemList
                         where item.ItemType == 6
                         where !(item.IsCraftItem && !item.IsCrafted)
                         orderby item.ID
                         select item;
            foreach (var armor in armors)
            {
                stringBuilder.Append(armor.ID);
                stringBuilder.Append(": ");
                stringBuilder.Append(armor.Name);
                string text = stringBuilder.ToString();
                _ArmorComboBox.Items.Add(text);
                stringBuilder.Clear();
            }
            if (_Shujinko.Armor != GameData.NoneItemID)
            {
                string search = _Shujinko.Armor + ": " + _GameData.ItemList[_Shujinko.Armor].Name;
                int index = _ArmorComboBox.Items.IndexOf(search);
                if (index != -1)
                    _ArmorComboBox.SelectedIndex = index;
            }

            // 体力、所持金、預金、顔グラ、砂鉄、薬草
            _WifeAffectionTextBox.Text = _Shujinko.WifeAffection.ToString();
            _HPTextBox.Text = _Shujinko.HitPoint.ToString();
            _MoneyTextBox.Text = _Shujinko.Money.ToString();
            _BankTextBox.Text = _Shujinko.Bank.ToString();
            _Face1TextBox.Text = _Shujinko.Face1.ToString();
            _Face2TextBox.Text = _Shujinko.Face2.ToString();
            _Face3TextBox.Text = _Shujinko.Face3.ToString();
            _Face4TextBox.Text = _Shujinko.Face4.ToString();
            _IronSandsTextBox.Text = _Shujinko.IronSands.ToString();
            _HerbsTextBox.Text = _Shujinko.Herbs.ToString();
            // 名所カードの設定
            var meishoCardList = _GameData.NameListDictionary["MeishoCard"];
            int ncards1 = meishoCardList.Count;
            ulong meishoFlags = _Shujinko.MeishoCardFlags;
            for (int i = 0; i < ncards1; ++i)
            {
                string text = meishoCardList[i];
                bool flag = (meishoFlags & ((ulong)0x01 << i)) != 0;
                _MeishoCardCheckedListBox.Items.Add(text, flag);
            }
            // その他カードの設定
            var otherCardList = _GameData.NameListDictionary["OtherCard"];
            int ncards2 = otherCardList.Count;
            ulong otherFlags = _Shujinko.OtherCardFlags;
            for (int i = 0; i < ncards2; ++i)
            {
                string text = otherCardList[i];
                bool flag = (otherFlags & ((ulong)0x01 << i)) != 0;
                _OtherCardCheckedListBox.Items.Add(text, flag);
            }

            // イベントハンドラの設定 (非テキストボックスでは更新確認のみ)
            EventHandler checkUpdate = (sender2, e2) => _IsDataEdited = true;
            _WeaponComboBox.SelectedIndexChanged += checkUpdate;
            _ArmorComboBox.SelectedIndexChanged += checkUpdate;
            _MeishoCardCheckedListBox.ItemCheck += (sender2, e2) => checkUpdate(sender2, e2);
            _OtherCardCheckedListBox.ItemCheck += (sender2, e2) => checkUpdate(sender2, e2);
            // IDコンボボックスでは顔IDも合わせる
            _IDComboBox.SelectedIndexChanged += (sender2, e2) =>
            {
                Busho busho = _GameData.BushoList[_IDComboBox.SelectedIndex];
                _Face1TextBox.Text = busho.Face1.ToString();
                _Face2TextBox.Text = busho.Face2.ToString();
                _IsDataEdited = true;
            };

            // テキストボックスの編集前のテキストを確保するための変数
            var controls = from Control control in this.Controls
                           where !(control is Label) && !(control is Button)
                           orderby control.TabIndex
                           select control;
            Control[] controlsArray = controls.ToArray();
            string[] beforeTexts = new string[controlsArray.Length];
            for (int i = 0; i < controlsArray.Length; ++i)
            {
                beforeTexts[i] = controlsArray[i].Text;
            }
            // イベントハンドラの設定 (テキストボックスは数値以外の文字入力の監視も行う)
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
            _WifeAffectionTextBox.TextChanged += checkTextCange;
            _HPTextBox.TextChanged += checkTextCange;
            _MoneyTextBox.TextChanged += checkTextCange;
            _BankTextBox.TextChanged += checkTextCange;
            _Face1TextBox.TextChanged += checkTextCange;
            _Face2TextBox.TextChanged += checkTextCange;
            _Face3TextBox.TextChanged += checkTextCange;
            _Face4TextBox.TextChanged += checkTextCange;
            _IronSandsTextBox.TextChanged += checkTextCange;
            _HerbsTextBox.TextChanged += checkTextCange;
        }

        /// <summary>
        /// カードチェックリストのコンテキストメニューで「全チェック」をクリックした際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void CardContextMenu_All_Click(object sender, EventArgs e)
        {
            // 名所
            if (_CardContextMenu.SourceControl == _MeishoCardCheckedListBox)
            {
                int n = _MeishoCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _MeishoCardCheckedListBox.SetItemChecked(i, true);
                }
            }
            // その他
            else if (_CardContextMenu.SourceControl == _OtherCardCheckedListBox)
            {
                int n = _OtherCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _OtherCardCheckedListBox.SetItemChecked(i, true);
                }
            }
        }

        /// <summary>
        /// カードチェックリストのコンテキストメニューで「全解除」をクリックした際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void CardContextMenu_Clear_Click(object sender, EventArgs e)
        {
            // 名所
            if (_CardContextMenu.SourceControl == _MeishoCardCheckedListBox)
            {
                int n = _MeishoCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _MeishoCardCheckedListBox.SetItemChecked(i, false);
                }
            }
            // その他
            else if (_CardContextMenu.SourceControl == _OtherCardCheckedListBox)
            {
                int n = _OtherCardCheckedListBox.Items.Count;
                for (int i = 0; i < n; ++i)
                {
                    _OtherCardCheckedListBox.SetItemChecked(i, false);
                }
            }
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
            ushort id = 0;
            ushort weapon = 0;
            ushort armor = 0;
            byte wifeAffection = 0;
            byte hp = 0;
            uint money = 0;
            uint bank = 0;
            ushort face1 = 0;
            ushort face2 = 0;
            ushort face3 = 0;
            ushort face4 = 0;
            ushort ironSands = 0;
            ushort herbs = 0;
            ulong meishoFlags = 0;
            ulong otherFlags = 0;

            // UIから入力内容を読み取る
            try
            {
                // キャスト時にエラーが出ないか確認
                id = (ushort)_IDComboBox.SelectedIndex;
                if (_WeaponComboBox.SelectedIndex != -1)
                    weapon = ushort.Parse(_WeaponComboBox.Text.Split(':')[0]);
                else
                    weapon = _Shujinko.Weapon;
                if (_ArmorComboBox.SelectedIndex != -1)
                    armor = ushort.Parse(_ArmorComboBox.Text.Split(':')[0]);
                else
                    armor = _Shujinko.Armor;
                wifeAffection = byte.Parse(_WifeAffectionTextBox.Text);
                hp = byte.Parse(_HPTextBox.Text);
                money = uint.Parse(_MoneyTextBox.Text);
                bank = uint.Parse(_BankTextBox.Text);
                face1 = ushort.Parse(_Face1TextBox.Text);
                face2 = ushort.Parse(_Face2TextBox.Text);
                face3 = ushort.Parse(_Face3TextBox.Text);
                face4 = ushort.Parse(_Face4TextBox.Text);
                ironSands = ushort.Parse(_IronSandsTextBox.Text);
                herbs = ushort.Parse(_HerbsTextBox.Text);
                int n1 = _MeishoCardCheckedListBox.Items.Count;
                for (int i = 0; i < n1; ++i)
                {
                    meishoFlags = meishoFlags | ((ulong)(_MeishoCardCheckedListBox.GetItemChecked(i) ? 1 : 0) << i);
                }
                int n2 = _OtherCardCheckedListBox.Items.Count;
                for (int i = 0; i < n2; ++i)
                {
                    otherFlags = otherFlags | ((ulong)(_OtherCardCheckedListBox.GetItemChecked(i) ? 1 : 0) << i);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, @"不正な入力が含まれています。内容を修正するか、一度このウィンドウを閉じてください。", @"エラー通知", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                _CloseCancelFlag = true;
                return;
            }

            // 内容の反映
            _Shujinko.ShujinkoID = id;
            _Shujinko.Weapon = weapon;
            _Shujinko.Armor = armor;
            _Shujinko.WifeAffection = wifeAffection;
            _Shujinko.HitPoint = hp;
            _Shujinko.Money = money;
            _Shujinko.Bank = bank;
            _Shujinko.Face1 = face1;
            _Shujinko.Face2 = face2;
            _Shujinko.Face3 = face3;
            _Shujinko.Face4 = face4;
            _Shujinko.IronSands = ironSands;
            _Shujinko.Herbs = herbs;
            _Shujinko.MeishoCardFlags = meishoFlags;
            _Shujinko.OtherCardFlags = otherFlags;

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
