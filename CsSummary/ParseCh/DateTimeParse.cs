using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsSummary.Parse
{
    public class DateTimeParse
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
    }
}
