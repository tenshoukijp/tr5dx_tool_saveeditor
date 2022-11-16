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

namespace Taiko5DXSaveEditor.DataEditForms.SeiryokuEdit
{
    /// <summary>
    /// 外交関係を設定するフォーム
    /// </summary>
    public partial class DiplomacyEditForm : DataEditForm
    {
        #region 定数
        /// <summary>
        /// 勢力数
        /// </summary>
        private static readonly int NUM_OF_SEIRYOKU = 120; 

        #endregion

        #region フィールド
        /// <summary>
        /// 編集対象の勢力リスト
        /// </summary>
        private List<Seiryoku> _SeiryokuEditList = new List<Seiryoku>();

        /// <summary>
        /// 外交関係
        /// </summary>
        private byte?[] _Diplomacy1 = new byte?[NUM_OF_SEIRYOKU];

        /// <summary>
        /// 外交感情
        /// </summary>
        private byte?[] _Diplomacy2 = new byte?[NUM_OF_SEIRYOKU];

        /// <summary>
        /// 停戦約定
        /// </summary>
        private byte?[] _Ceasefire = new byte?[NUM_OF_SEIRYOKU];

        /// <summary>
        /// 攻込名分
        /// </summary>
        private byte?[] _JustCause = new byte?[NUM_OF_SEIRYOKU];

        /// <summary>
        /// 勢力リストの選択が変更されたフラグ
        /// </summary>
        private bool _ListSelectChangedFlag = false;

        /// <summary>
        /// 停戦約定の変更前テキスト
        /// </summary>
        private string _BeforeCeasefireText = "";

        /// <summary>
        /// 攻込名分の変更前テキスト
        /// </summary>
        private string _BeforeJustCauseText = "";

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public DiplomacyEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public DiplomacyEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の勢力を全て受け取る
            var seiryokus = from seiryoku in gameData.SeiryokuList
                            where selectedIDs.Contains(seiryoku.ID)
                            select seiryoku;
            _SeiryokuEditList.AddRange(seiryokus);
            
            // コンポーネントの初期化
            InitializeComponent();

            // 編集対象の勢力の種類によってウィンドウのタイトルを変える
            if (_SeiryokuEditList[0] is Daimyoke) Text = @"大名家" + Text;
            else if (_SeiryokuEditList[0] is Shoka) Text = @"商家" + Text;
            else if (_SeiryokuEditList[0] is NinjaShu) Text = @"忍者衆" + Text;
            else if (_SeiryokuEditList[0] is KaizokuShu) Text = @"海賊衆" + Text;
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォームがロードされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void DiplomacyEditForm_Load(object sender, EventArgs e)
        {
            // 更新記録用のbool配列
            _Diplomacy1ComboBox.Tag = new bool[NUM_OF_SEIRYOKU];
            _Diplomacy2ComboBox.Tag = new bool[NUM_OF_SEIRYOKU];
            _CeasefireTextBox.Tag = new bool[NUM_OF_SEIRYOKU];
            _JustCauseTextBox.Tag = new bool[NUM_OF_SEIRYOKU];

            // リストボックスの構築
            StringBuilder stringBuilder = new StringBuilder();
            var seiryokuNames = new string[NUM_OF_SEIRYOKU];
            for (int i = 0; i < NUM_OF_SEIRYOKU; ++i)
            {
                stringBuilder.Append(i);
                stringBuilder.Append(": ");
                stringBuilder.Append(_GameData.SeiryokuList[i].Name);
                seiryokuNames[i] = stringBuilder.ToString();
                stringBuilder.Clear();
            }
            _SeiryokuListBox.Items.AddRange(seiryokuNames);

            // 初期値設定
            for (int i = 0; i < NUM_OF_SEIRYOKU; ++i)
            {
                byte? diplomacy1 = (byte)(_SeiryokuEditList[0].Diplomacy[i] & 0x03);
                byte? diplomacy2 = (byte)((_SeiryokuEditList[0].Diplomacy[i] & 0x7C) >> 2);
                byte? ceasefire = _SeiryokuEditList[0].Ceasefire[i];
                byte? justCause = _SeiryokuEditList[0].JustCause[i];
                int n = _SeiryokuEditList.Count;
                for (int j = 0; j < n; ++j)
                {
                    if ((diplomacy1 != null) && (diplomacy1 != (byte)(_SeiryokuEditList[j].Diplomacy[i] & 0x03)))
                        diplomacy1 = null;
                    if ((diplomacy2 != null) && (diplomacy2 != (byte)((_SeiryokuEditList[j].Diplomacy[i] & 0x7C) >> 2)))
                        diplomacy2 = null;
                    if ((ceasefire != null) && (ceasefire != _SeiryokuEditList[j].Ceasefire[i]))
                        ceasefire = null;
                    if ((justCause != null) && (justCause != _SeiryokuEditList[j].JustCause[i]))
                        justCause = null;
                }
                _Diplomacy1[i] = diplomacy1;
                _Diplomacy2[i] = diplomacy2;
                _Ceasefire[i] = ceasefire;
                _JustCause[i] = justCause;
            }

            // イベントハンドラの設定
            _SeiryokuListBox.SelectedIndexChanged += _SeiryokuListBox_SelectedIndexChanged;
            _Diplomacy1ComboBox.SelectedIndexChanged += _Diplomacy1ComboBox_SelectedIndexChanged;
            _Diplomacy2ComboBox.SelectedIndexChanged += _Diplomacy2ComboBox_SelectedIndexChanged;
            _CeasefireTextBox.TextChanged += _CeasefireTextBox_TextChanged;
            _JustCauseTextBox.TextChanged += _JustCauseTextBox_TextChanged;

            // とりあえずリストの一番上を選択する
            _SeiryokuListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 勢力リストの選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _SeiryokuListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ListSelectChangedFlag = true;
            int index = _SeiryokuListBox.SelectedIndex;

            // 相手の名前を表示
            _SeiryokuTextBox.Text = _GameData.SeiryokuList[index].Name;
            ushort leader = 0;
            if (_GameData.SeiryokuList[index] is Daimyoke daimyoke) leader = daimyoke.Leader;
            else if (_GameData.SeiryokuList[index] is Shoka shoka) leader = shoka.Leader;
            else if (_GameData.SeiryokuList[index] is NinjaShu ninjaShu) leader = ninjaShu.Leader;
            else if (_GameData.SeiryokuList[index] is KaizokuShu kaizokuShu) leader = kaizokuShu.Leader;
            if (leader != GameData.NoneBushoID)
                _LeaderTextBox.Text = _GameData.BushoList[leader].Name;
            else
                _LeaderTextBox.Text = "";

            // 支配or御用商人、従属or支持大名家
            if ((_SeiryokuEditList[0] is Daimyoke) && (_GameData.SeiryokuList[index] is Shoka))
                _Diplomacy1ComboBox.Items[3] = @"御用商人";
            else
                _Diplomacy1ComboBox.Items[3] = @"支配";
            if ((_SeiryokuEditList[0] is Shoka) && (_GameData.SeiryokuList[index] is Daimyoke))
                _Diplomacy1ComboBox.Items[2] = @"支持大名家";
            else
                _Diplomacy1ComboBox.Items[2] = @"従属";

            // 外交関係の値設定
            if (_Diplomacy1[index] != null)
                _Diplomacy1ComboBox.SelectedIndex = _Diplomacy1[index].Value;
            else
                _Diplomacy1ComboBox.SelectedIndex = -1;
            if (_Diplomacy2[index] != null)
                _Diplomacy2ComboBox.SelectedIndex = _Diplomacy2[index].Value;
            else
                _Diplomacy2ComboBox.SelectedIndex = -1;
            if (_Ceasefire[index] != null)
                _CeasefireTextBox.Text = _Ceasefire[index].Value.ToString();
            else
                _CeasefireTextBox.Text = "";
            if (_JustCause[index] != null)
                _JustCauseTextBox.Text = _JustCause[index].Value.ToString();
            else
                _JustCauseTextBox.Text = "";

            // 変更前テキストを保存
            _BeforeCeasefireText = _CeasefireTextBox.Text;
            _BeforeJustCauseText = _JustCauseTextBox.Text;

            _ListSelectChangedFlag = false;
        }

        /// <summary>
        /// 外交関係の選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _Diplomacy1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;

            int index = _SeiryokuListBox.SelectedIndex;
            _Diplomacy1[index] = (byte)_Diplomacy1ComboBox.SelectedIndex;
            ((bool[])_Diplomacy1ComboBox.Tag)[index] = true;
        }

        /// <summary>
        /// 外交感情の選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _Diplomacy2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;

            int index = _SeiryokuListBox.SelectedIndex;
            _Diplomacy2[index] = (byte)_Diplomacy2ComboBox.SelectedIndex;
            ((bool[])_Diplomacy2ComboBox.Tag)[index] = true;
        }

        /// <summary>
        /// 停戦約定のテキストが変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _CeasefireTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;
            if (_CeasefireTextBox.Text == _BeforeCeasefireText)
                return;

            int start = _CeasefireTextBox.SelectionStart - 1;
            bool badTextFlg = System.Text.RegularExpressions.Regex.IsMatch(_CeasefireTextBox.Text, @"[^0-9]");
            if (badTextFlg)
            {
                _CeasefireTextBox.Text = _BeforeCeasefireText;
                _CeasefireTextBox.SelectionStart = start;
            }
            else
            {
                int index = _SeiryokuListBox.SelectedIndex;
                int val = 0;
                if (!int.TryParse(_CeasefireTextBox.Text, out val))
                {
                    _CeasefireTextBox.TextChanged -= _CeasefireTextBox_TextChanged;
                    _CeasefireTextBox.Text = "0";
                    _CeasefireTextBox.TextChanged += _CeasefireTextBox_TextChanged;
                }
                if (val > 0xFF)
                {
                    val = 255;
                    _CeasefireTextBox.TextChanged -= _CeasefireTextBox_TextChanged;
                    _CeasefireTextBox.Text = "255";
                    _CeasefireTextBox.TextChanged += _CeasefireTextBox_TextChanged;
                }
                _Ceasefire[index] = (byte)val;
                _BeforeCeasefireText = _CeasefireTextBox.Text;
                ((bool[])_CeasefireTextBox.Tag)[index] = true;
            }
        }

        /// <summary>
        /// 攻込名分のテキストが変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _JustCauseTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;
            if (_JustCauseTextBox.Text == _BeforeJustCauseText)
                return;

            int start = _JustCauseTextBox.SelectionStart - 1;
            bool badTextFlg = System.Text.RegularExpressions.Regex.IsMatch(_JustCauseTextBox.Text, @"[^0-9]");
            if (badTextFlg)
            {
                _JustCauseTextBox.Text = _BeforeJustCauseText;
                _JustCauseTextBox.SelectionStart = start;
            }
            else
            {
                int index = _SeiryokuListBox.SelectedIndex;
                int val = 0;
                if (!int.TryParse(_JustCauseTextBox.Text, out val))
                {
                    _JustCauseTextBox.TextChanged -= _JustCauseTextBox_TextChanged;
                    _JustCauseTextBox.Text = "0";
                    _JustCauseTextBox.TextChanged += _JustCauseTextBox_TextChanged;
                }
                if (val > 0xFF)
                {
                    val = 255;
                    _JustCauseTextBox.TextChanged -= _JustCauseTextBox_TextChanged;
                    _JustCauseTextBox.Text = "255";
                    _JustCauseTextBox.TextChanged += _JustCauseTextBox_TextChanged;
                }
                _JustCause[index] = (byte)val;
                _BeforeJustCauseText = _JustCauseTextBox.Text;
                ((bool[])_JustCauseTextBox.Tag)[index] = true;
            }
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _OKButton_Click(object sender, EventArgs e)
        {
            // 結果を反映させる
            for (int i = 0; i < NUM_OF_SEIRYOKU; ++i)
            {
                if (((bool[])_Diplomacy1ComboBox.Tag)[i])
                {
                    foreach (var seiryoku in _SeiryokuEditList)
                    {
                        byte mask = 0xFC;
                        byte maskedValue = (byte)(seiryoku.Diplomacy[i] & mask);
                        seiryoku.Diplomacy[i] = (byte)(maskedValue | _Diplomacy1[i].Value);
                    }
                }
                if (((bool[])_Diplomacy2ComboBox.Tag)[i])
                {
                    foreach (var seiryoku in _SeiryokuEditList)
                    {
                        byte mask = 0x83;
                        byte maskedValue = (byte)(seiryoku.Diplomacy[i] & mask);
                        seiryoku.Diplomacy[i] = (byte)(maskedValue | (_Diplomacy2[i].Value << 2));
                    }
                }
                if (((bool[])_CeasefireTextBox.Tag)[i])
                {
                    foreach (var seiryoku in _SeiryokuEditList)
                    {
                        seiryoku.Ceasefire[i] = _Ceasefire[i].Value;
                    }
                }
                if (((bool[])_JustCauseTextBox.Tag)[i])
                {
                    foreach (var seiryoku in _SeiryokuEditList)
                    {
                        seiryoku.JustCause[i] = _JustCause[i].Value;
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
