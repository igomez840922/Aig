using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Integration.SysFarm;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .ForMember(p => p.RecordId, p=> p.MapFrom(s => s.Id));
            CreateMap<Root, SysFarmResponse>();
        }
    }
}
