using Aig.Farmacoterapia.Domain.Entities.Products;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping.MappingActions
{
    public class DateTimeMappingAction : IMappingAction<Registro, AigRecord>
    {
        public DateTimeMappingAction() { }
        public void Process(Registro source, AigRecord destination, ResolutionContext context)
        {
            destination.FechaExpedicion = DateTime.ParseExact(source.FechaExpedicion, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            destination.FechaVencimiento = DateTime.ParseExact(source.FechaVencimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            destination.FechaUltimaActualizacion = DateTime.ParseExact(source.FechaUltimaActualizacion, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}
