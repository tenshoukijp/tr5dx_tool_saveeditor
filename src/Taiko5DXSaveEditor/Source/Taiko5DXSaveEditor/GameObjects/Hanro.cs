using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 販路
    /// </summary>
    [Serializable]
    public class Hanro : GameObject
    {
        #region プロパティ
        /// <summary>
        /// 町1
        /// </summary>
        public ushort Machi1 { get; set; } = 0;

        /// <summary>
        /// 町2
        /// </summary>
        public ushort Machi2 { get; set; } = 0;

        /// <summary>
        /// 管理者
        /// </summary>
        public ushort Administrator { get; set; } = 0;

        /// <summary>
        /// 護衛
        /// </summary>
        public byte Guard { get; set; } = 0;

        /// <summary>
        /// 勘定
        /// </summary>
        public int Kanjo { get; set; } = 0;

        /// <summary>
        /// 維持費
        /// </summary>
        public ushort MaintenanceCosts { get; set; } = 0;

        /// <summary>
        /// 販路の種類（0陸路、1海路）
        /// </summary>
        public byte Type { get; set; } = 0;

        /// <summary>
        /// 荷留め期間
        /// </summary>
        public byte Stopping { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 販路のコンストラクタ
        /// </summary>
        public Hanro()
        {
        }

        #endregion

        #region ToString実装
        /// <summary>
        /// オブジェクトを文字列にして返す
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return ID + "";
        }

        #endregion

    }
}
