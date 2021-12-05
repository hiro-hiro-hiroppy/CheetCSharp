using Microsoft.EntityFrameworkCore;

namespace DbMigration.Entity
{
    public class ZDbContext : DbContext
    {
        public ZDbContext(DbContextOptions<ZDbContext> options) : base(options) { }

        public DbSet<M_POSITION>? M_POSITIONS { get; set; }
        public DbSet<T_PLAYER>? T_PLAYERS { get; set; }
        public DbSet<T_TEAM>? T_TEAMS { get; set; }
    }
}
