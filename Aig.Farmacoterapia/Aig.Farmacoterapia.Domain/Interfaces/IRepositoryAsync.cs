﻿using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        IQueryable<T> Entities { get; }
        IQueryable<T> EntitiesNoTracking { get; }
        Task<T?> GetByIdAsync(long id);
        IQueryable<T> GetAll();
        Task<int> CountAsync();
        Task<long> CountAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task<PaginatedResult<T>> GetPagedResponseAsync(PageArgs args, Tuple<SortingOption, Expression<Func<T, object>>> order);
        Task<PaginatedResult<IEntity>> GetPagedResponseAsync(PageArgs args, Tuple<SortingOption, Expression<Func<T, object>>> order, ISpecification<IEntity> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> UpdateDeepAsync(T entity, params Tuple<Expression<Func<T, object>>, object>[] navigation);
        T UpdateDeep(T entity, params Tuple<Expression<Func<T, object>>, object>[] navigation);
        Task DeleteAsync(T entity);
    }
}
