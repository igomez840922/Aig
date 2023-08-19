using System;
using System.Collections.Generic;
using System.Linq;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Configurations
{
    public class RecordConfiguration :
        IEntityTypeConfiguration<AigRecord> {
        public void Configure(EntityTypeBuilder<AigRecord> builder)
        {
            builder.HasKey(k => new { k.Id });
            
            builder.OwnsOne(o => o.Producto);
            builder.OwnsOne(o => o.Fabricante);
            builder.OwnsOne(o => o.Distribuidor);

            builder.Property(e => e.Presentaciones).HasJsonConversion();
            builder.Property(e => e.Excipientes).HasJsonConversion();
            builder.Ignore(c => c.ShowDetails);
        }
      
    }
}
