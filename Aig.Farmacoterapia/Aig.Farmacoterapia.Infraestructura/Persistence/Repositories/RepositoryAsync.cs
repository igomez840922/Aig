using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using Aig.Farmacoterapia.Infrastructure.Extensions;
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
        public IQueryable<T> EntitiesNoTracking => _dbContext.Set<T>().AsNoTracking();

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

        public async Task<PaginatedResult<T>> GetPagedResponseAsync(PageArgs args, Tuple<SortingOption, Expression<Func<T, object>>> order)
        {
            var result = await _dbContext.Set<T>().OrderBy(order).PaginatedByAsync(args.PageIndex, args.PageSize);
            return result;
        }
        public async Task<PaginatedResult<IEntity>> GetPagedResponseAsync(PageArgs args, Tuple<SortingOption, Expression<Func<T, object>>> order, ISpecification<IEntity> filter)
        {
            var result = await _dbContext.Set<T>().OrderBy(order).WhereBy(filter).PaginatedByAsync(args.PageIndex, args.PageSize);
            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = _dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
