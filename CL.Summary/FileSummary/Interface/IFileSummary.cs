using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.FileSummary.Interface
{
    interface IFileSummary
    {
        bool IsExistFile(string folderPath, string fileName);
        string ReadFile(string folderPath, string fileName);
        void SaveFile(string folderPath, string fileName, string text, bool isAppend = true);
        void SaveFile(string folderPath, string fileName, List<string> textList, bool isAppend = true);
        void SaveFile(string folderPath, string fileName, string[] textArray, bool isAppend = true);
        void CopyFile(string originFolderPath, string originFileName, string copyFolderPath, string copyFileName);
        void MoveFile(string originFolderPath, string originFileName, string moveFolderPath, string moveFileName);
        void DeleteFile(string folderPath, string fileName);
    }
}
