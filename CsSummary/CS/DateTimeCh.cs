using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class  DateTimeCh
    {
        public enum DayOfWeekStrPattern
        {
            //表記：日
            Normal,

            //表記：日曜日
            Detail
        }

        public Dictionary<DayOfWeek, string> DayOfWeekStrNormal = new Dictionary<DayOfWeek, string>()
        {
            { DayOfWeek.Sunday,    "日" },
            { DayOfWeek.Monday,    "月" },
            { DayOfWeek.Tuesday,   "火" },
            { DayOfWeek.Wednesday, "水" },
            { DayOfWeek.Thursday,  "木" },
            { DayOfWeek.Friday,    "金" },
            { DayOfWeek.Saturday,  "土" },
        };

        public Dictionary<DayOfWeek, string> DayOfWeekStrDetail = new Dictionary<DayOfWeek, string>()
        {
            { DayOfWeek.Sunday,    "日曜日" },
            { DayOfWeek.Monday,    "月曜日" },
            { DayOfWeek.Tuesday,   "火曜日" },
            { DayOfWeek.Wednesday, "水曜日" },
            { DayOfWeek.Thursday,  "木曜日" },
            { DayOfWeek.Friday,    "金曜日" },
            { DayOfWeek.Saturday,  "土曜日" },
        };

        /// <summary>
        /// 誕生日から年齢を取得
        /// </summary>
        /// <param name="birthDay"></param>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public int GetAge(DateTime birthDay, DateTime targetDate)
        {
            int age;

            age = targetDate.Year - birthDay.Year;

            //誕生日の月日を過ぎていない場合は、-1する
            if (targetDate.Month < birthDay.Month
                || (targetDate.Month == birthDay.Month && targetDate.Day < birthDay.Day))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// 指定日付から指定日付までの日数を取得
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int GetBetweenDate(DateTime startDate, DateTime endDate)
        {
            int betweenDate;

            TimeSpan ts = startDate - endDate;
            betweenDate = (startDate > endDate) ? -ts.Days : ts.Days;

            return betweenDate;
        }

        /// <summary>
        /// 指定日付から指定日付までの時間を取得
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public TimeSpan GetBetweenTime(DateTime startDate, DateTime endDate)
        {
            TimeSpan betweenTime;

            TimeSpan ts = startDate - endDate;
            betweenTime = (startDate > endDate) ? -ts : ts;

            return betweenTime;
        }

        /// <summary>
        /// 指定日付の月末日を取得する
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public DateTime GetLastDay(DateTime targetDate)
        {
            DateTime lastDay;

            lastDay = new DateTime(targetDate.Year, (targetDate.Month + 1), 1).AddDays(-1);

            return lastDay;
        }

        /// <summary>
        /// 指定日付の週の日曜日の日付を取得する
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public DateTime GetWeekOfSunday(DateTime targetDate)
        {
            DateTime sundayDay;

            int betweenDays = DayOfWeek.Sunday - targetDate.DayOfWeek;
            sundayDay = targetDate.AddDays(betweenDays);

            return sundayDay;
        }

        /// <summary>
        /// 指定日付の週の土曜日の日付を取得する
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public DateTime GetWeekOfSaturday(DateTime targetDate)
        {
            DateTime saturdayDay;

            int betweenDays = DayOfWeek.Saturday - targetDate.DayOfWeek;
            saturdayDay = targetDate.AddDays(betweenDays);

            return saturdayDay;
        }

        /// <summary>
        /// 指定日付の週の指定曜日の日付を取得する
        /// </summary>
        /// <param name="targetDate"></param>
        /// <param name="targetDow"></param>
        /// <returns></returns>
        public DateTime GetWeekOfTargetday(DateTime targetDate, DayOfWeek targetDow)
        {
            DateTime targetDay;

            int betweenDays = targetDow - targetDate.DayOfWeek;
            targetDay = targetDate.AddDays(betweenDays);

            return targetDay;
        }

        /// <summary>
        /// 指定月の第～週目の～曜日の日付を取得する
        /// </summary>
        /// <param name="targetMonth"></param>
        /// <param name="weekNo"></param>
        /// <param name="targetDow"></param>
        /// <returns></returns>
        public DateTime? GetTargetWeekDay(DateTime targetMonth, int weekNo, DayOfWeek targetDow)
        {
            DateTime? targetDay = null;

            targetMonth = new DateTime(targetMonth.Year, targetMonth.Month, 1);
            int countWeekNo = 1;

            while (true)
            {
                if (countWeekNo > weekNo || countWeekNo == 7)
                {
                    break;
                }

                if (countWeekNo == weekNo)
                {
                    targetDay = GetWeekOfTargetday(targetMonth, targetDow);

                    //指定した日付が指定月外の場合はNULLを返す
                    if (targetDay.Value.Month != targetMonth.Month)
                    {
                        targetDay = null;
                        break;
                    }
                }

                targetMonth = targetMonth.AddDays(7);
                countWeekNo++;
            }

            return targetDay;
        }

        /// <summary>
        /// 指定日付の曜日(文字列に変換)を取得する
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public string GetDayOfWeekStr(DateTime targetDate, DayOfWeekStrPattern pattern)
        {
            string dowStr;

            if (pattern == DayOfWeekStrPattern.Normal)
            {
                dowStr = DayOfWeekStrNormal[targetDate.DayOfWeek];
            }
            else
            {
                dowStr = DayOfWeekStrDetail[targetDate.DayOfWeek];
            }

            return dowStr;
        }
    }
}