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


namespace DataAccess.FarmacoVigilancia
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

            //modelBuilder.Entity<AUD_InspeccionTB>()
            //    .HasOne(e => e.Establecimiento)
            //    .WithOne()
            //    .HasForeignKey<AUD_InspeccionTB>(e => e.EstablecimientoId);

            //modelBuilder.Entity<AUD_InspRetiroRetencionTB>()
            //   .HasOne(e => e.Inspeccion)
            //   .WithOne()
            //   .HasForeignKey<AUD_InspRetiroRetencionTB>(e => e.EstablecimientoId);
                       
            ////JSON Serialization
            //modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            //  .Property(e => e.DatosEstablecimiento)
            //  .HasConversion(x => JsonConvert.SerializeObject(x), x => x==null?null: JsonConvert.DeserializeObject<AUD_DatosEstablecimiento>(x));

            //modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            //  .Property(e => e.DatosEstablecimiento)
            //  .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstablecimiento>(x));

            //modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            // .Property(e => e.DatosSolicitante)
            // .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosSolicitante>(x));

            //modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            //.Property(e => e.DatosRegente)
            //.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegente>(x));

            //modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            //.Property(e => e.DatosEstructuraOrganizacional)
            //.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstructuraOrganizacional>(x));

            modelBuilder.Entity<PersonalTrabajadorTB>()
                .HasMany(e => e.LPmr)
                .WithOne(e => e.Evaluador)
                .HasForeignKey(e => e.EvaluadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
               .HasMany(e => e.LIpsTramitador)
               .WithOne(e => e.Tramitador)
               .HasForeignKey(e => e.TramitadorId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
              .HasMany(e => e.LIpsRegistrador)
              .WithOne(e => e.Registrador)
              .HasForeignKey(e => e.RegistradorId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
              .HasMany(e => e.LIpsEvaluador)
              .WithOne(e => e.Evaluador)
              .HasForeignKey(e => e.EvaluadorId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FMV_PmrTB>()
               .HasMany(e => e.LProductos)
               .WithOne(e => e.Pmr)
               .HasForeignKey(e => e.PmrId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LaboratorioTB>()
              .HasMany(e => e.LProductos)
              .WithOne(e => e.Laboratorio)
              .HasForeignKey(e => e.LaboratorioId)
              .OnDelete(DeleteBehavior.NoAction);          

            modelBuilder.Entity<LaboratorioTB>()
              .HasMany(e => e.LIps)
              .WithOne(e => e.Laboratorio)
              .HasForeignKey(e => e.LaboratorioId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LaboratorioTB>()
             .HasMany(e => e.LRfv)
             .WithOne(e => e.Laboratorio)
             .HasForeignKey(e => e.LaboratorioId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FMV_OrigenAlertaTB>()
             .HasMany(e => e.LAlertas)
             .WithOne(e => e.OrigenAlerta)
             .HasForeignKey(e => e.OrigenAlertaId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
            .HasMany(e => e.LAlertas)
            .WithOne(e => e.Evaluador)
            .HasForeignKey(e => e.EvaluadorId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
           .HasMany(e => e.LNotas)
           .WithOne(e => e.Evaluador)
           .HasForeignKey(e => e.EvaluadorId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InstitucionDestinoTB>()
           .HasMany(e => e.LNotas)
           .WithOne(e => e.InstitucionDestino)
           .HasForeignKey(e => e.InstitucionDestinoId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FMV_IpsTB>()
            .Property(e => e.IpsData)
            .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_IpsData>(x));

            //modelBuilder.Entity<FMV_IpsTB>()
            //  .HasMany(e => e.LProducts)
            //  .WithOne(e => e.Ips)
            //  .HasForeignKey(e => e.IpsId)
            //  .OnDelete(DeleteBehavior.Cascade);                        

            base.OnModelCreating(modelBuilder);
        }
       
        public virtual DbSet<AttachmentTB> Attachment { get; set; }
        public virtual DbSet<PersonalTrabajadorTB> PersonalTrabajador { get; set; }
        public virtual DbSet<FMV_PmrTB> PmrTB { get; set; }
        public virtual DbSet<FMV_PmrProductoTB> Ram { get; set; }
        public virtual DbSet<FMV_IpsTB> Ips { get; set; }
        public virtual DbSet<FMV_RfvTB> Rfv { get; set; }
        public virtual DbSet<FMV_OrigenAlertaTB> OrigenAlerta { get; set; }
        public virtual DbSet<FMV_AlertaTB> Alerta { get; set; }
        public virtual DbSet<FMV_NotaTB> Nota { get; set; }
        public virtual DbSet<InstitucionDestinoTB> InstitucionDestino { get; set; }
        public virtual DbSet<LaboratorioTB> Laboratorio { get; set; }
        public virtual DbSet<CorregimientoTB> Corregimiento { get; set; }
        public virtual DbSet<DistritoTB> Distrito { get; set; }
        public virtual DbSet<PaisTB> Pais { get; set; }
        public virtual DbSet<ProvinciaTB> Provincia { get; set; }
        public virtual DbSet<SmtpCorreoTB> SmtpCorreo { get; set; }
        public virtual DbSet<UserProfileTB> UserProfile { get; set; }

    }
}
