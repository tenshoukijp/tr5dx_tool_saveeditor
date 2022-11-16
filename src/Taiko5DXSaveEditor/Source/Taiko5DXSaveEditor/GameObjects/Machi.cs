using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 町
    /// </summary>
    [Serializable]
    public class Machi : Kyoten
    {
        #region プロパティ
        /// <summary>
        /// 拠点画像ID
        /// </summary>
        public byte Image { get; set; } = 0;

        /// <summary>
        /// 投資金
        /// </summary>
        public uint Money { get; set; } = 0;

        /// <summary>
        /// 米相場（貫）
        /// </summary>
        public byte RiceMarketPrice { get; set; } = 0;

        /// <summary>
        /// 米在庫（千石）
        /// </summary>
        public byte RiceInventory { get; set; } = 0;

        /// <summary>
        /// 馬相場（貫）
        /// </summary>
        public byte HorseMarketPrice { get; set; } = 0;

        /// <summary>
        /// 馬在庫（10頭）
        /// </summary>
        public byte HorseInventory { get; set; } = 0;

        #endregion

        #region プロパティ：施設
        /// <summary>
        /// 米屋
        /// </summary>
        public ushort RiceStore { get; set; } = 0;

        /// <summary>
        /// 馬屋
        /// </summary>
        public ushort Stable { get; set; } = 0;

        /// <summary>
        /// 酒場
        /// </summary>
        public ushort Bar { get; set; } = 0;

        /// <summary>
        /// 宿屋
        /// </summary>
        public ushort Inn { get; set; } = 0;

        /// <summary>
        /// 民家
        /// </summary>
        public ushort PrivateHouse { get; set; } = 0;

        /// <summary>
        /// 寺
        /// </summary>
        public ushort Temple { get; set; } = 0;

        /// <summary>
        /// 道場1
        /// </summary>
        public ushort Dojo1 { get; set; } = 0;

        /// <summary>
        /// 道場2
        /// </summary>
        public ushort Dojo2 { get; set; } = 0;

        /// <summary>
        /// 医師宅
        /// </summary>
        public ushort DoctorHouse { get; set; } = 0;

        /// <summary>
        /// 茶人宅
        /// </summary>
        public ushort TeaMasterHouse { get; set; } = 0;

        /// <summary>
        /// 鍛冶屋
        /// </summary>
        public ushort Blacksmith { get; set; } = 0;

        /// <summary>
        /// 職人宅
        /// </summary>
        public ushort CraftsmanHouse { get; set; } = 0;

        /// <summary>
        /// 南蛮寺
        /// </summary>
        public ushort ForeignTemple { get; set; } = 0;

        /// <summary>
        /// 南蛮商館
        /// </summary>
        public ushort ForeignFirm { get; set; } = 0;

        /// <summary>
        /// 公家宅
        /// </summary>
        public ushort AristocraticHouse { get; set; } = 0;

        /// <summary>
        /// 御所
        /// </summary>
        public ushort ImperialPalace { get; set; } = 0;

        /// <summary>
        /// 座
        /// </summary>
        public ushort Market { get; set; } = 0;

        /// <summary>
        /// 交易所
        /// </summary>
        public ushort TradingPost { get; set; } = 0;

        #endregion

        #region 交易品
        /// <summary>
        /// 交易品
        /// </summary>
        public byte[] TradeGoods { get; set; } = null;

        /// <summary>
        /// 交易品の供給率
        /// </summary>
        public byte[] TradeGoodsSupplyRate { get; set; } = null;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 町のコンストラクタ
        /// </summary>
        public Machi()
        {
        }

        #endregion
    }
}
