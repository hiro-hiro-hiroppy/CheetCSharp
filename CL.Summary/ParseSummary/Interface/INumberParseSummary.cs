using System;
using System.Collections.Generic;
using System.Text;
using static CL.Summary.ParseSummary.NumberParseSummary;

namespace CL.Summary.ParseSummary.Interface
{
    interface INumberParseSummary
    {
        decimal? DecimalToNumber(decimal? value, DecimalParsePattern pattern, int digits = 0, int? errorResult = null);
    }
}
