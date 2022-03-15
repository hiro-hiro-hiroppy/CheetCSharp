using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.ParseSummary.Interface
{
    interface IBoolParseSummary
    {
        bool StrToBool(string value, bool errorResult = false);
        bool IntToBool(int? value, bool errorResult = false);
        int IntToBool(bool value);
    }
}
