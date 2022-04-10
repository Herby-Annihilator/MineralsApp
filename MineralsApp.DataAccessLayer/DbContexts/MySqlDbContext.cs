using Microsoft.EntityFrameworkCore;
using MineralsApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.DbContexts
{
    public class MySqlDbContext : DbContext
    {
        private string _connectionString;
        public DbSet<Country> Countries { get; set; }

        public DbSet<Territory> Territories { get; set; }

        public MySqlDbContext()
        {
            //_connectionString = connectionString;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=192.168.1.133;port=3306;user=dvrukin;password=qwerty123@;database=minerals;",
                new MySqlServerVersion(new Version(8, 0, 28)));
        }
    }
}
