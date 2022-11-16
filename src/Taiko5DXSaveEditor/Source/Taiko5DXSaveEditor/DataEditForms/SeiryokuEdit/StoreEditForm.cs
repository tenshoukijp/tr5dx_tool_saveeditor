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
    /// 店舗を設定するフォーム
    /// </summary>
    public partial class StoreEditForm : DataEditForm
    {
        #region 定数
        /// <summary>
        /// 店舗数
        /// </summary>
        private static readonly int NUM_OF_STORE = 15;

        #endregion

        #region フィールド
        /// <summary>
        /// 編集対象の商家リスト
        /// </summary>
        private List<Shoka> _ShokaEditList = new List<Shoka>();

        /// <summary>
        /// 店長
        /// </summary>
        private ushort?[] _Leader = new ushort?[NUM_OF_STORE];

        /// <summary>
        /// 拠点
        /// </summary>
        private ushort?[] _Kyoten = new ushort?[NUM_OF_STORE];

        /// <summary>
        /// 資金
        /// </summary>
        private uint?[] _Money = new uint?[NUM_OF_STORE];

        /// <summary>
        /// 鉄砲在庫
        /// </summary>
        private uint?[] _Guns = new uint?[NUM_OF_STORE];

        /// <summary>
        /// 宣伝効果残り期間
        /// </summary>
        private byte?[] _Advertisement = new byte?[NUM_OF_STORE];

        /// <summary>
        /// 本店
        /// </summary>
        private byte? _HomeStore = null;

        /// <summary>
        /// 店舗リストの選択が変更されたフラグ
        /// </summary>
        private bool _ListSelectChangedFlag = false;

        /// <summary>
        /// 資金の変更前テキスト
        /// </summary>
        private string _BeforeMoneyText = "";

        /// <summary>
        /// 鉄砲在庫の変更前テキスト
        /// </summary>
        private string _BeforeGunsText = "";

        /// <summary>
        /// 宣伝効果残り期間の変更前テキスト
        /// </summary>
        private string _BeforeAdvertisementText = "";

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public StoreEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public StoreEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の勢力を全て受け取る
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
        private void StoreEditForm_Load(object sender, EventArgs e)
        {
            // 更新記録用のbool配列
            _LeaderComboBox.Tag = new bool[NUM_OF_STORE];
            _KyotenComboBox.Tag = new bool[NUM_OF_STORE];
            _MoneyTextBox.Tag = new bool[NUM_OF_STORE];
            _GunsTextBox.Tag = new bool[NUM_OF_STORE];
            _AdvertisementTextBox.Tag = new bool[NUM_OF_STORE];
            _StoreListBox.Tag = false;

            // コンボボックスの構築
            StringBuilder sb = new StringBuilder();
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
            _KyotenComboBox.Items.AddRange(kyotenNames);
            _KyotenComboBox.Items.Add(GameData.NoneKyotenID + ": なし");

            // 初期値設定
            for (int i = 0; i < NUM_OF_STORE; ++i)
            {
                ushort? leader = _ShokaEditList[0].StoreList[i].Leader;
                ushort? kyoten = _ShokaEditList[0].StoreList[i].Kyoten;
                uint? money = _ShokaEditList[0].StoreList[i].Money;
                uint? guns = _ShokaEditList[0].StoreList[i].Guns;
                byte? advertisement = _ShokaEditList[0].StoreList[i].Advertisement;
                int n = _ShokaEditList.Count;
                for (int j = 0; j < n; ++j)
                {
                    if ((leader != null) && (leader != _ShokaEditList[j].StoreList[i].Leader))
                        leader = null;
                    if ((kyoten != null) && (kyoten != _ShokaEditList[j].StoreList[i].Kyoten))
                        kyoten = null;
                    if ((money != null) && (money != _ShokaEditList[j].StoreList[i].Money))
                        money = null;
                    if ((guns != null) && (guns != _ShokaEditList[j].StoreList[i].Guns))
                        guns = null;
                    if ((advertisement != null) && (advertisement != _ShokaEditList[j].StoreList[i].Advertisement))
                        advertisement = null;
                }
                _Leader[i] = leader;
                _Kyoten[i] = kyoten;
                _Money[i] = money;
                _Guns[i] = guns;
                _Advertisement[i] = advertisement;
            }
            _HomeStore = _ShokaEditList[0].HomeStore;
            for (int i = 1; i < _ShokaEditList.Count; ++i)
            {
                if (_HomeStore != _ShokaEditList[i].HomeStore)
                {
                    _HomeStore = null;
                    break;
                }
            }

            // リストボックスの構築
            var storeNames = new string[NUM_OF_STORE];
            for (int i = 0; i < NUM_OF_STORE; ++i)
            {
                sb.Append(i);
                sb.Append(": ");
                if ((_Kyoten[i] != null) && (_Kyoten[i] != GameData.NoneKyotenID))
                {
                    sb.Append(_GameData.KyotenList[_Kyoten[i].Value].Name);
                }
                if ((_HomeStore != null) && (i == _HomeStore))
                {
                    sb.Append(@" 【本店】");
                }
                storeNames[i] = sb.ToString();
                sb.Clear();
            }
            _StoreListBox.Items.AddRange(storeNames);

            // イベントハンドラの設定
            _StoreListBox.SelectedIndexChanged += _StoreListBox_SelectedIndexChanged;
            _LeaderComboBox.SelectedIndexChanged += _LeaderComboBox_SelectedIndexChanged;
            _KyotenComboBox.SelectedIndexChanged += _KyotenComboBox_SelectedIndexChanged;
            _MoneyTextBox.TextChanged += _MoneyTextBox_TextChanged;
            _GunsTextBox.TextChanged += _GunsTextBox_TextChanged;
            _AdvertisementTextBox.TextChanged += _AdvertisementTextBox_TextChanged;

            // とりあえずリストの一番上を選択する
            _StoreListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 店舗リストの選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _StoreListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = _StoreListBox.SelectedIndex;
            if (index == -1)
                return;

            _ListSelectChangedFlag = true;

            // 店長
            if (_Leader[index] != null)
            {
                if (_Leader[index] != GameData.NoneBushoID)
                    _LeaderComboBox.SelectedIndex = _Leader[index].Value;
                else
                    _LeaderComboBox.SelectedIndex = _LeaderComboBox.Items.Count - 1;
            }
            else
            {
                _LeaderComboBox.SelectedIndex = -1;
            }
            // 拠点
            if (_Kyoten[index] != null)
            {
                if (_Kyoten[index] != GameData.NoneKyotenID)
                    _KyotenComboBox.SelectedIndex = _Kyoten[index].Value;
                else
                    _KyotenComboBox.SelectedIndex = _KyotenComboBox.Items.Count - 1;
            }
            else
            {
                _KyotenComboBox.SelectedIndex = -1;
            }
            // 資金
            if (_Money[index] != null)
            {
                _MoneyTextBox.Text = _Money[index].Value.ToString();
            }
            else
            {
                _MoneyTextBox.Text = "";
            }
            // 鉄砲
            if (_Guns[index] != null)
            {
                _GunsTextBox.Text = _Guns[index].Value.ToString();
            }
            else
            {
                _GunsTextBox.Text = "";
            }
            // 宣伝
            if (_Advertisement[index] != null)
            {
                _AdvertisementTextBox.Text = _Advertisement[index].Value.ToString();
            }
            else
            {
                _AdvertisementTextBox.Text = "";
            }

            // 変更前テキストを保存
            _BeforeMoneyText = _MoneyTextBox.Text;
            _BeforeGunsText = _GunsTextBox.Text;
            _BeforeAdvertisementText = _AdvertisementTextBox.Text;

            _ListSelectChangedFlag = false;
        }

        /// <summary>
        /// 店主の選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _LeaderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;

            int index = _StoreListBox.SelectedIndex;
            _Leader[index] = (ushort)_LeaderComboBox.SelectedIndex;
            ((bool[])_LeaderComboBox.Tag)[index] = true;
        }

        /// <summary>
        /// 拠点の選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _KyotenComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;

            int index = _StoreListBox.SelectedIndex;
            _Kyoten[index] = (ushort)_KyotenComboBox.SelectedIndex;
            // 店名変更
            _StoreListBox.SelectedIndexChanged -= _StoreListBox_SelectedIndexChanged;
            _StoreListBox.Items[index] = index + ": " + _GameData.KyotenList[_Kyoten[index].Value].Name;
            if ((_HomeStore != null) && (index == _HomeStore))
            {
                _StoreListBox.Items[index] = _StoreListBox.Items[index] + @" 【本店】";
            }
            _StoreListBox.SelectedIndexChanged += _StoreListBox_SelectedIndexChanged;

            ((bool[])_KyotenComboBox.Tag)[index] = true;
        }

        /// <summary>
        /// 資金のテキストが変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _MoneyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;
            if (_MoneyTextBox.Text == _BeforeMoneyText)
                return;

            int start = _MoneyTextBox.SelectionStart - 1;
            bool badTextFlg = System.Text.RegularExpressions.Regex.IsMatch(_MoneyTextBox.Text, @"[^0-9]");
            if (badTextFlg)
            {
                _MoneyTextBox.Text = _BeforeMoneyText;
                _MoneyTextBox.SelectionStart = start;
            }
            else
            {
                int index = _StoreListBox.SelectedIndex;
                long val = 0;
                if (!long.TryParse(_MoneyTextBox.Text, out val))
                {
                    _MoneyTextBox.TextChanged -= _MoneyTextBox_TextChanged;
                    _MoneyTextBox.Text = "0";
                    _MoneyTextBox.TextChanged += _MoneyTextBox_TextChanged;
                }
                if (val > uint.MaxValue)
                {
                    val = uint.MaxValue;
                    _MoneyTextBox.TextChanged -= _MoneyTextBox_TextChanged;
                    _MoneyTextBox.Text = uint.MaxValue.ToString();
                    _MoneyTextBox.TextChanged += _MoneyTextBox_TextChanged;
                }
                _Money[index] = (uint)val;
                _BeforeMoneyText = _MoneyTextBox.Text;
                ((bool[])_MoneyTextBox.Tag)[index] = true;
            }
        }

        /// <summary>
        /// 鉄砲のテキストが変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _GunsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;
            if (_GunsTextBox.Text == _BeforeGunsText)
                return;

            int start = _GunsTextBox.SelectionStart - 1;
            bool badTextFlg = System.Text.RegularExpressions.Regex.IsMatch(_GunsTextBox.Text, @"[^0-9]");
            if (badTextFlg)
            {
                _GunsTextBox.Text = _BeforeGunsText;
                _GunsTextBox.SelectionStart = start;
            }
            else
            {
                int index = _StoreListBox.SelectedIndex;
                long val = 0;
                if (!long.TryParse(_GunsTextBox.Text, out val))
                {
                    _GunsTextBox.TextChanged -= _GunsTextBox_TextChanged;
                    _GunsTextBox.Text = "0";
                    _GunsTextBox.TextChanged += _GunsTextBox_TextChanged;
                }
                if (val > uint.MaxValue)
                {
                    val = uint.MaxValue;
                    _GunsTextBox.TextChanged -= _GunsTextBox_TextChanged;
                    _GunsTextBox.Text = uint.MaxValue.ToString();
                    _GunsTextBox.TextChanged += _GunsTextBox_TextChanged;
                }
                _Guns[index] = (uint)val;
                _BeforeGunsText = _GunsTextBox.Text;
                ((bool[])_GunsTextBox.Tag)[index] = true;
            }
        }

        /// <summary>
        /// 宣伝のテキストが変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _AdvertisementTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_ListSelectChangedFlag)
                return;
            if (_AdvertisementTextBox.Text == _BeforeAdvertisementText)
                return;

            int start = _AdvertisementTextBox.SelectionStart - 1;
            bool badTextFlg = System.Text.RegularExpressions.Regex.IsMatch(_AdvertisementTextBox.Text, @"[^0-9]");
            if (badTextFlg)
            {
                _AdvertisementTextBox.Text = _BeforeAdvertisementText;
                _AdvertisementTextBox.SelectionStart = start;
            }
            else
            {
                int index = _StoreListBox.SelectedIndex;
                int val = 0;
                if (!int.TryParse(_AdvertisementTextBox.Text, out val))
                {
                    _AdvertisementTextBox.TextChanged -= _AdvertisementTextBox_TextChanged;
                    _AdvertisementTextBox.Text = "0";
                    _AdvertisementTextBox.TextChanged += _AdvertisementTextBox_TextChanged;
                }
                if (val > byte.MaxValue)
                {
                    val = byte.MaxValue;
                    _AdvertisementTextBox.TextChanged -= _AdvertisementTextBox_TextChanged;
                    _AdvertisementTextBox.Text = byte.MaxValue.ToString();
                    _AdvertisementTextBox.TextChanged += _AdvertisementTextBox_TextChanged;
                }
                _Advertisement[index] = (byte)val;
                _BeforeAdvertisementText = _AdvertisementTextBox.Text;
                ((bool[])_AdvertisementTextBox.Tag)[index] = true;
            }
        }

        /// <summary>
        /// リストボックスでマウスが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _StoreListBox_MouseDown(object sender, MouseEventArgs e)
        {
            // 右クリックでも選択できるようにする
            if (e.Button == MouseButtons.Right)
            {
                if (_StoreListBox.IndexFromPoint(e.Location) != ListBox.NoMatches)
                {
                    _StoreListBox.SelectedIndex = _StoreListBox.IndexFromPoint(e.Location);
                }
            }
        }

        /// <summary>
        /// リストボックスのコンテキストメニュー「本店に設定する」がクリックされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _HomeStoreMenuItem_Click(object sender, EventArgs e)
        {
            if (_StoreListBox.SelectedIndex == ListBox.NoMatches) 
                return;

            // 前の本店の名前を元に戻す
            if (_HomeStore != null)
            {
                _StoreListBox.Items[_HomeStore.Value] = _HomeStore + ": " + _GameData.KyotenList[_Kyoten[_HomeStore.Value].Value].Name;
            }
            // 新たな本店の設定
            _HomeStore = (byte)_StoreListBox.SelectedIndex;
            _StoreListBox.Items[_HomeStore.Value] = _HomeStore + ": " + _GameData.KyotenList[_Kyoten[_HomeStore.Value].Value].Name + @" 【本店】";
            // 変更フラグを立てる
            _StoreListBox.Tag = true;
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _OKButton_Click(object sender, EventArgs e)
        {
            // 結果を反映させる
            for (int i = 0; i < NUM_OF_STORE; ++i)
            {
                if (((bool[])_LeaderComboBox.Tag)[i])
                {
                    foreach (var shoka in _ShokaEditList)
                    {
                        shoka.StoreList[i].Leader = _Leader[i].Value;
                    }
                }
                if (((bool[])_KyotenComboBox.Tag)[i])
                {
                    foreach (var shoka in _ShokaEditList)
                    {
                        shoka.StoreList[i].Kyoten = _Kyoten[i].Value;
                    }
                }
                if (((bool[])_MoneyTextBox.Tag)[i])
                {
                    foreach (var shoka in _ShokaEditList)
                    {
                        shoka.StoreList[i].Money = _Money[i].Value;
                    }
                }
                if (((bool[])_GunsTextBox.Tag)[i])
                {
                    foreach (var shoka in _ShokaEditList)
                    {
                        shoka.StoreList[i].Guns = _Guns[i].Value;
                    }
                }
                if (((bool[])_AdvertisementTextBox.Tag)[i])
                {
                    foreach (var shoka in _ShokaEditList)
                    {
                        shoka.StoreList[i].Advertisement = _Advertisement[i].Value;
                    }
                }
            }
            if ((bool)_StoreListBox.Tag)
            {
                foreach (var shoka in _ShokaEditList)
                {
                    shoka.HomeStore = _HomeStore.Value;
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
