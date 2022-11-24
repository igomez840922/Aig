using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;
using linqKit = LinqKit;

namespace Aig.Farmacoterapia.Domain.Specifications.Medicament
{
    public class AdminMedicamentSpecification : BaseSpecification<AigMedicamento>
    {
        public AdminMedicamentSpecification(string searchString)
        {
            Criteria = p => true;
            Includes.Add(a => a.FormaFarmaceutica);
            Includes.Add(a => a.Fabricante);
            if (!string.IsNullOrEmpty(searchString)) {
                Criteria = p => p.Nombre.Contains(searchString) || p.FormaFarmaceutica.Nombre.Contains(searchString);
            }
        }
        public AdminMedicamentSpecification(List<Expression<Func<AigMedicamento, bool>>> filters)
        {
            Includes.Add(a => a.FormaFarmaceutica);
            Includes.Add(a => a.Fabricante);
            Criteria = p => true;
            foreach (var filter in filters) 
                And(filter);

 
        }
      }

    public class MedicamentSpecification : BaseSpecification<AigMedicamento>
    {
      
        public MedicamentSpecification(List<Expression<Func<AigMedicamento, bool>>> filters, LogicalOperator logicalOperator=LogicalOperator.Or)
        {
            Includes.Add(a => a.FormaFarmaceutica);
            Includes.Add(a => a.Fabricante);
            var predicate = linqKit.PredicateBuilder.New<AigMedicamento>(true);
            foreach (var filter in filters) {
                predicate = logicalOperator== LogicalOperator.Or? predicate.Or(filter) : predicate.And(filter); 
            }
            Expression = predicate;
        }
    }
}