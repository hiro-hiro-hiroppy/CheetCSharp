using System;
using System.Collections.Generic;
using System.Text;
using static CL.Summary.WeekSummary.WeekSummary;

namespace CL.Summary.WeekSummary.Interface
{
    interface IWeekSummary
    {
        DateTime GetWeekOfSunday(DateTime targetDate);
        DateTime GetWeekOfSaturday(DateTime targetDate);
        DateTime GetWeekOfTargetday(DateTime targetDate, DayOfWeek targetDow);
        DateTime? GetTargetWeekDay(DateTime targetMonth, int weekNo, DayOfWeek targetDow);
        string GetDayOfWeekStr(DateTime targetDate, DayOfWeekStrPattern pattern);
    }
}
