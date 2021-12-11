using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsSummary
{
    public class ExceptionCh
    {
        /// <summary>
        /// 例外の種類
        /// </summary>
        public enum ExceptionType
        {
            NullReferenceException,




        }

        /// <summary>
        /// 例外をスルーする
        /// </summary>
        /// <param name="exceptionType"></param>
        public static void ThrowException(ExceptionType exceptionType)
        {
            switch(exceptionType)
            {
                case ExceptionType.NullReferenceException:
                    throw new NullReferenceException();





                default:
                    break;
            }
        }
    }
}
