using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;
using linqKit = LinqKit;

namespace Aig.Farmacoterapia.Domain.Specifications.Record
{
    public class AdminAigRecordSpecification : BaseSpecification<AigRecord>
    {
        public AdminAigRecordSpecification(List<Expression<Func<AigRecord, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
        }
    }

    public class AigRecordSpecification : BaseSpecification<AigRecord>
    {

        public AigRecordSpecification(List<Expression<Func<AigRecord, bool>>> filters, LogicalOperator logicalOperator = LogicalOperator.Or)
        {
            var predicate = linqKit.PredicateBuilder.New<AigRecord>(true);
            foreach (var filter in filters)
            {
                predicate = logicalOperator == LogicalOperator.Or ? predicate.Or(filter) : predicate.And(filter);
            }
            Expression = predicate;
        }
    }
}
