using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.JWT.Enum
{
    /// <summary>
    /// JWTトークン検証結果
    /// </summary>
    public class EnumJWTJudgeResult
    {

        public enum JWTJudgeResult
        {
            /// <summary>
            /// OK
            /// </summary>
            OK,

            /// <summary>
            /// 期限切れ
            /// </summary>
            Expired,

            /// <summary>
            /// 不適
            /// </summary>
            NoMatch,
        }
    }
}
