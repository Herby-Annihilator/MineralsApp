using MineralsApp.DataAccessLayer.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IRepository<T> where T : IEntity, new()
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Save(T entity);
        void Delete(int id);
    }
}
