using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Medicament
{
    public class MedicationRouteSpecification : BaseSpecification<AigViaAdministracion>
    {
        public MedicationRouteSpecification(string value)
        {
            if (!string.IsNullOrEmpty(value))
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                Criteria = p => p.Nombre.ToLower().StartsWith(value.ToLower());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        public MedicationRouteSpecification(List<Expression<Func<AigViaAdministracion, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
            }
      }
}