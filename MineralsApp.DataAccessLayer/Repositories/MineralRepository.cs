using Microsoft.EntityFrameworkCore;
using MineralsApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralsApp.DataAccessLayer.Repositories
{
    public class MineralRepository : DefaultRepository<Mineral>
    {
        public MineralRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
