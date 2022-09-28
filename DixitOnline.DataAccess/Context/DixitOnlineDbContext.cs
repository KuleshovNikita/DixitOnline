using DixitOnline.Models.PlayerData;
using DixitOnline.Models.RoomData;
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

            modelBuilder.Entity<PlayerModel>().HasKey(x => x.PlayerId);
            modelBuilder.Entity<PlayerModel>().ToTable("Players");
            modelBuilder.Entity<PlayerModel>(entity =>
            {
                entity.Property<int>("PlayerId")
                    .ValueGeneratedOnAdd();

                entity.Property<string>("Name")
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property<int>("RoomId")
                    .IsRequired();

                entity.Property<int>("GameScore")
                    .HasMaxLength(int.MaxValue)
                    .HasDefaultValue(0)
                    .IsRequired();
            });

            modelBuilder.Entity<RoomModel>().HasKey(x => x.RoomId);
            modelBuilder.Entity<RoomModel>().ToTable("Rooms");
            modelBuilder.Entity<RoomModel>(entity =>
            {
                entity.Property<int>("RoomId")
                    .ValueGeneratedOnAdd();

                entity.Property<string>("RoomCode")
                    .IsRequired()
                    .HasMaxLength(16);

                entity.HasAlternateKey(x => x.RoomCode);
            });

            modelBuilder.Entity<RoomModel>()
                .HasMany(x => x.Players)
                .WithOne()
                .HasForeignKey(x => x.RoomId);
        }
    }
}
