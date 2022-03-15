using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.ClosedXML.Enum
{
    /// <summary>
    /// セル表示形式 Enumクラス
    /// </summary>
    public class EnumCellType
    {
        /// <summary>
        /// セル表示形式
        /// </summary>
        public enum CellType
        {
            /// <summary>
            /// 標準
            /// </summary>
            Normal,

            /// <summary>
            /// 数字
            /// </summary>
            Number,

            /// <summary>
            /// 短い日付形式
            /// </summary>
            DateShort,

            /// <summary>
            /// 長い日付形式
            /// </summary>
            DateLong,

            /// <summary>
            /// 時刻
            /// </summary>
            Time,
        }
    }
}
