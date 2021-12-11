using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsSummary.ExcelCh
{
    public class ColumnRowModel
    {
        /// <summary>
        /// 列
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// 値
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// セル形式
        /// </summary>
        public CellEnum.CellType CellType { get; set; } = CellEnum.CellType.Normal;

        /// <summary>
        /// セルオプション
        /// </summary>
        public CellOption CellOption { get; set; } = new CellOption();

        /// <summary>
        /// シート名
        /// </summary>
        public string? SheetName { get; set; }
    }
}
