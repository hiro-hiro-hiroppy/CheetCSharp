using ClosedXML.Excel;
using Lib.ClosedXML.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.ClosedXML
{
    /// <summary>
    /// セルの設定
    /// </summary>
    public class CellOption
    {
        #region 色

        /// <summary>
        /// 背景色
        /// </summary>
        public XLColor BackGroundColor { get; set; }

        /// <summary>
        /// 文字色
        /// </summary>
        public XLColor FontColor { get; set; }

        #endregion

        #region 文字

        /// <summary>
        /// 太文字
        /// </summary>
        public bool? IsBold { get; set; }

        /// <summary>
        /// フォントサイズ
        /// </summary>
        public int? FontSize { get; set; }

        /// <summary>
        /// 文字下線
        /// </summary>
        public bool? FontUnderLine { get; set; }

        /// <summary>
        /// セルの種類
        /// </summary>
        public EnumCellType.CellType? CellType { get; set; }

        #endregion

        #region 線

        /// <summary>
        /// 上線
        /// </summary>
        public bool? TopLine { get; set; }

        /// <summary>
        /// 左線
        /// </summary>
        public bool? LeftLine { get; set; }

        /// <summary>
        /// 下線
        /// </summary>
        public bool? BottomLine { get; set; }

        /// <summary>
        /// 右線
        /// </summary>
        public bool? RightLine { get; set; }

        #endregion

        #region 文字位置

        /// <summary>
        /// 垂直方向の文字位置
        /// </summary>
        public EnumVerticalPosition.VerticalPosition? VerticalPosition { get; set; }

        /// <summary>
        /// 水平方向の文字位置
        /// </summary>
        public EnumHorizontalPosition.HorizontalPosition? HorizontalPosition { get; set; }

        #endregion
    }
}
