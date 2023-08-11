using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.SirFad;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping.ValuesResolver
{
    public class DistribuidorResolver : IValueResolver<Registro, AigRecord, AigDistributor>
    {
        public AigDistributor Resolve(Registro source, AigRecord destination, AigDistributor destMember, ResolutionContext context)
        {
            if (source.Distribuidores?.Count > 0) {
                var value=String.Join(",", source.Distribuidores.Select(s=>$"{s.Nombre} ({s.Licencia})"));
                return  new AigDistributor(){
                    NombreTitular = value,
                    NombreDistribuidorNacional = string.Empty,
                    NombreAcondicionadorPrimario = string.Empty,
                    NombreAcondicionadorSecundario = string.Empty
                };
            }
            return null;
        }
    }
}
