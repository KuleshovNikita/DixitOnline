using DixitOnline.Models.PlayerData;
using Microsoft.EntityFrameworkCore;

namespace DixitOnline.DataAccess.Context
{
    public class DixitOnlineDbContext : DbContext
    {
        private readonly string _connectionString;

        public DixitOnlineDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<PlayerModel> Players { get; set; }
    }
}
