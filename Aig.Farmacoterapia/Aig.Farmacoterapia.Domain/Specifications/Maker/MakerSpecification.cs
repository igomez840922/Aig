using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Contry
{
    public class MakerSpecification : BaseSpecification<AigFabricante>
    {
       
        public MakerSpecification(List<Expression<Func<AigFabricante, bool>>> filters)
        {
            Criteria = p => true;
            Includes.Add(a => a.Pais);
            foreach (var filter in filters)
                And(filter);
            }
      }
}