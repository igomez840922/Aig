using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;
using linqKit = LinqKit;

namespace Aig.Farmacoterapia.Domain.Specifications.Studies
{
    public class StudieDNFDSpecification : BaseSpecification<AigEstudioDNFD>
    {
        public StudieDNFDSpecification(List<Expression<Func<AigEstudioDNFD, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
        }
    }
}