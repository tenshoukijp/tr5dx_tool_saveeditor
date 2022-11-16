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

namespace Taiko5DXSaveEditor.DataEditForms.WorldEdit
{
    /// <summary>
    /// 世界関連の基本事項を設定するフォーム
    /// </summary>
    public partial class WorldEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 世界
        /// </summary>
        private World _World = null;

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
        public WorldEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public WorldEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            _World = gameData.World;
            InitializeComponent();
        }


        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォームがロードされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void WorldEditForm_Load(object sender, EventArgs e)
        {
            // シナリオ一覧
            var scenarioList = _GameData.NameListDictionary["Scenario"];
            _ScenarioComboBox.Items.AddRange(scenarioList.ToArray());
            // データの読み取り
            _ScenarioComboBox.SelectedIndex = _World.ScenarioNumber;
            _PlayDaysTextBox.Text = _World.PlayDays.ToString();
            _YearTextBox.Text = (_World.Year + 1500).ToString();
            _MonthComboBox.SelectedIndex = _World.Month;
            _DayComboBox.SelectedIndex = _World.Day;
            _TimeComboBox.SelectedIndex = _World.Time;
            _NextMeetingDaysTextBox.Text = _World.NextMeetingDays.ToString();
            // イベントハンドラの設定 (非テキストボックスでは更新確認のみ)
            EventHandler checkUpdate = (sender2, e2) => _IsDataEdited = true;
            _ScenarioComboBox.SelectedIndexChanged += checkUpdate;
            _MonthComboBox.SelectedIndexChanged += checkUpdate;
            _DayComboBox.SelectedIndexChanged += checkUpdate;
            _TimeComboBox.SelectedIndexChanged += checkUpdate;

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
            _PlayDaysTextBox.TextChanged += checkTextCange;
            _YearTextBox.TextChanged += checkTextCange;
            _NextMeetingDaysTextBox.TextChanged += checkTextCange;
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
            byte scenario = 0;
            ushort playDays = 0;
            byte year = 0;
            byte month = 0;
            byte day = 0;
            byte time = 0;
            byte nextMeetingDays = 0;

            // UIから入力内容を読み取る
            try
            {
                // キャスト時にエラーが出ないか確認
                scenario = (byte)_ScenarioComboBox.SelectedIndex;
                playDays = ushort.Parse(_PlayDaysTextBox.Text);
                month = (byte)_MonthComboBox.SelectedIndex;
                day = (byte)_DayComboBox.SelectedIndex;
                time = (byte)_TimeComboBox.SelectedIndex;
                nextMeetingDays = byte.Parse(_NextMeetingDaysTextBox.Text);
                int val = int.Parse(_YearTextBox.Text) - 1500;
                if ((val < 0) || (255 < val))
                    throw new Exception();
                year = (byte)val;
            }
            catch (Exception)
            {
                MessageBox.Show(this, @"不正な入力が含まれています。内容を修正するか、一度このウィンドウを閉じてください。", @"エラー通知", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                _CloseCancelFlag = true;
                return;
            }

            // 内容の反映
            _World.ScenarioNumber = scenario;
            _World.PlayDays = playDays;
            _World.Year = year;
            _World.Month = month;
            _World.Day = day;
            _World.Time = time;
            _World.NextMeetingDays = nextMeetingDays;

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
