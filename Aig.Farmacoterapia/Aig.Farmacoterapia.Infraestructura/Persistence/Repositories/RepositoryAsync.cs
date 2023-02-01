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

        //public async Task<T> UpdateAsync(T entity)
        //{
        //    var exist = _dbContext.Set<T>().Find(entity.Id);
        //    _dbContext.Entry(exist).CurrentValues.SetValues(entity);
        //    return entity;
        //}

        public async Task<T> UpdateAsync(T entity)
        {
            var result = _dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
