using Aig.Farmacoterapia.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.Mapping.ValuesResolver
{

    public class DateTimeResolver : IValueResolver<Registro, AigRecord, DateTime?>
    {
        public DateTime? Resolve(Registro source, AigRecord destination, DateTime? destMember, ResolutionContext context)
        {
            return DateTime.ParseExact(source.FechaExpedicion, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
