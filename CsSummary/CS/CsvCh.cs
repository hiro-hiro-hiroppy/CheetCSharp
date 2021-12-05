using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class CsvCh
    {
        /// <summary>
        /// CSVをインポートする
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="fileName"></param>
        /// <param name="isAddHeader"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public List<List<string>> ImportCsv(string folderName, string fileName, bool isAddHeader = false, string separator = ",")
        {
            string filePath = folderName + "\\" + fileName;
            List<List<string>> csvData = new List<List<string>>();

            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                string line;
                bool isReadHeader = false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!isAddHeader && !isReadHeader)
                    {
                        isReadHeader = true;
                        continue;
                    }

                    string[] separatorArray = { separator };

                    List<string> lineData = line.Split(separatorArray, StringSplitOptions.None).ToList();

                    csvData.Add(lineData);
                }
            }

            return csvData;
        }

        /// <summary>
        /// CSVをエクスポートする
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="fileName"></param>
        /// <param name="valueList"></param>
        /// <param name="isAppend"></param>
        /// <param name="separator"></param>
        public void ExportCsv(string folderName, string fileName, List<List<string>> valueList, bool isAppend = true, string separator = ",")
        {
            string filePath = folderName + "\\" + fileName;
            List<string> exportData = new List<string>();

            foreach (List<string> line in valueList)
            {
                List<string> addLine = new List<string>();

                foreach (string text in line)
                {
                    addLine.Add(text);
                }
                exportData.Add(string.Join(separator, addLine));
            }

            using (StreamWriter sw = new StreamWriter(filePath, isAppend, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                sw.Write(string.Join("¥r¥n", exportData));
            }
        }
    }
}