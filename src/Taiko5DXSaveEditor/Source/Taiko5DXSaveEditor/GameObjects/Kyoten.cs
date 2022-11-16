using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 拠点（城、町、里、砦）
    /// </summary>
    [Serializable]
    public abstract class Kyoten : GameObject
    {
        #region ツールで管理するプロパティ
        /// <summary>
        /// 拠点名
        /// </summary>
        public string Name { get; set; } = "";

        #endregion

        #region プロパティ
        /// <summary>
        /// 立地（0港湾、1平地、2山地）
        /// </summary>
        public byte Location { get; set; } = 0;

        /// <summary>
        /// 規模
        /// </summary>
        public byte Scale { get; set; } = 0;

        /// <summary>
        /// 名称ID (名前リストに対応した名前になる)
        /// </summary>
        public ushort NameID { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 拠点のコンストラクタ
        /// </summary>
        public Kyoten()
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
