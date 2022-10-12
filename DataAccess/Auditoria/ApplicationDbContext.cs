using DataModel;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Auditoria
{    
    //ApiAuthorizationDbContext IdentityDbContext
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(conString);
            //}

            //lazy loading
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(e => e.LPosSystems)
            //    .WithOne(e => e.User)
            //    .HasForeignKey(e => e.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasOne(s => s.UserProfile)
            //    .WithOne(ad => ad.AppUser);

            modelBuilder.Entity<AUD_InspeccionTB>()
                .HasOne(e => e.Establecimiento)
                .WithOne()
                .HasForeignKey<AUD_InspeccionTB>(e => e.EstablecimientoId);

            modelBuilder.Entity<AUD_InspeccionTB>()
               .HasOne(e => e.InspAperCambUbicFarm)
               .WithOne()
               .HasForeignKey<AUD_InspeccionTB>(e => e.InspAperCambUbicFarmId);

            modelBuilder.Entity<AUD_InspeccionTB>()
               .HasOne(e => e.InspRetiroRetencion)
               .WithOne()
               .HasForeignKey<AUD_InspeccionTB>(e => e.InspRetiroRetencionId);

            //JSON Serialization
            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
              .Property(e => e.DatosEstablecimiento)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x==null?null: JsonConvert.DeserializeObject<AUD_DatosEstablecimiento>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
              .Property(e => e.DatosEstablecimiento)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstablecimiento>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
             .Property(e => e.DatosSolicitante)
             .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosSolicitante>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            .Property(e => e.DatosRegente)
            .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegente>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            .Property(e => e.DatosEstructuraOrganizacional)
            .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstructuraOrganizacional>(x));


            base.OnModelCreating(modelBuilder);
        }
       
        public virtual DbSet<AttachmentTB> Attachment { get; set; }
        public virtual DbSet<AUD_EstablecimientoTB> AUD_Establecimiento { get; set; }
        public virtual DbSet<AUD_InspAperCambUbicFarmTB> AUD_InspAperCambUbicFarm { get; set; }
        public virtual DbSet<AUD_InspeccionTB> AUD_Inspeccion { get; set; }
        public virtual DbSet<AUD_InspRetiroRetencionTB> AUD_InspRetiroRetencion { get; set; }
        public virtual DbSet<AUD_ProdRetiroRetencionTB> AUD_ProdRetiroRetencion { get; set; }
        public virtual DbSet<AUD_TipoEstablecimientoTB> AUD_TipoEstablecimiento { get; set; }
        public virtual DbSet<CorregimientoTB> Corregimiento { get; set; }
        public virtual DbSet<DistritoTB> Distrito { get; set; }
        public virtual DbSet<PaisTB> Pais { get; set; }
        public virtual DbSet<ProvinciaTB> Provincia { get; set; }
        public virtual DbSet<UserProfileTB> UserProfile { get; set; }



    }
}
