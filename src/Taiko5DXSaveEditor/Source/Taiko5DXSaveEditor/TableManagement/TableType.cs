using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.TableManagement
{
    /// <summary>
    /// テーブルの種類
    /// </summary>
    [Flags]
    public enum TableType
    {
        /// <summary>無し</summary>
        None = 0,
        /// <summary>世界</summary>
        World = 0x00000001,
        /// <summary>主人公</summary>
        Shujinko = 0x00000002,
        /// <summary>行が1つのテーブル</summary>
        SingleRow = 0x0000000F,
        /// <summary>武将</summary>
        Busho = 0x00000010,
        /// <summary>汎用ライバル</summary>
        GeneralPurpose = 0x00000020,
        /// <summary>イベント人物</summary>
        EventPerson = 0x00000040,
        /// <summary>町人、その他</summary>
        Citizen = 0x00000080,
        /// <summary>人物</summary>
        People = 0x000000F0,
        /// <summary>大名家</summary>
        Daimyoke = 0x00000100,
        /// <summary>商家</summary>
        Shoka = 0x00000200,
        /// <summary>忍者衆</summary>
        NinjaShu = 0x00000400,
        /// <summary>海賊衆</summary>
        KaizokuShu = 0x00000800,
        /// <summary>勢力</summary>
        Seiryoku = 0x00000F00,
        /// <summary>城</summary>
        Shiro = 0x00001000,
        /// <summary>町</summary>
        Machi = 0x00002000,
        /// <summary>忍びの里</summary>
        Sato = 0x00004000,
        /// <summary>海賊砦</summary>
        Toride = 0x00008000,
        /// <summary>拠点</summary>
        Kyoten = 0x0000F000,
        /// <summary>既存アイテム</summary>
        NormalItem = 0x00010000,
        /// <summary>製作アイテム</summary>
        CraftItem = 0x00020000,
        /// <summary>アイテム</summary>
        Item = 0x00030000,
        /// <summary>販路</summary>
        Hanro = 0x00100000,
        /// <summary>商圏</summary>
        Shoken = 0x00200000,
        /// <summary>流派</summary>
        Ryuha = 0x00400000,
        /// <summary>官位</summary>
        Kani = 0x00800000,
    }
}
