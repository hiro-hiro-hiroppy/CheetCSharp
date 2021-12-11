using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsSummary.ParseCh
{
    /// <summary>
    /// 真偽値 変換
    /// </summary>
    public class BoolParse
    {

        /// <summary>
        /// 文字列⇒真偽値
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorResult"></param>
        /// <returns></returns>
        public static bool StrToBool(string value, bool errorResult = false)
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
        public static bool IntToBool(int? value, bool errorResult = false)
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
        public static int IntToBool(bool value)
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
