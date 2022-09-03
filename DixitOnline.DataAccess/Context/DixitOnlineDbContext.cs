using DixitOnline.Models.PlayerData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace DixitOnline.DataAccess.Context
{
    public class DixitOnlineDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<PlayerModel> Players { get; set; }

        public DixitOnlineDbContext(DbContextOptions<DixitOnlineDbContext> options)
        {
            _connectionString = options.GetExtension<SqlServerOptionsExtension>().ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerModel>(entity =>
            {
                entity.Property<int>("PlayerId")
                    .ValueGeneratedOnAdd();

                entity.Property<string>("Name")
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property<int>("Room")
                    .HasMaxLength(int.MaxValue)
                    .IsRequired();

                entity.Property<int>("GameScore")
                    .HasMaxLength(int.MaxValue)
                    .HasDefaultValue(0)
                    .IsRequired();
            });
        }
    }
}
