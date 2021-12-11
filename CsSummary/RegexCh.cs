using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsSummary
{
    public class RegexCh
    {
        /// <summary>
        /// 指定した正規表現が文字列内に含まれているか
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public bool IsMatchRegex(string value, string[] regex)
        {
            bool result = false;

            foreach (string regexItem in regex)
            {
                result = System.Text.RegularExpressions.Regex.IsMatch(value, regexItem);

                if (result)
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 指定した正規表現の箇所を削除する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public string RemoveRegex(string value, string[] regex)
        {
            foreach (string regexItem in regex)
            {
                value = System.Text.RegularExpressions.Regex.Replace(value, regexItem, "");
            }

            return value;
        }

        /// <summary>
        /// 指定した正規表現の箇所(最初のみ)を抜き取る
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public string[] ExtractRegex(string value, string[] regex)
        {
            string[] extractValues = new string[regex.Length];

            foreach (var item in regex.Select((Value, Index) => new { Value, Index }))
            {
                string matchValue = System.Text.RegularExpressions.Regex.Match(value, item.Value).Value;

                if (!string.IsNullOrWhiteSpace(matchValue))
                {
                    extractValues[item.Index] = matchValue;
                }
            }

            return extractValues;
        }

        /// <summary>
        /// 指定した正規表現の箇所(全て)を抜き取る
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        //public string[] ExtractRegexAll(string value, string[] regex)
        //{
        //    string[] extractValues = new string[regex.Length];

        //    foreach (var item in regex.Select((Value, Index) => new { Value, Index }))
        //    {
        //        string matchValue = Regex.Matches(value, item.Value);

        //        if (!string.IsNullOrWhiteSpace(matchValue))
        //        {
        //            extractValues[item.Index] = matchValue;
        //        }
        //    }

        //    return extractValues;
        //}
        //

        /// <summary>
        /// 指定した正規表現の箇所を別の文字に置き換える
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regex"></param>
        /// <param name="replaceValue"></param>
        /// <returns></returns>
        public string ReplaceRegex(string value, string[] regex, string replaceValue)
        {
            foreach (string regexItem in regex)
            {
                value = System.Text.RegularExpressions.Regex.Replace(value, regexItem, replaceValue);
            }

            return value;
        }
    }
}