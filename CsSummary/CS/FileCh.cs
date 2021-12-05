using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class FileCh
    {
        /// <summary>
        /// ファイルが存在するかどうかを確かめる
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool IsExistFile(string folderPath, string fileName)
        {
            bool result = false;

            string filePath = folderPath + "\\" + fileName;

            if (File.Exists(filePath))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// ファイルを読み込む
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadFile(string folderPath, string fileName)
        {
            string fileText = "";
            string filePath = folderPath + "\\" + fileName;

            if (!File.Exists(filePath))
            {
                return fileText;
            }

            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                fileText = sr.ReadToEnd();
            }

            return fileText;
        }

        /// <summary>
        /// ファイルを作成する
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <param name="isAppend"></param>
        public void SaveFile(string folderPath, string fileName, string text, bool isAppend = true)
        {
            string filePath = folderPath + "\\" + fileName;

            using (StreamWriter sw = new StreamWriter(filePath, isAppend, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                sw.Write(text);
            }
        }

        /// <summary>
        /// ファイルを作成する
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="textList"></param>
        /// <param name="isAppend"></param>
        public void SaveFile(string folderPath, string fileName, List<string> textList, bool isAppend = true)
        {
            string fileText = string.Join("¥r¥n", textList);
            string filePath = folderPath + "\\" + fileName;

            using (StreamWriter sw = new StreamWriter(filePath, isAppend, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                sw.Write(fileText);
            }
        }

        /// <summary>
        /// ファイルを作成する
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="textArray"></param>
        /// <param name="isAppend"></param>
        public void SaveFile(string folderPath, string fileName, string[] textArray, bool isAppend = true)
        {
            string fileText = string.Join("¥r¥n", textArray);
            string filePath = folderPath + "\\" + fileName;

            using (StreamWriter sw = new StreamWriter(filePath, isAppend, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                sw.Write(fileText);
            }
        }

        /// <summary>
        /// ファイルをコピーする
        /// </summary>
        /// <param name="originFolderPath"></param>
        /// <param name="originFileName"></param>
        /// <param name="copyFolderPath"></param>
        /// <param name="copyFileName"></param>
        public void CopyFile(string originFolderPath, string originFileName, string copyFolderPath, string copyFileName)
        {
            string originFilePath = originFolderPath + "\\" + originFileName;
            string copyFilePath = copyFolderPath + "\\" + copyFileName;

            if (File.Exists(originFilePath))
            {
                File.Move(originFilePath, copyFilePath);
            }
        }

        /// <summary>
        /// ファイルを移動する
        /// </summary>
        /// <param name="originFolderPath"></param>
        /// <param name="originFileName"></param>
        /// <param name="moveFolderPath"></param>
        /// <param name="moveFileName"></param>
        public void MoveFile(string originFolderPath, string originFileName, string moveFolderPath, string moveFileName)
        {
            string originFilePath = originFolderPath + "\\" + originFileName;
            string moveFilePath = moveFolderPath + "\\" + moveFileName;

            if (File.Exists(originFilePath))
            {
                File.Move(originFilePath, moveFilePath);
            }
        }

        /// <summary>
        /// ファイルを削除する
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        public void DeleteFile(string folderPath, string fileName)
        {
            string filePath = folderPath + "\\" + fileName;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}