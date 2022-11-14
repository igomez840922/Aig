using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using Microsoft.EntityFrameworkCore;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T: BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }


        public IQueryable<T> GetAll()
        {
            return  _dbContext.Set<T>().AsQueryable();
        }
        public Task<int> CountAsync()
        {
            return _dbContext.Set<T>().CountAsync();
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<T> UpdateAsync(T entity)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var exist = _dbContext.Set<T>().Find(entity.Id);
#pragma warning disable CS8634 // The type 'T?' cannot be used as type parameter 'TEntity' in the generic type or method 'DbContext.Entry<TEntity>(TEntity)'. Nullability of type argument 'T?' doesn't match 'class' constraint.
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
#pragma warning restore CS8634 // The type 'T?' cannot be used as type parameter 'TEntity' in the generic type or method 'DbContext.Entry<TEntity>(TEntity)'. Nullability of type argument 'T?' doesn't match 'class' constraint.
            return entity;
        }
    }
}
