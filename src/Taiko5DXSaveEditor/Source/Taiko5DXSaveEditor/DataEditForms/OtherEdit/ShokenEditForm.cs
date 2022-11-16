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
    /// 商圏を設定するフォーム
    /// </summary>
    public partial class ShokenEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の商圏リスト
        /// </summary>
        private List<Shoken> _ShokenEditList = new List<Shoken>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public ShokenEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public ShokenEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の武将を全て受け取る
            var shokens = from shoken in gameData.ShokenList
                          where selectedIDs.Contains(shoken.ID)
                          select shoken;
            _ShokenEditList.AddRange(shokens);

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
        private void ShokenEditForm_Load(object sender, EventArgs e)
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
            var ndaimyoke = GameData.NumOfDaimyoke;
            var daimyokeNames = new string[ndaimyoke];
            for (int i = 0; i < ndaimyoke; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                sb.Append(_GameData.SeiryokuList[i].Name);
                daimyokeNames[i] = sb.ToString();
                sb.Clear();
            }
            _DaimyokeComboBox.Items.AddRange(daimyokeNames);
            _DaimyokeComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");
            var nshoka = GameData.NumOfShoka;
            var shokaNames = new string[nshoka];
            for (int i = 0; i < nshoka; ++i)
            {
                int index = GameData.NumOfDaimyoke + i;
                sb.Append(index);
                sb.Append(": ");
                sb.Append(_GameData.SeiryokuList[index].Name);
                shokaNames[i] = sb.ToString();
                sb.Clear();
            }
            _ShoninTukasaComboBox.Items.AddRange(shokaNames);
            _ShoninTukasaComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");
            // 初期値の設定
            byte daimyoke = _ShokenEditList[0].Daimyoke;
            byte shoninTukasa = _ShokenEditList[0].ShoninTukasa;
            // 他と一致するか確認
            bool notMatchedDaimyoke = false;
            bool notMatchedShoninTukasa = false;
            int nedits = _ShokenEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (daimyoke != _ShokenEditList[i].Daimyoke)
                    notMatchedDaimyoke = true;
                if (shoninTukasa != _ShokenEditList[i].ShoninTukasa)
                    notMatchedShoninTukasa = true;
            }
            if (!notMatchedDaimyoke)
            {
                if (daimyoke != GameData.NoneSeiryokuID)
                    _DaimyokeComboBox.SelectedIndex = daimyoke;
                else
                    _DaimyokeComboBox.SelectedIndex = ndaimyoke;
            }
            if (!notMatchedShoninTukasa)
            {
                if (shoninTukasa != GameData.NoneSeiryokuID)
                    _ShoninTukasaComboBox.SelectedIndex = shoninTukasa - GameData.NumOfDaimyoke;
                else
                    _ShoninTukasaComboBox.SelectedIndex = nshoka;
            }
            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _DaimyokeComboBox.SelectedIndexChanged += checker;
            _ShoninTukasaComboBox.SelectedIndexChanged += checker;
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
            byte daimyoke = 0;
            byte shoninTukasa = 0;
            try
            {
                if ((bool)_DaimyokeComboBox.Tag)
                {
                    daimyoke = byte.Parse(_DaimyokeComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_ShoninTukasaComboBox.Tag)
                {
                    shoninTukasa = byte.Parse(_ShoninTukasaComboBox.Text.Split(':')[0]);
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
            int n = _ShokenEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_DaimyokeComboBox.Tag)
                {
                    _ShokenEditList[i].Daimyoke = daimyoke;
                }
                if ((bool)_ShoninTukasaComboBox.Tag)
                {
                    _ShokenEditList[i].ShoninTukasa = shoninTukasa;
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
