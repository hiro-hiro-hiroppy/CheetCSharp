using CL.Summary.ParseSummary.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.ParseSummary
{
    public class NumberParseSummary : INumberParseSummary
    {
        public enum DecimalParsePattern
        {
            //切り上げ
            Ceiling,

            //切り捨て(-1.5 ⇒ -2)
            Floor,

            //切り捨て(-1.5 ⇒ -1)
            Truncate,

            //四捨五入(-1.5 ⇒ -2)
            Round,
        }

        /// <summary>
        /// 小数⇒整数or小数(切り上げ、切り下げ、四捨五入など)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <param name="digits"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public decimal? DecimalToNumber(decimal? value, DecimalParsePattern pattern, int digits = 0, int? errorResult = null)
        {
            decimal? result = null;
            decimal pow = (decimal)Math.Pow(10, digits);

            switch (pattern)
            {
                case DecimalParsePattern.Ceiling:
                    result = Math.Ceiling(value.Value * pow) / pow;
                    break;

                case DecimalParsePattern.Floor:
                    result = Math.Floor(value.Value * pow) / pow;
                    break;

                case DecimalParsePattern.Truncate:
                    result = Math.Truncate(value.Value * pow) / pow;
                    break;

                case DecimalParsePattern.Round:
                    result = Math.Round(value.Value, digits);
                    break;

                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}
