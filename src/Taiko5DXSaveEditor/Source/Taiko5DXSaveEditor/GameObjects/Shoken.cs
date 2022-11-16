using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 商圏
    /// </summary>
    [Serializable]
    public class Shoken : GameObject
    {
        #region ツールで管理するプロパティ
        /// <summary>
        /// 商圏名
        /// </summary>
        public string Name { get; set; } = "";

        #endregion

        #region プロパティ
        /// <summary>
        /// 有力大名家
        /// </summary>
        public byte Daimyoke { get; set; } = 0;

        /// <summary>
        /// 商人司
        /// </summary>
        public byte ShoninTukasa { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 商圏のコンストラクタ
        /// </summary>
        public Shoken()
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
            return ID + ": " + Name;
        }

        #endregion
    }
}
