using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsSummary.ExcelCh
{
    public class CellOption
    {
        /// <summary>
        /// 背景色
        /// </summary>
        public XLColor? BackGroundColor { get; set; }

        /// <summary>
        /// 文字色
        /// </summary>
        public XLColor? FontColor { get; set; }

        /// <summary>
        /// 太文字
        /// </summary>
        public bool IsBold { get; set; }

        /// <summary>
        /// フォントサイズ
        /// </summary>
        public int? FontSize { get; set; }

        /// <summary>
        /// 文字下線
        /// </summary>
        public bool FontUnderLine { get; set; }

        /// <summary>
        /// 上線
        /// </summary>
        public bool TopLine { get; set; }

        /// <summary>
        /// 左線
        /// </summary>
        public bool LeftLine { get; set; }

        /// <summary>
        /// 下線
        /// </summary>
        public bool BottomLine { get; set; }

        /// <summary>
        /// 右線
        /// </summary>
        public bool RightLine { get; set; }

        /// <summary>
        /// 垂直方向の文字位置
        /// </summary>
        public CellEnum.VerticalPosition VerticalPosition { get; set; }

        /// <summary>
        /// 水平方向の文字位置
        /// </summary>
        public CellEnum.HorizontalPosition HorizontalPosition { get; set; }
    }
}
