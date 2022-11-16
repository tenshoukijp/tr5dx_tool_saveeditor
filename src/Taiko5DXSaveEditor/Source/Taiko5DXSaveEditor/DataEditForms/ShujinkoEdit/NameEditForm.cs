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
using Microsoft.International.Converters;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.DataEditForms.ShujinkoEdit
{
    /// <summary>
    /// 名前編集フォーム
    /// </summary>
    public partial class NameEditForm : DataEditForm
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
        public NameEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public NameEditForm(int[] selectedIDs, GameData gameData)
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
        private void NameEditForm_Load(object sender, EventArgs e)
        {
            // テキストボックスに初期値を入れる
            _NameOfMyRyuhaTextBox.Text = _Shujinko.NameOfMyRyuha;
            _KanaOfMyRyuhaTextBox.Text = _Shujinko.KanaOfMyRyuha;
            _NameOfMyShokaTextBox.Text = _Shujinko.NameOfMyShoka;
            _KanaOfMyShokaTextBox.Text = _Shujinko.KanaOfMyShoka;

            // イベントハンドラの設定
            EventHandler checkTextCange = (sender2, e2) => _IsDataEdited = true;
            _NameOfMyRyuhaTextBox.TextChanged += checkTextCange;
            _KanaOfMyRyuhaTextBox.TextChanged += checkTextCange;
            _NameOfMyShokaTextBox.TextChanged += checkTextCange;
            _KanaOfMyShokaTextBox.TextChanged += checkTextCange;
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

            // 前処理を行い入力ミスをなるべく解消する
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
            string nameOfMyRyuha = halfToFull(_NameOfMyRyuhaTextBox.Text);
            string kanaOfMyRyuha = fullToHalf(_KanaOfMyRyuhaTextBox.Text);
            string nameOfMyShoka = halfToFull(_NameOfMyShokaTextBox.Text);
            string kanaOfMyShoka = fullToHalf(_KanaOfMyShokaTextBox.Text);

            // 入力内容が正しいかチェックする
            try
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                // 流派名チェック
                byte[] bytesNameOfMyRyuha = sjisEnc.GetBytes(nameOfMyRyuha);
                if (bytesNameOfMyRyuha.Length > 8)
                    throw new Exception();
                // 流派名かなチェック
                byte[] bytesKanaOfMyRyuha = sjisEnc.GetBytes(kanaOfMyRyuha);
                if (bytesKanaOfMyRyuha.Length > 13)
                    throw new Exception();
                if (System.Text.RegularExpressions.Regex.IsMatch(kanaOfMyRyuha, @"[^ｦ-ﾟ]"))
                    throw new Exception();
                // 屋号チェック
                byte[] bytesNameOfMyShoka = sjisEnc.GetBytes(nameOfMyShoka);
                if (bytesNameOfMyShoka.Length > 6)
                    throw new Exception();
                // 屋号かなチェック
                byte[] bytesKanaOfMyShoka = sjisEnc.GetBytes(kanaOfMyShoka);
                if (bytesNameOfMyRyuha.Length > 11)
                    throw new Exception();
                if (System.Text.RegularExpressions.Regex.IsMatch(kanaOfMyShoka, @"[^ｦ-ﾟ]"))
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show(this, @"不正な入力が含まれています。内容を修正するか、一度このウィンドウを閉じてください。", @"エラー通知", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                _CloseCancelFlag = true;
                return;
            }

            // 内容の反映
            _Shujinko.NameOfMyRyuha = nameOfMyRyuha;
            _Shujinko.KanaOfMyRyuha = kanaOfMyRyuha;
            _Shujinko.NameOfMyShoka = nameOfMyShoka;
            _Shujinko.KanaOfMyShoka = kanaOfMyShoka;

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
