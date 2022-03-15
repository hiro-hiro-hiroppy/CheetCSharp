using CL.Summary.ParseSummary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.Summary.ParseSummary
{
    public class BoolParseSummary : IBoolParseSummary
    {
        /// <summary>
        /// 文字列⇒真偽値
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public bool StrToBool(string value, bool errorResult = false)
        {
            bool result = false;
            string[] truePatterns = new string[] { "1", "１", "TRUE", "True", "true" };

            if (truePatterns.Contains(value))
            {
                result = true;
            }

            return result;
        }


        /// <summary>
        /// 数値⇒真偽値
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public bool IntToBool(int? value, bool errorResult = false)
        {
            bool result = false;

            if (value == 1)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 真偽値⇒数値
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IntToBool(bool value)
        {
            int result = 0;

            if (value)
            {
                result = 1;
            }

            return result;
        }
    }
}
