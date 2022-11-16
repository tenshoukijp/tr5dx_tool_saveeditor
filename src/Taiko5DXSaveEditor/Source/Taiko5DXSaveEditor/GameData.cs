using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor
{
    /// <summary>
    /// ゲームデータ。
    /// このクラスのインスタンスは他クラスのインスタンスの集合であり、
    /// セーブデータファイルを読み取ることで生成される。
    /// </summary>
    public class GameData
    {
        #region 定数
        /// <summary>
        /// 無しの武将ID
        /// </summary>
        public static readonly ushort NoneBushoID = 1305;

        /// <summary>
        /// 無しの勢力ID
        /// </summary>
        public static readonly byte NoneSeiryokuID = 121;

        /// <summary>
        /// 無しの拠点ID
        /// </summary>
        public static readonly ushort NoneKyotenID = 275;

        /// <summary>
        /// 無しの拠点ID (死亡武将用)
        /// </summary>
        public static readonly ushort NoneKyotenIDForDead = 511;

        /// <summary>
        /// 無しの身分ID (死亡)
        /// </summary>
        public static readonly byte NoneMibunID = 63;

        /// <summary>
        /// 無しのアイテムID
        /// </summary>
        public static readonly ushort NoneItemID = 655;

        /// <summary>
        /// 無しの商家名ID
        /// </summary>
        public static readonly byte NoneShokaNameID = 63;

        /// <summary>
        /// 無しの流派ID
        /// </summary>
        public static readonly byte NoneRyuhaID = 31;

        /// <summary>
        /// 無しの流派名ID
        /// </summary>
        public static readonly byte NoneRyuhaNameID = 31;

        /// <summary>
        /// 無しの官位ID
        /// </summary>
        public static readonly byte NoneKaniID = 151;

        /// <summary>
        /// 無しの地方ID
        /// </summary>
        public static readonly byte NoneChihoID = 11;

        /// <summary>
        /// 無しの国ID
        /// </summary>
        public static readonly byte NoneKuniID = 67;

        /// <summary>
        /// 無しの交易品ID
        /// </summary>
        public static readonly byte NoneTradeGoodsID = 101;

        /// <summary>
        /// 自分で作った流派名のID
        /// </summary>
        public static readonly byte MyRyuhaNameID = 30;

        /// <summary>
        /// 自分で作った商家名のID
        /// </summary>
        public static readonly byte MyShokaNameID = 41;

        /// <summary>
        /// 武将の枠数
        /// </summary>
        public static readonly int NumOfBusho = 1000;

        /// <summary>
        /// 汎用ライバルの枠数
        /// </summary>
        public static readonly int NumOfGeneralPurpose = 162;

        /// <summary>
        /// イベント人物の枠数
        /// </summary>
        public static readonly int NumOfEventPerson = 82;

        /// <summary>
        /// 町人の枠数
        /// </summary>
        public static readonly int NumOfCitizen = 51;

        /// <summary>
        /// 無効の人物の枠数
        /// </summary>
        public static readonly int NumOfInvalid = 9;

        /// <summary>
        /// カテゴリ関係なく登場人物全員の数
        /// </summary>
        public static int NumOfPeople { get { return NumOfBusho + NumOfGeneralPurpose + NumOfEventPerson + NumOfCitizen + NumOfInvalid; } }

        /// <summary>
        /// 大名家の枠数
        /// </summary>
        public static readonly int NumOfDaimyoke = 70;

        /// <summary>
        /// 商家の枠数
        /// </summary>
        public static readonly int NumOfShoka = 20;

        /// <summary>
        /// 忍者衆の枠数
        /// </summary>
        public static readonly int NumOfNinjaShu = 15;

        /// <summary>
        /// 海賊衆の枠数
        /// </summary>
        public static readonly int NumOfKaizokuShu = 15;

        /// <summary>
        /// 城の枠数
        /// </summary>
        public static readonly int NumOfShiro = 180;

        /// <summary>
        /// 町の枠数
        /// </summary>
        public static readonly int NumOfMachi = 66;

        /// <summary>
        /// 忍者里の枠数
        /// </summary>
        public static readonly int NumOfSato = 12;

        /// <summary>
        /// 海賊砦の枠数
        /// </summary>
        public static readonly int NumOfToride = 16;

        /// <summary>
        /// 通常アイテムの枠数
        /// </summary>
        public static readonly int NumOfNormalItems = 355;

        /// <summary>
        /// 制作アイテムの枠数
        /// </summary>
        public static readonly int NumOfCraftItems = 300;

        /// <summary>
        /// 販路の枠数
        /// </summary>
        public static readonly int NumOfHanro = 209;

        /// <summary>
        /// 商圏の枠数
        /// </summary>
        public static readonly int NumOfShoken = 15;

        /// <summary>
        /// 流派の枠数
        /// </summary>
        public static readonly int NumOfRyuha = 30;

        /// <summary>
        /// 規模のランクごとの境界値。
        /// それぞれの数値以上なら巨、大、中とし、それ未満は小である。
        /// </summary>
        public static readonly int[] ScaleLevels = new int[] { 23, 15, 7 };

        #endregion

        #region 名前リスト
        /// <summary>
        /// 名前リストの辞書。
        /// キーはファイル名から拡張子を除いたもの。値は名前リスト。
        /// </summary>
        public Dictionary<string, List<string>> NameListDictionary { get; private set; }

        #endregion

        #region ゲームオブジェクト
        /// <summary>
        /// 世界データ
        /// </summary>
        public World World { get; set; }

        /// <summary>
        /// 主人公データ
        /// </summary>
        public Shujinko Shujinko { get; set; }

        /// <summary>
        /// 武将リスト
        /// </summary>
        public List<Busho> BushoList { get; set; }

        /// <summary>
        /// 勢力リスト
        /// </summary>
        public List<Seiryoku> SeiryokuList { get; set; }

        /// <summary>
        /// 拠点リスト
        /// </summary>
        public List<Kyoten> KyotenList { get; set; }

        /// <summary>
        /// アイテムリスト
        /// </summary>
        public List<Item> ItemList { get; set; }

        /// <summary>
        /// 販路リスト
        /// </summary>
        public List<Hanro> HanroList { get; set; }

        /// <summary>
        /// 商圏リスト
        /// </summary>
        public List<Shoken> ShokenList { get; set; }

        /// <summary>
        /// 流派リスト
        /// </summary>
        public List<Ryuha> RyuhaList { get; set; }

        /// <summary>
        /// 官位表
        /// </summary>
        public List<Kani> KaniList { get; set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// ゲームデータのコンストラクタ
        /// </summary>
        /// <param name="nameListDictionary">名前リストの辞書</param>
        public GameData(Dictionary<string, List<string>> nameListDictionary)
        {
            NameListDictionary = nameListDictionary;
        }

        #endregion

    }

}
