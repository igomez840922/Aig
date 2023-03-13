using System;
using System.Collections.Generic;
using System.Linq;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Configurations
{
    public class StudiesConfiguration :
        IEntityTypeConfiguration<AigEstudioDNFD>,
        IEntityTypeConfiguration<AigEstudio>,
        IEntityTypeConfiguration<AigEstudioEvaluador>,
        IEntityTypeConfiguration<ApplicationUser>,
        IEntityTypeConfiguration<AigCodigoEstudio> {
        public void Configure(EntityTypeBuilder<AigEstudioDNFD> builder)
        {
            builder.HasKey(k => new { k.Id });
            builder.Property(e => e.Medicamentos).HasJsonConversion();
            builder.Property(p => p.ProductsMetadata).HasColumnType("nvarchar(max)");
            builder.Ignore(c => c.ShowDetails);

            // 1-1 relationships
            builder.HasOne(c => c.AigCodigo)
                   .WithOne().HasForeignKey<AigEstudioDNFD>(b => b.AigCodigoEstudioId)
                   .IsRequired();

        }
        public void Configure(EntityTypeBuilder<AigEstudio> builder)
        {
            builder.HasKey(k => new { k.Id });
            builder.Property(p => p.ProductsMetadata).HasColumnType("nvarchar(max)");
            builder.OwnsOne(o => o.Nota);
            builder.OwnsOne(o => o.Tramitante);

            // m-m relationships
            builder.HasMany(c => c.EstudioEvaluador)
                   .WithOne().HasForeignKey(pls => pls.EstudioId)
                   .IsRequired();

            builder.Property(e => e.Medicamentos).HasJsonConversion();
            builder.Property(e => e.Documents).HasJsonConversion();
            builder.Ignore(c => c.ShowDetails);
            builder.Ignore(c => c.ElapsedDays);
            builder.Ignore(c => c.Evaluators);
            builder.Ignore(c => c.EvaluatorToShow);
            builder.Ignore(c => c.Match);
            builder.Ignore(c => c.MatchInfo);
            
            //builder.HasOne(a => a.AigEstudioDNFD)
            //       .WithOne(b => b.AigEstudio)
            //       .HasForeignKey<AigEstudioDNFD>(b => b.AigEstudioId)
            //       .IsRequired();

            //n - 1 relationships
            builder.HasOne(s => s.AigEstudioDNFD)
                   .WithMany(c => c.AigEstudios)
                   .HasForeignKey(s => s.AigEstudioDNFDId)
                   .IsRequired(false);

        }
        public void Configure(EntityTypeBuilder<AigEstudioEvaluador> builder)
        {

            builder.HasKey(p => new { p.Id });
            builder.ToTable("AigEstudioEvaluador");
            builder
                .Property(p => p.CreatedBy)
                .IsRequired()
                .HasColumnType("nvarchar(250)");
            builder
                .Property(p => p.LastModifiedBy)
                .HasColumnType("nvarchar(250)");
            builder.Property(p => p.Created).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModified).HasColumnType("datetime");
        }
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // m-m relationships
            builder.HasMany(c => c.EstudioEvaluador)
                   .WithOne().HasForeignKey(pls => pls.UserId)
                   .IsRequired();
        }
        public void Configure(EntityTypeBuilder<AigCodigoEstudio> builder)
        {
            builder.HasKey(k => new { k.Id });
            builder.Property(p => p.Codigo)
                   .IsRequired()
                   .HasColumnType("nvarchar(250)");

            builder.ToTable("AigCodigos");
        }
    }
}
