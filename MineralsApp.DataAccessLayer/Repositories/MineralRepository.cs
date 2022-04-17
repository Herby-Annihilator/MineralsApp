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
            Mineral result = _dbContext.Minerals
                .Include(m => m.FieldHasMinerals)
                .ThenInclude(f => f.Field)
                .Include(m => m.PublicationDescribesMineral)
                .ThenInclude(pm => pm.Publication)
                .ThenInclude(p => p.ResearcherHasPublication)
                .ThenInclude(rp => rp.Researcher)
                .Include(m => m.OreHasMinerals)
                .ThenInclude(om => om.Ore)
                .Single(m => m.Id == id);
            return result;
        }

        public IEnumerable<Mineral> GetAll()
        {
            return _dbContext.Minerals.ToList();
        }

        public void Save(Mineral entity)
        {
            if (entity.Id == default || entity.Id < 0)
                _dbContext.Minerals.Add(entity);
            else
                _dbContext.Minerals.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
