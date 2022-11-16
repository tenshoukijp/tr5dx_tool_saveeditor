using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 勢力（大名家、商家、忍者衆、海賊衆）
    /// </summary>
    [Serializable]
    public abstract class Seiryoku : GameObject
    {
        #region ツールで管理するプロパティ
        /// <summary>
        /// 勢力名
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 滅亡しているか
        /// </summary>
        public bool IsDestruction { get; set; } = false;

        #endregion

        #region プロパティ
        /// <summary>
        /// 各勢力との停戦期間。1バイト1勢力。
        /// </summary>
        public byte[] Ceasefire { get; set; } = null;

        /// <summary>
        /// 各勢力への攻め込み名分。1バイト1勢力。
        /// </summary>
        public byte[] JustCause { get; set; } = null;

        /// <summary>
        /// 各勢力との外交関係。1バイト1勢力。
        /// </summary>
        public byte[] Diplomacy { get; set; } = null;

        /// <summary>
        /// 主人公との関係
        /// </summary>
        public byte RelationshipWithShujinko { get; set; } = 0;

        /// <summary>
        /// 出奔カウンタ (3bits)
        /// </summary>
        public byte DepartureCounter { get; set; } = 0;

        /// <summary>
        /// 家紋ID。忍者や海賊にも設定できるが参照されない。
        /// </summary>
        public byte FamilyCrest { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 勢力のコンストラクタ
        /// </summary>
        public Seiryoku()
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
