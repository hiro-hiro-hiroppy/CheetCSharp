using Microsoft.EntityFrameworkCore;
using Migration.Entity;

namespace Migration
{
    public class MgContext : DbContext
    {
        //--------------------------------------------------
        // テーブル
        //--------------------------------------------------
        public DbSet<M_Position> Positions{get;set;}
        public DbSet<T_Player> Players{get;set;}
        public DbSet<T_Team> Teams{get;set;}
        
        public string DbPath{get;set;}
        
        /// <summary>
        /// コンストラクタ：DB接続情報を設定
        /// </summary>
        public MgContext(DbContextOptions options): base(options)
        {
            // var folder = Environment.SpecialFolder.LocalApplicationData;
            // var path = Environment.GetFolderPath(folder);
            // DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlite($"Data Source={DbPath}");
        
    }
}