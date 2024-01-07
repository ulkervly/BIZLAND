﻿using BizLand.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table { get; }
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<int> CommitAsync();

        Task<TEntity> GetByIdAsync(Expression<Func<TEntity , bool>>? expression = null , params string[]? includes);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity , bool>>? expression = null, params string[]? includes);
    }
}
