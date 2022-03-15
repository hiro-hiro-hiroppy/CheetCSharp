using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Lib.JWT
{
    /// <summary>
    /// JWTの設定
    /// </summary>
    public class JWTOption
    {
        /// <summary>
        /// 共通鍵
        /// </summary>
        public SymmetricSecurityKey CommonKey { get; set; }

        /// <summary>
        /// パスワード有効期限
        /// </summary>
        public DateTime Expires { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SigningCredentials Credentials { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Claim> Claims { get; set; }
    }
}
