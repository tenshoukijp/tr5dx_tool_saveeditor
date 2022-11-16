using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 海賊衆
    /// </summary>
    [Serializable]
    public class KaizokuShu : Seiryoku
    {
        #region プロパティ
        /// <summary>
        /// 当主
        /// </summary>
        public ushort Leader { get; set; } = 0;

        /// <summary>
        /// 名称ID (名前リストに対応した名前になる)
        /// </summary>
        public byte NameID { get; set; } = 0;

        /// <summary>
        /// 戦略
        /// </summary>
        public byte Senryaku { get; set; } = 0;

        /// <summary>
        /// 戦略ターゲット。
        /// 戦略によって選ぶものが異なる。
        /// </summary>
        public ushort SenryakuTarget { get; set; } = 0;

        /// <summary>
        /// 大型船の建造技術
        /// </summary>
        public byte ShipbuildingMiddle { get; set; } = 0;

        /// <summary>
        /// 鉄甲船の建造技術
        /// </summary>
        public byte ShipbuildingStrong { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 海賊衆のコンストラクタ
        /// </summary>
        public KaizokuShu()
        {
        }

        #endregion
    }
}
