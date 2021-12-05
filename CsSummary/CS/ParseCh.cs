using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class ParseCh
    {
        //参考用
        public enum DateParseItem
        {
            //4けたの年 2004
            yyyy,
            //0埋め2けたの年 04
            yy,
            //0埋め2けたの月 08
            MM,
            //0埋め2けたの日 24
            dd,
            //曜日の省略名（カルチャに依存） 火
            ddd,
            //曜日の完全名（カルチャに依存） 火曜日
            dddd,
            //0埋め2けたの時間（24時間表記） 20
            HH,
            //0埋め2けたの時間（12時間表記） 08
            hh,
            //0埋め2けたの分 23
            mm,
            //0埋め2けたの秒 06
            ss,
        }

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
        /// 文字列⇒日付
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public DateTime? StrToDate(string value, DateTime? errorResult = null)
        {
            DateTime? result;

            DateTime parseValue = new DateTime();
            bool parseResult = false;

            if (value != null)
            {
                parseResult = DateTime.TryParse(value, out parseValue);
            }

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
        /// 数値⇒日付
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public DateTime? IntToDate(int? value, DateTime? errorResult = null)
        {
            DateTime? result;

            DateTime parseValue = new DateTime();
            bool parseResult = false;

            if (value != null)
            {
                parseResult = DateTime.TryParse(value.ToString(), out parseValue);
            }

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