using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsSummary.ExcelCh
{
    public static class ExcelDelete
    {

        public static void CellDelete(this ExcelBase excelBase)
        {


        }

        /// <summary>
        /// 行を削除
        /// </summary>
        /// <param name="excelBase"></param>
        /// <param name="rows">行数</param>
        /// <param name="isFill">行を削除した後詰めるかどうか</param>
        public static void RowDelete(this ExcelBase excelBase, List<ColumnRowModel> rows, bool isFill = true)
        {

        }

        /// <summary>
        /// 列を削除
        /// </summary>
        /// <param name="excelBase"></param>
        /// <param name="columns">行数</param>
        /// <param name="isFill">行を削除した後詰めるかどうか</param>
        public static void ColumnRow(this ExcelBase excelBase, List<ColumnRowModel> columns, bool isFill = true)
        {


        }

    }
}
