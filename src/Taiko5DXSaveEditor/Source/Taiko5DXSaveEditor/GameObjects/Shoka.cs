using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 商家
    /// </summary>
    [Serializable]
    public class Shoka : Seiryoku
    {
        #region 管理用
        /// <summary>
        /// 当主
        /// </summary>
        public ushort Leader
        {
            get { return StoreList[HomeStore].Leader; }
            set { StoreList[HomeStore].Leader = value; }
        }

        /// <summary>
        /// 本店
        /// </summary>
        public ushort Home
        {
            get { return StoreList[HomeStore].Kyoten; }
            set { StoreList[HomeStore].Kyoten = value; }
        }

        #endregion

        #region プロパティ
        /// <summary>
        /// 名称ID (名前リストに対応した名前になる)
        /// </summary>
        public byte NameID { get; set; } = 0;

        /// <summary>
        /// 店舗(全部で15店舗)
        /// </summary>
        public List<Store> StoreList { get; set; } = new List<Store>();

        /// <summary>
        /// 本店店舗
        /// </summary>
        public byte HomeStore { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 商家のコンストラクタ
        /// </summary>
        public Shoka()
        {
            for (int i = 0; i < 15; ++i)
            {
                StoreList.Add(new Store());
            }
        }

        #endregion

        #region メソッド
        /// <summary>
        /// 店舗データのセット
        /// </summary>
        /// <param name="leader">店長</param>
        /// <param name="kyoten">拠点</param>
        /// <param name="money">資金</param>
        /// <param name="guns">鉄砲在庫</param>
        /// <param name="advertisement">宣伝期間</param>
        public void SetStoresData(byte[] leader, byte[] kyoten, byte[] money, byte[] guns, byte[] advertisement)
        {
            int n = StoreList.Count;
            for (int i = 0; i < n; ++i)
            {
                StoreList[i].Leader = (ushort)((leader[i * 2 + 1] << 8) | leader[i * 2]);
                StoreList[i].Kyoten = (ushort)((kyoten[i * 2 + 1] << 8) | kyoten[i * 2]);
                StoreList[i].Money = (uint)((money[i * 4 + 3] << 24) | (money[i * 4 + 2] << 16) | (money[i * 4 + 1] << 8) | money[i * 4]);
                StoreList[i].Guns = (uint)((guns[i * 4 + 3] << 24) | (guns[i * 4 + 2] << 16) | (guns[i * 4 + 1] << 8) | guns[i * 4]);
                StoreList[i].Advertisement = advertisement[i];
            }
        }

        /// <summary>
        /// 店長のbyte配列取得
        /// </summary>
        /// <returns>店長</returns>
        public byte[] GetStoreLeaderBytes()
        {
            byte[] result = new byte[30];
            int n = StoreList.Count;
            for (int i = 0; i < n; ++i)
            {
                result[i * 2] = (byte)(StoreList[i].Leader & 0xFF);
                result[i * 2 + 1] = (byte)((StoreList[i].Leader & 0xFF00) >> 8);
            }
            return result;
        }

        /// <summary>
        /// 拠点のbyte配列取得
        /// </summary>
        /// <returns>拠点</returns>
        public byte[] GetStoreKyotenBytes()
        {
            byte[] result = new byte[30];
            int n = StoreList.Count;
            for (int i = 0; i < n; ++i)
            {
                result[i * 2] = (byte)(StoreList[i].Kyoten & 0xFF);
                result[i * 2 + 1] = (byte)((StoreList[i].Kyoten & 0xFF00) >> 8);
            }
            return result;
        }

        /// <summary>
        /// 資金のbyte配列取得
        /// </summary>
        /// <returns>資金</returns>
        public byte[] GetStoreMoneyBytes()
        {
            byte[] result = new byte[60];
            int n = StoreList.Count;
            for (int i = 0; i < n; ++i)
            {
                result[i * 4] = (byte)(StoreList[i].Money & 0xFF);
                result[i * 4 + 1] = (byte)((StoreList[i].Money & 0xFF00) >> 8);
                result[i * 4 + 2] = (byte)((StoreList[i].Money & 0xFF0000) >> 16);
                result[i * 4 + 3] = (byte)((StoreList[i].Money & 0xFF000000) >> 24);
            }
            return result;
        }

        /// <summary>
        /// 鉄砲のbyte配列取得
        /// </summary>
        /// <returns>鉄砲</returns>
        public byte[] GetStoreGunsBytes()
        {
            byte[] result = new byte[60];
            int n = StoreList.Count;
            for (int i = 0; i < n; ++i)
            {
                result[i * 4] = (byte)(StoreList[i].Guns & 0xFF);
                result[i * 4 + 1] = (byte)((StoreList[i].Guns & 0xFF00) >> 8);
                result[i * 4 + 2] = (byte)((StoreList[i].Guns & 0xFF0000) >> 16);
                result[i * 4 + 3] = (byte)((StoreList[i].Guns & 0xFF000000) >> 24);
            }
            return result;
        }

        /// <summary>
        /// 宣伝期間のbyte配列取得
        /// </summary>
        /// <returns>宣伝期間</returns>
        public byte[] GetStoreAdvertisementBytes()
        {
            byte[] result = new byte[15];
            int n = StoreList.Count;
            for (int i = 0; i < n; ++i)
            {
                result[i] = StoreList[i].Advertisement;
            }
            return result;
        }

        #endregion

    }

    /// <summary>
    /// 店舗
    /// </summary>
    public class Store
    {
        #region プロパティ
        /// <summary>
        /// 店長
        /// </summary>
        public ushort Leader { get; set; } = 0;

        /// <summary>
        /// 拠点
        /// </summary>
        public ushort Kyoten { get; set; } = 0;

        /// <summary>
        /// 資金
        /// </summary>
        public uint Money { get; set; } = 0;

        /// <summary>
        /// 鉄砲在庫
        /// </summary>
        public uint Guns { get; set; } = 0;

        /// <summary>
        /// 宣伝効果残り期間（カ月）
        /// </summary>
        public byte Advertisement { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 店舗のコンストラクタ
        /// </summary>
        public Store()
        {
        }

        #endregion

    }

}
