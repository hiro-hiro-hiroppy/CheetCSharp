using System;
using System.Collections.Generic;
using System.Text;
using static Lib.JWT.Enum.EnumJWTJudgeResult;

namespace Lib.JWT.Judge
{
    /// <summary>
    /// JWTトークンを検証する
    /// </summary>
    public static class JudgeJWTToken
    {
        /// <summary>
        /// 検証
        /// </summary>
        /// <param name="jwtBase"></param>
        /// <returns></returns>
        public static JWTJudgeResult Judge(this JWTBase jwtBase, string token)
        {


            return JWTJudgeResult.OK;
        }
    }
}
