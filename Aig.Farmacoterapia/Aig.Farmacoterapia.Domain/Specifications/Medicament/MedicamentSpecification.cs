using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Medicament
{
    public class MedicamentSpecification : BaseSpecification<AigMedicamento>
    {
        public MedicamentSpecification(string searchString)
        {
            Criteria = p => true;
#pragma warning disable CS8603 // Possible null reference return.
            Includes.Add(a => a.FormaFarmaceutica);
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning disable CS8603 // Possible null reference return.
            Includes.Add(a => a.Fabricante);
#pragma warning restore CS8603 // Possible null reference return.
            if (!string.IsNullOrEmpty(searchString)) {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                Criteria = p => p.Nombre.Contains(searchString) || p.FormaFarmaceutica.Nombre.Contains(searchString);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }
        public MedicamentSpecification(List<Expression<Func<AigMedicamento, bool>>> filters)
        {
#pragma warning disable CS8603 // Possible null reference return.
            Includes.Add(a => a.FormaFarmaceutica);
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning disable CS8603 // Possible null reference return.
            Includes.Add(a => a.Fabricante);
#pragma warning restore CS8603 // Possible null reference return.
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
            }
      }
}