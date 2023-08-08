using System;
using System.Collections.Generic;
using System.Linq;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<AigService> {
        public void Configure(EntityTypeBuilder<AigService> builder)
        {
            builder.HasKey(k => new { k.Id });
        }
    }
}
