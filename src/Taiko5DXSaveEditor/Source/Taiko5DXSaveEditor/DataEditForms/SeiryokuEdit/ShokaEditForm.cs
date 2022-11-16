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
    /// 商家関連の基本事項を設定するフォーム
    /// </summary>
    public partial class ShokaEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の商家リスト
        /// </summary>
        private List<Shoka> _ShokaEditList = new List<Shoka>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public ShokaEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public ShokaEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の商家を全て受け取る
            var shokas = from shoka in gameData.SeiryokuList
                         where selectedIDs.Contains(shoka.ID)
                         select (Shoka)shoka;
            _ShokaEditList.AddRange(shokas);
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
        private void ShokaEditForm_Load(object sender, EventArgs e)
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
            var nameList = _GameData.NameListDictionary["Sho-ka"];
            _NameComboBox.Items.AddRange(nameList.ToArray());
            StringBuilder sb = new StringBuilder();
            sb.Append(_GameData.Shujinko.NameOfMyShoka);
            sb.Append("屋");
            _NameComboBox.Items.Add(sb.ToString());
            sb.Clear();
            _NameComboBox.Items.Add("");
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
            _LeaderComboBox.Items.AddRange(bushoNames);
            _LeaderComboBox.Items.Add(GameData.NoneBushoID + ": なし");
            int nkyoten = _GameData.KyotenList.Count;
            var kyotenNames = new string[nkyoten];
            for (int i = 0; i < nkyoten; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                sb.Append(_GameData.KyotenList[i].Name);
                kyotenNames[i] = sb.ToString();
                sb.Clear();
            }
            _HomeComboBox.Items.AddRange(kyotenNames);
            _HomeComboBox.Items.Add(GameData.NoneKyotenID + ": なし");

            // 初期値の設定
            int nameIndex = _ShokaEditList[0].NameID;
            int leaderIndex = _ShokaEditList[0].Leader;
            int home = _ShokaEditList[0].Home;
            byte relationshipWithShujinko = _ShokaEditList[0].RelationshipWithShujinko;
            byte departureCounter = _ShokaEditList[0].DepartureCounter;
            // 他と一致するか確認
            bool notMatchedNameIndex = false;
            bool notMatchedLeaderIndex = false;
            bool notMatchedHome = false;
            bool notMatchedRelationshipWithShujinko = false;
            bool notMatchedDepartureCounter = false;
            int nedits = _ShokaEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (nameIndex != _ShokaEditList[i].NameID)
                    notMatchedNameIndex = true;
                if (leaderIndex != _ShokaEditList[i].Leader)
                    notMatchedLeaderIndex = true;
                if (home != _ShokaEditList[i].Home)
                    notMatchedHome = true;
                if (relationshipWithShujinko != _ShokaEditList[i].RelationshipWithShujinko)
                    notMatchedRelationshipWithShujinko = true;
                if (departureCounter != _ShokaEditList[i].DepartureCounter)
                    notMatchedDepartureCounter = true;
            }
            if (!notMatchedNameIndex)
            {
                if (nameIndex > GameData.MyShokaNameID) _NameComboBox.SelectedIndex = _NameComboBox.Items.Count - 1;
                else _NameComboBox.SelectedIndex = nameIndex;
            }
            if (!notMatchedLeaderIndex)
            {
                if (leaderIndex >= nbusho) _LeaderComboBox.SelectedIndex = nbusho;
                else _LeaderComboBox.SelectedIndex = leaderIndex;
            }
            if (!notMatchedHome)
            {
                if (home >= nkyoten) _HomeComboBox.SelectedIndex = nkyoten;
                else _HomeComboBox.SelectedIndex = home;
            }
            if (!notMatchedRelationshipWithShujinko)
            {
                _RelationshipWithShujinkoComboBox.SelectedIndex = relationshipWithShujinko;
            }
            if (!notMatchedDepartureCounter)
            {
                _DepartureCounterComboBox.SelectedIndex = departureCounter;
            }

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _NameComboBox.SelectedIndexChanged += checker;
            _LeaderComboBox.SelectedIndexChanged += checker;
            _HomeComboBox.SelectedIndexChanged += checker;
            _RelationshipWithShujinkoComboBox.SelectedIndexChanged += checker;
            _DepartureCounterComboBox.SelectedIndexChanged += checker;
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
            byte nameId = 0;
            ushort leaderId = 0;
            ushort home = 0;
            byte relationshipWithShujinko = 0;
            byte departureCounter = 0;
            try
            {
                if ((bool)_NameComboBox.Tag)
                {
                    if (_NameComboBox.Text == "") nameId = GameData.NoneShokaNameID;
                    else nameId = (byte)_NameComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_LeaderComboBox.Tag)
                {
                    leaderId = ushort.Parse(_LeaderComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_HomeComboBox.Tag)
                {
                    home = ushort.Parse(_HomeComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_RelationshipWithShujinkoComboBox.Tag)
                {
                    relationshipWithShujinko = (byte)_RelationshipWithShujinkoComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_DepartureCounterComboBox.Tag)
                {
                    departureCounter = (byte)_DepartureCounterComboBox.SelectedIndex;
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
            int n = _ShokaEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_LeaderComboBox.Tag)
                {
                    _ShokaEditList[i].Leader = leaderId;
                    if (leaderId == GameData.NoneBushoID)
                    {
                        _ShokaEditList[i].IsDestruction = true;
                        _ShokaEditList[i].Name = "";
                    }
                    else
                        _ShokaEditList[i].IsDestruction = false;
                }
                if ((bool)_NameComboBox.Tag)
                {
                    _ShokaEditList[i].NameID = nameId;
                    if (_ShokaEditList[i].IsDestruction)
                        _ShokaEditList[i].Name = "";
                    else
                        _ShokaEditList[i].Name = _NameComboBox.Text;
                }
                if ((bool)_HomeComboBox.Tag)
                {
                    _ShokaEditList[i].Home = home;
                }
                if ((bool)_RelationshipWithShujinkoComboBox.Tag)
                {
                    _ShokaEditList[i].RelationshipWithShujinko = relationshipWithShujinko;
                }
                if ((bool)_DepartureCounterComboBox.Tag)
                {
                    _ShokaEditList[i].DepartureCounter = departureCounter;
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
