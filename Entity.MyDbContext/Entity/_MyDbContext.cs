using Entity.MyDbContext.ConnectionDefine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.MyDbContext.Entity
{
    /// <summary>
    /// DbContext継承クラス
    /// </summary>
    public class _MyDbContext : DbContext
    {
        public _MyDbContext() { }
        public _MyDbContext(DbContextOptions<_MyDbContext> options) : base(options) { }

        /// <summary>
        /// テーブル定義
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PlayerConfiguration(modelBuilder.Entity<Player>());
            new TeamConfiguration(modelBuilder.Entity<Team>());
            new SchoolConfiguration(modelBuilder.Entity<School>());
        }

        /// <summary>
        /// データベースの接続設定
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //PostgreSQL接続設定
            optionsBuilder.UseNpgsql(ConnectionPostgreSQL.DefineConnectionInfo(new ConnectionPostgreSQL.ConfigModel()
            {
                ServerUrl = "localhost",
                Port = 5432,
                UserName = "postgres_user",
                Password = "password",
                DataBaseName = "test"
            }));
        }
    }
}
