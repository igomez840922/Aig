using System;
using System.Collections.Generic;
using System.Linq;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Configurations
{
    public class MedicationRecordConfiguration :
        IEntityTypeConfiguration<AigRecord> {
        public void Configure(EntityTypeBuilder<AigRecord> builder)
        {
            builder.HasKey(k => new { k.Id });
            builder.Property(e => e.Producto).HasJsonConversion();
            builder.Property(e => e.Fabricante).HasJsonConversion();
            builder.Property(e => e.Distribuidor).HasJsonConversion();
            builder.Property(e => e.Presentaciones).HasJsonConversion();
            builder.Property(e => e.Excipientes).HasJsonConversion();
            builder.Ignore(c => c.ShowDetails);
        }
      
    }
}
