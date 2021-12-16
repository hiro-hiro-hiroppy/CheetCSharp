using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbMigration.Entity
{
    /// <summary>
    /// ログイン用ユーザーテーブル
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// ユーザー名
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// パスワードハッシュ値
        /// </summary>
        public byte[] PasswordHash { get; set; } = new byte[0];

        /// <summary>
        /// パスワード暗号鍵
        /// </summary>
        public byte[] PasswordSalt { get; set; } = new byte[0];
    }

    /// <summary>
    /// ログイン用ユーザーテーブルの詳細定義
    /// https://docs.microsoft.com/ja-jp/ef/core/modeling/
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public UserConfiguration(EntityTypeBuilder<User> builder)
        {
            Configure(builder);
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            //テーブル名の設定
            builder.ToTable("User");

            //主キーの設定
            builder.HasKey(team => team.Id);

            //各カラムの制約条件

            //カラム名の設定
            builder.Property(user => user.Id).HasComment("ユーザーID");
            builder.Property(user => user.Name).HasComment("ユーザー名");
            builder.Property(user => user.PasswordHash).HasComment("パスワードハッシュ値");
            builder.Property(user => user.PasswordSalt).HasComment("パスワード暗号鍵");

            //NULL非許容
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.PasswordHash).IsRequired();
            builder.Property(user => user.PasswordSalt).IsRequired();

            //ユニーク
            builder.HasIndex(user => user.Name).IsUnique();
        }
    }
}
