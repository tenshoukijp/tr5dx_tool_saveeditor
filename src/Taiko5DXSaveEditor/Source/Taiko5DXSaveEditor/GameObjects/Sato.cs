using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 忍びの里
    /// </summary>
    [Serializable]
    public class Sato : Kyoten
    {
        #region プロパティ
        /// <summary>
        /// 拠点主
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

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 忍びの里のコンストラクタ
        /// </summary>
        public Sato()
        {
        }

        #endregion
    }
}
