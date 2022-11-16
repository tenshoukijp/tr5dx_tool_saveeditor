using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// アイテム
    /// </summary>
    [Serializable]
    public class Item : GameObject
    {
        #region ツールで管理するプロパティ
        /// <summary>
        /// 制作アイテムであるか
        /// </summary>
        public bool IsCraftItem { get; set; } = false;

        /// <summary>
        /// 制作済みであるか
        /// </summary>
        public bool IsCrafted { get; set; } = false;

        #endregion

        #region プロパティ
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 読み
        /// </summary>
        public string Kana { get; set; } = "";

        /// <summary>
        /// 画像
        /// </summary>
        public byte Image { get; set; } = 0;

        /// <summary>
        /// 価格。制作アイテムで65535なら存在しないことになる。
        /// </summary>
        public ushort Price { get; set; } = 0;

        /// <summary>
        /// 価値
        /// </summary>
        public byte Rarity { get; set; } = 0;

        /// <summary>
        /// 種類
        /// </summary>
        public byte ItemType { get; set; } = 0;

        /// <summary>
        /// 能力上昇量
        /// </summary>
        public byte AbilityScores { get; set; } = 0;

        /// <summary>
        /// 上昇する能力の種類
        /// </summary>
        public byte AbilityType { get; set; } = 0;

        /// <summary>
        /// 所有者（基本的に価値5以上のアイテムに設定）
        /// </summary>
        public ushort Owner { get; set; } = 0;

        /// <summary>
        /// 主人公の所持数
        /// </summary>
        public byte Number { get; set; } = 0;

        /// <summary>
        /// 未鑑定フラグ（1なら未鑑定）
        /// </summary>
        public byte SecretFlag { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// アイテムのコンストラクタ
        /// </summary>
        public Item()
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
