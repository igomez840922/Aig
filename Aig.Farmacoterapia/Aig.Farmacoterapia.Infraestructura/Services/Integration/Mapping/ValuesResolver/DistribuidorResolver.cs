using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.SirFad;
using AutoMapper;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping.ValuesResolver
{
    public class DistribuidorResolver : IValueResolver<Registro, AigRecord, AigDistributor>
    {
        public AigDistributor Resolve(Registro source, AigRecord destination, AigDistributor destMember, ResolutionContext context)
        {
            if (source?.Distribuidores?.Count > 0) {
                var value=String.Join(",", source?.Distribuidores.Select(s=>$"{s.Nombre} ({s.Licencia})"));
                return  new AigDistributor(){
                    NombreAcondicionadorPrimario = source?.Acondicionador?.AconAntiguo ?? string.Empty,
                    PaisAcondicionadorPrimario = source?.Acondicionador?.AconAntiguoPais ?? string.Empty,
                    NombreDistribuidorNacional = value,
                    NombreTitular = string.Empty,
                    NombreAcondicionadorSecundario = string.Empty
                };
            }
            return null;
        }
    }
}
