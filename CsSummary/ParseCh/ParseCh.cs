using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class ParseCh
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
        /// 日付⇒文字列
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parsePattern"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public string DateToStr(DateTime? value, string parsePattern = "yyyy/MM/dd", string errorResult = null)
        {
            string result;

            if (value != null)
            {
                result = value.Value.ToString(parsePattern);
            }
            else
            {
                result = errorResult;
            }

            return result;
        }


        /// <summary>
        /// 文字列⇒数値
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public int? StrToInt(string value, int? errorResult = null)
        {
            int? result;

            int parseValue;
            bool parseResult = int.TryParse(value, out parseValue);

            if (parseResult)
            {
                result = parseValue;
            }
            else
            {
                result = errorResult;
            }

            return result;
        }


        /// <summary>
        /// 数値⇒文字列
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public string IntToStr(int? value, string errorResult = null)
        {
            string result;

            if (value != null)
            {
                result = value.ToString();
            }
            else
            {
                result = errorResult;
            }

            return result;
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

        /// <summary>
        /// 文字列⇒真偽値
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public bool StrToBool(string value, bool errorResult = false)
        {
            bool result = false;

            bool parseValue;
            bool parseResult = bool.TryParse(value, out parseValue);

            if (parseResult)
            {
                result = parseValue;
            }
            else
            {
                result = errorResult;
            }


            return result;
        }

    }
}