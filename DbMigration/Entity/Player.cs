using DbMigration.Enum;
using DbMigration.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DbMigration.Entity
{
    /// <summary>
    /// 選手テーブル
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// 選手ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 選手名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// ポジション
        /// </summary>
        public PositionEnum.Position Position { get; set; }

        /// <summary>
        /// チームID
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// 学校ID
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// チーム
        /// </summary>
        public virtual Team Team { get; set; }

        /// <summary>
        /// 出身校
        /// </summary>
        public virtual School School { get; set; }
    }

    /// <summary>
    /// 選手テーブルの詳細定義
    /// https://docs.microsoft.com/ja-jp/ef/core/modeling/
    /// </summary>
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public PlayerConfiguration(EntityTypeBuilder<Player> builder)
        {
            Configure(builder);
        }

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            //テーブル名の設定
            builder.ToTable("Player");

            //主キーの設定
            builder.HasKey(player => player.Id);

            //各カラムの制約条件

            //カラム名の設定
            builder.Property(player => player.Id).HasComment("選手ID");
            builder.Property(player => player.Name).HasComment("選手名");
            builder.Property(player => player.Position).HasComment("ポジション");
            builder.Property(player => player.TeamId).HasComment("チームID");
            builder.Property(player => player.SchoolId).HasComment("学校ID");

            //NULL非許容
            builder.Property(player => player.Name).IsRequired();
            builder.Property(player => player.Position).IsRequired();
            builder.Property(player => player.TeamId).IsRequired();
            builder.Property(player => player.SchoolId).IsRequired();

            //外部キー制約の設定
            builder.HasOne(player => player.Team)
                .WithMany(team => team.Player)
                .HasForeignKey(player => player.TeamId);
            builder.HasOne(player => player.School)
                .WithMany(school => school.Player)
                //.HasForeignKey(player => new { player.SchoolId, player.TeamId });
                .HasForeignKey(player => player.SchoolId);
        }
    }
}
