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
    public class ProfessionRepository : GenericRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}
