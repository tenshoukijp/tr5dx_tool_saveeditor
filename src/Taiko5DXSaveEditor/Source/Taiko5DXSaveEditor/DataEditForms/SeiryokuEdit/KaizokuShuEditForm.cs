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
    /// 海賊衆関連の基本事項を設定するフォーム
    /// </summary>
    public partial class KaizokuShuEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の海賊衆リスト
        /// </summary>
        private List<KaizokuShu> _KaizokuShuEditList = new List<KaizokuShu>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public KaizokuShuEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public KaizokuShuEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の海賊衆を全て受け取る
            var kaizokuShus = from kaizokuShu in gameData.SeiryokuList
                              where selectedIDs.Contains(kaizokuShu.ID)
                              select (KaizokuShu)kaizokuShu;
            _KaizokuShuEditList.AddRange(kaizokuShus);
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
        private void KaizokuShuEditForm_Load(object sender, EventArgs e)
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
            var nameList = _GameData.NameListDictionary["Kaizoku-shu"];
            _NameComboBox.Items.AddRange(nameList.ToArray());
            var nbusho = GameData.NumOfBusho + GameData.NumOfGeneralPurpose;
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

            // 初期値の設定
            int nameIndex = _KaizokuShuEditList[0].NameID;
            int leaderIndex = _KaizokuShuEditList[0].Leader;
            byte relationshipWithShujinko = _KaizokuShuEditList[0].RelationshipWithShujinko;
            byte departureCounter = _KaizokuShuEditList[0].DepartureCounter;
            byte senryaku = _KaizokuShuEditList[0].Senryaku;
            ushort senryakuTarget = _KaizokuShuEditList[0].SenryakuTarget;
            byte shipbuildingMiddle = _KaizokuShuEditList[0].ShipbuildingMiddle;
            byte shipbuildingStrong = _KaizokuShuEditList[0].ShipbuildingStrong;
            // 他と一致するか確認
            bool notMatchedNameIndex = false;
            bool notMatchedLeaderIndex = false;
            bool notMatchedRelationshipWithShujinko = false;
            bool notMatchedDepartureCounter = false;
            bool notMatchedSenryaku = false;
            bool notMatchedSenryakuTarget = false;
            bool notMatchedShipbuildingMiddle = false;
            bool notMatchedShipbuildingStrong = false;
            int nedits = _KaizokuShuEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (nameIndex != _KaizokuShuEditList[i].NameID)
                    notMatchedNameIndex = true;
                if (leaderIndex != _KaizokuShuEditList[i].Leader)
                    notMatchedLeaderIndex = true;
                if (relationshipWithShujinko != _KaizokuShuEditList[i].RelationshipWithShujinko)
                    notMatchedRelationshipWithShujinko = true;
                if (departureCounter != _KaizokuShuEditList[i].DepartureCounter)
                    notMatchedDepartureCounter = true;
                if (senryaku != _KaizokuShuEditList[i].Senryaku)
                    notMatchedSenryaku = true;
                if (senryakuTarget != _KaizokuShuEditList[i].SenryakuTarget)
                    notMatchedSenryakuTarget = true;
                if (shipbuildingMiddle != _KaizokuShuEditList[i].ShipbuildingMiddle)
                    notMatchedShipbuildingMiddle = true;
                if (shipbuildingStrong != _KaizokuShuEditList[i].ShipbuildingStrong)
                    notMatchedShipbuildingStrong = true;
            }
            if (!notMatchedNameIndex)
            {
                _NameComboBox.SelectedIndex = nameIndex;
            }
            if (!notMatchedLeaderIndex)
            {
                if (leaderIndex >= nbusho) _LeaderComboBox.SelectedIndex = nbusho;
                else _LeaderComboBox.SelectedIndex = leaderIndex;
            }
            if (!notMatchedRelationshipWithShujinko)
            {
                _RelationshipWithShujinkoComboBox.SelectedIndex = relationshipWithShujinko;
            }
            if (!notMatchedDepartureCounter)
            {
                _DepartureCounterComboBox.SelectedIndex = departureCounter;
            }
            if (!notMatchedSenryaku)
            {
                _SenryakuComboBox.SelectedIndex = senryaku;
                if (!notMatchedSenryakuTarget)
                {
                    int search = -1;
                    int nsearch = _SenryakuTargetComboBox.Items.Count;
                    for (int j = 0; j < nsearch; ++j)
                    {
                        string text1 = senryakuTarget.ToString();
                        string text2 = _SenryakuTargetComboBox.Items[j].ToString().Split(':')[0];
                        if (text1 == text2)
                        {
                            search = j;
                            break;
                        }
                    }
                    if (search != -1)
                        _SenryakuTargetComboBox.SelectedIndex = search;
                }
            }
            if (!notMatchedShipbuildingMiddle)
            {
                _ShipbuildingMiddleComboBox.SelectedIndex = shipbuildingMiddle;
            }
            if (!notMatchedShipbuildingStrong)
            {
                _ShipbuildingStrongComboBox.SelectedIndex = shipbuildingStrong;
            }

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _NameComboBox.SelectedIndexChanged += checker;
            _LeaderComboBox.SelectedIndexChanged += checker;
            _RelationshipWithShujinkoComboBox.SelectedIndexChanged += checker;
            _DepartureCounterComboBox.SelectedIndexChanged += checker;
            _SenryakuTargetComboBox.SelectedIndexChanged += checker;
            _ShipbuildingMiddleComboBox.SelectedIndexChanged += checker;
            _ShipbuildingStrongComboBox.SelectedIndexChanged += checker;
        }

        /// <summary>
        /// 戦略コンボボックスの選択が変更された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _SenryakuComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ターゲットのアイテムをいったんクリアする
            _SenryakuTargetComboBox.Items.Clear();

            // 現在の戦略に合ったターゲットを設定
            StringBuilder stringBuilder = new StringBuilder();
            switch (_SenryakuComboBox.SelectedIndex)
            {
                // 砦守備、里強化
                case 0:
                case 1:
                    _SenryakuTargetComboBox.Items.Add("65535: なし");
                    _SenryakuTargetComboBox.SelectedIndex = 0;
                    break;
                // 他衆攻略
                case 2:
                    int nkaizoku = GameData.NumOfKaizokuShu;
                    var kaizokuNames = new string[nkaizoku];
                    for (int i = 0; i < nkaizoku; ++i)
                    {
                        int index = GameData.NumOfDaimyoke + GameData.NumOfShoka + GameData.NumOfNinjaShu + i;
                        stringBuilder.Append(index);
                        stringBuilder.Append(": ");
                        string name = _GameData.SeiryokuList[index].Name;
                        stringBuilder.Append(name);
                        kaizokuNames[i] = stringBuilder.ToString();
                        stringBuilder.Clear();
                    }
                    _SenryakuTargetComboBox.Items.AddRange(kaizokuNames);
                    _SenryakuTargetComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");
                    _SenryakuTargetComboBox.Items.Add(65535 + ": なし");
                    _SenryakuTargetComboBox.SelectedIndex = nkaizoku;
                    break;
                // 大名支援
                case 3:
                    int ndaimyo = GameData.NumOfDaimyoke;
                    var daimyoNames = new string[ndaimyo];
                    for (int i = 0; i < ndaimyo; ++i)
                    {
                        stringBuilder.Append(i);
                        stringBuilder.Append(": ");
                        string name = _GameData.SeiryokuList[i].Name;
                        stringBuilder.Append(name);
                        daimyoNames[i] = stringBuilder.ToString();
                        stringBuilder.Clear();
                    }
                    _SenryakuTargetComboBox.Items.AddRange(daimyoNames);
                    _SenryakuTargetComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");
                    _SenryakuTargetComboBox.Items.Add(65535 + ": なし");
                    _SenryakuTargetComboBox.SelectedIndex = ndaimyo;
                    break;
                // それ以外
                default:
                    _SenryakuTargetComboBox.Items.Add("65535: なし");
                    _SenryakuTargetComboBox.SelectedIndex = 0;
                    break;
            }
            _SenryakuComboBox.Tag = true;
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
            byte relationshipWithShujinko = 0;
            byte departureCounter = 0;
            byte senryaku = 0;
            ushort senryakuTarget = 0;
            byte shipbuildingMiddle = 0;
            byte shipbuildingStrong = 0;
            try
            {
                if ((bool)_NameComboBox.Tag)
                {
                    nameId = (byte)_NameComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_LeaderComboBox.Tag)
                {
                    leaderId = ushort.Parse(_LeaderComboBox.Text.Split(':')[0]);
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
                if ((bool)_SenryakuComboBox.Tag)
                {
                    senryaku = (byte)_SenryakuComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_SenryakuTargetComboBox.Tag)
                {
                    senryakuTarget = ushort.Parse(_SenryakuTargetComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_ShipbuildingMiddleComboBox.Tag)
                {
                    shipbuildingMiddle = (byte)_ShipbuildingMiddleComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_ShipbuildingStrongComboBox.Tag)
                {
                    shipbuildingStrong = (byte)_ShipbuildingStrongComboBox.SelectedIndex;
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
            int n = _KaizokuShuEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_LeaderComboBox.Tag)
                {
                    _KaizokuShuEditList[i].Leader = leaderId;
                    if (leaderId == GameData.NoneBushoID)
                    {
                        _KaizokuShuEditList[i].IsDestruction = true;
                        _KaizokuShuEditList[i].Name = "";
                    }
                    else
                        _KaizokuShuEditList[i].IsDestruction = false;
                }
                if ((bool)_NameComboBox.Tag)
                {
                    _KaizokuShuEditList[i].NameID = nameId;
                    if (_KaizokuShuEditList[i].IsDestruction)
                        _KaizokuShuEditList[i].Name = "";
                    else
                        _KaizokuShuEditList[i].Name = _NameComboBox.Text;
                }
                if ((bool)_RelationshipWithShujinkoComboBox.Tag)
                {
                    _KaizokuShuEditList[i].RelationshipWithShujinko = relationshipWithShujinko;
                }
                if ((bool)_DepartureCounterComboBox.Tag)
                {
                    _KaizokuShuEditList[i].DepartureCounter = departureCounter;
                }
                if ((bool)_SenryakuComboBox.Tag)
                {
                    _KaizokuShuEditList[i].Senryaku = senryaku;
                }
                if ((bool)_SenryakuTargetComboBox.Tag)
                {
                    _KaizokuShuEditList[i].SenryakuTarget = senryakuTarget;
                }
                if ((bool)_ShipbuildingMiddleComboBox.Tag)
                {
                    _KaizokuShuEditList[i].ShipbuildingMiddle = shipbuildingMiddle;
                }
                if ((bool)_ShipbuildingStrongComboBox.Tag)
                {
                    _KaizokuShuEditList[i].ShipbuildingStrong = shipbuildingStrong;
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
