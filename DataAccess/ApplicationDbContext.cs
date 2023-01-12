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


namespace DataAccess
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
               .WithOne(e => e.Inspeccion)
               .HasForeignKey<AUD_InspeccionTB>(e => e.InspAperCambUbicFarmId);

            modelBuilder.Entity<AUD_InspeccionTB>()
               .HasOne(e => e.InspRetiroRetencion)
               .WithOne(e=>e.Inspeccion)
               .HasForeignKey<AUD_InspeccionTB>(e => e.InspRetiroRetencionId);

            modelBuilder.Entity<AUD_InspeccionTB>()
              .HasOne(e => e.InspAperCambUbicAgen)
              .WithOne(e => e.Inspeccion)
              .HasForeignKey<AUD_InspeccionTB>(e => e.InspAperCambUbicAgenId);

            modelBuilder.Entity<AUD_InspeccionTB>()
              .HasOne(e => e.InspAperFabricante)
              .WithOne(e => e.Inspeccion)
              .HasForeignKey<AUD_InspeccionTB>(e => e.InspAperFabricanteId);

            modelBuilder.Entity<AUD_InspeccionTB>()
              .HasOne(e => e.InspRutinaVigFarmacia)
              .WithOne(e => e.Inspeccion)
              .HasForeignKey<AUD_InspeccionTB>(e => e.InspRutinaVigFarmaciaId);

            modelBuilder.Entity<AUD_InspeccionTB>()
             .HasOne(e => e.InspInvestigacion)
             .WithOne(e => e.Inspeccion)
             .HasForeignKey<AUD_InspeccionTB>(e => e.InspInvestigacionId);

            modelBuilder.Entity<AUD_InspeccionTB>()
            .HasOne(e => e.InspGuiBPMFabCosmeticoMed)
            .WithOne(e => e.Inspeccion)
            .HasForeignKey<AUD_InspeccionTB>(e => e.InspGuiBPMFabCosmeticoMedId);

            modelBuilder.Entity<AUD_InspeccionTB>()
           .HasOne(e => e.InspAperturaCosmetArtesanal)
           .WithOne(e => e.Inspeccion)
           .HasForeignKey<AUD_InspeccionTB>(e => e.InspAperturaCosmetArtesanalId);

            modelBuilder.Entity<AUD_InspeccionTB>()
          .HasOne(e => e.InspGuiBPMFabNatMedicina)
          .WithOne(e => e.Inspeccion)
          .HasForeignKey<AUD_InspeccionTB>(e => e.InspGuiBPMFabNatMedicinaId);

            modelBuilder.Entity<AUD_InspeccionTB>()
         .HasOne(e => e.InspRutinaVigAgencia)
         .WithOne(e => e.Inspeccion)
         .HasForeignKey<AUD_InspeccionTB>(e => e.InspRutinaVigAgenciaId);

            modelBuilder.Entity<AUD_InspeccionTB>()
        .HasOne(e => e.InspCierreOperacion)
        .WithOne(e => e.Inspeccion)
        .HasForeignKey<AUD_InspeccionTB>(e => e.InspCierreOperacionId);

            modelBuilder.Entity<AUD_InspeccionTB>()
       .HasOne(e => e.InspDisposicionFinal)
       .WithOne(e => e.Inspeccion)
       .HasForeignKey<AUD_InspeccionTB>(e => e.InspDisposicionFinalId);

            modelBuilder.Entity<AUD_InspeccionTB>()
    .HasOne(e => e.InspGuiaBPMFabricanteMed)
    .WithOne(e => e.Inspeccion)
    .HasForeignKey<AUD_InspeccionTB>(e => e.InspGuiaBPMFabricanteMedId);

            modelBuilder.Entity<AUD_InspeccionTB>()
   .HasOne(e => e.InspGuiaBPMLabAcondicionador)
   .WithOne(e => e.Inspeccion)
   .HasForeignKey<AUD_InspeccionTB>(e => e.InspGuiaBPMLabAcondicionadorId);

            modelBuilder.Entity<AUD_InspeccionTB>()
  .HasOne(e => e.InspGuiaBPM_Bpa)
  .WithOne(e => e.Inspeccion)
  .HasForeignKey<AUD_InspeccionTB>(e => e.InspGuiaBPM_BpaId);

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_EstablecimientoTB>()
                .HasMany(e => e.LInspections)
                .WithOne(e => e.Establecimiento)
                .HasForeignKey(e => e.EstablecimientoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AUD_InspeccionTB>()
                .HasMany(e => e.LAttachments)
                .WithOne(e => e.Inspeccion)
                .HasForeignKey(e => e.InspeccionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AUD_InspRetiroRetencionTB>()
                .HasMany(e => e.LProductos)
                .WithOne(e => e.FrmRetiroRetencion)
                .HasForeignKey(e => e.FrmRetiroRetencionId)
                .OnDelete(DeleteBehavior.Cascade);


            ///////////////////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
              .Property(e => e.DatosEstablecimiento)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x==null?null: JsonConvert.DeserializeObject<AUD_DatosEstablecimiento>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
             .Property(e => e.DatosSolicitante)
             .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosSolicitante>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            .Property(e => e.DatosRegente)
            .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegente>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            .Property(e => e.DatosEstructuraOrganizacional)
            .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstructuraOrganizacional>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
            .Property(e => e.DatosInfraEstructura)
            .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosInfraEstructura>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
           .Property(e => e.DatosAreaFisica)
           .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaFisicas>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
          .Property(e => e.DatosPreguntasGenericas)
          .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosPreguntasGenericas>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
          .Property(e => e.DatosSenalizacionAvisos)
          .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosSenalizacionAvisos>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
         .Property(e => e.DatosAreaProductosControlados)
         .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaProductosControlados>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
        .Property(e => e.DatosAreaAlmacenamiento)
        .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaAlmacenamiento>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
       .Property(e => e.DatosConclusiones)
       .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicFarmTB>()
    .Property(e => e.DatosAtendidosPor)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAtendidosPor>(x));


            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspRetiroRetencionTB>()
      .Property(e => e.DatosConclusiones)
      .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            modelBuilder.Entity<AUD_InspRetiroRetencionTB>()
     .Property(e => e.DatosRegente)
     .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegente>(x));

            modelBuilder.Entity<AUD_InspRetiroRetencionTB>()
     .Property(e => e.DatosRepresentLegal)
     .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRepresentLegal>(x));

            modelBuilder.Entity<AUD_InspRetiroRetencionTB>()
    .Property(e => e.DatosAtendidosPor)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAtendidosPor>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspAperCambUbicAgenTB>()
    .Property(e => e.DatosEstablecimiento)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstablecimiento>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicAgenTB>()
    .Property(e => e.DatosSolicitante)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosSolicitante>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicAgenTB>()
    .Property(e => e.DatosRegente)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegente>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicAgenTB>()
    .Property(e => e.DatosRepresentLegal)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRepresentLegal>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicAgenTB>()
    .Property(e => e.DatosCondicionesLocal)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosCondicionesLocal>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicAgenTB>()
     .Property(e => e.DatosConclusiones)
     .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicAgenTB>()
     .Property(e => e.DatosAtendidosPor)
     .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAtendidosPor>(x));

            modelBuilder.Entity<AUD_InspAperCambUbicAgenTB>()
    .Property(e => e.DatosActProd)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosActProd>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
     .Property(e => e.DatosEstablecimiento)
     .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstablecimiento>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
     .Property(e => e.DatosSolicitante)
     .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosSolicitante>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
     .Property(e => e.DatosRegente)
     .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegente>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosRepresentLegal)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRepresentLegal>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosProcedimientoPrograma)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosProcedimientoPrograma>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosAutoInspeccion)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAutoInspeccion>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosProdAnalisisContrato)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosProdAnalisisContrato>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosReclamoProductoRetirado)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosReclamoProductoRetirado>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosLocal)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosLocal>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosDocumentacion)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosDocumentacion>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosAreaInterna)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaInterna>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosAreaExterna)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaExterna>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosAreaAlmacenamiento)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaAlmacenamiento>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosAreaProduccion)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaProduccion>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosAreaAuxiliares)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaAuxiliares>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosEquipos)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEquipos>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosAreaDispensado)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaDispensado>(x));

            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosAreaLabCtrCalidad)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAreaLabCtrCalidad>(x));


            modelBuilder.Entity<AUD_InspAperFabricanteTB>()
    .Property(e => e.DatosConclusiones)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));


            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
    .Property(e => e.DatosGeneralesFarmacia)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosGeneralesFarmacia>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
    .Property(e => e.DatosRegente)
    .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegente>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
   .Property(e => e.DatosFarmaceutico)
   .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosFarmaceutico>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
   .Property(e => e.DatosRepresentLegal)
   .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRepresentLegal>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
 .Property(e => e.DatosPersonalTecnico)
 .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosPersonalTecnico>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
 .Property(e => e.DatosExpedienteColaborador)
 .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosExpedienteColaborador>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
 .Property(e => e.DatosEstructuraFarmacia)
 .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstructuraFarmacia>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
 .Property(e => e.DatosEquipoRegistroFarmacia)
 .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEquipoRegistroFarmacia>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
 .Property(e => e.DatosAnuncioFarmacia)
 .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAnuncioFarmacia>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
 .Property(e => e.DatosRegMovimientoExistenciaFarmacia)
 .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegMovimientoExistenciaFarmacia>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
 .Property(e => e.DatosAlmacenProductosFarmacia)
 .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAlmacenProductosFarmacia>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
.Property(e => e.DatosProcedimientoFarmacia)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosProcedimientoFarmacia>(x));

            modelBuilder.Entity<AUD_InspRutinaVigFarmaciaTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspInvestigacionTB>()
.Property(e => e.DatosEstablecimiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosEstablecimiento>(x));

            modelBuilder.Entity<AUD_InspInvestigacionTB>()
.Property(e => e.DatosAtendidosPor)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosAtendidosPor>(x));

            modelBuilder.Entity<AUD_InspInvestigacionTB>()
.Property(e => e.DatosRepresentLegal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRepresentLegal>(x));

            modelBuilder.Entity<AUD_InspInvestigacionTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AuditoriaSanitaria)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_AuditoriaSanitaria>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.RepresentLegal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));
            
            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.RegenteFarmaceutico)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.OtrosFuncionarios)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_OtrosFuncionarios>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.RespProduccion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.RespControlCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.RequisitosLegales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.ClasifActComerciales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.ClasifEstablecimiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.ClasifEstablecimiento2)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.GenEstructuraOrganizativa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.CondExtAlmacenas)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.CondIntAlmacenas)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));
           
            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AreaRecepMateriaPrima)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AlmacenMateriaPrima)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AlmacenMatAcondicionamineto)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.RecepProductoTerminado)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AlmacenProductoTerminado)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.ProductoDevueltoRechazado)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.DistProductoTerminado)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.ManejoQuejaReclamos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.RetiroProcMercado)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.SistemaInstAgua)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.OsmosisInversa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.SistemaDeIonizacion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.CalibraVerifEquipo)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.Validaciones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.MantAreaEquipos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AreaProdCondExternas)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AreaProdCondInternas)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AreaOrganizaDocumentacion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AreaDispensionOrdFab)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.FabProdDesinfectante)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.FabPlaguicida)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.FabCosmeticos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AreaEnvasado)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AreaEtiquetadoEmpaque)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.LabControlCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.AnalisisContrato)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.InspeccionAudito)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabCosmeticoMedTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspAperturaCosmetArtesanalTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspAperturaCosmetArtesanalTB>()
.Property(e => e.Propietario)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspAperturaCosmetArtesanalTB>()
.Property(e => e.Documentacion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspAperturaCosmetArtesanalTB>()
.Property(e => e.Locales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspAperturaCosmetArtesanalTB>()
.Property(e => e.AreaAlmacenamiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspAperturaCosmetArtesanalTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///
            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AuditoriaSanitaria)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_AuditoriaSanitaria>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.RepresentLegal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.RegenteFarmaceutico)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.OtrosFuncionarios)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_OtrosFuncionarios>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.InfoGeneral)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AuthFuncionamiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Organizacion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Personal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.ResponPersonal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Capacitacion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.HigieneSalud)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.UbicacionDisenoConstruc)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Almacenes)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AreaRecepLimpieza)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AreaSecadoMolienda)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AreaDispensadoMatPrima)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AreaProduccion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AreaEnvasadoEmpaque)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AreaAuxiliares)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AreaControlCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Generalidades8)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Calibracion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.SistemaAgua)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.SistemaAire)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Generalidades9)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.DispensadoMatPrima)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.MatAcondicionamiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.ProdAGranel)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.ProdTerminados)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.ProdRechazados)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.ProdDevueltos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Generalidades10)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.DocumentosExigido)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.ProcedimientoReg)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.ProdControlProceso)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Generalidades12)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.GarantiaCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Generalidades13)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Muestreo)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.MetodologiaAnalitica)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.MaterialesReferencia)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Estabilidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Generalidades14)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Retiros)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Generalidades15)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Contratante)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.Contratista)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiBPMFabNatMedicinaTB>()
.Property(e => e.AuditoriaCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.DatosRegente)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRegente>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.DatosRepresentLegal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosRepresentLegal>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.GenEstablecimiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.AreaRecepProductos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.AreaAlmacenamiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.AreaProdDevueltos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.AreaDespachoProductos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.AreaAlmCadenaFrio)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.AreaDesperdicio)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.AreaSustanciasControladas)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.Procedimientos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.Transporte)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.ActividadDistribucion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.InventarioMedicamento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_InventarioMedicamento>(x));

            modelBuilder.Entity<AUD_InspRutinaVigAgenciaTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspCierreOperacionTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspCierreOperacionTB>()
.Property(e => e.DatosResponsable)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspCierreOperacionTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///
            modelBuilder.Entity<AUD_InspDisposicionFinalTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspDisposicionFinalTB>()
.Property(e => e.DatosResponsable)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspDisposicionFinalTB>()
.Property(e => e.InventarioMedicamento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_InventarioMedicamento>(x));

            modelBuilder.Entity<AUD_InspDisposicionFinalTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.AuditoriaSanitaria)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_AuditoriaSanitaria>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.RepresentLegal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.RegenteFarmaceutico)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.OtrosFuncionarios)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_OtrosFuncionarios>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.RespProduccion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.RespControlCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.RequisitosLegales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.ClasifActComerciales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.ClasifEstablecimiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.OrganizacionPersonal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.EdifInstalaciones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.Almacenes)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.AreaDispMatPrima)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.AreaProduccion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.AreaAcondicionamiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.EquiposGeneralidades)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.Equipos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.MatProducts)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.Documentacion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.Produccion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.GarantiaCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.ControlCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));


            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.ProdAnalisisContrato)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.ValGenerales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.QuejasReclamos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.AutoInspecAuditCal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.FabProdFarmEsteril_A)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.FabProdFarmEsteril_Gen)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.FabProdFarmEsteril_A2)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.FabProdFarmEsteril_A3)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.Lactamicos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.ProdCitostatico)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMFabricanteMedTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.AuditoriaSanitaria)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_AuditoriaSanitaria>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.RepresentLegal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.RegenteFarmaceutico)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.OtrosFuncionarios)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_OtrosFuncionarios>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.RespProduccion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.RespControlCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.RequisitosLegales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.ClasifActComerciales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.ClasifEstablecimiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.OrganizacionPersonal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.EdifInstalaciones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.Almacenes)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.AreaAcondicionamiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.EquiposGeneralidades)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.MatProducts)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.Documentacion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.Acondicionamiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.GarantiaCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.ControlCalidad)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));


            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.ProdAnalisisContrato)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.ValGenerales)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.QuejasReclamos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.AutoInspecAuditCal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));           

            modelBuilder.Entity<AUD_InspGuiaBPMLabAcondicionadorTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));

            ///////////////////////////////////////////
            ///

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.GeneralesEmpresa)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_GeneralesEmpresa>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.RepresentLegal)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.RegenteFarmaceutico)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<DatosPersona>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.PropositoInsp)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_PropositosInspeccion>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.OtrosFuncionarios)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_OtrosFuncionarios>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.DispGenerlestablecimiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.AreasEstablecimiento)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.Distribucion)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.TransProdFarmaceuticos)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.AutoInspec)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ContenidoTablas>(x));

            modelBuilder.Entity<AUD_InspGuiaBPM_BpaTB>()
.Property(e => e.DatosConclusiones)
.HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AUD_DatosConclusiones>(x));


            /////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            /// ////////////////////////////////////////////////
            ///

            //numero de nota unico
            modelBuilder.Entity<FMV_NotaTB>()
        .HasIndex(e => e.NumNota).IsUnique();

            //Codigo CNFV
            modelBuilder.Entity<FMV_RamTB>()
        .HasIndex(e => e.CodigoCNFV).IsUnique();

            //ID Facedra
            modelBuilder.Entity<FMV_RamTB>()
        .HasIndex(e => e.IdFacedra).IsUnique();

            //Codigo Noti-Facedra
            modelBuilder.Entity<FMV_RamTB>()
        .HasIndex(e => e.CodigoNotiFacedra).IsUnique();

            //Codigo Externo
            modelBuilder.Entity<FMV_RamTB>()
        .HasIndex(e => e.CodExterno).IsUnique();

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

            modelBuilder.Entity<PersonalTrabajadorTB>()
              .HasMany(e => e.LIpsTramitador)
              .WithOne(e => e.Tramitador)
              .HasForeignKey(e => e.TramitadorId)
              .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<FMV_PmrTB>()
            //   .HasMany(e => e.LProductos)
            //   .WithOne(e => e.Pmr)
            //   .HasForeignKey(e => e.PmrId)
            //   .OnDelete(DeleteBehavior.Cascade);
                              
            modelBuilder.Entity<FMV_PmrTB>()
              .HasOne(e => e.PmrProducto)
              .WithOne(e => e.Pmr)
              .HasForeignKey<FMV_PmrTB>(e => e.PmrProductoId);

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

            modelBuilder.Entity<LaboratorioTB>()
             .HasMany(e => e.LFf)
             .WithOne(e => e.Fabricant)
             .HasForeignKey(e => e.FabricanteId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LaboratorioTB>()
             .HasMany(e => e.LFt)
             .WithOne(e => e.Fabricant)
             .HasForeignKey(e => e.FabricanteId)
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

            modelBuilder.Entity<PersonalTrabajadorTB>()
          .HasMany(e => e.LRams)
          .WithOne(e => e.Evaluador)
          .HasForeignKey(e => e.EvaluadorId)
          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
          .HasMany(e => e.LRams2)
          .WithOne(e => e.Evaluador)
          .HasForeignKey(e => e.EvaluadorId)
          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
         .HasMany(e => e.LFf)
         .WithOne(e => e.Evaluador)
         .HasForeignKey(e => e.EvaluadorId)
         .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
         .HasMany(e => e.LFt)
         .WithOne(e => e.Evaluador)
         .HasForeignKey(e => e.EvaluadorId)
         .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonalTrabajadorTB>()
        .HasMany(e => e.LEsavi)
        .WithOne(e => e.Evaluador)
        .HasForeignKey(e => e.EvaluadorId)
        .OnDelete(DeleteBehavior.NoAction);

           // modelBuilder.Entity<InstitucionDestinoTB>()
           //.HasMany(e => e.LNotas)
           //.WithOne(e => e.InstitucionDestino)
           //.HasForeignKey(e => e.InstitucionDestinoId)
           //.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FMV_IpsTB>()
            .Property(e => e.IpsData)
            .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_IpsData>(x));

           // modelBuilder.Entity<FMV_RamTB>()
           //.HasMany(e => e.LNotificaciones)
           //.WithOne(e => e.Ram)
           //.HasForeignKey(e => e.RamId)
           //.OnDelete(DeleteBehavior.Cascade);

          //  modelBuilder.Entity<FMV_EsaviTB>()
          //.HasMany(e => e.LNotificaciones)
          //.WithOne(e => e.Esavi)
          //.HasForeignKey(e => e.EsaviId)
          //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TipoInstitucionTB>()
         .HasMany(e => e.LInstituciones)
         .WithOne(e => e.TipoInstitucion)
         .HasForeignKey(e => e.TipoInstitucionId)
         .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProvinciaTB>()
          .HasMany(e => e.LInstitucion)
          .WithOne(e => e.Provincia)
          .HasForeignKey(e => e.ProvinciaId)
          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoInstitucionTB>()
       .HasMany(e => e.LEsavi)
       .WithOne(e => e.TipoInstitucion)
       .HasForeignKey(e => e.TipoInstitucionId)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProvinciaTB>()
        .HasMany(e => e.LEsavi)
        .WithOne(e => e.Provincia)
        .HasForeignKey(e => e.ProvinciaId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InstitucionDestinoTB>()
       .HasMany(e => e.LEsavi)
       .WithOne(e => e.InstitucionDestino)
       .HasForeignKey(e => e.InstitucionId)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoInstitucionTB>()
      .HasMany(e => e.LFf)
      .WithOne(e => e.TipoInstitucion)
      .HasForeignKey(e => e.TipoInstitucionId)
      .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProvinciaTB>()
        .HasMany(e => e.LFf)
        .WithOne(e => e.Provincia)
        .HasForeignKey(e => e.ProvinciaId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InstitucionDestinoTB>()
       .HasMany(e => e.LFf)
       .WithOne(e => e.InstitucionDestino)
       .HasForeignKey(e => e.InstitucionId)
       .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<TipoInstitucionTB>()
     .HasMany(e => e.LRam)
     .WithOne(e => e.TipoInstitucion)
     .HasForeignKey(e => e.TipoInstitucionId)
     .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProvinciaTB>()
        .HasMany(e => e.LRam)
        .WithOne(e => e.Provincia)
        .HasForeignKey(e => e.ProvinciaId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InstitucionDestinoTB>()
       .HasMany(e => e.LRam)
       .WithOne(e => e.InstitucionDestino)
       .HasForeignKey(e => e.InstitucionId)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<IntensidadEsaviTB>()
       .HasMany(e => e.LEsaviNotificacion)
       .WithOne(e => e.IntensidadEsavi)
       .HasForeignKey(e => e.IntensidadEsaviId)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoVacunaTB>()
      .HasMany(e => e.LEsaviNotificacion)
      .WithOne(e => e.TipoVacuna)
      .HasForeignKey(e => e.TipoVacunaId)
      .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LaboratorioTB>()
              .HasMany(e => e.LEsaviNotificacion)
              .WithOne(e => e.Laboratorio)
              .HasForeignKey(e => e.LaboratorioId)
              .OnDelete(DeleteBehavior.NoAction);

            ///////////////////////////////
            ///
            //JSON Serialization
            modelBuilder.Entity<FMV_RamTB>()
              .Property(e => e.EvaluacionCalidadInfo)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamEvaluacionCalidadInfo>(x));

            modelBuilder.Entity<FMV_RamTB>()
              .Property(e => e.EvaluacionCausalidad)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamEvaluacionCausalidad>(x));

            modelBuilder.Entity<FMV_RamTB>()
              .Property(e => e.ObservacionInfoNotifica)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamObservacionInfoNotifica>(x));

            modelBuilder.Entity<FMV_RamTB>()
              .Property(e => e.AccionesRegulatoria)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamAccionesRegulatoria>(x));

            ///////////////////////////////
            ///
            //JSON Serialization
            modelBuilder.Entity<FMV_FfTB>()
              .Property(e => e.FallaReportada)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_FfFallaReportada>(x));

            modelBuilder.Entity<FMV_FfTB>()
             .Property(e => e.OtrasEspecificaciones)
             .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_FfOtrasEspecificaciones>(x));

            ///////////////////////////////
            ///
            //JSON Serialization
            modelBuilder.Entity<FMV_FtTB>()
              .Property(e => e.OtrasEspecificaciones)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_FfOtrasEspecificaciones>(x));

            modelBuilder.Entity<FMV_FtTB>()
              .Property(e => e.DatosPaciente)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_FtDatosPaciente>(x));

            modelBuilder.Entity<FMV_FtTB>()
              .Property(e => e.EvaluacionCausalidad)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_FtEvaluacionCausalidad>(x));

            modelBuilder.Entity<FMV_FtTB>()
             .Property(e => e.Concominantes)
             .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamConcominantes>(x));

            ///////////////////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<FMV_AlertaTB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));
           
            ///////////////////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<FMV_NotaTB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));

            modelBuilder.Entity<FMV_NotaTB>()
             .Property(e => e.Instituciones)
             .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_NotaInstitucion>(x));

            modelBuilder.Entity<FMV_NotaTB>()
              .Property(e => e.NotaContactos)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_NotaContactos>(x));

            ///////////////////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<FMV_PmrTB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));

			///////////////////////////////////////////
			///

			//JSON Serialization
			modelBuilder.Entity<FMV_IpsTB>()
			  .Property(e => e.Adjunto)
			  .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));

            ///////////////////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<FMV_RfvTB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));

            ///////////////////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<FMV_FfTB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));

            ///////////////////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<FMV_FtTB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));

            ///////////////////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<FMV_NotaDestinoTB>()
              .Property(e => e.NotaClasificacion)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_NotaClasificacion>(x));

            //JSON Serialization
            modelBuilder.Entity<FMV_NotaDestinoTB>()
              .Property(e => e.NotaContactos)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_NotaContactos>(x));

            ///////////////////////////////
            ///

            //Codigo CNFV
            modelBuilder.Entity<FMV_Ram2TB>()
        .HasIndex(e => e.CodigoCNFV).IsUnique();

            //ID Facedra
            modelBuilder.Entity<FMV_Ram2TB>()
        .HasIndex(e => e.IdFacedra).IsUnique();

            //Codigo Noti-Facedra
            modelBuilder.Entity<FMV_Ram2TB>()
        .HasIndex(e => e.CodigoNotiFacedra).IsUnique();

            //Codigo Externo
            modelBuilder.Entity<FMV_Ram2TB>()
        .HasIndex(e => e.CodExterno).IsUnique();

            modelBuilder.Entity<FMV_Ram2TB>()
       .HasMany(e => e.LFarmacos)
       .WithOne(e => e.Ram)
       .HasForeignKey(e => e.RamId)
       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FMV_RamFarmacoTB>()
       .HasMany(e => e.LRams)
       .WithOne(e => e.Farmaco)
       .HasForeignKey(e => e.FarmacoId)
       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FMV_Ram2TB>()
             .Property(e => e.ObservacionInfoNotifica)
             .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamObservacionInfoNotifica>(x));

            modelBuilder.Entity<FMV_Ram2TB>()
              .Property(e => e.AccionesRegulatoria)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamAccionesRegulatoria>(x));

            modelBuilder.Entity<FMV_Ram2TB>()
             .Property(e => e.Concominantes)
             .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamConcominantes>(x));

            //JSON Serialization
            modelBuilder.Entity<FMV_Ram2TB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));
            
            //////
            ///
            modelBuilder.Entity<FMV_SocTB>()
      .HasMany(e => e.LTerMedras)
      .WithOne(e => e.Soc)
      .HasForeignKey(e => e.SocId)
      .OnDelete(DeleteBehavior.Cascade);

            ///////////////////////////////
            ///

            //JSON Serialization
            modelBuilder.Entity<FMV_EsaviTB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));

            ///////////////////////////////
            ///

            modelBuilder.Entity<FMV_Esavi2TB>()
      .HasMany(e => e.LVacunas)
      .WithOne(e => e.Esavi)
      .HasForeignKey(e => e.EsaviId)
      .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FMV_EsaviVacunaTB>()
     .HasMany(e => e.LEsavis)
     .WithOne(e => e.EsaviVacuna)
     .HasForeignKey(e => e.EsaviVacunaId)
     .OnDelete(DeleteBehavior.Cascade);
                       

            //JSON Serialization
            modelBuilder.Entity<FMV_Esavi2TB>()
             .Property(e => e.Concominantes)
             .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamConcominantes>(x));

            modelBuilder.Entity<FMV_Esavi2TB>()
              .Property(e => e.Adjunto)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<AttachmentData>(x));


            ///////////////////////////////
            ///

            base.OnModelCreating(modelBuilder);
        }
       
        public virtual DbSet<AttachmentTB> Attachment { get; set; }
        public virtual DbSet<ActividadEstablecimientoTB> ActividadEstablecimiento { get; set; }
        public virtual DbSet<AUD_EstablecimientoTB> AUD_Establecimiento { get; set; }
        public virtual DbSet<AUD_InspAperFabricanteTB> AUD_InspAperFabricante { get; set; }
        public virtual DbSet<AUD_InspAperCambUbicAgenTB> AUD_InspAperCambUbicAgen { get; set; }
        public virtual DbSet<AUD_InspAperCambUbicFarmTB> AUD_InspAperCambUbicFarm { get; set; }
        public virtual DbSet<AUD_InspeccionTB> AUD_Inspeccion { get; set; }
        public virtual DbSet<AUD_InspRetiroRetencionTB> AUD_InspRetiroRetencion { get; set; }
        public virtual DbSet<AUD_ProdRetiroRetencionTB> AUD_ProdRetiroRetencion { get; set; }
        public virtual DbSet<AUD_TipoEstablecimientoTB> AUD_TipoEstablecimiento { get; set; }
        public virtual DbSet<CorregimientoTB> Corregimiento { get; set; }
        public virtual DbSet<DistritoTB> Distrito { get; set; }
        public virtual DbSet<PaisTB> Pais { get; set; }
        public virtual DbSet<ProductoEstablecimientoTB> ProductoEstablecimiento { get; set; }
        public virtual DbSet<ProvinciaTB> Provincia { get; set; }
        public virtual DbSet<SmtpCorreoTB> SmtpCorreo { get; set; }
        public virtual DbSet<UserProfileTB> UserProfile { get; set; }
        public virtual DbSet<AUD_CorrespondenciaTB> AUD_Correspondencia { get; set; }


        /////////////////////////////////////////////////
        ///

        //public virtual DbSet<AttachmentTB> Attachment { get; set; }
        public virtual DbSet<PersonalTrabajadorTB> PersonalTrabajador { get; set; }
        public virtual DbSet<FMV_PmrProductoTB> FMV_PmrProducto { get; set; }
        public virtual DbSet<FMV_PmrTB> FMV_Pmr { get; set; }
        public virtual DbSet<FMV_RamNotificacionTB> FMV_RamNotificacion { get; set; }
        public virtual DbSet<FMV_RamTB> FMV_Ram { get; set; }
        public virtual DbSet<FMV_FtTB> FMV_Ft { get; set; }
        public virtual DbSet<FMV_FfTB> FMV_Ff { get; set; }
        public virtual DbSet<FMV_IpsTB> MV_Ips { get; set; }
        public virtual DbSet<FMV_RfvTB> FMV_Rfv { get; set; }
        public virtual DbSet<FMV_OrigenAlertaTB> FMV_OrigenAlerta { get; set; }
        public virtual DbSet<FMV_AlertaTB> FMV_Alerta { get; set; }
        public virtual DbSet<FMV_EsaviNotificacionTB> FMV_EsaviNotificacion { get; set; }
        public virtual DbSet<FMV_EsaviTB> FMV_Esavi { get; set; }
        public virtual DbSet<FMV_NotaTB> FMV_Nota { get; set; }
        public virtual DbSet<FMV_SocTB> FMV_Soc { get; set; }
        public virtual DbSet<FMV_NotaDestinoTB> FMV_NotaDestino { get; set; }
        public virtual DbSet<InstitucionDestinoTB> InstitucionDestino { get; set; }
        public virtual DbSet<LaboratorioTB> Laboratorio { get; set; }
        public virtual DbSet<TipoInstitucionTB> TipoInstitucion { get; set; }
        public virtual DbSet<IntensidadEsaviTB> IntensidadEsavi { get; set; }
        public virtual DbSet<TipoVacunaTB> TipoVacuna { get; set; }
        public virtual DbSet<FMV_ContactosTB> FMV_Contactos { get; set; }
        public virtual DbSet<FMV_Ram2TB> FMV_Ram2 { get; set; }
        public virtual DbSet<FMV_RamFarmacoTB> FMV_RamFarmaco { get; set; }
        public virtual DbSet<FMV_RamFarmacoRamTB> FMV_RamFarmacoRam { get; set; }
        public virtual DbSet<FMV_TerMedraTB> FMV_TerMedra { get; set; }
        public virtual DbSet<FMV_Esavi2TB> FMV_Esavi2 { get; set; }
        public virtual DbSet<FMV_EsaviVacunaTB> FMV_EsaviVacuna { get; set; }
        public virtual DbSet<FMV_EsaviVacunaEsaviTB> FMV_EsaviVacunaEsavi { get; set; }



    }
}
