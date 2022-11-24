using System;
using System.Linq.Expressions;
using Aig.Farmacoterapia.Domain.Interfaces;
using linqKit = LinqKit;

namespace Aig.Farmacoterapia.Domain.Specifications.Base
{
    public interface ISpecification<T> where T : class, IEntity
    {
        Expression<Func<T, bool>> Criteria { get; }
        linqKit.ExpressionStarter<T> Expression { get; set; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<T, bool>> And(Expression<Func<T, bool>> query);
        Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query);
    }
}