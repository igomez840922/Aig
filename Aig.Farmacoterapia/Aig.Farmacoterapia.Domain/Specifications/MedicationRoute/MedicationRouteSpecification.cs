using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Medicament
{
    public class MedicationRouteSpecification : BaseSpecification<AigViaAdministracion>
    {
       
        public MedicationRouteSpecification(List<Expression<Func<AigViaAdministracion, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
            }
      }
}