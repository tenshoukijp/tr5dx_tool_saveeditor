using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DDS;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.DataEditForms.SeiryokuEdit
{
    /// <summary>
    /// 大名家関連の基本事項を設定するフォーム
    /// </summary>
    public partial class DaimyokeEditForm : DataEditForm
    {
        #region 定数
        /// <summary>
        /// 家紋画像のフォルダのパス
        /// </summary>
        private static readonly string IMAGE_DIRECTORY_PATH = @"Image/FamilyCrest/";

        #endregion

        #region フィールド
        /// <summary>
        /// 編集対象の大名家リスト
        /// </summary>
        private List<Daimyoke> _DaimyokeEditList = new List<Daimyoke>();

        /// <summary>
        /// 家紋画像一覧
        /// </summary>
        private List<Image> _FamilyCrestImageList = new List<Image>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public DaimyokeEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public DaimyokeEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の大名家を全て受け取る
            var daimyokes = from daimyoke in gameData.SeiryokuList
                            where selectedIDs.Contains(daimyoke.ID)
                            select (Daimyoke)daimyoke;
            _DaimyokeEditList.AddRange(daimyokes);
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
        private void DaimyokeEditForm_Load(object sender, EventArgs e)
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
            int nbusho = GameData.NumOfBusho;
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
            int nshoka = GameData.NumOfShoka;
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
            _GoyoShonin1ComboBox.Items.AddRange(shokaNames);
            _GoyoShonin2ComboBox.Items.AddRange(shokaNames);
            _GoyoShonin3ComboBox.Items.AddRange(shokaNames);
            _GoyoShonin1ComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");
            _GoyoShonin2ComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");
            _GoyoShonin3ComboBox.Items.Add(GameData.NoneSeiryokuID + ": なし");

            // 家紋画像を読み込む
            string fileName = "FamilyCrest.dds";
            string filePath = IMAGE_DIRECTORY_PATH + fileName;
            if (File.Exists(filePath))
            {
                var ddsImage = DDSImage.Load(filePath);
                Bitmap image = ddsImage.Images[0];
                for (int i = 0; i < 256; ++i)
                {
                    Bitmap canvas = new Bitmap(60, 60);
                    Graphics g = Graphics.FromImage(canvas);

                    int x = (i % 16) * 60;
                    int y = (i / 16) * 60;
                    Rectangle srcRect = new Rectangle(x, y, 60, 60);
                    Rectangle desRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);

                    g.FillRectangle(Brushes.Black, desRect);
                    g.DrawImage(image, desRect, srcRect, GraphicsUnit.Pixel);
                    g.Dispose();

                    _FamilyCrestImageList.Add(canvas);
                }
            }
            else
            {
                for (int i = 0; i < 256; ++i)
                {
                    _FamilyCrestImageList.Add(null);
                }
            }

            // 初期値の設定
            ushort leaderIndex = _DaimyokeEditList[0].Leader;
            byte imperialCourtContribution = _DaimyokeEditList[0].ImperialCourtContribution;
            byte familyCrest = _DaimyokeEditList[0].FamilyCrest;
            byte relationshipWithShujinko = _DaimyokeEditList[0].RelationshipWithShujinko;
            byte departureCounter = _DaimyokeEditList[0].DepartureCounter;
            byte inactivationFlag = _DaimyokeEditList[0].InactivationFlag;
            byte daihoshin = _DaimyokeEditList[0].Daihoshin;
            ushort daihoshinTarget =_DaimyokeEditList[0].DaihoshinTarget;
            byte senryaku = _DaimyokeEditList[0].Senryaku;
            ushort senryakuTarget = _DaimyokeEditList[0].SenryakuTarget;
            byte goyoShonin1 = _DaimyokeEditList[0].GoyoShonin1;
            byte goyoShoninContribution1 = _DaimyokeEditList[0].GoyoShoninContribution1;
            byte goyoShonin2 = _DaimyokeEditList[0].GoyoShonin2;
            byte goyoShoninContribution2 = _DaimyokeEditList[0].GoyoShoninContribution2;
            byte goyoShonin3 = _DaimyokeEditList[0].GoyoShonin3;
            byte goyoShoninContribution3 = _DaimyokeEditList[0].GoyoShoninContribution3;
            // 他と一致するか確認
            bool notMatchedLeaderIndex = false;
            bool notMatchedImperialCourtContribution = false;
            bool notMatchedFamilyCrest = false;
            bool notMatchedRelationshipWithShujinko = false;
            bool notMatchedDepartureCounter = false;
            bool notMatchedInactivationFlag = false;
            bool notMatchedDaihoshin = false;
            bool notMatchedDaihoshinTarget = false;
            bool notMatchedSenryaku = false;
            bool notMatchedSenryakuTarget = false;
            bool notMatchedGoyoShonin1 = false;
            bool notMatchedGoyoShoninContribution1 = false;
            bool notMatchedGoyoShonin2 = false;
            bool notMatchedGoyoShoninContribution2 = false;
            bool notMatchedGoyoShonin3 = false;
            bool notMatchedGoyoShoninContribution3 = false;
            int nedits = _DaimyokeEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (leaderIndex != _DaimyokeEditList[i].Leader)
                    notMatchedLeaderIndex = true;
                if (imperialCourtContribution != _DaimyokeEditList[i].ImperialCourtContribution)
                    notMatchedImperialCourtContribution = true;
                if (familyCrest != _DaimyokeEditList[i].FamilyCrest)
                    notMatchedFamilyCrest = true;
                if (relationshipWithShujinko != _DaimyokeEditList[i].RelationshipWithShujinko)
                    notMatchedRelationshipWithShujinko = true;
                if (departureCounter != _DaimyokeEditList[i].DepartureCounter)
                    notMatchedDepartureCounter = true;
                if (inactivationFlag != _DaimyokeEditList[i].InactivationFlag)
                    notMatchedInactivationFlag = true;
                if (daihoshin != _DaimyokeEditList[i].Daihoshin)
                    notMatchedDaihoshin = true;
                if (daihoshinTarget != _DaimyokeEditList[i].DaihoshinTarget)
                    notMatchedDaihoshinTarget = true;
                if (senryaku != _DaimyokeEditList[i].Senryaku)
                    notMatchedSenryaku = true;
                if (senryakuTarget != _DaimyokeEditList[i].SenryakuTarget)
                    notMatchedSenryakuTarget = true;
                if (goyoShonin1 != _DaimyokeEditList[i].GoyoShonin1)
                    notMatchedGoyoShonin1 = true;
                if (goyoShoninContribution1 != _DaimyokeEditList[i].GoyoShoninContribution1)
                    notMatchedGoyoShoninContribution1 = true;
                if (goyoShonin2 != _DaimyokeEditList[i].GoyoShonin2)
                    notMatchedGoyoShonin2 = true;
                if (goyoShoninContribution2 != _DaimyokeEditList[i].GoyoShoninContribution2)
                    notMatchedGoyoShoninContribution2 = true;
                if (goyoShonin3 != _DaimyokeEditList[i].GoyoShonin3)
                    notMatchedGoyoShonin3 = true;
                if (goyoShoninContribution3 != _DaimyokeEditList[i].GoyoShoninContribution3)
                    notMatchedGoyoShoninContribution3 = true;
            }
            if (!notMatchedLeaderIndex)
            {
                if (leaderIndex >= nbusho) _LeaderComboBox.SelectedIndex = nbusho;
                else _LeaderComboBox.SelectedIndex = leaderIndex;
            }
            if (!notMatchedImperialCourtContribution)
            {
                _ImperialCourtContributionTextBox.Text = imperialCourtContribution.ToString();
            }
            if (!notMatchedFamilyCrest)
            {
                _FamilyCrestTextBox.Text = familyCrest.ToString();
                _FamilyCrestPictureBox.Image = _FamilyCrestImageList[familyCrest];
            }
            if (!notMatchedRelationshipWithShujinko)
            {
                _RelationshipWithShujinkoComboBox.SelectedIndex = relationshipWithShujinko;
            }
            if (!notMatchedDepartureCounter)
            {
                _DepartureCounterComboBox.SelectedIndex = departureCounter;
            }
            if (!notMatchedInactivationFlag)
            {
                _InactivationFlagComboBox.SelectedIndex = inactivationFlag;
            }
            if (!notMatchedDaihoshin)
            {
                _DaihoshinComboBox.SelectedIndex = daihoshin;
            }
            if (!notMatchedDaihoshinTarget)
            {
                _DaihoshinTargetTextBox.Text = daihoshinTarget.ToString();
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
            if (!notMatchedGoyoShonin1)
            {
                if (goyoShonin1 == GameData.NoneSeiryokuID) _GoyoShonin1ComboBox.SelectedIndex = nshoka;
                else _GoyoShonin1ComboBox.SelectedIndex = goyoShonin1 - GameData.NumOfDaimyoke;
            }
            if (!notMatchedGoyoShoninContribution1)
            {
                _GoyoShoninContribution1TextBox.Text = goyoShoninContribution1.ToString();
            }
            if (!notMatchedGoyoShonin2)
            {
                if (goyoShonin2 == GameData.NoneSeiryokuID) _GoyoShonin2ComboBox.SelectedIndex = nshoka;
                else _GoyoShonin2ComboBox.SelectedIndex = goyoShonin2 - GameData.NumOfDaimyoke;
            }
            if (!notMatchedGoyoShoninContribution2)
            {
                _GoyoShoninContribution2TextBox.Text = goyoShoninContribution2.ToString();
            }
            if (!notMatchedGoyoShonin3)
            {
                if (goyoShonin3 == GameData.NoneSeiryokuID) _GoyoShonin3ComboBox.SelectedIndex = nshoka;
                else _GoyoShonin3ComboBox.SelectedIndex = goyoShonin3 - GameData.NumOfDaimyoke;
            }
            if (!notMatchedGoyoShoninContribution3)
            {
                _GoyoShoninContribution3TextBox.Text = goyoShoninContribution3.ToString();
            }

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _LeaderComboBox.SelectedIndexChanged += checker;
            _RelationshipWithShujinkoComboBox.SelectedIndexChanged += checker;
            _DepartureCounterComboBox.SelectedIndexChanged += checker;
            _InactivationFlagComboBox.SelectedIndexChanged += checker;
            _DaihoshinComboBox.SelectedIndexChanged += checker;
            _SenryakuTargetComboBox.SelectedIndexChanged += checker;
            _GoyoShonin1ComboBox.SelectedIndexChanged += checker;
            _GoyoShonin2ComboBox.SelectedIndexChanged += checker;
            _GoyoShonin3ComboBox.SelectedIndexChanged += checker;
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
                    if (tb == _FamilyCrestTextBox)
                    {
                        byte id = 0;
                        if (byte.TryParse(_FamilyCrestTextBox.Text, out id))
                        {
                            _FamilyCrestPictureBox.Image = _FamilyCrestImageList[id];
                        }
                        else
                        {
                            _FamilyCrestPictureBox.Image = null;
                        }
                    }
                }
            };
            _ImperialCourtContributionTextBox.TextChanged += checkerForTextBox;
            _FamilyCrestTextBox.TextChanged += checkerForTextBox;
            _DaihoshinTargetTextBox.TextChanged += checkerForTextBox;
            _GoyoShoninContribution1TextBox.TextChanged += checkerForTextBox;
            _GoyoShoninContribution2TextBox.TextChanged += checkerForTextBox;
            _GoyoShoninContribution3TextBox.TextChanged += checkerForTextBox;
        }

        /// <summary>
        /// 戦略コンボボックスの選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _SenryakuComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ターゲットのアイテムをいったんクリアする
            _SenryakuTargetComboBox.Items.Clear();
            
            // 現在の戦略に合ったターゲットを設定
            int index = _SenryakuComboBox.SelectedIndex;
            StringBuilder stringBuilder = new StringBuilder();
            switch (index)
            {
                // 領土発展、領土守備、天下統一
                case 0:
                case 1:
                case 8:
                    _SenryakuTargetComboBox.Items.Add("0: なし");
                    _SenryakuTargetComboBox.Items.Add(65535 + ": なし");
                    _SenryakuTargetComboBox.SelectedIndex = 0;
                    break;
                // 敵城攻略
                case 2:
                    int nshiro = GameData.NumOfShiro;
                    var shiroNames = new string[nshiro];
                    for (int i = 0; i < nshiro; ++i)
                    {
                        stringBuilder.Append(i);
                        stringBuilder.Append(": ");
                        string name = _GameData.KyotenList[i].Name;
                        stringBuilder.Append(name);
                        shiroNames[i] = stringBuilder.ToString();
                        stringBuilder.Clear();
                    }
                    _SenryakuTargetComboBox.Items.AddRange(shiroNames);
                    _SenryakuTargetComboBox.Items.Add(GameData.NoneKyotenID + ": なし");
                    _SenryakuTargetComboBox.Items.Add(65535 + ": なし");
                    _SenryakuTargetComboBox.SelectedIndex = nshiro;
                    break;
                // 大名攻略
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
                // 国内統一、国内守備
                case 4:
                case 5:
                    var kuniList = _GameData.NameListDictionary["Kuni"];
                    int nkuni = kuniList.Count;
                    var kuniNames = new string[nkuni];
                    for (int i = 0; i < nkuni; ++i)
                    {
                        stringBuilder.Append(i);
                        stringBuilder.Append(": ");
                        stringBuilder.Append(kuniList[i]);
                        kuniNames[i] = stringBuilder.ToString();
                        stringBuilder.Clear();
                    }
                    _SenryakuTargetComboBox.Items.AddRange(kuniNames);
                    _SenryakuTargetComboBox.Items.Add(GameData.NoneKuniID + ": なし");
                    _SenryakuTargetComboBox.Items.Add(65535 + ": なし");
                    _SenryakuTargetComboBox.SelectedIndex = nkuni;
                    break;
                // 地方統一、地方守備
                case 6:
                case 7:
                    var chihoList = _GameData.NameListDictionary["Chiho"];
                    int nchiho = chihoList.Count;
                    var chihoNames = new string[nchiho];
                    for (int i = 0; i < nchiho; ++i)
                    {
                        stringBuilder.Append(i);
                        stringBuilder.Append(": ");
                        stringBuilder.Append(chihoList[i]);
                        chihoNames[i] = stringBuilder.ToString();
                        stringBuilder.Clear();
                    }
                    _SenryakuTargetComboBox.Items.AddRange(chihoNames);
                    _SenryakuTargetComboBox.Items.Add(GameData.NoneChihoID + ": なし");
                    _SenryakuTargetComboBox.Items.Add(65535 + ": なし");
                    _SenryakuTargetComboBox.SelectedIndex = nchiho;
                    break;
                // それ以外
                default:
                    _SenryakuTargetComboBox.Items.Add("0: なし");
                    _SenryakuTargetComboBox.Items.Add(65535 + ": なし");
                    _SenryakuTargetComboBox.SelectedIndex = 0;
                    break;
            }

            // 更新フラグを建てる
            if (sender is Control control)
                control.Tag = true;
        }

        /// <summary>
        /// 家紋画像が押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _FamilyCrestPictureBox_Click(object sender, EventArgs e)
        {
            // 例外は握りつぶす
            try
            {
                string[] names = new string[256];
                for (int i = 0; i < 256; ++i)
                {
                    names[i] = i.ToString();
                }
                int selected = 0;
                int.TryParse(_FamilyCrestTextBox.Text, out selected);
                var form = new ImageSelectForm(60, 60, _FamilyCrestImageList.ToArray(), names, selected);
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    _FamilyCrestTextBox.Text = form.SelectedImageIndex.ToString();
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

            // UIから入力内容を読み取る
            ushort leaderId = 0;
            byte imperialCourtContribution = 0;
            byte familyCrest = 0;
            byte relationshipWithShujinko = 0;
            byte departureCounter = 0;
            byte inactivationFlag = 0;
            byte daihoshin = 0;
            ushort daihoshinTarget = 0;
            byte senryaku = 0;
            ushort senryakuTarget = 0;
            byte goyoShonin1 = 0;
            byte goyoShoninContribution1 = 0;
            byte goyoShonin2 = 0;
            byte goyoShoninContribution2 = 0;
            byte goyoShonin3 = 0;
            byte goyoShoninContribution3 = 0;
            try
            {
                if ((bool)_LeaderComboBox.Tag)
                {
                    leaderId = ushort.Parse(_LeaderComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_ImperialCourtContributionTextBox.Tag)
                {
                    imperialCourtContribution = byte.Parse(_ImperialCourtContributionTextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_FamilyCrestTextBox.Tag)
                {
                    familyCrest = byte.Parse(_FamilyCrestTextBox.Text);
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
                if ((bool)_InactivationFlagComboBox.Tag)
                {
                    inactivationFlag = (byte)_InactivationFlagComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_DaihoshinComboBox.Tag)
                {
                    daihoshin = (byte)_DaihoshinComboBox.SelectedIndex;
                    isDataEdited = true;
                }
                if ((bool)_DaihoshinTargetTextBox.Tag)
                {
                    daihoshinTarget = ushort.Parse(_DaihoshinTargetTextBox.Text);
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
                if ((bool)_GoyoShonin1ComboBox.Tag)
                {
                    goyoShonin1 = byte.Parse(_GoyoShonin1ComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_GoyoShoninContribution1TextBox.Tag)
                {
                    goyoShoninContribution1 = byte.Parse(_GoyoShoninContribution1TextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_GoyoShonin2ComboBox.Tag)
                {
                    goyoShonin2 = byte.Parse(_GoyoShonin2ComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_GoyoShoninContribution2TextBox.Tag)
                {
                    goyoShoninContribution2 = byte.Parse(_GoyoShoninContribution2TextBox.Text);
                    isDataEdited = true;
                }
                if ((bool)_GoyoShonin3ComboBox.Tag)
                {
                    goyoShonin3 = byte.Parse(_GoyoShonin3ComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_GoyoShoninContribution3TextBox.Tag)
                {
                    goyoShoninContribution3 = byte.Parse(_GoyoShoninContribution3TextBox.Text);
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
            int n = _DaimyokeEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_LeaderComboBox.Tag)
                {
                    _DaimyokeEditList[i].Leader = leaderId;
                    if (leaderId == GameData.NoneBushoID)
                    {
                        _DaimyokeEditList[i].IsDestruction = true;
                        _DaimyokeEditList[i].Name = "";
                    }
                    else
                    {
                        _DaimyokeEditList[i].IsDestruction = false;
                        _DaimyokeEditList[i].Name = _GameData.BushoList[leaderId].FamilyName + "家";
                    }
                }
                if ((bool)_ImperialCourtContributionTextBox.Tag)
                {
                    _DaimyokeEditList[i].ImperialCourtContribution = imperialCourtContribution;
                }
                if ((bool)_FamilyCrestTextBox.Tag)
                {
                    _DaimyokeEditList[i].FamilyCrest = familyCrest;
                }
                if ((bool)_RelationshipWithShujinkoComboBox.Tag)
                {
                    _DaimyokeEditList[i].RelationshipWithShujinko = relationshipWithShujinko;
                }
                if ((bool)_DepartureCounterComboBox.Tag)
                {
                    _DaimyokeEditList[i].DepartureCounter = departureCounter;
                }
                if ((bool)_InactivationFlagComboBox.Tag)
                {
                    _DaimyokeEditList[i].InactivationFlag = inactivationFlag;
                }
                if ((bool)_DaihoshinComboBox.Tag)
                {
                    _DaimyokeEditList[i].Daihoshin = daihoshin;
                }
                if ((bool)_DaihoshinTargetTextBox.Tag)
                {
                    _DaimyokeEditList[i].DaihoshinTarget = daihoshinTarget;
                }
                if ((bool)_SenryakuComboBox.Tag)
                {
                    _DaimyokeEditList[i].Senryaku = senryaku;
                }
                if ((bool)_SenryakuTargetComboBox.Tag)
                {
                    _DaimyokeEditList[i].SenryakuTarget = senryakuTarget;
                }
                if ((bool)_GoyoShonin1ComboBox.Tag)
                {
                    _DaimyokeEditList[i].GoyoShonin1 = goyoShonin1;
                }
                if ((bool)_GoyoShoninContribution1TextBox.Tag)
                {
                    _DaimyokeEditList[i].GoyoShoninContribution1 = goyoShoninContribution1;
                }
                if ((bool)_GoyoShonin2ComboBox.Tag)
                {
                    _DaimyokeEditList[i].GoyoShonin2 = goyoShonin2;
                }
                if ((bool)_GoyoShoninContribution2TextBox.Tag)
                {
                    _DaimyokeEditList[i].GoyoShoninContribution2 = goyoShoninContribution2;
                }
                if ((bool)_GoyoShonin3ComboBox.Tag)
                {
                    _DaimyokeEditList[i].GoyoShonin3 = goyoShonin3;
                }
                if ((bool)_GoyoShoninContribution3TextBox.Tag)
                {
                    _DaimyokeEditList[i].GoyoShoninContribution3 = goyoShoninContribution3;
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
