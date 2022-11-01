using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class new_schemaContext : DbContext
    {
        public new_schemaContext()
        {
        }

        public new_schemaContext(DbContextOptions<new_schemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abogado> Abogados { get; set; } = null!;
        public virtual DbSet<AbogadoCo> AbogadoCos { get; set; } = null!;
        public virtual DbSet<Acondicionador> Acondicionadors { get; set; } = null!;
        public virtual DbSet<AcondicionadorCo> AcondicionadorCos { get; set; } = null!;
        public virtual DbSet<Adjunto> Adjuntos { get; set; } = null!;
        public virtual DbSet<AdjuntosCo> AdjuntosCos { get; set; } = null!;
        public virtual DbSet<AdjuntosComentario> AdjuntosComentarios { get; set; } = null!;
        public virtual DbSet<AdjuntosComentariosCo> AdjuntosComentariosCos { get; set; } = null!;
        public virtual DbSet<Agencia> Agencias { get; set; } = null!;
        public virtual DbSet<CatFormaCosmetica> CatFormaCosmeticas { get; set; } = null!;
        public virtual DbSet<ClasificacionCo> ClasificacionCos { get; set; } = null!;
        public virtual DbSet<CosmeticoDet> CosmeticoDets { get; set; } = null!;
        public virtual DbSet<CosmeticosEnc> CosmeticosEncs { get; set; } = null!;
        public virtual DbSet<Decreto> Decretos { get; set; } = null!;
        public virtual DbSet<Distribuidor> Distribuidors { get; set; } = null!;
        public virtual DbSet<DistribuidorCa> DistribuidorCas { get; set; } = null!;
        public virtual DbSet<DocumentoAclaratorio> DocumentoAclaratorios { get; set; } = null!;
        public virtual DbSet<DocumentoAclaratorioCo> DocumentoAclaratorioCos { get; set; } = null!;
        public virtual DbSet<EmpresaSolicitante> EmpresaSolicitantes { get; set; } = null!;
        public virtual DbSet<EmpresaSolicitanteCo> EmpresaSolicitanteCos { get; set; } = null!;
        public virtual DbSet<EncaSolicitud> EncaSolicituds { get; set; } = null!;
        public virtual DbSet<Etiqueta> Etiquetas { get; set; } = null!;
        public virtual DbSet<Excepcion> Excepcions { get; set; } = null!;
        public virtual DbSet<Fabricante> Fabricantes { get; set; } = null!;
        public virtual DbSet<FabricanteCo> FabricanteCos { get; set; } = null!;
        public virtual DbSet<Farmaceutico> Farmaceuticos { get; set; } = null!;
        public virtual DbSet<FarmaceuticoCo> FarmaceuticoCos { get; set; } = null!;
        public virtual DbSet<FormaFarmaceutica> FormaFarmaceuticas { get; set; } = null!;
        public virtual DbSet<Paise> Paises { get; set; } = null!;
        public virtual DbSet<Parametro> Parametros { get; set; } = null!;
        public virtual DbSet<ParametroCosmetico> ParametroCosmeticos { get; set; } = null!;
        public virtual DbSet<ParametroMedicamento> ParametroMedicamentos { get; set; } = null!;
        public virtual DbSet<Preregistro> Preregistros { get; set; } = null!;
        public virtual DbSet<PresentacionProducto> PresentacionProductos { get; set; } = null!;
        public virtual DbSet<PresentacionesCo> PresentacionesCos { get; set; } = null!;
        public virtual DbSet<PresentacionesComentariosCo> PresentacionesComentariosCos { get; set; } = null!;
        public virtual DbSet<Publicidad> Publicidads { get; set; } = null!;
        public virtual DbSet<RegistrosCo> RegistrosCos { get; set; } = null!;
        public virtual DbSet<Registrospublicidad> Registrospublicidads { get; set; } = null!;
        public virtual DbSet<Renovacioncambio> Renovacioncambios { get; set; } = null!;
        public virtual DbSet<Representante> Representantes { get; set; } = null!;
        public virtual DbSet<RepresentanteCo> RepresentanteCos { get; set; } = null!;
        public virtual DbSet<SeguimientoCo> SeguimientoCos { get; set; } = null!;
        public virtual DbSet<SeguimientoExcepcion> SeguimientoExcepcions { get; set; } = null!;
        public virtual DbSet<SeguimientoMedicamento> SeguimientoMedicamentos { get; set; } = null!;
        public virtual DbSet<SeguimientoPreregistro> SeguimientoPreregistros { get; set; } = null!;
        public virtual DbSet<SeguimientoPublicidad> SeguimientoPublicidads { get; set; } = null!;
        public virtual DbSet<Solicitud> Solicituds { get; set; } = null!;
        public virtual DbSet<TipoPagoCosmetico> TipoPagoCosmeticos { get; set; } = null!;
        public virtual DbSet<TipoPagoMedicamento> TipoPagoMedicamentos { get; set; } = null!;
        public virtual DbSet<Titular> Titulars { get; set; } = null!;
        public virtual DbSet<TitularCo> TitularCos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<ViaAdministracion> ViaAdministracions { get; set; } = null!;
        public virtual DbSet<ViaAdministracionCo> ViaAdministracionCos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=new_schema;user=root;password=Adm123+-*", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Abogado>(entity =>
            {
                entity.HasKey(e => e.CodigoAbogado)
                    .HasName("PRIMARY");

                entity.ToTable("abogado");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoAbogado).HasColumnName("codigo_abogado");

                entity.Property(e => e.AbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("abogado_sol");

                entity.Property(e => e.CedulaAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("cedula_abogado_sol");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("correo_abogado_sol");

                entity.Property(e => e.DireccionAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_abogado_sol");

                entity.Property(e => e.FirmaAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("firma_abogado_sol");

                entity.Property(e => e.IdoneidadAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("idoneidad_abogado_sol");

                entity.Property(e => e.TelefonoAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_abogado_sol");
            });

            modelBuilder.Entity<AbogadoCo>(entity =>
            {
                entity.HasKey(e => e.CodigoAbogado)
                    .HasName("PRIMARY");

                entity.ToTable("abogado_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoAbogado).HasColumnName("codigo_abogado");

                entity.Property(e => e.AbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("abogado_sol");

                entity.Property(e => e.CedulaAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("cedula_abogado_sol");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("correo_abogado_sol");

                entity.Property(e => e.DireccionAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_abogado_sol");

                entity.Property(e => e.FirmaAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("firma_abogado_sol");

                entity.Property(e => e.IdoneidadAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("idoneidad_abogado_sol");

                entity.Property(e => e.TelefonoAbogadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_abogado_sol");
            });

            modelBuilder.Entity<Acondicionador>(entity =>
            {
                entity.HasKey(e => e.CodigoAcondicionador)
                    .HasName("PRIMARY");

                entity.ToTable("acondicionador");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoAcondicionador).HasColumnName("codigo_acondicionador");

                entity.Property(e => e.AcondicionadorSol)
                    .HasMaxLength(600)
                    .HasColumnName("acondicionador_sol");

                entity.Property(e => e.CodigoPAcondicionador)
                    .HasMaxLength(600)
                    .HasColumnName("codigo_p_acondicionador");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoAcondicionador)
                    .HasMaxLength(600)
                    .HasColumnName("correo_acondicionador");

                entity.Property(e => e.DireccionAcondicionador)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_acondicionador");

                entity.Property(e => e.TipoacondicionadorSol)
                    .HasMaxLength(600)
                    .HasColumnName("tipoacondicionador_sol");
            });

            modelBuilder.Entity<AcondicionadorCo>(entity =>
            {
                entity.HasKey(e => e.CodigoAcondicionador)
                    .HasName("PRIMARY");

                entity.ToTable("acondicionador_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoAcondicionador).HasColumnName("codigo_acondicionador");

                entity.Property(e => e.AcondicionadorSol)
                    .HasMaxLength(600)
                    .HasColumnName("acondicionador_sol");

                entity.Property(e => e.CodigoPAcondicionador)
                    .HasMaxLength(600)
                    .HasColumnName("codigo_p_acondicionador");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoAcondicionador)
                    .HasMaxLength(600)
                    .HasColumnName("correo_acondicionador");

                entity.Property(e => e.DireccionAcondicionador)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_acondicionador");

                entity.Property(e => e.TipoacondicionadorSol)
                    .HasMaxLength(600)
                    .HasColumnName("tipoacondicionador_sol");
            });

            modelBuilder.Entity<Adjunto>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("adjuntos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.AclaratoriosSol)
                    .HasMaxLength(600)
                    .HasColumnName("aclaratorios_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.CertificadoAnalisisSol)
                    .HasMaxLength(600)
                    .HasColumnName("certificado_analisis_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.CertificadoManufacturaSol)
                    .HasMaxLength(600)
                    .HasColumnName("certificado_manufactura_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.CertificadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("certificado_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.CodigoSol)
                    .HasColumnName("codigo_sol")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Condiciones)
                    .HasMaxLength(600)
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.Controles)
                    .HasMaxLength(600)
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.DesechoSol)
                    .HasMaxLength(600)
                    .HasColumnName("desecho_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.EspecificacionesSol)
                    .HasMaxLength(600)
                    .HasColumnName("especificaciones_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.EstabilidadSol)
                    .HasMaxLength(600)
                    .HasColumnName("estabilidad_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.EtiquetasSol)
                    .HasMaxLength(600)
                    .HasColumnName("etiquetas_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.FormulaSol)
                    .HasMaxLength(600)
                    .HasColumnName("formula_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.LoteSol)
                    .HasMaxLength(600)
                    .HasColumnName("lote_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.ManejoRiesgo)
                    .HasMaxLength(600)
                    .HasColumnName("manejoRiesgo")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.MetodoAnalisisSol)
                    .HasMaxLength(600)
                    .HasColumnName("metodo_analisis_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.MetodoManufacturaSol)
                    .HasMaxLength(600)
                    .HasColumnName("metodo_manufactura_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.MonografiaSol)
                    .HasMaxLength(600)
                    .HasColumnName("monografia_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.MuestraSol)
                    .HasMaxLength(600)
                    .HasColumnName("muestra_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.PatronesSol)
                    .HasMaxLength(600)
                    .HasColumnName("patrones_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.PoderSol)
                    .HasMaxLength(600)
                    .HasColumnName("poder_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.ProductoTerminado)
                    .HasMaxLength(600)
                    .HasColumnName("productoTerminado")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.ReciboMefSol)
                    .HasMaxLength(600)
                    .HasColumnName("reciboMEF_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.ReciboSol)
                    .HasMaxLength(600)
                    .HasColumnName("recibo_sol")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.TasaservicioSol)
                    .HasMaxLength(600)
                    .HasColumnName("tasaservicio_sol")
                    .HasDefaultValueSql("'--'");
            });

            modelBuilder.Entity<AdjuntosCo>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("adjuntos_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.AclaratoriosSol)
                    .HasMaxLength(600)
                    .HasColumnName("aclaratorios_sol");

                entity.Property(e => e.CertificadoLibreSol)
                    .HasMaxLength(600)
                    .HasColumnName("certificado_libre_sol");

                entity.Property(e => e.CertificadoManufacturaSol)
                    .HasMaxLength(600)
                    .HasColumnName("certificado_manufactura_sol");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.DocAvalSol)
                    .HasMaxLength(600)
                    .HasColumnName("doc_aval_sol");

                entity.Property(e => e.FormulaCualiSol)
                    .HasMaxLength(600)
                    .HasColumnName("formula_cuali_sol");

                entity.Property(e => e.FotoMuestraSol)
                    .HasMaxLength(600)
                    .HasColumnName("foto_muestra_sol");

                entity.Property(e => e.PoderSol)
                    .HasMaxLength(600)
                    .HasColumnName("poder_sol");

                entity.Property(e => e.PresentacionSol)
                    .HasMaxLength(600)
                    .HasColumnName("presentacion_sol");

                entity.Property(e => e.ProductoTerminadoSol)
                    .HasMaxLength(600)
                    .HasColumnName("producto_terminado_sol");

                entity.Property(e => e.ReciboSol)
                    .HasMaxLength(600)
                    .HasColumnName("recibo_sol");

                entity.Property(e => e.ReciboTasaSol)
                    .HasMaxLength(600)
                    .HasColumnName("recibo_tasa_sol");
            });

            modelBuilder.Entity<AdjuntosComentario>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("adjuntos_comentarios");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.Adjunto)
                    .HasMaxLength(1500)
                    .HasColumnName("adjunto");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Comentario)
                    .HasColumnType("text")
                    .HasColumnName("comentario");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");
            });

            modelBuilder.Entity<AdjuntosComentariosCo>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("adjuntos_comentarios_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.Adjunto)
                    .HasMaxLength(1500)
                    .HasColumnName("adjunto");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Comentario)
                    .HasColumnType("text")
                    .HasColumnName("comentario");

                entity.Property(e => e.Documento)
                    .HasMaxLength(500)
                    .HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");
            });

            modelBuilder.Entity<Agencia>(entity =>
            {
                entity.HasKey(e => e.CodigoAg)
                    .HasName("PRIMARY");

                entity.ToTable("agencias");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoAg).HasColumnName("codigo_ag");

                entity.Property(e => e.ActividadAg)
                    .HasMaxLength(300)
                    .HasColumnName("actividad_ag")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.EstablecimientoAg)
                    .HasMaxLength(300)
                    .HasColumnName("establecimiento_ag")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.FarmaceuticoAg)
                    .HasMaxLength(300)
                    .HasColumnName("farmaceutico_ag")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.LicenciaAg)
                    .HasMaxLength(45)
                    .HasColumnName("licencia_ag")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.RegistroFarmaceuticoAg)
                    .HasMaxLength(45)
                    .HasColumnName("registroFarmaceutico_ag")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.UbicacionAg)
                    .HasMaxLength(600)
                    .HasColumnName("ubicacion_ag")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.VigenciaDesdeAg)
                    .HasColumnType("datetime")
                    .HasColumnName("vigenciaDesde_ag");

                entity.Property(e => e.VigenciaHastaAg)
                    .HasColumnType("datetime")
                    .HasColumnName("vigenciaHasta_ag");
            });

            modelBuilder.Entity<CatFormaCosmetica>(entity =>
            {
                entity.HasKey(e => e.IdFc)
                    .HasName("PRIMARY");

                entity.ToTable("cat_forma_cosmetica");

                entity.Property(e => e.IdFc).HasColumnName("id_fc");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<ClasificacionCo>(entity =>
            {
                entity.HasKey(e => e.IdVa)
                    .HasName("PRIMARY");

                entity.ToTable("clasificacion_cos");

                entity.Property(e => e.IdVa).HasColumnName("id_va");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<CosmeticoDet>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("cosmetico_det");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CosmeticoCod)
                    .HasMaxLength(600)
                    .HasColumnName("cosmetico_cod");
            });

            modelBuilder.Entity<CosmeticosEnc>(entity =>
            {
                entity.HasKey(e => e.CodRc)
                    .HasName("PRIMARY");

                entity.ToTable("cosmeticos_enc");

                entity.Property(e => e.CodRc).HasColumnName("cod_rc");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.CodigoUEvaluador)
                    .HasColumnName("codigo_u_evaluador")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(600)
                    .HasColumnName("comentario");

                entity.Property(e => e.ComentarioInterno)
                    .HasMaxLength(600)
                    .HasColumnName("comentario_interno");

                entity.Property(e => e.DescEnvase)
                    .HasMaxLength(600)
                    .HasColumnName("desc_envase");

                entity.Property(e => e.Estado)
                    .HasMaxLength(5)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaExpedicionIn).HasColumnName("fechaExpedicion_in");

                entity.Property(e => e.FechaSolicitud).HasColumnName("fecha_solicitud");

                entity.Property(e => e.FolioIn)
                    .HasMaxLength(45)
                    .HasColumnName("folio_in");

                entity.Property(e => e.IdClasificacion)
                    .HasMaxLength(200)
                    .HasColumnName("id_clasificacion");

                entity.Property(e => e.IdViaAdmin)
                    .HasMaxLength(200)
                    .HasColumnName("id_via_admin");

                entity.Property(e => e.LibroIn)
                    .HasMaxLength(45)
                    .HasColumnName("libro_in");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(600)
                    .HasColumnName("nombre_producto");

                entity.Property(e => e.NumeroRegistroIn)
                    .HasMaxLength(100)
                    .HasColumnName("numero_registro_in");

                entity.Property(e => e.NumeroRegistroLetrasIn)
                    .HasMaxLength(2000)
                    .HasColumnName("numero_registro_letras_in");

                entity.Property(e => e.NumeroRenovacion)
                    .HasMaxLength(45)
                    .HasColumnName("numero_renovacion");

                entity.Property(e => e.NumeroSolicitud)
                    .HasMaxLength(45)
                    .HasColumnName("numero_solicitud");

                entity.Property(e => e.RegistroLetraIn)
                    .HasMaxLength(100)
                    .HasColumnName("registroLetra_in");

                entity.Property(e => e.RegistroNumeroIn)
                    .HasMaxLength(100)
                    .HasColumnName("registroNumero_in");

                entity.Property(e => e.TipoPagoSol)
                    .HasColumnName("tipo_pago_sol")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TipoSolicitud)
                    .HasMaxLength(2)
                    .HasColumnName("tipo_solicitud");

                entity.Property(e => e.Variante)
                    .HasMaxLength(600)
                    .HasColumnName("variante");

                entity.Property(e => e.VigenciaIn).HasColumnName("vigencia_in");
            });

            modelBuilder.Entity<Decreto>(entity =>
            {
                entity.HasKey(e => e.CodigoDe)
                    .HasName("PRIMARY");

                entity.ToTable("decreto");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoDe).HasColumnName("codigo_de");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.NombreDe)
                    .HasMaxLength(1500)
                    .HasColumnName("nombre_de");

                entity.Property(e => e.TextoDe)
                    .HasColumnType("text")
                    .HasColumnName("texto_de");
            });

            modelBuilder.Entity<Distribuidor>(entity =>
            {
                entity.HasKey(e => e.CodigoDistribuidor)
                    .HasName("PRIMARY");

                entity.ToTable("distribuidor");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoDistribuidor).HasColumnName("codigo_distribuidor");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.CorreoDistribuidor)
                    .HasMaxLength(600)
                    .HasColumnName("correo_distribuidor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.LicenciaDistribuidor)
                    .HasMaxLength(600)
                    .HasColumnName("licencia_distribuidor");

                entity.Property(e => e.NombreDistribuidor)
                    .HasMaxLength(600)
                    .HasColumnName("nombre_distribuidor");

                entity.Property(e => e.TelefonoDistribuidor)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_distribuidor");
            });

            modelBuilder.Entity<DistribuidorCa>(entity =>
            {
                entity.HasKey(e => e.CodigoDistribuidor)
                    .HasName("PRIMARY");

                entity.ToTable("distribuidor_cas");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoDistribuidor).HasColumnName("codigo_distribuidor");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.CorreoDistribuidor)
                    .HasMaxLength(600)
                    .HasColumnName("correo_distribuidor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.LicenciaDistribuidor)
                    .HasMaxLength(600)
                    .HasColumnName("licencia_distribuidor");

                entity.Property(e => e.NombreDistribuidor)
                    .HasMaxLength(600)
                    .HasColumnName("nombre_distribuidor");

                entity.Property(e => e.TelefonoDistribuidor)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_distribuidor");
            });

            modelBuilder.Entity<DocumentoAclaratorio>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("documento_aclaratorio");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(2000)
                    .HasColumnName("archivo");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Documento)
                    .HasMaxLength(1500)
                    .HasColumnName("documento");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(500)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<DocumentoAclaratorioCo>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("documento_aclaratorio_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(2000)
                    .HasColumnName("archivo");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Documento)
                    .HasMaxLength(1500)
                    .HasColumnName("documento");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(500)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<EmpresaSolicitante>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpresaSolicitante)
                    .HasName("PRIMARY");

                entity.ToTable("empresa_solicitante");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoEmpresaSolicitante).HasColumnName("codigo_empresa_solicitante");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoEmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("correo_empresa_sol");

                entity.Property(e => e.DireccionEmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_empresa_sol");

                entity.Property(e => e.EmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("empresa_sol");

                entity.Property(e => e.RucEmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("ruc_empresa_sol");

                entity.Property(e => e.TelefonoEmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_empresa_sol");
            });

            modelBuilder.Entity<EmpresaSolicitanteCo>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpresaSolicitante)
                    .HasName("PRIMARY");

                entity.ToTable("empresa_solicitante_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoEmpresaSolicitante).HasColumnName("codigo_empresa_solicitante");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoEmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("correo_empresa_sol");

                entity.Property(e => e.DireccionEmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_empresa_sol");

                entity.Property(e => e.EmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("empresa_sol");

                entity.Property(e => e.RucEmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("ruc_empresa_sol");

                entity.Property(e => e.TelefonoEmpresaSol)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_empresa_sol");
            });

            modelBuilder.Entity<EncaSolicitud>(entity =>
            {
                entity.HasKey(e => e.CodigoSol)
                    .HasName("PRIMARY");

                entity.ToTable("enca_solicitud");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.AdvertenciasSol)
                    .HasColumnType("text")
                    .HasColumnName("advertencias_sol");

                entity.Property(e => e.AprobadoSol)
                    .HasMaxLength(300)
                    .HasColumnName("aprobado_sol");

                entity.Property(e => e.ArchivoFirmado).HasMaxLength(800);

                entity.Property(e => e.CodigoAtcSol)
                    .HasMaxLength(1000)
                    .HasColumnName("codigoATC_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.CodigoUEvaluador)
                    .HasColumnName("codigo_u_evaluador")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ComposicionSol)
                    .HasColumnType("text")
                    .HasColumnName("composicion_sol");

                entity.Property(e => e.ConcentracionSol)
                    .HasColumnType("text")
                    .HasColumnName("concentracion_sol");

                entity.Property(e => e.Condicion)
                    .HasColumnType("text")
                    .HasColumnName("condicion");

                entity.Property(e => e.CondicionventaSol)
                    .HasColumnType("text")
                    .HasColumnName("condicionventa_sol");

                entity.Property(e => e.ConducirSol)
                    .HasColumnType("text")
                    .HasColumnName("conducir_sol");

                entity.Property(e => e.ContraindicacionesSol)
                    .HasColumnType("text")
                    .HasColumnName("contraindicaciones_sol");

                entity.Property(e => e.DatosProtegidos)
                    .HasMaxLength(5)
                    .HasColumnName("datosProtegidos")
                    .HasDefaultValueSql("'NO'");

                entity.Property(e => e.DescripcionEnvaseSol)
                    .HasColumnType("text")
                    .HasColumnName("Descripcion_envase_sol");

                entity.Property(e => e.DocumentoFirmadoResponsable)
                    .HasMaxLength(1200)
                    .HasColumnName("documentoFirmadoResponsable");

                entity.Property(e => e.ElaboradoSol)
                    .HasMaxLength(300)
                    .HasColumnName("elaborado_sol");

                entity.Property(e => e.EmbarazoSol)
                    .HasColumnType("text")
                    .HasColumnName("embarazo_sol");

                entity.Property(e => e.EnvaseSol)
                    .HasColumnType("text")
                    .HasColumnName("envase_sol");

                entity.Property(e => e.Estado)
                    .HasMaxLength(4)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'PC'");

                entity.Property(e => e.ExcipientesSol)
                    .HasColumnType("text")
                    .HasColumnName("excipientes_sol");

                entity.Property(e => e.FabricanteproductoSol)
                    .HasColumnType("text")
                    .HasColumnName("fabricanteproducto_sol");

                entity.Property(e => e.FechaExpedicionIn).HasColumnName("fechaExpedicion_in");

                entity.Property(e => e.FechaSol).HasColumnName("fecha_sol");

                entity.Property(e => e.FolioIn)
                    .HasMaxLength(45)
                    .HasColumnName("folio_in");

                entity.Property(e => e.FormaSol)
                    .HasColumnType("text")
                    .HasColumnName("forma_sol");

                entity.Property(e => e.FormafarmaceuticaSol)
                    .HasColumnType("text")
                    .HasColumnName("formafarmaceutica_sol");

                entity.Property(e => e.IncompatiblesSol)
                    .HasColumnType("text")
                    .HasColumnName("incompatibles_sol");

                entity.Property(e => e.IndicacionesSol)
                    .HasColumnType("text")
                    .HasColumnName("indicaciones_sol");

                entity.Property(e => e.InteraccionesSol)
                    .HasColumnType("text")
                    .HasColumnName("interacciones_sol");

                entity.Property(e => e.LibroIn)
                    .HasMaxLength(45)
                    .HasColumnName("libro_in");

                entity.Property(e => e.MedicamentoSol)
                    .HasColumnType("text")
                    .HasColumnName("medicamento_sol");

                entity.Property(e => e.NumeroRegistroIn)
                    .HasMaxLength(100)
                    .HasColumnName("numero_registro_in");

                entity.Property(e => e.NumeroRegistroLetrasIn)
                    .HasMaxLength(2000)
                    .HasColumnName("numero_registro_letras_in");

                entity.Property(e => e.NumeroSol)
                    .HasMaxLength(45)
                    .HasColumnName("numero_sol");

                entity.Property(e => e.PosologiaSol)
                    .HasColumnType("text")
                    .HasColumnName("posologia_sol");

                entity.Property(e => e.PrecaucionesSol)
                    .HasColumnType("text")
                    .HasColumnName("precauciones_sol");

                entity.Property(e => e.PreclinicosSol)
                    .HasColumnType("text")
                    .HasColumnName("preclinicos_sol");

                entity.Property(e => e.PreparaciónSol)
                    .HasColumnType("text")
                    .HasColumnName("preparación_sol");

                entity.Property(e => e.PrincipioSol)
                    .HasColumnType("text")
                    .HasColumnName("principio_sol");

                entity.Property(e => e.ProductoSol)
                    .HasMaxLength(600)
                    .HasColumnName("producto_sol");

                entity.Property(e => e.PropiedadesFarmacoSol)
                    .HasColumnType("text")
                    .HasColumnName("propiedades_farmaco_sol");

                entity.Property(e => e.PropiedadesSol)
                    .HasColumnType("text")
                    .HasColumnName("propiedades_sol");

                entity.Property(e => e.QuimicoSol)
                    .HasColumnType("text")
                    .HasColumnName("quimico_sol");

                entity.Property(e => e.ReaccionesSol)
                    .HasColumnType("text")
                    .HasColumnName("reacciones_sol");

                entity.Property(e => e.RefereciasSol)
                    .HasColumnType("text")
                    .HasColumnName("referecias_sol");

                entity.Property(e => e.RegistroLetraIn)
                    .HasMaxLength(45)
                    .HasColumnName("registroLetra_in")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.RegistroNumeroIn)
                    .HasMaxLength(45)
                    .HasColumnName("registroNumero_in")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.RegistroRenovacion)
                    .HasMaxLength(100)
                    .HasColumnName("registroRenovacion");

                entity.Property(e => e.SobredosificacionSol)
                    .HasColumnType("text")
                    .HasColumnName("sobredosificacion_sol");

                entity.Property(e => e.TextoDosis)
                    .HasMaxLength(4000)
                    .HasColumnName("textoDosis")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.TipoMedicamentoSol)
                    .HasMaxLength(2)
                    .HasColumnName("tipo_medicamento_sol");

                entity.Property(e => e.TipoPagoSol)
                    .HasColumnName("tipo_pago_sol")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TipoRegistroSol)
                    .HasMaxLength(2)
                    .HasColumnName("tipo_registro_sol");

                entity.Property(e => e.TipoSol)
                    .HasMaxLength(2)
                    .HasColumnName("tipo_sol");

                entity.Property(e => e.ValidezSol)
                    .HasColumnType("text")
                    .HasColumnName("validez_sol");

                entity.Property(e => e.VersionDocumento)
                    .HasMaxLength(400)
                    .HasColumnName("versionDocumento");

                entity.Property(e => e.VersiondocumentoSol)
                    .HasMaxLength(600)
                    .HasColumnName("versiondocumento_sol");

                entity.Property(e => e.ViaSol)
                    .HasColumnType("text")
                    .HasColumnName("via_sol");

                entity.Property(e => e.VidaUtil)
                    .HasMaxLength(500)
                    .HasColumnName("vidaUtil");

                entity.Property(e => e.VigenciaIn).HasColumnName("vigencia_in");
            });

            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("etiquetas");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(600)
                    .HasColumnName("archivo");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.EtiquetaSol)
                    .HasMaxLength(600)
                    .HasColumnName("etiqueta_sol");

                entity.Property(e => e.PresentacionesSol)
                    .HasMaxLength(600)
                    .HasColumnName("presentaciones_sol");
            });

            modelBuilder.Entity<Excepcion>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("excepcion");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.Acondicionador)
                    .HasMaxLength(300)
                    .HasColumnName("acondicionador");

                entity.Property(e => e.Analisis)
                    .HasMaxLength(300)
                    .HasColumnName("analisis");

                entity.Property(e => e.ArchivoFirmado).HasMaxLength(800);

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(45)
                    .HasColumnName("cantidad");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(300)
                    .HasColumnName("cedula");

                entity.Property(e => e.Certificado)
                    .HasMaxLength(300)
                    .HasColumnName("certificado");

                entity.Property(e => e.CodigoPAcondicionador).HasColumnName("codigo_p_acondicionador");

                entity.Property(e => e.CodigoPLaboratorio).HasColumnName("codigo_p_laboratorio");

                entity.Property(e => e.CodigoPTitular).HasColumnName("codigo_p_titular");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(300)
                    .HasColumnName("contacto");

                entity.Property(e => e.Correo)
                    .HasMaxLength(300)
                    .HasColumnName("correo");

                entity.Property(e => e.Declaracion)
                    .HasMaxLength(300)
                    .HasColumnName("declaracion");

                entity.Property(e => e.DetalleCantidad)
                    .HasMaxLength(500)
                    .HasColumnName("detalleCantidad");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaExpiracion)
                    .HasMaxLength(1000)
                    .HasColumnName("fechaExpiracion");

                entity.Property(e => e.Forma)
                    .HasMaxLength(300)
                    .HasColumnName("forma");

                entity.Property(e => e.Laboratorio)
                    .HasMaxLength(300)
                    .HasColumnName("laboratorio");

                entity.Property(e => e.Lote)
                    .HasMaxLength(45)
                    .HasColumnName("lote");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(600)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NombreDistribuidora)
                    .HasMaxLength(1500)
                    .HasColumnName("nombreDistribuidora")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.NombrePaciente)
                    .HasMaxLength(1500)
                    .HasColumnName("nombrePaciente")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.NombreTramita)
                    .HasMaxLength(300)
                    .HasColumnName("nombreTramita");

                entity.Property(e => e.Nota)
                    .HasMaxLength(300)
                    .HasColumnName("nota");

                entity.Property(e => e.NumeroSolicitud)
                    .HasMaxLength(45)
                    .HasColumnName("numeroSolicitud");

                entity.Property(e => e.OtrosDocumentos)
                    .HasMaxLength(300)
                    .HasColumnName("otrosDocumentos");

                entity.Property(e => e.Presentacion)
                    .HasMaxLength(300)
                    .HasColumnName("presentacion");

                entity.Property(e => e.Principio)
                    .HasMaxLength(300)
                    .HasColumnName("principio");

                entity.Property(e => e.Producto)
                    .HasMaxLength(300)
                    .HasColumnName("producto");

                entity.Property(e => e.Receta)
                    .HasMaxLength(300)
                    .HasColumnName("receta");

                entity.Property(e => e.Registro)
                    .HasMaxLength(300)
                    .HasColumnName("registro");

                entity.Property(e => e.Tasa)
                    .HasMaxLength(300)
                    .HasColumnName("tasa");

                entity.Property(e => e.TipoExcepcion)
                    .HasMaxLength(200)
                    .HasColumnName("tipoExcepcion");

                entity.Property(e => e.TipoTramite)
                    .HasMaxLength(200)
                    .HasColumnName("tipoTramite");

                entity.Property(e => e.Titular)
                    .HasMaxLength(300)
                    .HasColumnName("titular");
            });

            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.HasKey(e => e.CodigoFabricante)
                    .HasName("PRIMARY");

                entity.ToTable("fabricante");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoFabricante).HasColumnName("codigo_fabricante");

                entity.Property(e => e.CodigoPFabricante)
                    .HasMaxLength(600)
                    .HasColumnName("codigo_p_fabricante");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoFabricante)
                    .HasMaxLength(600)
                    .HasColumnName("correo_fabricante");

                entity.Property(e => e.DireccionFabricante)
                    .HasMaxLength(5000)
                    .HasColumnName("direccion_fabricante");

                entity.Property(e => e.FabricanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("fabricante_sol");
            });

            modelBuilder.Entity<FabricanteCo>(entity =>
            {
                entity.HasKey(e => e.CodigoFabricante)
                    .HasName("PRIMARY");

                entity.ToTable("fabricante_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoFabricante).HasColumnName("codigo_fabricante");

                entity.Property(e => e.CodigoPFabricante)
                    .HasMaxLength(600)
                    .HasColumnName("codigo_p_fabricante");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoFabricante)
                    .HasMaxLength(600)
                    .HasColumnName("correo_fabricante");

                entity.Property(e => e.DireccionFabricante)
                    .HasMaxLength(5000)
                    .HasColumnName("direccion_fabricante");

                entity.Property(e => e.EsAcondicionador).HasMaxLength(45);

                entity.Property(e => e.EsTitular).HasMaxLength(45);

                entity.Property(e => e.FabricanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("fabricante_sol");
            });

            modelBuilder.Entity<Farmaceutico>(entity =>
            {
                entity.HasKey(e => e.CodigoFarmaceutico)
                    .HasName("PRIMARY");

                entity.ToTable("farmaceutico");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoFarmaceutico).HasColumnName("codigo_farmaceutico");

                entity.Property(e => e.CedulaFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("cedula_farmaceutico_sol");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("correo_farmaceutico_sol");

                entity.Property(e => e.DireccionFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_farmaceutico_sol");

                entity.Property(e => e.FarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("farmaceutico_sol");

                entity.Property(e => e.FirmaFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("firma_farmaceutico_sol");

                entity.Property(e => e.IdoneidadFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("idoneidad_farmaceutico_sol");

                entity.Property(e => e.RefrendoFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("refrendo_farmaceutico_sol");

                entity.Property(e => e.TelefonoFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_farmaceutico_sol");
            });

            modelBuilder.Entity<FarmaceuticoCo>(entity =>
            {
                entity.HasKey(e => e.CodigoFarmaceutico)
                    .HasName("PRIMARY");

                entity.ToTable("farmaceutico_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoFarmaceutico).HasColumnName("codigo_farmaceutico");

                entity.Property(e => e.CedulaFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("cedula_farmaceutico_sol");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("correo_farmaceutico_sol");

                entity.Property(e => e.DireccionFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_farmaceutico_sol");

                entity.Property(e => e.FarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("farmaceutico_sol");

                entity.Property(e => e.FirmaFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("firma_farmaceutico_sol");

                entity.Property(e => e.IdoneidadFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("idoneidad_farmaceutico_sol");

                entity.Property(e => e.RefrendoFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("refrendo_farmaceutico_sol");

                entity.Property(e => e.TelefonoFarmaceuticoSol)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_farmaceutico_sol");
            });

            modelBuilder.Entity<FormaFarmaceutica>(entity =>
            {
                entity.HasKey(e => e.CodigoFf)
                    .HasName("PRIMARY");

                entity.ToTable("forma_farmaceutica");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoFf).HasColumnName("codigo_ff");

                entity.Property(e => e.EstadoFf)
                    .HasMaxLength(5)
                    .HasColumnName("estado_ff")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.NombreFf)
                    .HasMaxLength(500)
                    .HasColumnName("nombre_ff");
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.HasKey(e => e.CodigoPais)
                    .HasName("PRIMARY");

                entity.ToTable("paises");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CodigoPais).HasColumnName("codigo_pais");

                entity.Property(e => e.IsoPais)
                    .HasMaxLength(2)
                    .HasColumnName("iso_pais")
                    .IsFixedLength();

                entity.Property(e => e.NombrePais)
                    .HasMaxLength(80)
                    .HasColumnName("nombre_pais");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.Correo)
                    .HasName("PRIMARY");

                entity.ToTable("parametro");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correo)
                    .HasMaxLength(300)
                    .HasColumnName("correo");

                entity.Property(e => e.Clave)
                    .HasMaxLength(45)
                    .HasColumnName("clave");

                entity.Property(e => e.Leyenda)
                    .HasMaxLength(2000)
                    .HasColumnName("leyenda");

                entity.Property(e => e.Puerto).HasColumnName("puerto");

                entity.Property(e => e.RutaArchivos)
                    .HasMaxLength(300)
                    .HasColumnName("rutaArchivos");

                entity.Property(e => e.Servidor)
                    .HasMaxLength(200)
                    .HasColumnName("servidor");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(45)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<ParametroCosmetico>(entity =>
            {
                entity.HasKey(e => e.NumeroCotizacion)
                    .HasName("PRIMARY");

                entity.ToTable("parametro_cosmeticos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.NumeroCotizacion)
                    .HasColumnName("numeroCotizacion")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<ParametroMedicamento>(entity =>
            {
                entity.HasKey(e => e.NumeroCotizacion)
                    .HasName("PRIMARY");

                entity.ToTable("parametro_medicamentos");

                entity.HasComment("	")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.NumeroCotizacion)
                    .HasColumnName("numeroCotizacion")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Preregistro>(entity =>
            {
                entity.HasKey(e => e.CodigoT)
                    .HasName("PRIMARY");

                entity.ToTable("preregistro");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoT).HasColumnName("codigo_t");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(45)
                    .HasColumnName("cedula");

                entity.Property(e => e.Celular)
                    .HasMaxLength(15)
                    .HasColumnName("celular");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Correo)
                    .HasMaxLength(300)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(5)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Idoneidad)
                    .HasMaxLength(500)
                    .HasColumnName("idoneidad");

                entity.Property(e => e.NombreApellido)
                    .HasMaxLength(300)
                    .HasColumnName("nombreApellido");

                entity.Property(e => e.NumeroIdoneidad)
                    .HasMaxLength(45)
                    .HasColumnName("numeroIdoneidad");

                entity.Property(e => e.NumeroSolicitud)
                    .HasMaxLength(45)
                    .HasColumnName("numeroSolicitud");

                entity.Property(e => e.TelefonoOficina)
                    .HasMaxLength(15)
                    .HasColumnName("telefonoOficina");

                entity.Property(e => e.TipoIdoneidad)
                    .HasMaxLength(4)
                    .HasColumnName("tipoIdoneidad")
                    .HasDefaultValueSql("'F'");
            });

            modelBuilder.Entity<PresentacionProducto>(entity =>
            {
                entity.HasKey(e => e.CodigoPre)
                    .HasName("PRIMARY");

                entity.ToTable("presentacion_producto");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoPre).HasColumnName("codigo_pre");

                entity.Property(e => e.NombrePre)
                    .HasMaxLength(600)
                    .HasColumnName("nombre_pre");
            });

            modelBuilder.Entity<PresentacionesCo>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("presentaciones_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(600)
                    .HasColumnName("archivo");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Documento)
                    .HasMaxLength(1500)
                    .HasColumnName("documento");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(600)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<PresentacionesComentariosCo>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("presentaciones_comentarios_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.Archivo).HasMaxLength(1500);

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Comentario)
                    .HasColumnType("text")
                    .HasColumnName("comentario");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(1500)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1500)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Publicidad>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("publicidad");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.ArchivoFirmado).HasMaxLength(800);

                entity.Property(e => e.AudioVideo)
                    .HasMaxLength(2)
                    .HasColumnName("audioVideo");

                entity.Property(e => e.Banner)
                    .HasMaxLength(2)
                    .HasColumnName("banner");

                entity.Property(e => e.Boligrafo)
                    .HasMaxLength(2)
                    .HasColumnName("boligrafo");

                entity.Property(e => e.Calendarios)
                    .HasMaxLength(2)
                    .HasColumnName("calendarios");

                entity.Property(e => e.Charlas)
                    .HasMaxLength(2)
                    .HasColumnName("charlas");

                entity.Property(e => e.CodigoPublicidad)
                    .HasMaxLength(200)
                    .HasColumnName("codigoPublicidad");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Congresos)
                    .HasMaxLength(2)
                    .HasColumnName("congresos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(300)
                    .HasColumnName("correo");

                entity.Property(e => e.Cupones)
                    .HasMaxLength(5000)
                    .HasColumnName("cupones");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(5000)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Documentos)
                    .HasMaxLength(500)
                    .HasColumnName("documentos");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.Fabricante)
                    .HasMaxLength(600)
                    .HasColumnName("fabricante");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Folletos)
                    .HasMaxLength(2)
                    .HasColumnName("folletos");

                entity.Property(e => e.Libretas)
                    .HasMaxLength(2)
                    .HasColumnName("libretas");

                entity.Property(e => e.Libros)
                    .HasMaxLength(2)
                    .HasColumnName("libros");

                entity.Property(e => e.Lineal)
                    .HasMaxLength(2)
                    .HasColumnName("lineal");

                entity.Property(e => e.MaterialPromocional)
                    .HasMaxLength(2)
                    .HasColumnName("materialPromocional");

                entity.Property(e => e.Muestra)
                    .HasMaxLength(500)
                    .HasColumnName("muestra");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(600)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(600)
                    .HasColumnName("nombreEmpresa");

                entity.Property(e => e.NumeroRegistro)
                    .HasMaxLength(45)
                    .HasColumnName("numeroRegistro");

                entity.Property(e => e.NumeroSolicitud)
                    .HasMaxLength(45)
                    .HasColumnName("numeroSolicitud")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.OtraInformacion)
                    .HasMaxLength(5000)
                    .HasColumnName("otraInformacion");

                entity.Property(e => e.Pago)
                    .HasMaxLength(500)
                    .HasColumnName("pago");

                entity.Property(e => e.Pais)
                    .HasMaxLength(300)
                    .HasColumnName("pais");

                entity.Property(e => e.Producto)
                    .HasMaxLength(600)
                    .HasColumnName("producto");

                entity.Property(e => e.Regleta)
                    .HasMaxLength(2)
                    .HasColumnName("regleta");

                entity.Property(e => e.Revistas)
                    .HasMaxLength(2)
                    .HasColumnName("revistas");

                entity.Property(e => e.TipoAudiovisuales)
                    .HasMaxLength(2)
                    .HasColumnName("tipoAudiovisuales");

                entity.Property(e => e.TipoCupones)
                    .HasMaxLength(2)
                    .HasColumnName("tipoCupones");

                entity.Property(e => e.TipoImpresos)
                    .HasMaxLength(2)
                    .HasColumnName("tipoImpresos");

                entity.Property(e => e.TipoOtros)
                    .HasMaxLength(2)
                    .HasColumnName("tipoOtros");
            });

            modelBuilder.Entity<RegistrosCo>(entity =>
            {
                entity.HasKey(e => e.RegistroSanitario)
                    .HasName("PRIMARY");

                entity.ToTable("registros_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.RegistroSanitario)
                    .HasMaxLength(8)
                    .HasColumnName("registro_sanitario");

                entity.Property(e => e.FabricanteNombre)
                    .HasMaxLength(1000)
                    .HasColumnName("fabricante_nombre");

                entity.Property(e => e.FabricantePais)
                    .HasMaxLength(100)
                    .HasColumnName("fabricante_pais");

                entity.Property(e => e.FechaExpedicion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_expedicion");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.Folio)
                    .HasMaxLength(10)
                    .HasColumnName("folio");

                entity.Property(e => e.Libro)
                    .HasMaxLength(10)
                    .HasColumnName("libro");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(1000)
                    .HasColumnName("nombre_producto");
            });

            modelBuilder.Entity<Registrospublicidad>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("registrospublicidad");

                entity.HasComment("	")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.CodigoPu).HasColumnName("codigo_pu");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.Estado)
                    .HasMaxLength(4)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.Fabricante)
                    .HasMaxLength(500)
                    .HasColumnName("fabricante");

                entity.Property(e => e.Pais)
                    .HasMaxLength(300)
                    .HasColumnName("pais");

                entity.Property(e => e.Producto)
                    .HasMaxLength(500)
                    .HasColumnName("producto");

                entity.Property(e => e.Registro)
                    .HasMaxLength(45)
                    .HasColumnName("registro");
            });

            modelBuilder.Entity<Renovacioncambio>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("renovacioncambios");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.Rc1)
                    .HasMaxLength(2)
                    .HasColumnName("RC1");

                entity.Property(e => e.Rc10)
                    .HasMaxLength(2)
                    .HasColumnName("RC10");

                entity.Property(e => e.Rc11)
                    .HasMaxLength(2)
                    .HasColumnName("RC11");

                entity.Property(e => e.Rc12)
                    .HasMaxLength(2)
                    .HasColumnName("RC12");

                entity.Property(e => e.Rc13)
                    .HasMaxLength(2)
                    .HasColumnName("RC13");

                entity.Property(e => e.Rc14)
                    .HasMaxLength(2)
                    .HasColumnName("RC14");

                entity.Property(e => e.Rc15)
                    .HasMaxLength(2)
                    .HasColumnName("RC15");

                entity.Property(e => e.Rc16)
                    .HasMaxLength(2)
                    .HasColumnName("RC16");

                entity.Property(e => e.Rc17)
                    .HasMaxLength(2)
                    .HasColumnName("RC17");

                entity.Property(e => e.Rc18)
                    .HasMaxLength(2)
                    .HasColumnName("RC18");

                entity.Property(e => e.Rc19)
                    .HasMaxLength(2)
                    .HasColumnName("RC19");

                entity.Property(e => e.Rc2)
                    .HasMaxLength(2)
                    .HasColumnName("RC2");

                entity.Property(e => e.Rc20)
                    .HasMaxLength(2)
                    .HasColumnName("RC20");

                entity.Property(e => e.Rc21)
                    .HasMaxLength(2)
                    .HasColumnName("RC21");

                entity.Property(e => e.Rc3)
                    .HasMaxLength(2)
                    .HasColumnName("RC3");

                entity.Property(e => e.Rc4)
                    .HasMaxLength(2)
                    .HasColumnName("RC4");

                entity.Property(e => e.Rc5)
                    .HasMaxLength(2)
                    .HasColumnName("RC5");

                entity.Property(e => e.Rc6)
                    .HasMaxLength(2)
                    .HasColumnName("RC6");

                entity.Property(e => e.Rc7)
                    .HasMaxLength(2)
                    .HasColumnName("RC7");

                entity.Property(e => e.Rc8)
                    .HasMaxLength(2)
                    .HasColumnName("RC8");

                entity.Property(e => e.Rc9)
                    .HasMaxLength(2)
                    .HasColumnName("RC9");

                entity.Property(e => e.Rcn1)
                    .HasMaxLength(2)
                    .HasColumnName("RCN1");

                entity.Property(e => e.Rcn2)
                    .HasMaxLength(2)
                    .HasColumnName("RCN2");

                entity.Property(e => e.Rcn3)
                    .HasMaxLength(2)
                    .HasColumnName("RCN3");

                entity.Property(e => e.Rcn4)
                    .HasMaxLength(2)
                    .HasColumnName("RCN4");

                entity.Property(e => e.Rcn5)
                    .HasMaxLength(2)
                    .HasColumnName("RCN5");
            });

            modelBuilder.Entity<Representante>(entity =>
            {
                entity.HasKey(e => e.CodigoRepresentante)
                    .HasName("PRIMARY");

                entity.ToTable("representante");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoRepresentante).HasColumnName("codigo_representante");

                entity.Property(e => e.CedulaRepresentanteSol)
                    .HasMaxLength(45)
                    .HasColumnName("cedula_representante_sol");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoRepresentanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("correo_representante_sol");

                entity.Property(e => e.DireccionRepresentanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_representante_sol");

                entity.Property(e => e.RepresentanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("representante_sol");

                entity.Property(e => e.TelefonoRepresentanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_representante_sol");
            });

            modelBuilder.Entity<RepresentanteCo>(entity =>
            {
                entity.HasKey(e => e.CodigoRepresentante)
                    .HasName("PRIMARY");

                entity.ToTable("representante_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoRepresentante).HasColumnName("codigo_representante");

                entity.Property(e => e.CedulaRepresentanteSol)
                    .HasMaxLength(45)
                    .HasColumnName("cedula_representante_sol");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoRepresentanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("correo_representante_sol");

                entity.Property(e => e.DireccionRepresentanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_representante_sol");

                entity.Property(e => e.RepresentanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("representante_sol");

                entity.Property(e => e.TelefonoRepresentanteSol)
                    .HasMaxLength(600)
                    .HasColumnName("telefono_representante_sol");
            });

            modelBuilder.Entity<SeguimientoCo>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("seguimiento_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.ComentariosInternos)
                    .HasColumnType("text")
                    .HasColumnName("comentariosInternos");

                entity.Property(e => e.ComentariosUsuario)
                    .HasColumnType("text")
                    .HasColumnName("comentariosUsuario");

                entity.Property(e => e.Estado)
                    .HasMaxLength(5)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(45)
                    .HasColumnName("fecha");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(5)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("'FD'");
            });

            modelBuilder.Entity<SeguimientoExcepcion>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("seguimiento_excepcion");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.CodigoExcepcion).HasColumnName("codigoExcepcion");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.ComentariosInternos)
                    .HasColumnType("text")
                    .HasColumnName("comentariosInternos");

                entity.Property(e => e.ComentariosUsuario)
                    .HasColumnType("text")
                    .HasColumnName("comentariosUsuario");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(5)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("'P'");
            });

            modelBuilder.Entity<SeguimientoMedicamento>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("seguimiento_medicamentos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.ComentariosInternos)
                    .HasColumnType("text")
                    .HasColumnName("comentariosInternos");

                entity.Property(e => e.ComentariosUsuario)
                    .HasColumnType("text")
                    .HasColumnName("comentariosUsuario");

                entity.Property(e => e.Estado)
                    .HasMaxLength(5)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(45)
                    .HasColumnName("fecha");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(5)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("'FD'");
            });

            modelBuilder.Entity<SeguimientoPreregistro>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("seguimiento_preregistro");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.CodigoPreregistro).HasColumnName("codigoPreregistro");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.ComentariosInternos)
                    .HasMaxLength(500)
                    .HasColumnName("comentariosInternos");

                entity.Property(e => e.ComentariosUsuario)
                    .HasMaxLength(500)
                    .HasColumnName("comentariosUsuario");

                entity.Property(e => e.Fecha).HasColumnName("fecha");
            });

            modelBuilder.Entity<SeguimientoPublicidad>(entity =>
            {
                entity.HasKey(e => e.Correlativo)
                    .HasName("PRIMARY");

                entity.ToTable("seguimiento_publicidad");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Correlativo).HasColumnName("correlativo");

                entity.Property(e => e.CodigoPublicidad).HasColumnName("codigoPublicidad");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.ComentariosInternos)
                    .HasColumnType("text")
                    .HasColumnName("comentariosInternos");

                entity.Property(e => e.ComentariosUsuario)
                    .HasColumnType("text")
                    .HasColumnName("comentariosUsuario");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(2)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("'--'");
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.ToTable("solicitud");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpresaSol)
                    .HasMaxLength(500)
                    .HasColumnName("empresa_sol");

                entity.Property(e => e.FabricanteSol)
                    .HasMaxLength(500)
                    .HasColumnName("fabricante_sol");

                entity.Property(e => e.FarmaceuticoSol)
                    .HasMaxLength(500)
                    .HasColumnName("farmaceutico_sol");

                entity.Property(e => e.FechaSol)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_sol");

                entity.Property(e => e.ProductoSol)
                    .HasMaxLength(500)
                    .HasColumnName("producto_sol");

                entity.Property(e => e.RepresentantelegalSol)
                    .HasMaxLength(500)
                    .HasColumnName("representantelegal_sol");
            });

            modelBuilder.Entity<TipoPagoCosmetico>(entity =>
            {
                entity.HasKey(e => e.CodigoTp)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_pago_cosmetico");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoTp).HasColumnName("codigo_tp");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .HasColumnName("estado");

                entity.Property(e => e.MontoTp).HasColumnName("monto_tp");

                entity.Property(e => e.NombreTp)
                    .HasMaxLength(1000)
                    .HasColumnName("nombre_tp");
            });

            modelBuilder.Entity<TipoPagoMedicamento>(entity =>
            {
                entity.HasKey(e => e.CodigoTp)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_pago_medicamento");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoTp).HasColumnName("codigo_tp");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .HasColumnName("estado");

                entity.Property(e => e.MontoTp).HasColumnName("monto_tp");

                entity.Property(e => e.NombreTp)
                    .HasMaxLength(1000)
                    .HasColumnName("nombre_tp");
            });

            modelBuilder.Entity<Titular>(entity =>
            {
                entity.HasKey(e => e.CodigoTitular)
                    .HasName("PRIMARY");

                entity.ToTable("titular");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoTitular).HasColumnName("codigo_titular");

                entity.Property(e => e.CodigoPTitular)
                    .HasMaxLength(600)
                    .HasColumnName("codigo_p_titular");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoTitular)
                    .HasMaxLength(600)
                    .HasColumnName("correo_titular");

                entity.Property(e => e.DireccionTitular)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_titular");

                entity.Property(e => e.TitularSol)
                    .HasMaxLength(600)
                    .HasColumnName("titular_sol");
            });

            modelBuilder.Entity<TitularCo>(entity =>
            {
                entity.HasKey(e => e.CodigoTitular)
                    .HasName("PRIMARY");

                entity.ToTable("titular_cos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoTitular).HasColumnName("codigo_titular");

                entity.Property(e => e.CodigoPTitular)
                    .HasMaxLength(600)
                    .HasColumnName("codigo_p_titular");

                entity.Property(e => e.CodigoSol).HasColumnName("codigo_sol");

                entity.Property(e => e.CorreoTitular)
                    .HasMaxLength(600)
                    .HasColumnName("correo_titular");

                entity.Property(e => e.DireccionTitular)
                    .HasMaxLength(600)
                    .HasColumnName("direccion_titular");

                entity.Property(e => e.TitularSol)
                    .HasMaxLength(600)
                    .HasColumnName("titular_sol");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodigoU)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoU).HasColumnName("codigo_u");

                entity.Property(e => e.ClaveU)
                    .HasMaxLength(100)
                    .HasColumnName("clave_u");

                entity.Property(e => e.EmailU)
                    .HasMaxLength(500)
                    .HasColumnName("email_u");

                entity.Property(e => e.EstadoU)
                    .HasMaxLength(1)
                    .HasColumnName("estado_u");

                entity.Property(e => e.InicialesU)
                    .HasMaxLength(10)
                    .HasColumnName("iniciales_u")
                    .HasDefaultValueSql("'--'");

                entity.Property(e => e.NombreU)
                    .HasMaxLength(500)
                    .HasColumnName("nombre_u");

                entity.Property(e => e.RoleU)
                    .HasMaxLength(3)
                    .HasColumnName("role_u");

                entity.Property(e => e.UsuarioU)
                    .HasMaxLength(100)
                    .HasColumnName("usuario_u");
            });

            modelBuilder.Entity<ViaAdministracion>(entity =>
            {
                entity.HasKey(e => e.CodigoVia)
                    .HasName("PRIMARY");

                entity.ToTable("via_administracion");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CodigoVia).HasColumnName("codigo_via");

                entity.Property(e => e.DescripcionVia)
                    .HasMaxLength(300)
                    .HasColumnName("descripcion_via");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.NumeroVia)
                    .HasMaxLength(10)
                    .HasColumnName("numero_via");
            });

            modelBuilder.Entity<ViaAdministracionCo>(entity =>
            {
                entity.HasKey(e => e.IdVa)
                    .HasName("PRIMARY");

                entity.ToTable("via_administracion_cos");

                entity.Property(e => e.IdVa).HasColumnName("id_va");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .HasColumnName("descripcion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
