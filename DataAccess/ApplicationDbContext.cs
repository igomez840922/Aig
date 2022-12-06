﻿using DataModel;
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


            /////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            /// ////////////////////////////////////////////////
            ///

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

            modelBuilder.Entity<PersonalTrabajadorTB>()
          .HasMany(e => e.LRams)
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

            modelBuilder.Entity<InstitucionDestinoTB>()
           .HasMany(e => e.LNotas)
           .WithOne(e => e.InstitucionDestino)
           .HasForeignKey(e => e.InstitucionDestinoId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FMV_IpsTB>()
            .Property(e => e.IpsData)
            .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_IpsData>(x));

            modelBuilder.Entity<FMV_RamTB>()
           .HasMany(e => e.LNotificaciones)
           .WithOne(e => e.Ram)
           .HasForeignKey(e => e.RamId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FMV_EsaviTB>()
          .HasMany(e => e.LNotificaciones)
          .WithOne(e => e.Esavi)
          .HasForeignKey(e => e.EsaviId)
          .OnDelete(DeleteBehavior.Cascade);

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

            ///////////////////////////////
            ///
            //JSON Serialization
            modelBuilder.Entity<FMV_RamNotificacionTB>()
              .Property(e => e.EvaluacionCalidadInfo)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamEvaluacionCalidadInfo>(x));

            modelBuilder.Entity<FMV_RamNotificacionTB>()
              .Property(e => e.EvaluacionCausalidad)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamEvaluacionCausalidad>(x));

            modelBuilder.Entity<FMV_RamNotificacionTB>()
              .Property(e => e.ObservacionInfoNotifica)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => x == null ? null : JsonConvert.DeserializeObject<FMV_RamObservacionInfoNotifica>(x));

            modelBuilder.Entity<FMV_RamNotificacionTB>()
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
        public virtual DbSet<InstitucionDestinoTB> InstitucionDestino { get; set; }
        public virtual DbSet<LaboratorioTB> Laboratorio { get; set; }
        public virtual DbSet<TipoInstitucionTB> TipoInstitucion { get; set; }

    }
}
