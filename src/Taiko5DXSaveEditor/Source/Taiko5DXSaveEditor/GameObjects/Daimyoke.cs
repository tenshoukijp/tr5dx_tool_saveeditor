using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 大名家
    /// </summary>
    [Serializable]
    public class Daimyoke : Seiryoku
    {
        #region プロパティ
        /// <summary>
        /// 当主
        /// </summary>
        public ushort Leader { get; set; } = 0;

        /// <summary>
        /// 朝廷貢献
        /// </summary>
        public byte ImperialCourtContribution { get; set; } = 0;

        /// <summary>
        /// 不活性フラグ (0攻める、1攻めない)
        /// </summary>
        public byte InactivationFlag { get; set; } = 0;

        /// <summary>
        /// 大方針
        /// </summary>
        public byte Daihoshin { get; set; } = 0;

        /// <summary>
        /// 大方針ターゲット
        /// </summary>
        public ushort DaihoshinTarget { get; set; } = 0;

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
        /// 御用商人1
        /// </summary>
        public byte GoyoShonin1 { get; set; } = 0;

        /// <summary>
        /// 御用商人1の貢献度
        /// </summary>
        public byte GoyoShoninContribution1 { get; set; } = 0;

        /// <summary>
        /// 御用商人2
        /// </summary>
        public byte GoyoShonin2 { get; set; } = 0;

        /// <summary>
        /// 御用商人2の貢献度
        /// </summary>
        public byte GoyoShoninContribution2 { get; set; } = 0;

        /// <summary>
        /// 御用商人3
        /// </summary>
        public byte GoyoShonin3 { get; set; } = 0;

        /// <summary>
        /// 御用商人3の貢献度
        /// </summary>
        public byte GoyoShoninContribution3 { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 大名家のコンストラクタ
        /// </summary>
        public Daimyoke()
        {
        }

        #endregion
    }
}
