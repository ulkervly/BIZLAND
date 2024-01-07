using BizLand.Core.Entities;
using BizLand.Core.Repository.Interfaces;
using BizLand.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Data.Repository.Implementations
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _appDb;

        public GenericRepository(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public DbSet<TEntity> Table => _appDb.Set<TEntity>();

        public async Task<int> CommitAsync()
        {
            return await _appDb.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _appDb.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _appDb.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);
            return expression is not null
                ? await query.Where(expression).ToListAsync()
                : await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);
            return expression is not null
                ? await query.Where(expression).FirstOrDefaultAsync()
                : await query.FirstOrDefaultAsync();
        }


        private IQueryable<TEntity> GetQuery(string[] includes)
        {
            var query = Table.AsQueryable();

            if(query != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            return query;
        }
    }
}
