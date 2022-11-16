using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.TableManagement
{
    /// <summary>
    /// ゲームデータテーブルのセルの値を表すクラス。
    /// ソート用の数値と表示用の文字列を持つ。
    /// </summary>
    public struct GameDataTableCellValue : IEquatable<GameDataTableCellValue>, IComparable<GameDataTableCellValue>
    {
        #region 空の値
        /// <summary>
        /// 空の値
        /// </summary>
        public static readonly GameDataTableCellValue Empty = new GameDataTableCellValue("", 0x7FFFFFFF);

        #endregion

        /// <summary>
        /// 表示用のテキスト
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// ソート用の値
        /// </summary>
        public int SortValue { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="text">表示用のテキスト</param>
        /// <param name="sortValue">ソート用の値</param>
        public GameDataTableCellValue(string text, int sortValue)
        {
            Text = text;
            SortValue = sortValue;
        }

        /// <summary>
        /// 表示用のテキストを返す
        /// </summary>
        /// <returns>表示用のテキスト</returns>
        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// ハッシュマップ取得
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return SortValue;
        }

        /// <summary>
        /// 同じか判断
        /// </summary>
        /// <param name="obj">比較対象</param>
        /// <returns>比較結果</returns>
        public override bool Equals(object obj)
        {
            return (obj is GameDataTableCellValue cellValue) ? Equals(cellValue) : false;
        }

        /// <summary>
        /// 同じか判断
        /// </summary>
        /// <param name="other">比較対象</param>
        /// <returns>比較結果</returns>
        public bool Equals(GameDataTableCellValue other)
        {
            return SortValue.Equals(other.SortValue);
            //return other is null ? false : SortValue.Equals(other.SortValue);
        }

        /// <summary>
        /// ==のオーバーロード
        /// </summary>
        /// <param name="value1">値1</param>
        /// <param name="value2">値2</param>
        /// <returns>結果</returns>
        public static bool operator ==(GameDataTableCellValue value1, GameDataTableCellValue value2)
        {
            return value1.Equals(value2);
        }

        /// <summary>
        /// !=のオーバーロード
        /// </summary>
        /// <param name="value1">値1</param>
        /// <param name="value2">値2</param>
        /// <returns>結果</returns>
        public static bool operator !=(GameDataTableCellValue value1, GameDataTableCellValue value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        /// 比較
        /// </summary>
        /// <param name="compare">比較対象</param>
        /// <returns>比較結果</returns>
        public int CompareTo(GameDataTableCellValue compare)
        {
            return SortValue.CompareTo(compare.SortValue);
            //return compare == null ? 1 : SortValue.CompareTo(compare.SortValue);
        }

    }
}
