using DbMigration.Entity;
using JwtWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// ユーザー登録
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("regist")]
        public async Task<ActionResult<UserDto.UserJwtDto>> Register(UserDto.UserPostDto request)
        {
            //パスワードを作成
            var newUser = CreatePasswordHash(request.Password);
            newUser.Username = request.Username;

            using (var context = new _MyDbContext())
            {
                var isUser = context.Users.Any(x => x.Name == request.Username);

                if (isUser)
                {
                    return BadRequest("同名ユーザー登録済");
                }

                context.Users.Add(new User()
                {
                    Name = newUser.Username,
                    PasswordHash = newUser.PasswordHash,
                    PasswordSalt = newUser.PasswordSalt,
                });

                await context.SaveChangesAsync();
                return Ok(newUser);
            }
        }

        /// <summary>
        /// ログイン
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto.UserPostDto request)
        {
            using(var context = new _MyDbContext())
            {
                var authUser = context.Users.SingleOrDefault(x => x.Name == request.Username);

                if (authUser == null)
                {
                    return BadRequest("ユーザー未登録");
                }

                if(!VerifyPasswordHash(request.Password, authUser.PasswordHash, authUser.PasswordSalt))
                {
                    return BadRequest("パスワードが合っていないよ");
                }

                string token = CreateToken(request);
                return Ok(token);
            }
        }

        /// <summary>
        /// JWTトークン作成
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        private string CreateToken(UserDto.UserPostDto loginUser)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginUser.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        /// <summary>
        /// パスワードを暗号化して返す
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private UserDto.UserJwtDto CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var user = new UserDto.UserJwtDto();
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return user;
            }
        }

        /// <summary>
        /// パスワードが一致しているか調べる
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
