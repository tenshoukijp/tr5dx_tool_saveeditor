using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taiko5DXSaveEditor.GameObjects;
using Taiko5DXSaveEditor.TableManagement;

namespace Taiko5DXSaveEditor.ImportingAndExporting
{
    /// <summary>
    /// 編集データ
    /// </summary>
    [Serializable]
    public class EditingData
    {
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public TableType TableType { get; set; }

        /// <summary>
        /// 適用対象のプロパティ
        /// </summary>
        public string[] Properties { get; set; }

        /// <summary>
        /// ゲームデータ
        /// </summary>
        public object[] Data { get; set; }

        /// <summary>
        /// 編集データのコンストラクタ
        /// </summary>
        public EditingData()
        {
        }

    }

}
