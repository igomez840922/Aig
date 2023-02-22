using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;
using linqKit = LinqKit;

namespace Aig.Farmacoterapia.Domain.Specifications.Studies
{
    public class CodeSpecification : BaseSpecification<AigCodigoEstudio>
    {
        public CodeSpecification(List<Expression<Func<AigCodigoEstudio, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
        }
        public CodeSpecification(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Criteria = p => p.Codigo.ToLower().Contains(value.ToLower());
        }
    }
}