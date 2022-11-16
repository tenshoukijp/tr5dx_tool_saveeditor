using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Taiko5DXSaveEditor
{
    /// <summary>
    /// アドレス情報。
    /// JSonファイルをデシリアライズすることで読み込む。
    /// </summary>
    [Serializable]
    public class AddressInfo
    {
        /// <summary>
        /// データの名前
        /// </summary>
        public string DataName { get; set; } = "";

        /// <summary>
        /// アドレス。
        /// JSonファイルで16進表記で書けるように文字列にしている。
        /// </summary>
        public string HexAddress { get; set; } = "";

        /// <summary>
        /// データサイズ（ビット単位）
        /// </summary>
        public int NumberOfDataBits { get; set; } = 0;

        /// <summary>
        /// 最下位ビット。
        /// 0-7で指定する。途中のビットから始まるデータを読むためのもの。
        /// </summary>
        public int LeastSignificantBit { get; set; } = 0;

        /// <summary>
        /// 次のデータへのオフセット（バイト単位）
        /// </summary>
        public int OffsetBytesOfNextData { get; set; } = 0;

        /// <summary>
        /// アドレスをint型で受け取る
        /// </summary>
        [JsonIgnore]
        public int AddressInt { get { return Convert.ToInt32(HexAddress, 16); } }

        /// <summary>
        /// アドレス情報のコンストラクタ
        /// </summary>
        public AddressInfo()
        {
        }

    }

}
