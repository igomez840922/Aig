
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> PaginatedByAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new Exception();
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await source.CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }

        public static IQueryable<T> WhereBy<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class, IEntity
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(query,
                    (current, include) => current.Include(include));
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));
            return secondaryResult.Where(spec.Criteria);
        }
        public static IQueryable<T> WhereBy2<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class, IEntity
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(query,
                    (current, include) => current.Include(include));
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));
            return secondaryResult.Where(spec.Expression);
        }
        public static async Task<List<T>> WhereByAsync<T>(this IQueryable<T> query, Expression<Func<T, object>> sort = null, ISpecification<T> spec = null) where T : class, IEntity
        {
         
            if (spec is null)
                return sort == null ? await query.ToListAsync() : await query.OrderBy(sort).ToListAsync();
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(query,
                    (current, include) => current.Include(include));
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));
            return sort == null ?
                            await secondaryResult.Where(spec.Criteria).ToListAsync() :
                            await secondaryResult.Where(spec.Criteria).OrderBy(sort).AsQueryable().ToListAsync();
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, List<Tuple<SortingOption, Expression<Func<T, object>>>> orderByList)
        {
            if (orderByList == null)
                return query;
            orderByList = orderByList.OrderBy(ob => ob.Item1.Priority).ToList();
            IOrderedQueryable<T> orderedQuery = null;
            foreach (var orderBy in orderByList)
            {
                if (orderedQuery == null)
                    orderedQuery = orderBy.Item1.Direction == SortingDirection.ASC ? query.OrderBy(orderBy.Item2) : query.OrderByDescending(orderBy.Item2);
                else
                    orderedQuery = orderBy.Item1.Direction == SortingDirection.ASC ? orderedQuery.ThenBy(orderBy.Item2) : orderedQuery.ThenByDescending(orderBy.Item2);
            }
            return orderedQuery ?? query;
        }
    }
}