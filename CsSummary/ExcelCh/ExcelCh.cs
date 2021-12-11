using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace CheetNetCoreMVC.CS
{
    public class ExcelCh
    {
        public class ColumnRow
        {
            public int Column { get; set; }

            public int Row { get; set; }

            public string? Value { get; set; }

            public string? SheetName { get; set; }
        }

        public class ReadIndexNo
        {
            public int StartColumn { get; set; }

            public int EndColumn { get; set; }

            public int StartRow { get; set; }

            public int EndRow { get; set; }
        }

        /// <summary>
        /// Excelファイルをインポートする
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="readIndexNo"></param>
        /// <returns></returns>
        public List<ColumnRow> ImportExcel(string folderPath, string fileName, ReadIndexNo readIndexNo)
        {
            string filePath = folderPath + "\\" + fileName;
            List<ColumnRow> excelData = new List<ColumnRow>();

            using (var excelFile = new XLWorkbook(filePath))
            {
                foreach (var ws in excelFile.Worksheets)
                {
                    string wsName = ws.Name;

                    //読み込む行数・列数を指定している場合
                    for (int i = readIndexNo.StartRow; i < readIndexNo.EndRow; i++)
                    {
                        for (int j = readIndexNo.StartColumn; j < readIndexNo.EndColumn; j++)
                        {
                            ColumnRow cellData = new ColumnRow();
                            cellData.Row = i;
                            cellData.Column = j;
                            cellData.SheetName = wsName;
                            cellData.Value = ws.Cell(i, j).Value.ToString();

                            excelData.Add(cellData);
                        }
                    }
                }
            }

            return excelData;
        }

        /// <summary>
        /// Excelファイルをエクスポートする
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="columnRowList"></param>
        public void ExportExcel(string folderPath, string fileName, List<ColumnRow> columnRowList)
        {
            string filePath = folderPath + "\\" + fileName;

            using (var excelFile = new XLWorkbook())
            {
                var sheetNameList = columnRowList.Select(x => x.SheetName).Distinct().ToList();

                foreach (var sheetName in sheetNameList)
                {
                    // ワークブックにシートを追加
                    excelFile.Worksheets.Add(sheetName);
                }

                //シートが一枚も追加されていない場合はシートを追加する
                if (excelFile.Worksheets.Count < 1)
                {
                    excelFile.Worksheets.Add("Sheet1");
                }

                foreach (var columnRow in columnRowList)
                {
                    //シート名が未指定の場合は1番目のシートを、それ以外は指定のシートを参照する
                    if (string.IsNullOrWhiteSpace(columnRow.SheetName))
                    {
                        var ws = excelFile.Worksheet(1);
                        ws.Cell(columnRow.Row, columnRow.Column).Value = columnRow.Value;
                    }
                    else
                    {
                        var ws = excelFile.Worksheet(columnRow.SheetName);
                        ws.Cell(columnRow.Row, columnRow.Column).Value = columnRow.Value;
                    }
                }

                excelFile.SaveAs(filePath);
            }
        }

        /// <summary>
        /// テンプレートのExcelファイルを使用してエクスポートする
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="templateFilePath"></param>
        /// <param name="columnRowList"></param>
        public void ExportTempExcel(string folderPath, string fileName, string templateFilePath, List<ColumnRow> columnRowList)
        {
            string filePath = folderPath + "\\" + fileName;

            using (var excelFile = new XLWorkbook(templateFilePath))
            {
                foreach (var columnRow in columnRowList)
                {
                    //シート名が未指定の場合は1番目のシートを、それ以外は指定のシートを参照する
                    if (string.IsNullOrWhiteSpace(columnRow.SheetName))
                    {
                        var ws = excelFile.Worksheet(1);
                        ws.Cell(columnRow.Row, columnRow.Column).Value = columnRow.Value;
                    }
                    else
                    {
                        var ws = excelFile.Worksheet(columnRow.SheetName);
                        ws.Cell(columnRow.Row, columnRow.Column).Value = columnRow.Value;
                    }
                }

                excelFile.SaveAs(filePath);
            }
        }

        /// <summary>
        /// 指定のセルの値を読み取る
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="columnRow"></param>
        /// <returns></returns>
        public ColumnRow GetExcelValue(string folderPath, string fileName, ColumnRow columnRow)
        {
            string filePath = folderPath + "\\" + fileName;
            ColumnRow cellData = new ColumnRow();

            using (var excelFile = new XLWorkbook(filePath))
            {
                //シート名が未指定の場合は1番目のシートを、それ以外は指定のシートを参照する
                if (string.IsNullOrWhiteSpace(columnRow.SheetName))
                {
                    var ws = excelFile.Worksheet(1);
                    cellData.Row = columnRow.Row;
                    cellData.Column = columnRow.Column;
                    cellData.SheetName = columnRow.SheetName;
                    cellData.Value = ws.Cell(columnRow.Row, columnRow.Column).Value.ToString();
                }
                else
                {
                    var ws = excelFile.Worksheet(columnRow.SheetName);
                    cellData.Row = columnRow.Row;
                    cellData.Column = columnRow.Column;
                    cellData.SheetName = columnRow.SheetName;
                    cellData.Value = ws.Cell(columnRow.Row, columnRow.Column).Value.ToString();
                }
            }

            return cellData;
        }

        /// <summary>
        /// 指定のセルの値を読み取る(複数)
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="columnRowList"></param>
        /// <returns></returns>
        public List<ColumnRow> GetExcelValueList(string folderPath, string fileName, List<ColumnRow> columnRowList)
        {
            string filePath = folderPath + "\\" + fileName;
            List<ColumnRow> cellDataList = new List<ColumnRow>();

            using (var excelFile = new XLWorkbook(filePath))
            {
                //シート名が未指定の場合は1番目のシートを、それ以外は指定のシートを参照する
                foreach (var columnRow in columnRowList)
                {
                    IXLWorksheet ws;

                    if (string.IsNullOrWhiteSpace(columnRow.SheetName))
                    {
                        ws = excelFile.Worksheet(1);
                    }
                    else
                    {
                        ws = excelFile.Worksheet(columnRow.SheetName);
                    }

                    ColumnRow cellData = new ColumnRow();

                    cellData.Row = columnRow.Row;
                    cellData.Column = columnRow.Column;
                    cellData.SheetName = ws.Name;
                    cellData.Value = ws.Cell(columnRow.Row, columnRow.Column).Value.ToString();
                }
            }

            return cellDataList;
        }

        /// <summary>
        /// 指定のセルの値を書き換える
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="columnRow"></param>
        public void UpdateExcelValue(string folderPath, string fileName, ColumnRow columnRow)
        {
            string filePath = folderPath + "\\" + fileName;

            using (var excelFile = new XLWorkbook(filePath))
            {
                //シート名が未指定の場合は1番目のシートを、それ以外は指定のシートを参照する
                if (string.IsNullOrWhiteSpace(columnRow.SheetName))
                {
                    var ws = excelFile.Worksheet(1);
                    ws.Cell(columnRow.Row, columnRow.Column).Value = columnRow.Value;
                }
                else
                {
                    var ws = excelFile.Worksheet(columnRow.SheetName);
                    ws.Cell(columnRow.Row, columnRow.Column).Value = columnRow.Value;
                }

                excelFile.SaveAs(filePath);
            }
        }

        /// <summary>
        /// 指定のセルの値を書き換える(複数)
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="columnRowList"></param>
        public void UpdateExcelValueList(string folderPath, string fileName, List<ColumnRow> columnRowList)
        {
            string filePath = folderPath + "\\" + fileName;

            using (var excelFile = new XLWorkbook(filePath))
            {
                //シート名が未指定の場合は1番目のシートを、それ以外は指定のシートを参照する
                foreach (var columnRow in columnRowList)
                {
                    if (string.IsNullOrWhiteSpace(columnRow.SheetName))
                    {
                        var ws = excelFile.Worksheet(1);
                        ws.Cell(columnRow.Row, columnRow.Column).Value = columnRow.Value;
                    }
                    else
                    {
                        var ws = excelFile.Worksheet(columnRow.SheetName);
                        ws.Cell(columnRow.Row, columnRow.Column).Value = columnRow.Value;
                    }
                }

                excelFile.SaveAs(filePath);
            }
        }

    }
}