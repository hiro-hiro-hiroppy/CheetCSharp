using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.ParseSummary.Interface
{
    interface IDateTimeParseSummary
    {
        DateTime? StrToDate(string value, DateTime? errorResult = null);
        DateTime? IntToDate(int? value, DateTime? errorResult = null);
    }
}
