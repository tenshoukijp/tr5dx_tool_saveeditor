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

namespace Taiko5DXSaveEditor.DataEditForms.KyotenEdit
{
    /// <summary>
    /// 町の施設を設定するフォーム
    /// </summary>
    public partial class MachiShisetuEditForm : DataEditForm
    {
        #region フィールド
        /// <summary>
        /// 編集対象の町リスト
        /// </summary>
        private List<Machi> _MachiEditList = new List<Machi>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public MachiShisetuEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public MachiShisetuEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の町を全て受け取る
            var machis = from machi in gameData.KyotenList
                         where selectedIDs.Contains(machi.ID)
                         select (Machi)machi;
            _MachiEditList.AddRange(machis);
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
        private void MachiShisetuEditForm_Load(object sender, EventArgs e)
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

            // 閉鎖
            string close = GameData.NoneBushoID + @": なし";
            // 米屋 (1245のみ)
            _RiceStoreComboBox.Items.Add(1245 + ": " + _GameData.BushoList[1245].Name);
            _RiceStoreComboBox.Items.Add(close);
            // 馬屋 (1246のみ)
            _StableComboBox.Items.Add(1246 + ": " + _GameData.BushoList[1246].Name);
            _StableComboBox.Items.Add(close);
            // 酒場 (1247のみ)
            _BarComboBox.Items.Add(1247 + ": " + _GameData.BushoList[1247].Name);
            _BarComboBox.Items.Add(close);
            // 宿屋 (1248のみ)
            _InnComboBox.Items.Add(1248 + ": " + _GameData.BushoList[1248].Name);
            _InnComboBox.Items.Add(close);
            // 民家 (1249のみ)
            _PrivateHouseComboBox.Items.Add(1249 + ": " + _GameData.BushoList[1249].Name);
            _PrivateHouseComboBox.Items.Add(close);
            // 寺 (僧侶の武将)
            var soryos = from busho in _GameData.BushoList
                         where busho.ID < 1000
                         where busho.Mibun == 32
                         orderby busho.ID
                         select busho.ID + ": " + busho.Name;
            _TempleComboBox.Items.AddRange(soryos.ToArray());
            // 道場 (師範・師範代)
            var shihans = from busho in _GameData.BushoList
                          where busho.ID < 1000
                          where (busho.Mibun == 33) || (busho.Mibun == 34)
                          orderby busho.ID
                          select busho.ID + ": " + busho.Name;
            _Dojo1ComboBox.Items.AddRange(shihans.ToArray());
            _Dojo2ComboBox.Items.AddRange(shihans.ToArray());
            // 寺・道場1 (汎用ライバル以降の人物)
            StringBuilder stringBuilder = new StringBuilder();
            int n = GameData.NumOfGeneralPurpose + GameData.NumOfEventPerson + GameData.NumOfCitizen + GameData.NumOfInvalid;
            var names = new string[n];
            for (int i = 0; i < n; ++i)
            {
                int index = GameData.NumOfBusho + i;
                stringBuilder.Append(index);
                stringBuilder.Append(": ");
                stringBuilder.Append(_GameData.BushoList[index].FamilyName);
                stringBuilder.Append(_GameData.BushoList[index].GivenName);
                string name = stringBuilder.ToString();
                names[i] = name;
                stringBuilder.Clear();
            }
            _TempleComboBox.Items.AddRange(names);
            _Dojo1ComboBox.Items.AddRange(names);
            _TempleComboBox.Items.Add(close);
            _Dojo1ComboBox.Items.Add(close);
            _Dojo2ComboBox.Items.Add(close);
            // 医師宅・茶人宅・鍛冶屋・職人宅・南蛮寺・南蛮商館 (誰でもOK)
            var names2 = new string[GameData.NumOfPeople];
            for (int i = 0; i < GameData.NumOfPeople; ++i)
            {
                stringBuilder.Append(i);
                stringBuilder.Append(": ");
                stringBuilder.Append(_GameData.BushoList[i].FamilyName);
                stringBuilder.Append(_GameData.BushoList[i].GivenName);
                string name = stringBuilder.ToString();
                names2[i] = name;
                stringBuilder.Clear();
            }
            _DoctorHouseComboBox.Items.AddRange(names2);
            _TeaMasterHouseComboBox.Items.AddRange(names2);
            _BlacksmithComboBox.Items.AddRange(names2);
            _CraftsmanHouseComboBox.Items.AddRange(names2);
            _ForeignTempleComboBox.Items.AddRange(names2);
            _ForeignFirmComboBox.Items.AddRange(names2);
            _DoctorHouseComboBox.Items.Add(close);
            _TeaMasterHouseComboBox.Items.Add(close);
            _BlacksmithComboBox.Items.Add(close);
            _CraftsmanHouseComboBox.Items.Add(close);
            _ForeignTempleComboBox.Items.Add(close);
            _ForeignFirmComboBox.Items.Add(close);
            // 公家宅 (1174のみ)
            _AristocraticHouseComboBox.Items.Add(1174 + ": " + _GameData.BushoList[1174].Name);
            _AristocraticHouseComboBox.Items.Add(close);
            // 御所 (1176のみ)
            _ImperialPalaceComboBox.Items.Add(1176 + ": " + _GameData.BushoList[1176].Name);
            _ImperialPalaceComboBox.Items.Add(close);
            // 座 (1269のみ)
            _MarketComboBox.Items.Add(1269 + ": " + _GameData.BushoList[1269].Name);
            _MarketComboBox.Items.Add(close);
            // 交易所 (1270-1273のみ)
            _TradingPostComboBox.Items.Add(1270 + ": " + _GameData.BushoList[1270].Name);
            _TradingPostComboBox.Items.Add(1271 + ": " + _GameData.BushoList[1271].Name);
            _TradingPostComboBox.Items.Add(1272 + ": " + _GameData.BushoList[1272].Name);
            _TradingPostComboBox.Items.Add(1273 + ": " + _GameData.BushoList[1273].Name);
            _TradingPostComboBox.Items.Add(close);

            // 初期値の設定
            ushort riceStore = _MachiEditList[0].RiceStore;
            ushort stable = _MachiEditList[0].Stable;
            ushort bar = _MachiEditList[0].Bar;
            ushort inn = _MachiEditList[0].Inn;
            ushort privateHouse = _MachiEditList[0].PrivateHouse;
            ushort temple = _MachiEditList[0].Temple;
            ushort dojo1 = _MachiEditList[0].Dojo1;
            ushort dojo2 = _MachiEditList[0].Dojo2;
            ushort doctorHouse = _MachiEditList[0].DoctorHouse;
            ushort teaMasterHouse = _MachiEditList[0].TeaMasterHouse;
            ushort blacksmith = _MachiEditList[0].Blacksmith;
            ushort craftsmanHouse = _MachiEditList[0].CraftsmanHouse;
            ushort foreignTemple = _MachiEditList[0].ForeignTemple;
            ushort foreignFirm = _MachiEditList[0].ForeignFirm;
            ushort aristocraticHouse = _MachiEditList[0].AristocraticHouse;
            ushort imperialPalace = _MachiEditList[0].ImperialPalace;
            ushort market = _MachiEditList[0].Market;
            ushort tradingPost = _MachiEditList[0].TradingPost;
            // 他と一致するか確認
            bool notMatchedRiceStore = false;
            bool notMatchedStable = false;
            bool notMatchedBar = false;
            bool notMatchedInn = false;
            bool notMatchedPrivateHouse = false;
            bool notMatchedTemple = false;
            bool notMatchedDojo1 = false;
            bool notMatchedDojo2 = false;
            bool notMatchedDoctorHouse = false;
            bool notMatchedTeaMasterHouse = false;
            bool notMatchedBlacksmith = false;
            bool notMatchedCraftsmanHouse = false;
            bool notMatchedForeignTemple = false;
            bool notMatchedForeignFirm = false;
            bool notMatchedAristocraticHouse = false;
            bool notMatchedImperialPalace = false;
            bool notMatchedMarket = false;
            bool notMatchedTradingPost = false;
            int nedits = _MachiEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (riceStore != _MachiEditList[i].RiceStore)
                    notMatchedRiceStore = true;
                if (stable != _MachiEditList[i].Stable)
                    notMatchedStable = true;
                if (bar != _MachiEditList[i].Bar)
                    notMatchedBar = true;
                if (inn != _MachiEditList[i].Inn)
                    notMatchedInn = true;
                if (privateHouse != _MachiEditList[i].PrivateHouse)
                    notMatchedPrivateHouse = true;
                if (temple != _MachiEditList[i].Temple)
                    notMatchedTemple = true;
                if (dojo1 != _MachiEditList[i].Dojo1)
                    notMatchedDojo1 = true;
                if (dojo2 != _MachiEditList[i].Dojo2)
                    notMatchedDojo2 = true;
                if (doctorHouse != _MachiEditList[i].DoctorHouse)
                    notMatchedDoctorHouse = true;
                if (teaMasterHouse != _MachiEditList[i].TeaMasterHouse)
                    notMatchedTeaMasterHouse = true;
                if (blacksmith != _MachiEditList[i].Blacksmith)
                    notMatchedBlacksmith = true;
                if (craftsmanHouse != _MachiEditList[i].CraftsmanHouse)
                    notMatchedCraftsmanHouse = true;
                if (foreignTemple != _MachiEditList[i].ForeignTemple)
                    notMatchedForeignTemple = true;
                if (foreignFirm != _MachiEditList[i].ForeignFirm)
                    notMatchedForeignFirm = true;
                if (aristocraticHouse != _MachiEditList[i].AristocraticHouse)
                    notMatchedAristocraticHouse = true;
                if (imperialPalace != _MachiEditList[i].ImperialPalace)
                    notMatchedImperialPalace = true;
                if (market != _MachiEditList[i].Market)
                    notMatchedMarket = true;
            }

            Action<ushort, ComboBox> setInitValue = (val, comboBox) =>
            {
                if (val != GameData.NoneBushoID)
                {
                    string search = val + ": " + _GameData.BushoList[val].Name;
                    int index = comboBox.Items.IndexOf(search);
                    if (index != -1)
                        comboBox.SelectedIndex = index;
                }
                else
                {
                    comboBox.SelectedIndex = comboBox.Items.Count - 1;
                }
            };
            if (!notMatchedRiceStore)
            {
                setInitValue(riceStore, _RiceStoreComboBox);
            }
            if (!notMatchedStable)
            {
                setInitValue(stable, _StableComboBox);
            }
            if (!notMatchedBar)
            {
                setInitValue(bar, _BarComboBox);
            }
            if (!notMatchedInn)
            {
                setInitValue(inn, _InnComboBox);
            }
            if (!notMatchedPrivateHouse)
            {
                setInitValue(privateHouse, _PrivateHouseComboBox);
            }
            if (!notMatchedTemple)
            {
                setInitValue(temple, _TempleComboBox);
            }
            if (!notMatchedDojo1)
            {
                setInitValue(dojo1, _Dojo1ComboBox);
            }
            if (!notMatchedDojo2)
            {
                setInitValue(dojo2, _Dojo2ComboBox);
            }
            if (!notMatchedDoctorHouse)
            {
                setInitValue(doctorHouse, _DoctorHouseComboBox);
            }
            if (!notMatchedTeaMasterHouse)
            {
                setInitValue(teaMasterHouse, _TeaMasterHouseComboBox);
            }
            if (!notMatchedBlacksmith)
            {
                setInitValue(blacksmith, _BlacksmithComboBox);
            }
            if (!notMatchedCraftsmanHouse)
            {
                setInitValue(craftsmanHouse, _CraftsmanHouseComboBox);
            }
            if (!notMatchedForeignTemple)
            {
                setInitValue(foreignTemple, _ForeignTempleComboBox);
            }
            if (!notMatchedForeignFirm)
            {
                setInitValue(foreignFirm, _ForeignFirmComboBox);
            }
            if (!notMatchedAristocraticHouse)
            {
                setInitValue(aristocraticHouse, _AristocraticHouseComboBox);
            }
            if (!notMatchedImperialPalace)
            {
                setInitValue(imperialPalace, _ImperialPalaceComboBox);
            }
            if (!notMatchedMarket)
            {
                setInitValue(market, _MarketComboBox);
            }
            if (!notMatchedTradingPost)
            {
                setInitValue(tradingPost, _TradingPostComboBox);
            }

            // イベントハンドラの設定
            EventHandler checker = (sender2, e2) =>
            {
                if (sender2 is Control control)
                    control.Tag = true;
            };
            _RiceStoreComboBox.SelectedIndexChanged += checker;
            _StableComboBox.SelectedIndexChanged += checker;
            _BarComboBox.SelectedIndexChanged += checker;
            _InnComboBox.SelectedIndexChanged += checker;
            _PrivateHouseComboBox.SelectedIndexChanged += checker;
            _TempleComboBox.SelectedIndexChanged += checker;
            _Dojo1ComboBox.SelectedIndexChanged += checker;
            _Dojo2ComboBox.SelectedIndexChanged += checker;
            _DoctorHouseComboBox.SelectedIndexChanged += checker;
            _TeaMasterHouseComboBox.SelectedIndexChanged += checker;
            _BlacksmithComboBox.SelectedIndexChanged += checker;
            _CraftsmanHouseComboBox.SelectedIndexChanged += checker;
            _ForeignTempleComboBox.SelectedIndexChanged += checker;
            _ForeignFirmComboBox.SelectedIndexChanged += checker;
            _AristocraticHouseComboBox.SelectedIndexChanged += checker;
            _ImperialPalaceComboBox.SelectedIndexChanged += checker;
            _MarketComboBox.SelectedIndexChanged += checker;
            _TradingPostComboBox.SelectedIndexChanged += checker;
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
            ushort riceStore = 0;
            ushort stable = 0;
            ushort bar = 0;
            ushort inn = 0;
            ushort privateHouse = 0;
            ushort temple = 0;
            ushort dojo1 = 0;
            ushort dojo2 = 0;
            ushort doctorHouse = 0;
            ushort teaMasterHouse = 0;
            ushort blacksmith = 0;
            ushort craftsmanHouse = 0;
            ushort foreignTemple = 0;
            ushort foreignFirm = 0;
            ushort aristocraticHouse = 0;
            ushort imperialPalace = 0;
            ushort market = 0;
            ushort tradingPost = 0;
            try
            {
                if ((bool)_RiceStoreComboBox.Tag)
                {
                    riceStore = ushort.Parse(_RiceStoreComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_StableComboBox.Tag)
                {
                    stable = ushort.Parse(_StableComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_BarComboBox.Tag)
                {
                    bar = ushort.Parse(_BarComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_InnComboBox.Tag)
                {
                    inn = ushort.Parse(_InnComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_PrivateHouseComboBox.Tag)
                {
                    privateHouse = ushort.Parse(_PrivateHouseComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_TempleComboBox.Tag)
                {
                    temple = ushort.Parse(_TempleComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_Dojo1ComboBox.Tag)
                {
                    dojo1 = ushort.Parse(_Dojo1ComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_Dojo2ComboBox.Tag)
                {
                    dojo2 = ushort.Parse(_Dojo2ComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_DoctorHouseComboBox.Tag)
                {
                    doctorHouse = ushort.Parse(_DoctorHouseComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_TeaMasterHouseComboBox.Tag)
                {
                    teaMasterHouse = ushort.Parse(_TeaMasterHouseComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_BlacksmithComboBox.Tag)
                {
                    blacksmith = ushort.Parse(_BlacksmithComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_CraftsmanHouseComboBox.Tag)
                {
                    craftsmanHouse = ushort.Parse(_CraftsmanHouseComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_ForeignTempleComboBox.Tag)
                {
                    foreignTemple = ushort.Parse(_ForeignTempleComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_ForeignFirmComboBox.Tag)
                {
                    foreignFirm = ushort.Parse(_ForeignFirmComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_AristocraticHouseComboBox.Tag)
                {
                    aristocraticHouse = ushort.Parse(_AristocraticHouseComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_ImperialPalaceComboBox.Tag)
                {
                    imperialPalace = ushort.Parse(_ImperialPalaceComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_MarketComboBox.Tag)
                {
                    market = ushort.Parse(_MarketComboBox.Text.Split(':')[0]);
                    isDataEdited = true;
                }
                if ((bool)_TradingPostComboBox.Tag)
                {
                    tradingPost = ushort.Parse(_TradingPostComboBox.Text.Split(':')[0]);
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
            int n = _MachiEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_RiceStoreComboBox.Tag)
                {
                    _MachiEditList[i].RiceStore = riceStore;
                }
                if ((bool)_StableComboBox.Tag)
                {
                    _MachiEditList[i].Stable = stable;
                }
                if ((bool)_BarComboBox.Tag)
                {
                    _MachiEditList[i].Bar = bar;
                }
                if ((bool)_InnComboBox.Tag)
                {
                    _MachiEditList[i].Inn = inn;
                }
                if ((bool)_PrivateHouseComboBox.Tag)
                {
                    _MachiEditList[i].PrivateHouse = privateHouse;
                }
                if ((bool)_TempleComboBox.Tag)
                {
                    _MachiEditList[i].Temple = temple;
                }
                if ((bool)_Dojo1ComboBox.Tag)
                {
                    _MachiEditList[i].Dojo1 = dojo1;
                }
                if ((bool)_Dojo2ComboBox.Tag)
                {
                    _MachiEditList[i].Dojo2 = dojo2;
                }
                if ((bool)_DoctorHouseComboBox.Tag)
                {
                    _MachiEditList[i].DoctorHouse = doctorHouse;
                }
                if ((bool)_TeaMasterHouseComboBox.Tag)
                {
                    _MachiEditList[i].TeaMasterHouse = teaMasterHouse;
                }
                if ((bool)_BlacksmithComboBox.Tag)
                {
                    _MachiEditList[i].Blacksmith = blacksmith;
                }
                if ((bool)_CraftsmanHouseComboBox.Tag)
                {
                    _MachiEditList[i].CraftsmanHouse = craftsmanHouse;
                }
                if ((bool)_ForeignTempleComboBox.Tag)
                {
                    _MachiEditList[i].ForeignTemple = foreignTemple;
                }
                if ((bool)_ForeignFirmComboBox.Tag)
                {
                    _MachiEditList[i].ForeignFirm = foreignFirm;
                }
                if ((bool)_AristocraticHouseComboBox.Tag)
                {
                    _MachiEditList[i].AristocraticHouse = aristocraticHouse;
                }
                if ((bool)_ImperialPalaceComboBox.Tag)
                {
                    _MachiEditList[i].ImperialPalace = imperialPalace;
                }
                if ((bool)_MarketComboBox.Tag)
                {
                    _MachiEditList[i].Market = market;
                }
                if ((bool)_TradingPostComboBox.Tag)
                {
                    _MachiEditList[i].TradingPost = tradingPost;
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
