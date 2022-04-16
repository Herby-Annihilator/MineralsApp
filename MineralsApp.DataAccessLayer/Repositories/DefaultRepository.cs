using Microsoft.EntityFrameworkCore;
using MineralsApp.DataAccessLayer.Entities.Interfaces;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Repositories
{
    public class DefaultRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected DbContext _dbContext;
        public DefaultRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            _dbContext.Remove(new T() { Id = id });
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            T result = (T)_dbContext.Find(typeof(T), id);
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public void Save(T entity)
        {
            if (entity.Id == default)
                _dbContext.Add(entity);
            else
                _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
