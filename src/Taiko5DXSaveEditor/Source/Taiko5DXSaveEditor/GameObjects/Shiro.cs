using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 城
    /// </summary>
    [Serializable]
    public class Shiro : Kyoten
    {
        #region プロパティ
        /// <summary>
        /// 城主
        /// </summary>
        public ushort Leader { get; set; } = 0;

        /// <summary>
        /// 軍資金
        /// </summary>
        public uint Money { get; set; } = 0;

        /// <summary>
        /// 兵糧
        /// </summary>
        public uint MilitaryFood { get; set; } = 0;

        /// <summary>
        /// 兵士数
        /// </summary>
        public ushort NumOfSoldiers { get; set; } = 0;

        /// <summary>
        /// 訓練度
        /// </summary>
        public byte DegreeOfTraining { get; set; } = 0;

        /// <summary>
        /// 士気
        /// </summary>
        public byte Morale { get; set; } = 0;

        /// <summary>
        /// 防御度
        /// </summary>
        public byte DefensePower { get; set; } = 0;

        /// <summary>
        /// 軍馬
        /// </summary>
        public ushort NumOfWarHorses { get; set; } = 0;

        /// <summary>
        /// 鉄砲
        /// </summary>
        public ushort NumOfGuns { get; set; } = 0;

        /// <summary>
        /// 大砲
        /// </summary>
        public ushort NumOfCannons { get; set; } = 0;

        /// <summary>
        /// 石高
        /// </summary>
        public ushort Kokudaka { get; set; } = 0;

        /// <summary>
        /// 最大石高倍数。
        /// 城の規模ごとに設定される10～40千石と掛け算する。
        /// </summary>
        public byte MaxKokudaka { get; set; } = 0;

        /// <summary>
        /// 人口。
        /// この値+50[千人]が実際の値になる
        /// </summary>
        public byte Population { get; set; } = 0;

        /// <summary>
        /// 鉱山
        /// </summary>
        public byte Mine { get; set; } = 0;

        /// <summary>
        /// 鉱山の最大値
        /// </summary>
        public byte MaxMine { get; set; } = 0;

        /// <summary>
        /// 住民安定
        /// </summary>
        public byte ResidentSupport { get; set; } = 0;

        /// <summary>
        /// 拠点画像ID
        /// </summary>
        public byte Image { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 城のコンストラクタ
        /// </summary>
        public Shiro()
        {
        }

        #endregion
    }
}
