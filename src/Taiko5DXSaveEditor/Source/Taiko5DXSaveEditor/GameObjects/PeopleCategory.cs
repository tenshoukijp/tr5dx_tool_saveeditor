using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 人物カテゴリ
    /// </summary>
    [Serializable]
    public enum PeopleCategory
    {
        /// <summary>武将</summary>
        Busho,
        /// <summary>汎用ライバル</summary>
        GeneralPurpose,
        /// <summary>イベント人物</summary>
        EventPerson,
        /// <summary>町人</summary>
        Citizen,
        /// <summary>無効</summary>
        Invalid
    }
}
