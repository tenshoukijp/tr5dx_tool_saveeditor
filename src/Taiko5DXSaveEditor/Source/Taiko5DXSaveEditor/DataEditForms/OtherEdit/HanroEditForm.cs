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
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.DataEditForms.OtherEdit
{
    /// <summary>
    /// 販路を設定するフォーム
    /// </summary>
    public partial class HanroEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の販路リスト
        /// </summary>
        private List<Hanro> _HanroEditList = new List<Hanro>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public HanroEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public HanroEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の武将を全て受け取る
            var hanros = from hanro in gameData.HanroList
                         where selectedIDs.Contains(hanro.ID)
                         select hanro;
            _HanroEditList.AddRange(hanros);

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
        private void HanroEditForm_Load(object sender, EventArgs e)
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
            StringBuilder sb = new StringBuilder();
            var nmachi = GameData.NumOfMachi;
            var machiNames = new string[nmachi];
            for (int i = 0; i < nmachi; ++i)
            {
                int index = GameData.NumOfShiro + i;
                sb.Append(index);
                sb.Append(": ");
                sb.Append(_GameData.KyotenList[index].Name);
                machiNames[i] = sb.ToString();
                sb.Clear();
            }
            _Machi1ComboBox.Items.AddRange(machiNames);
            _Machi2ComboBox.Items.AddRange(machiNames);
            _Machi1ComboBox.Items.Add(GameData.NoneKyotenID + ": なし");
            _Machi2ComboBox.Items.Add(GameData.NoneKyotenID + ": なし");
            var nbusho = GameData.NumOfPeople;
            var bushoNames = new string[nbusho];
            for (int i = 0; i < nbusho; ++i)
            {
                int index = i;
                sb.Append(index);
                sb.Append(": ");
                sb.Append(_GameData.BushoList[index].FamilyName);
                sb.Append(_GameData.BushoList[index].GivenName);
                bushoNames[i] = sb.ToString();
                sb.Clear();
            }
            _AdministratorComboBox.Items.AddRange(bushoNames);
            _AdministratorComboBox.Items.Add(GameData.NoneBushoID + ": なし");
            var nguard = GameData.NumOfNinjaShu + GameData.NumOfKaizokuShu;
            var guardNames = new string[nguard];
            for (int i = 0; i < nguard; ++i)
            {
                int index = GameData.NumOfDaimyoke + GameData.NumOfShoka + i;
                sb.Append(index);
                sb.Append(": ");
                sb.Append(_GameData.SeiryokuList[index].Name);
                guardNames[i] = sb.ToString();
                sb.Clear();
            }
            _GuardComboBox.Items.AddRange(guardNames);
            _GuardComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");
            // 初期値の設定
            ushort machi1 = _HanroEditList[0].Machi1;
            ushort machi2 = _HanroEditList[0].Machi2;
            ushort administrator = _HanroEditList[0].Administrator;
            byte guard = _HanroEditList[0].Guard;
            int kanjo = _HanroEditList[0].Kanjo;
            ushort maintenanceCosts = _HanroEditList[0].MaintenanceCosts;
            byte type = _HanroEditList[0].Type;
            byte stopping = _HanroEditList[0].Stopping;
            // 他と一致するか確認
            bool notMatchedMachi1 = false;
            bool notMatchedMachi2 = false;
            bool notMatchedAdministrator = false;
            bool notMatchedGuard = false;
            bool notMatchedKanjo = false;
            bool notMatchedMaintenanceCosts = false;
            bool notMatchedType = false;
            bool notMatchedStopping = false;
            int nedits = _HanroEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (machi1 != _HanroEditList[i].Machi1)
                    notMatchedMachi1 = true;
                if (machi2 != _HanroEditList[i].Machi2)
                    notMatchedMachi2 = true;
                if (administrator != _HanroEditList[i].Administrator)
                    notMatchedAdministrator = true;
                if (guard != _HanroEditList[i].Guard)
                    notMatchedGuard = true;
                if (kanjo != _HanroEditList[i].Kanjo)
                    notMatchedKanjo = true;
                if (maintenanceCosts != _HanroEditList[i].MaintenanceCosts)
                    notMatchedMaintenanceCosts = true;
                if (type != _HanroEditList[i].Type)
                    notMatchedType = true;
                if (stopping != _HanroEditList[i].Stopping)
                    notMatchedStopping = true;
            }
            if (!notMatchedMachi1)
            {
                if (machi1 != GameData.NoneKyotenID)
                    _Machi1ComboBox.SelectedIndex = machi1 - GameData.NumOfShiro;
                else
                    _Machi1ComboBox.SelectedIndex = nmachi;
            }
            if (!notMatchedMachi2)
            {
                if (machi2 != GameData.NoneKyotenID)
                    _Machi2ComboBox.SelectedIndex = machi2 - GameData.NumOfShiro;
                else
                    _Machi2ComboBox.SelectedIndex = nmachi;
            }
            if (!notMatchedAdministrator)
            {
                if (administrator != GameData.NoneBushoID)
                    _AdministratorComboBox.SelectedIndex = administrator;
                else
                    _AdministratorComboBox.SelectedIndex = nbusho;
            }
            if (!notMatchedGuard)
            {
                if (guard != GameData.NoneSeiryokuID)
                    _GuardComboBox.SelectedIndex = guard - GameData.NumOfDaimyoke - GameData.NumOfShoka;
                else
                    _GuardComboBox.SelectedIndex = nguard;
            }
            if (!notMatchedKanjo)
            {
                _KanjoTextBox.Text = kanjo.ToString();
            }
            if (!notMatchedMaintenanceCosts)
            {
                _MaintenanceCostsTextBox.Text = maintenanceCosts.ToString();
            }
            if (!notMatchedType)
            {
                _TypeComboBox.SelectedIndex = type;
            }
            if (!notMatchedStopping)
            {
                _StoppingTextBox.Text = stopping.ToString();
            }

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _Machi1ComboBox.SelectedIndexChanged += checker;
            _Machi2ComboBox.SelectedIndexChanged += checker;
            _AdministratorComboBox.SelectedIndexChanged += checker;
            _GuardComboBox.SelectedIndexChanged += checker;
            _TypeComboBox.SelectedIndexChanged += checker;
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
            _MaintenanceCostsTextBox.TextChanged += checkerForTextBox;
            _StoppingTextBox.TextChanged += checkerForTextBox;
            _KanjoTextBox.TextChanged += (sender2, e2) =>
            {
                TextBox tb = (TextBox)sender2;
                if (tb.Text == beforeTexts[tb.TabIndex]) return;
                int start = tb.SelectionStart - 1;
                bool badTextFlg = System.Text.RegularExpressions.Regex.IsMatch(tb.Text, @"[^0-9\-]");
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
            ushort machi1 = 0;
            ushort machi2 = 0;
            ushort administrator = 0;
            byte guard = 0;
            int kanjo = 0;
            ushort maintenanceCosts = 0;
            byte type = 0;
            byte stopping = 0;
            try
            {
                if ((bool)_Machi1ComboBox.Tag)
                {
                    machi1 = ushort.Parse(_Machi1ComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_Machi2ComboBox.Tag)
                {
                    machi2 = ushort.Parse(_Machi2ComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_AdministratorComboBox.Tag)
                {
                    administrator = ushort.Parse(_AdministratorComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_GuardComboBox.Tag)
                {
                    guard = byte.Parse(_GuardComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_KanjoTextBox.Tag)
                {
                    kanjo = int.Parse(_KanjoTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_MaintenanceCostsTextBox.Tag)
                {
                    maintenanceCosts = ushort.Parse(_MaintenanceCostsTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_TypeComboBox.Tag)
                {
                    type = (byte)_TypeComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_StoppingTextBox.Tag)
                {
                    stopping = byte.Parse(_StoppingTextBox.Text);
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
            int n = _HanroEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_Machi1ComboBox.Tag)
                {
                    _HanroEditList[i].Machi1 = machi1;
                }
                if ((bool)_Machi2ComboBox.Tag)
                {
                    _HanroEditList[i].Machi2 = machi2;
                }
                if ((bool)_AdministratorComboBox.Tag)
                {
                    _HanroEditList[i].Administrator = administrator;
                }
                if ((bool)_GuardComboBox.Tag)
                {
                    _HanroEditList[i].Guard = guard;
                }
                if ((bool)_KanjoTextBox.Tag)
                {
                    _HanroEditList[i].Kanjo = kanjo;
                }
                if ((bool)_MaintenanceCostsTextBox.Tag)
                {
                    _HanroEditList[i].MaintenanceCosts = maintenanceCosts;
                }
                if ((bool)_TypeComboBox.Tag)
                {
                    _HanroEditList[i].Type = type;
                }
                if ((bool)_StoppingTextBox.Tag)
                {
                    _HanroEditList[i].Stopping = stopping;
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
