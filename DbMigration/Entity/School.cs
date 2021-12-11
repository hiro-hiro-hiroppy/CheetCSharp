using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DbMigration.Entity
{
    /// <summary>
    /// 学校テーブル
    /// </summary>
    public class School
    {
        /// <summary>
        /// 学校ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 学校名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 選手
        /// </summary>
        public List<Player>? Player { get; set; }
    }

    /// <summary>
    /// 学校テーブルの詳細定義
    /// https://docs.microsoft.com/ja-jp/ef/core/modeling/
    /// </summary>
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public SchoolConfiguration(EntityTypeBuilder<School> builder)
        {
            Configure(builder);
        }

        public void Configure(EntityTypeBuilder<School> builder)
        {
            //テーブル名の設定
            builder.ToTable("School");

            //主キーの設定
            builder.HasKey(school => school.Id);

            //各カラムの制約条件

            //カラム名の設定
            builder.Property(school => school.Id).HasComment("学校ID");
            builder.Property(school => school.Name).HasComment("学校名");


            //NULL非許容
            builder.Property(school => school.Name).IsRequired();

            //外部キー制約の設定
            //builder.HasMany(school => school.Player)
            //    .WithOne(player => player.School);

            //初期データ
            builder.HasData(new School { Id = 1, Name = "パワフル高校" });
            builder.HasData(new School { Id = 2, Name = "あかつき高校" });
            builder.HasData(new School { Id = 3, Name = "帝王高校" });
        }
    }
}
