using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.MyDbContext.ConnectionDefine
{
    /// <summary>
    /// PostgreSQL接続設定
    /// </summary>
    public class ConnectionPostgreSQL
    {
        public class ConfigModel
        {
            /// <summary>
            /// データベースURL
            /// </summary>
            public string ServerUrl { get; set; }

            /// <summary>
            /// ポート番号
            /// </summary>
            public int Port { get; set; }

            /// <summary>
            /// ユーザー名
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// パスワード
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// データベース名
            /// </summary>
            public string DataBaseName { get; set; }
        }

        /// <summary>
        /// PostgreSQL接続設定
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string DefineConnectionInfo(ConfigModel config)
        {
            StringBuilder sbConfig = new StringBuilder();
            sbConfig.Append($"Server={config.ServerUrl};");
            sbConfig.Append($"Port={config.Port};");
            sbConfig.Append($"Username={config.UserName};");
            sbConfig.Append($"Password={config.Password};");
            sbConfig.Append($"Database={config.DataBaseName};");

            return sbConfig.ToString();
        }
    }
}
