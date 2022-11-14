using Aig.Farmacoterapia.Domain.Extensions;
using Aig.Farmacoterapia.Domain.Interfaces;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Base
{
    public abstract class BaseSpecification<T> : ISpecification<T> where T : class, IEntity
    {
#pragma warning disable CS8618 // Non-nullable property 'Criteria' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public Expression<Func<T, bool>> Criteria { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Criteria' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<Expression<Func<T, object>>> Includes { get; } = new();
        public List<string> IncludeStrings { get; } = new();

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        public Expression<Func<T, bool>> And(Expression<Func<T, bool>> query)
        {
            return Criteria = Criteria == null ? query : Criteria.And(query);
        }

        public Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query)
        {
            return Criteria = Criteria == null ? query : Criteria.Or(query);
        }
    }
}