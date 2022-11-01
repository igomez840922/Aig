using System;
using System.Collections.Generic;
using System.Linq;
using Aig.Farmacoterapia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Configurations
{
    public class EntityConfiguration : 
        IEntityTypeConfiguration<AigMedicamento>,
        IEntityTypeConfiguration<AigFabricante>,
        IEntityTypeConfiguration<AigPais>,
        IEntityTypeConfiguration<AigFormaFarmaceutica> {
        public void Configure(EntityTypeBuilder<AigMedicamento> builder)
        {
            builder.HasKey(k => new { k.Id });
            //builder.OwnsOne(o => o.Propiadades, p => {
            //    p.Property(s => s.Quimico).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Propiedades).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.PropiedadesFarmaco).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Indicaciones).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Contraindicaciones).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Advertencias).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Embarazo).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Conducir).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Interacciones).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Reacciones).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Posologia).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Sobredosificacion).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Preclinicos).HasColumnType("nvarchar(512)");
            //});
            //builder.OwnsOne(o => o.Prospecto, p => {
            //    p.Property(s => s.ModoDeUso).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Composicion).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Forma).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Envase).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.VidaUtil).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.Condicion).HasColumnType("nvarchar(512)");
            //    p.Property(s => s.InformaciónAdicional).HasColumnType("nvarchar(512)");
            //});
            builder.Ignore(c => c.ShowDetails);
            builder.HasOne(t => t.Fabricante)
                 .WithMany(t => t.Medicamentos)
                 .HasForeignKey(t => t.FabricanteId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.FormaFarmaceutica)
                  .WithMany(t => t.Medicamentos)
                  .HasForeignKey(t => t.FormaFarmaceuticaId)
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
    }
}
