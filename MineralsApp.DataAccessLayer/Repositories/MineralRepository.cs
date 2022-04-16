using Microsoft.EntityFrameworkCore;
using MineralsApp.DataAccessLayer.DbContexts;
using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Repositories
{
    public class MineralRepository : IRepository<Mineral>
    {
        MySqlDbContext _dbContext;
        public MineralRepository(MySqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            _dbContext.Minerals.Remove(new Mineral() { Id = id });
            _dbContext.SaveChanges();
        }

        public Mineral Get(int id)
        {
            //_dbContext.Minerals.Include()
            throw new NotImplementedException();
        }

        public IEnumerable<Mineral> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Mineral entity)
        {
            throw new NotImplementedException();
        }
    }
}
