using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 流派
    /// </summary>
    [Serializable]
    public class Ryuha : GameObject
    {
        #region ツールで管理するプロパティ
        /// <summary>
        /// 流派名
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 滅亡しているか
        /// </summary>
        public bool IsDestruction { get; set; } = false;

        #endregion

        #region プロパティ
        /// <summary>
        /// 宗家
        /// </summary>
        public ushort Leader { get; set; } = 0;

        /// <summary>
        /// 名称ID (名前リストに対応した名前になる)
        /// </summary>
        public byte NameID { get; set; } = 0;

        /// <summary>
        /// 主人公が印可状を所持しているか
        /// </summary>
        public byte License { get; set; } = 0;

        /// <summary>
        /// 道場破り。通常は道場破りをしたら6になる。
        /// </summary>
        public byte DojoYaburi { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 流派のコンストラクタ
        /// </summary>
        public Ryuha()
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
