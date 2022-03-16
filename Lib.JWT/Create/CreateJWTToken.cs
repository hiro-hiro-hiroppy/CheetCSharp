using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Lib.JWT.Create
{
    /// <summary>
    /// JWTトークンを発行する
    /// </summary>
    public static class CreateJWTToken
    {
        /// <summary>
        /// JWTトークンの発行
        /// </summary>
        /// <param name="jwtBase"></param>
        /// <param name="claimPairs"></param>
        /// <param name="expires"></param>
        public static string Create(this JWTBase jwtBase, Dictionary<string, object> claimPairs, int expires = 1)
        {
            var handler = new JwtSecurityTokenHandler();
            var claims = claimPairs.Select(x => new Claim(x.Key, x.Value.ToString())).ToList();
            var tokenKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JWTConfig.SymmetricSecurityKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(expires),
                SigningCredentials = new SigningCredentials(
                tokenKey,
                SecurityAlgorithms.HmacSha512Signature),
                Audience = JWTConfig.Audience,
                Issuer = JWTConfig.Issuer,
            };

            // トークンを生成
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
