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
    /// 戦績、その他を編集するフォーム
    /// </summary>
    public partial class OtherEditForm : DataEditForm
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
        public OtherEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public OtherEditForm(int[] selectedIDs, GameData gameData)
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
        private void OtherEditForm_Load(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            // 兵法指南大名家の設定
            int ndaimyo = GameData.NumOfDaimyoke;
            var daimyoNames = new string[ndaimyo];
            for (int i = 0; i < ndaimyo; ++i)
            {
                stringBuilder.Append(i);
                stringBuilder.Append(": ");
                stringBuilder.Append(_GameData.SeiryokuList[i].Name);
                daimyoNames[i] = stringBuilder.ToString();
                stringBuilder.Clear();
            }
            _InstructionDaimyokeComboBox.Items.AddRange(daimyoNames);
            _InstructionDaimyokeComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");
            if (_Shujinko.InstructionDaimyoke >= ndaimyo)
                _InstructionDaimyokeComboBox.SelectedIndex = ndaimyo;
            else
                _InstructionDaimyokeComboBox.SelectedIndex = _Shujinko.InstructionDaimyoke;
            // 武将一覧を作り、ライバルIDを設定する
            int nbusho = GameData.NumOfBusho + GameData.NumOfGeneralPurpose;
            var bushoNames = new string[nbusho];
            for (int i = 0; i < nbusho; ++i)
            {
                stringBuilder.Append(i);
                stringBuilder.Append(": ");
                stringBuilder.Append(_GameData.BushoList[i].FamilyName);
                stringBuilder.Append(_GameData.BushoList[i].GivenName);
                bushoNames[i] = stringBuilder.ToString();
                stringBuilder.Clear();
            }
            _RivalComboBox.Items.AddRange(bushoNames);
            _RivalComboBox.Items.Add(GameData.NoneBushoID + ": なし");
            if (_Shujinko.Rival >= nbusho)
                _RivalComboBox.SelectedIndex = nbusho;
            else
                _RivalComboBox.SelectedIndex = _Shujinko.Rival;
            // 用心棒ランクは0-7で固定
            _BodyguardRankComboBox.SelectedIndex = _Shujinko.BodyguardRank;
            // テキストボックスの設定
            _NumOfWinsTextBox.Text = _Shujinko.NumOfWins.ToString();
            _NumOfConsecutiveWinsTextBox.Text = _Shujinko.NumOfConsecutiveWins.ToString();
            _NumOfDefeatsTextBox.Text = _Shujinko.NumOfDefeats.ToString();
            _NumOfWinsWithSwordTextBox.Text = _Shujinko.NumOfWinsWithSword.ToString();
            _NumOfWinsWithSpearTextBox.Text = _Shujinko.NumOfWinsWithSpear.ToString();
            _NumOfWinsWithKunaiTextBox.Text = _Shujinko.NumOfWinsWithKunai.ToString();
            _NumOfWinsWithKusarigamaTextBox.Text = _Shujinko.NumOfWinsWithKusarigama.ToString();
            _NumOfWinsWithGunTextBox.Text = _Shujinko.NumOfWinsWithGun.ToString();
            _NumOfWinsWithBowTextBox.Text = _Shujinko.NumOfWinsWithBow.ToString();
            _NumOfDisciplesTextBox.Text = _Shujinko.NumOfDisciples.ToString();
            _DojoMoneyTextBox.Text = _Shujinko.DojoMoney.ToString();
            _BodyguardDaysTextBox.Text = _Shujinko.BodyguardDays.ToString();

            // イベントハンドラの設定 (非テキストボックスでは更新確認のみ)
            EventHandler checkUpdate = (sender2, e2) => _IsDataEdited = true;
            _RivalComboBox.SelectedIndexChanged += checkUpdate;
            _BodyguardRankComboBox.SelectedIndexChanged += checkUpdate;
            _InstructionDaimyokeComboBox.SelectedIndexChanged += checkUpdate;

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
            _NumOfWinsTextBox.TextChanged += checkTextCange;
            _NumOfConsecutiveWinsTextBox.TextChanged += checkTextCange;
            _NumOfDefeatsTextBox.TextChanged += checkTextCange;
            _NumOfWinsWithSwordTextBox.TextChanged += checkTextCange;
            _NumOfWinsWithSpearTextBox.TextChanged += checkTextCange;
            _NumOfWinsWithKunaiTextBox.TextChanged += checkTextCange;
            _NumOfWinsWithKusarigamaTextBox.TextChanged += checkTextCange;
            _NumOfWinsWithGunTextBox.TextChanged += checkTextCange;
            _NumOfWinsWithBowTextBox.TextChanged += checkTextCange;
            _NumOfDisciplesTextBox.TextChanged += checkTextCange;
            _DojoMoneyTextBox.TextChanged += checkTextCange;
            _BodyguardDaysTextBox.TextChanged += checkTextCange;
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
            uint numOfWins = 0;
            uint numOfConsecutiveWins = 0;
            uint numOfDefeats = 0;
            byte numOfWinsWithSword = 0;
            byte numOfWinsWithSpear = 0;
            byte numOfWinsWithKunai = 0;
            byte numOfWinsWithKusarigama = 0;
            byte numOfWinsWithGun = 0;
            byte numOfWinsWithBow = 0;
            ushort numOfDisciples = 0;
            ushort dojoMoney = 0;
            byte instructionDaimyoke = 0;
            ushort rival = 0;
            byte bodyguardDays = 0;
            byte bodyguardRank = 0;

            // UIから入力内容を読み取る
            try
            {
                // キャスト時にエラーが出ないか確認
                numOfWins = uint.Parse(_NumOfWinsTextBox.Text);
                numOfConsecutiveWins = uint.Parse(_NumOfConsecutiveWinsTextBox.Text);
                numOfDefeats = uint.Parse(_NumOfDefeatsTextBox.Text);
                numOfWinsWithSword = byte.Parse(_NumOfWinsWithSwordTextBox.Text);
                numOfWinsWithSpear = byte.Parse(_NumOfWinsWithSpearTextBox.Text);
                numOfWinsWithKunai = byte.Parse(_NumOfWinsWithKunaiTextBox.Text);
                numOfWinsWithKusarigama = byte.Parse(_NumOfWinsWithKusarigamaTextBox.Text);
                numOfWinsWithGun = byte.Parse(_NumOfWinsWithGunTextBox.Text);
                numOfWinsWithBow = byte.Parse(_NumOfWinsWithBowTextBox.Text);
                numOfDisciples = ushort.Parse(_NumOfDisciplesTextBox.Text);
                dojoMoney = ushort.Parse(_DojoMoneyTextBox.Text);
                instructionDaimyoke = byte.Parse(_InstructionDaimyokeComboBox.Text.Split(':')[0]);
                rival = ushort.Parse(_RivalComboBox.Text.Split(':')[0]);
                bodyguardDays = byte.Parse(_BodyguardDaysTextBox.Text);
                bodyguardRank = (byte)_BodyguardRankComboBox.SelectedIndex;
            }
            catch (Exception)
            {
                MessageBox.Show(this, @"不正な入力が含まれています。内容を修正するか、一度このウィンドウを閉じてください。", @"エラー通知", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                _CloseCancelFlag = true;
                return;
            }

            // 内容の反映
            _Shujinko.NumOfWins = numOfWins;
            _Shujinko.NumOfConsecutiveWins = numOfConsecutiveWins;
            _Shujinko.NumOfDefeats = numOfDefeats;
            _Shujinko.NumOfWinsWithSword = numOfWinsWithSword;
            _Shujinko.NumOfWinsWithSpear = numOfWinsWithSpear;
            _Shujinko.NumOfWinsWithKunai = numOfWinsWithKunai;
            _Shujinko.NumOfWinsWithKusarigama = numOfWinsWithKusarigama;
            _Shujinko.NumOfWinsWithGun = numOfWinsWithGun;
            _Shujinko.NumOfWinsWithBow = numOfWinsWithBow;
            _Shujinko.NumOfDisciples = numOfDisciples;
            _Shujinko.DojoMoney = dojoMoney;
            _Shujinko.InstructionDaimyoke = instructionDaimyoke;
            _Shujinko.Rival = rival;
            _Shujinko.BodyguardDays = bodyguardDays;
            _Shujinko.BodyguardRank = bodyguardRank;

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
