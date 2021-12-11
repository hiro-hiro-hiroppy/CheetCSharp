using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsSummary.ExcelCh
{
    public class CellEnum
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

        /// <summary>
        /// 垂直方向の文字位置
        /// </summary>
        public enum VerticalPosition
        {
            Top,
            Center,
            Bottom
        }

        /// <summary>
        /// 水平方向の文字位置
        /// </summary>
        public enum HorizontalPosition
        {
            Left,
            Center,
            Right
        }

        /// <summary>
        /// エクセル操作の種類
        /// </summary>
        public enum ExcelOperationType
        {
            Create,

            TemplateCreate,




        }


    }
}
