using CL.Summary.DateSummary.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.DateSummary
{
    public class DateSummary: IDateSummary
    {
        /// <summary>
        /// 誕生日から年齢を計算する
        /// </summary>
        /// <param name="birthDay"></param>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public int? CalcNowAge(DateTime birthDay, DateTime targetDate)
        {
            if (birthDay < targetDate)
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
        /// 指定日付から指定日付までの日数を計算する
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int CalcBetweenDate(DateTime startDate, DateTime endDate)
        {
            int betweenDate;

            TimeSpan ts = startDate - endDate;
            betweenDate = (startDate > endDate) ? -ts.Days : ts.Days;

            return betweenDate;
        }

        /// <summary>
        /// 指定日付から指定日付までの時間を計算する
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public TimeSpan CalcBetweenTime(DateTime startDate, DateTime endDate)
        {
            TimeSpan betweenTime;

            TimeSpan ts = startDate - endDate;
            betweenTime = (startDate > endDate) ? -ts : ts;

            return betweenTime;
        }

        /// <summary>
        /// 指定日付の月末日を計算する
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public DateTime CalcLastDay(DateTime targetDate)
        {
            DateTime lastDay;

            lastDay = new DateTime(targetDate.Year, (targetDate.Month + 1), 1).AddDays(-1);

            return lastDay;
        }
    }
}
