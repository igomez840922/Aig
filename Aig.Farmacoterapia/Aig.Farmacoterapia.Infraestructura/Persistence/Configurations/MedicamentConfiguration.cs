using System;
using System.Collections.Generic;
using System.Linq;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Configurations
{
    public class MedicamentConfiguration : 
        IEntityTypeConfiguration<AigMedicamento>,
        IEntityTypeConfiguration<AigFabricante>,
        IEntityTypeConfiguration<AigPais>,
        IEntityTypeConfiguration<AigFormaFarmaceutica>,
        IEntityTypeConfiguration<AigViaAdministracion>,
        IEntityTypeConfiguration<ApplicationUser>
        //IEntityTypeConfiguration<AigEstudios>
    {

        public void Configure(EntityTypeBuilder<AigMedicamento> builder)
        {
            builder.HasKey(k => new { k.Id });
            builder.Ignore(c => c.ShowDetails);
            //builder.Ignore(c => c.DataSheelFile);

            builder.HasOne(t => t.Fabricante)
                 .WithMany(t => t.Medicamentos)
                 .HasForeignKey(t => t.FabricanteId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.FormaFarmaceutica)
                  .WithMany(t => t.Medicamentos)
                  .HasForeignKey(t => t.FormaFarmaceuticaId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.ViaAdministracion)
                 .WithMany(t => t.Medicamentos)
                 .HasForeignKey(t => t.ViaAdministracionId)
                 .OnDelete(DeleteBehavior.NoAction);
        }

        public void Configure(EntityTypeBuilder<AigFabricante> builder)
        {
            builder.HasKey(k => new { k.Id });
            builder.Property(p => p.Nombre)
                   .HasColumnType("nvarchar(600)")
                   .IsRequired();
            builder.HasOne(t => t.Pais)
                 .WithMany(t => t.Fabricantes)
                 .HasForeignKey(t => t.PaisId)
                 .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<AigPais> builder)
        {
            builder.HasKey(k => new { k.Id });
        }

        public void Configure(EntityTypeBuilder<AigFormaFarmaceutica> builder)
        {
            builder.HasKey(k => new { k.Id });
        }
        public void Configure(EntityTypeBuilder<AigViaAdministracion> builder)
        {
            builder.HasKey(k => new { k.Id });
        }

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Ignore(c => c.Password);
            builder.Ignore(c => c.PasswordConfirm);
            builder.Ignore(c => c.FullName);
        }

        //public void Configure(EntityTypeBuilder<AigEstudios> builder)
        //{
        //    builder.HasKey(k => new { k.Id });
        //    builder.Ignore(c => c.ShowDetails);
        //    builder.Property(e => e.Medicamentos).HasJsonConversion();
        //}

    }
}
