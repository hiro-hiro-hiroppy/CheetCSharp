using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.RegexSummary.Interface
{
    interface IRegexSummary
    {
        bool IsMatchRegex(string value, string[] regex);
        string RemoveRegex(string value, string[] regex);
        string[] ExtractRegex(string value, string[] regex);
        string ReplaceRegex(string value, string[] regex, string replaceValue);
    }
}
