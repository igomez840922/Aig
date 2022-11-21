using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Maker
{
    public class MakerSpecification : BaseSpecification<AigFabricante>
    {
        public MakerSpecification(string value)
        {
            Includes.Add(a => a.Pais);
            if(!string.IsNullOrEmpty(value))
                Criteria = p => p.Nombre.ToLower().Contains(value.ToLower());
        }

        public MakerSpecification(List<Expression<Func<AigFabricante, bool>>> filters)
        {
            Criteria = p => true;
            Includes.Add(a => a.Pais);
            foreach (var filter in filters)
                And(filter);
            }
      }
}