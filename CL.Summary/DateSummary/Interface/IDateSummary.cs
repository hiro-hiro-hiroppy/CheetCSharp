using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.DateSummary.Interface
{
    interface IDateSummary
    {
        int? CalcNowAge(DateTime birthDay, DateTime targetDate);
        int CalcBetweenDate(DateTime startDate, DateTime endDate);
        TimeSpan CalcBetweenTime(DateTime startDate, DateTime endDate);
        DateTime CalcLastDay(DateTime targetDate);
    }
}
