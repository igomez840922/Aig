using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Medicament
{
    public class PharmaceuticalSpecification : BaseSpecification<AigFormaFarmaceutica>
    {
       
        public PharmaceuticalSpecification(List<Expression<Func<AigFormaFarmaceutica, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
            }
      }
}