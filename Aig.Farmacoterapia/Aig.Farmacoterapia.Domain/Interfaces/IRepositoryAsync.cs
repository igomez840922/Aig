using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        IQueryable<T> Entities { get; }
        IQueryable<T> EntitiesNoTracking { get; }
        Task<T?> GetByIdAsync(long id);
        IQueryable<T> GetAll();
        Task<int> CountAsync();
        Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task<PaginatedResult<T>> GetPagedResponseAsync(PageArgs args, Tuple<SortingOption, Expression<Func<T, object>>> order);
        Task<PaginatedResult<IEntity>> GetPagedResponseAsync(PageArgs args, Tuple<SortingOption, Expression<Func<T, object>>> order, ISpecification<IEntity> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
