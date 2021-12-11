using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsSummary.ExcelCh
{
    /// <summary>
    /// 属性
    /// </summary>
    public class ColumnRowAttribute : Attribute
    {
        /// <summary>
        /// 列
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// セルオプション
        /// </summary>
        public CellOption CellOption { get; set; } = new CellOption();
    }
}
