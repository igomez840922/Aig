using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Integration.SysFarm;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping.MappingActions;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping.ValuesResolver;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping
{
    public class SysFarmMapProfile : Profile
    {
        public SysFarmMapProfile()
        {
            CreateMap<Producto, AigMedication>();
            CreateMap<Excipiente, AigExcipient>();
            CreateMap<Fabricante, AigMaker>();
            CreateMap<Distribuidor, AigDistributor>();
            CreateMap<Presentacione, AigPresentation>();
            CreateMap<Registro, AigRecord>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(p => p.RecordId, p => p.MapFrom(s => s.Id))
                //.ForMember(dest => dest.FechaExpedicion, opt => opt.MapFrom<DateTimeResolver>())
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
                .ForMember(dest => dest.Distribuidor, opt => opt.MapFrom((source, destination, member, context) =>
                        new Distribuidor()
                        {
                            NombreDistribuidorNacional = source.Distribuidor?.NombreDistribuidorNacional,
                            NombreTitular = source.Distribuidor?.NombreTitular,
                            NombreAcondicionadorPrimario = source.Distribuidor?.NombreAcondicionadorPrimario,
                            NombreAcondicionadorSecundario = source.Distribuidor?.NombreAcondicionadorSecundario,
                        })).AfterMap<DateTimeMappingAction>();
            CreateMap<Root, SysFarmResponse>();
        }
    }
}