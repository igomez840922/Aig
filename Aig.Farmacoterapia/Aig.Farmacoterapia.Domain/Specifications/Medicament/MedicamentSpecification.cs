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
            Includes.Add(a => a.FormaFarmaceutica);
            Includes.Add(a => a.Fabricante);
            if (!string.IsNullOrEmpty(searchString)) {
                Criteria = p => p.Nombre.Contains(searchString) || p.FormaFarmaceutica.Nombre.Contains(searchString);
            }
        }
        public MedicamentSpecification(List<Expression<Func<AigMedicamento, bool>>> filters)
        {
            Includes.Add(a => a.FormaFarmaceutica);
            Includes.Add(a => a.Fabricante);
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
            }
      }
}