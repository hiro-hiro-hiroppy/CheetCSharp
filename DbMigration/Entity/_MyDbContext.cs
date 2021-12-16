using Configure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace DbMigration.Entity
{
    /// <summary>
    /// エンティティ定義
    /// 参考URL : https://tsuna-can.hateblo.jp/entry/2021/07/09/130000
    /// </summary>
    public class _MyDbContext : DbContext
    {
#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        public _MyDbContext() { }
        public _MyDbContext(DbContextOptions<_MyDbContext> options) : base(options) { }
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; } 
        public DbSet<School> Schools { get; set; }

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
            optionsBuilder.UseNpgsql(ConfigurePostgreSQL.DefineConnectionInfo(new ConfigurePostgreSQL.ConfigModel()
            {
                ServerUrl = "localhost",
                Port = 5432,
                UserName = "postgres_user",
                Password = "password",
                DataBaseName = "test"
            }));

            //SQLServer接続設定
            //optionsBuilder.UseSqlServer(ConfigureSqlServer());
        }
    }
}
