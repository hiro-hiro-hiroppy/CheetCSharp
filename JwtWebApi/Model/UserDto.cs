namespace JwtWebApi.Model
{
    public class UserDto
    {
        public class UserPostDto
        {
            /// <summary>
            /// ユーザー名
            /// </summary>
            public string Username { get; set; } = string.Empty;
            /// <summary>
            /// パスワード
            /// </summary>
            public string Password { get; set; } = string.Empty;
        }

        public class UserJwtDto
        {
            /// <summary>
            /// ユーザー名
            /// </summary>
            public string Username { get; set; } = string.Empty;

            /// <summary>
            /// 
            /// </summary>
            public byte[] PasswordHash { get; set; } = new byte[0];

            /// <summary>
            /// 
            /// </summary>
            public byte[] PasswordSalt { get; set; } = new byte[0];
        }
    }
}
