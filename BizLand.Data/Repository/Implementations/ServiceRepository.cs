using BizLand.Core.Entities;
using BizLand.Core.Repository.Interfaces;
using BizLand.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Data.Repository.Implementations
{
    public class ServiceRepository : GenericRepository<Services>, IServiceRepository
    {
        public ServiceRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}
