using MineralsApp.DataAccessLayer.DbContexts;
using System;

namespace MineralsApp.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlDbContext db = new MySqlDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
