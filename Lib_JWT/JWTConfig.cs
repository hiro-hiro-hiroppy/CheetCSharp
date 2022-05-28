using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.JWT
{
    /// <summary>
    /// 発行時の設定
    /// </summary>
    public class JWTConfig
    {
        /// <summary>
        /// 共通鍵
        /// </summary>
        public static readonly string SymmetricSecurityKey = "symmetricsecuritykey";

        /// <summary>
        /// JWTトークン発行者
        /// </summary>
        public static readonly string Issuer = "issuer";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string Audience = "audience";
    }
}
