using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// ゲームオブジェクト
    /// </summary>
    [Serializable]
    public class GameObject
    {
        #region ツールで管理するプロパティ
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// ゲームオブジェクトのコンストラクタ
        /// </summary>
        public GameObject()
        {
        }

        #endregion
    }
}
