using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;
using linqKit = LinqKit;

namespace Aig.Farmacoterapia.Domain.Specifications.Studies
{
    public class StudieSpecification : BaseSpecification<AigEstudio>
    {
        public StudieSpecification(List<Expression<Func<AigEstudio, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
        }
    }
    public class StudyEvaluadorSpecification : BaseSpecification<AigEstudioEvaluador>
    {
        public StudyEvaluadorSpecification(long id) => Criteria = p => p.EstudioId == id;
    }
}