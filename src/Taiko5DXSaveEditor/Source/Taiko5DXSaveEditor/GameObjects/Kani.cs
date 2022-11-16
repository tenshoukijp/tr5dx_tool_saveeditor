using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 官位（ゲーム中にその他情報から確認できる表のもの）
    /// </summary>
    [Serializable]
    public class Kani : GameObject
    {
        #region プロパティ
        /// <summary>
        /// 就任者
        /// </summary>
        public ushort InauguratedPerson { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 官位のコンストラクタ
        /// </summary>
        public Kani()
        {
        }

        #endregion

    }
}
