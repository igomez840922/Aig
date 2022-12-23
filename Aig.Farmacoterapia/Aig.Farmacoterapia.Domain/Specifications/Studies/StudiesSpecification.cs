using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Studies
{
    public class StudiesSpecification : BaseSpecification<AigEstudios>
    {
        public StudiesSpecification(List<Expression<Func<AigEstudios, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
        }
     }
}