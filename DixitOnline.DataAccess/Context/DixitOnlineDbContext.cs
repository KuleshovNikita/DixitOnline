using DixitOnline.Models.PlayerData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DixitOnline.DataAccess.Context
{
    public class DixitOnlineDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\MYBASE;Database=DixitOnline;Trusted_Connection=True;");
        }

        public DbSet<PlayerModel> Players { get; set; }
    }
}
