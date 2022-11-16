using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 世界
    /// </summary>
    [Serializable]
    public class World : GameObject
    {
        #region プロパティ
        /// <summary>
        /// シナリオ番号
        /// </summary>
        public byte ScenarioNumber { get; set; } = 0;

        /// <summary>
        /// 年。1500年から何年たっているか。
        /// </summary>
        public byte Year { get; set; } = 0;

        /// <summary>
        /// 月。1月は0。
        /// </summary>
        public byte Month { get; set; } = 0;

        /// <summary>
        /// 日。1日は0。
        /// </summary>
        public byte Day { get; set; } = 0;

        /// <summary>
        /// 時間
        /// </summary>
        public byte Time { get; set; } = 0;

        /// <summary>
        /// シナリオ開始からの経過日数
        /// </summary>
        public ushort PlayDays { get; set; } = 0;

        /// <summary>
        /// 次の評定までの日数
        /// </summary>
        public byte NextMeetingDays { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 世界のコンストラクタ
        /// </summary>
        public World()
        {
        }

        #endregion

    }
}
