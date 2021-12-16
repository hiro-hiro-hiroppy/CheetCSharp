using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DbMigration.Entity
{
    /// <summary>
    /// チームテーブル
    /// </summary>
    public class Team
    {
        /// <summary>
        /// チームID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// チーム名
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 所属選手
        /// </summary>
        public virtual List<Player> Player { get; set; } = new List<Player> { };
    }

    /// <summary>
    /// チームテーブルの詳細定義
    /// https://docs.microsoft.com/ja-jp/ef/core/modeling/
    /// </summary>
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public TeamConfiguration(EntityTypeBuilder<Team> builder)
        {
            Configure(builder);
        }

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //テーブル名の設定
            builder.ToTable("Team");

            //主キーの設定
            builder.HasKey(team => team.Id);

            //各カラムの制約条件

            //カラム名の設定
            builder.Property(team => team.Id).HasComment("チームID");
            builder.Property(team => team.Name).HasComment("チーム名");

            //NULL非許容
            builder.Property(team => team.Name).IsRequired();

            //外部キー制約の設定
            //builder.HasMany(team => team.Player)
            //    .WithOne(player => player.Team)
            //    .HasForeignKey(player => player.TeamId);

            //初期データ
            builder.HasData(new Team { Id = 1, Name = "巨人" });
            builder.HasData(new Team { Id = 2, Name = "阪神" });
            builder.HasData(new Team { Id = 3, Name = "中日" });
        }
    }
}
