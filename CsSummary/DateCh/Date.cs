using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CsSummary.DateCh
{
    public class Date
    {
        /// <summary>
        /// 誕生日から年齢を取得
        /// </summary>
        /// <param name="birthDay"></param>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public static int? GetAge(DateTime birthDay, DateTime targetDate)
        {
            if(birthDay < targetDate)
            {
                return null;
            }

            int age = targetDate.Year - birthDay.Year;

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
        public static int GetBetweenDate(DateTime startDate, DateTime endDate)
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
        public static TimeSpan GetBetweenTime(DateTime startDate, DateTime endDate)
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
        public static DateTime GetLastDay(DateTime targetDate)
        {
            DateTime lastDay;

            lastDay = new DateTime(targetDate.Year, (targetDate.Month + 1), 1).AddDays(-1);

            return lastDay;
        }
    }
}