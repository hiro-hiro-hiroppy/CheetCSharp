using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class LogCh
    {
        public enum LogType
        {
            Debug,
            Info,
            Warn,
            Error,
            Fatal,
            None,
        }

        /// <summary>
        /// ログを出力
        /// </summary>
        /// <param name="Log"></param>
        public void LogExport(LogType logType, string logText, string logFilePath = null, bool isAddText = true)
        {
            string formatLogText = FormatLogText(logType, logText);

            using (StreamWriter sw = new StreamWriter(logFilePath, isAddText, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                sw.Write(formatLogText);
            }
        }

        /// <summary>
        /// ログテキストをフォーマットする(フォーマット方法は任意)
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="logText"></param>
        /// <returns></returns>
        public string FormatLogText(LogType logType, string logText)
        {
            DateTime now = DateTime.Now;
            string nowText = now.ToString("yyyy/MM/dd HH:mm:ss");

            switch (logType)
            {
                case LogType.Debug:
                    logText = $"{nowText} デバッグ:{logText}";
                    break;

                case LogType.Info:
                    logText = $"{nowText} 正常:{logText}";
                    break;

                case LogType.Warn:
                    logText = $"{nowText} 警戒:{logText}";
                    break;

                case LogType.Error:
                    logText = $"{nowText} エラー:{logText}";
                    break;

                case LogType.Fatal:
                    logText = $"{nowText} 致命的なエラー:{logText}";
                    break;

                case LogType.None:
                    logText = $"{nowText} 特になし:{logText}";
                    break;

                default:
                    break;
            }

            return logText;
        }

    }
}