using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Integration.SirFad;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping.MappingActions;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping.ValuesResolver;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.SirFad;
using AutoMapper;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping
{
    public class SirFadMapProfile : Profile
    {
        public SirFadMapProfile()
        {
            CreateMap<Producto, AigMedication>();
            CreateMap<Fabricante, AigMaker>();
            CreateMap<Presentacione, AigPresentation>();
            CreateMap<Registro, AigRecord>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(p => p.RecordId, p => p.MapFrom(s => s.Id))
            .ForMember(p => p.RenovacionNumero, p => p.MapFrom(s => 0))
            .ForMember(p => p.RenovacionTexto, p => p.MapFrom(s => string.Empty))
            .ForMember(p => p.Activated, p => p.MapFrom(s =>true))
            .ForMember(p => p.Numero, p => p.MapFrom(s => s.NumeroRegistro))
            .ForMember(p => p.Estado, p => p.MapFrom(s => s.EstadoDetalles))
            .ForMember(p => p.Excipientes, p => p.MapFrom(s => Array.Empty<AigExcipient>()))
            .ForMember(dest => dest.Producto, opt => opt.MapFrom((source, destination, member, context) =>
                new AigMedication()
                {
                    Nombre = source.Producto?.Nombre,
                    DescripcionEnvase = source.Producto?.DescripcionEnvase,
                    ClasificacionMedica = source.Producto?.ClasificacionMedica,
                    CondicionVenta = source.Producto?.CondicionVenta,
                    PrincipioActivo = source.Producto?.PrincipioActivo,
                    ViaAdministracion = source.Producto?.ViaAdministracion,
                    FormaFarmaceutica = source.Producto?.FormaFarmaceutica,
                    VidaUtil = source.Producto?.VidaUtil,

                }))
            .ForMember(dest => dest.Fabricante, opt => opt.MapFrom((source, destination, member, context) =>
                    new AigMaker()
                    {
                        Nombre = source.Fabricante?.Nombre,
                        Direccion = source.Fabricante?.Direccion,
                        Correo = source.Fabricante?.Correo,
                        Pais = source.Fabricante?.Pais,
                        PaisISO2 = source.Fabricante?.PaisISO2,
                        PaisISO3 = source.Fabricante?.PaisISO3,
                    }))
             .ForMember(dest => dest.Distribuidor, opt => opt.MapFrom(new DistribuidorResolver()))
                .AfterMap<SirFadMappingAction>();
            CreateMap<Root, SirFadResponse>();
        }
    }
}