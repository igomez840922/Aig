using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActividadEstablecimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadEstablecimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUD_InspAperCambUbicAgen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciboPago = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DatosEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosCondicionesLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAtendidosPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosActProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperCambUbicAgen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUD_InspAperCambUbicFarm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciboPago = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DatosEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosEstructuraOrganizacional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosInfraEstructura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaFisica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosPreguntasGenericas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosSenalizacionAvisos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaProductosControlados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaAlmacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAtendidosPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperCambUbicFarm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUD_InspAperFabricante",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProductos = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DatosEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosDocumentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosProcedimientoPrograma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAutoInspeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosProdAnalisisContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosReclamoProductoRetirado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaProduccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosEquipos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaLabCtrCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaAlmacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaAuxiliares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperFabricante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUD_InspRetiroRetencion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeccionOficinaRegional = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RetiroRetencionType = table.Column<int>(type: "int", nullable: false),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAtendidosPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspRetiroRetencion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUD_InspRutinaVigFarmaciaTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatosGeneralesFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosFarmaceutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosPersonalTecnico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosExpedienteColaborador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosEstructuraFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosEquipoRegistroFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAnuncioFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegMovimientoExistenciaFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAlmacenProductosFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosProcedimientoFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspRutinaVigFarmaciaTB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUD_TipoEstablecimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TipoEstablecimiento = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_TipoEstablecimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "FMV_OrigenAlerta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_OrigenAlerta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TipoLaboratorio = table.Column<int>(type: "int", nullable: false),
                    TipoUbicacion = table.Column<int>(type: "int", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrabajador",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Evaluador = table.Column<bool>(type: "bit", nullable: false),
                    Tramitador = table.Column<bool>(type: "bit", nullable: false),
                    Registrador = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrabajador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoEstablecimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoEstablecimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmtpCorreo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SmtpServidor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SmtpPuerto = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpCorreo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoInstitucion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInstitucion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SureName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SecondSurName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Languanje = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LogoBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptTerms = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AUD_ProdRetiroRetencion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrmRetiroRetencionId = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PresentacionComercial = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaExp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CantidadRetenida = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CantidadRetirada = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Destino = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_ProdRetiroRetencion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUD_ProdRetiroRetencion_AUD_InspRetiroRetencion_FrmRetiroRetencionId",
                        column: x => x.FrmRetiroRetencionId,
                        principalTable: "AUD_InspRetiroRetencion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FMV_Rfv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DireccionFisica = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telefonos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Correos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TipoUbicacion = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNotificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Rfv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Rfv_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PaisId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincia_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_Alerta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEvaluador = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    OrigenAlertaId = table.Column<long>(type: "bigint", nullable: true),
                    TipoAlerta = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DCI = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecomProfPaciente = table.Column<bool>(type: "bit", nullable: false),
                    ActualizaMonografias = table.Column<bool>(type: "bit", nullable: false),
                    ConsentFirmado = table.Column<bool>(type: "bit", nullable: false),
                    SuspencionRetiroLote = table.Column<bool>(type: "bit", nullable: false),
                    SuspencCancelRegSanitario = table.Column<bool>(type: "bit", nullable: false),
                    OtrasConsideraciones = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    NumNota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Alerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Alerta_FMV_OrigenAlerta_OrigenAlertaId",
                        column: x => x.OrigenAlertaId,
                        principalTable: "FMV_OrigenAlerta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Alerta_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_Pmr",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEvaluador = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaTramite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    PrincActivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Pmr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Pmr_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_Ram",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRecibidoCNFV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    FarmacoSospechosoComercial = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FarmacoSospechosoDci = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Atc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubGrupoTerapeutico = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RamType = table.Column<int>(type: "int", nullable: false),
                    RamOrigenType = table.Column<int>(type: "int", nullable: false),
                    CodigoNotiFacedra = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdFacedra = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CodigoCNFV = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ValUnico = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Ram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Ram_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MV_Ips",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRegistrador = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistradorId = table.Column<long>(type: "bigint", nullable: true),
                    NomComercial = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PrincActivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EstatusRecepcion = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TramitadorId = table.Column<long>(type: "bigint", nullable: true),
                    EstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    FechaAsigEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    ResumenEjec = table.Column<int>(type: "int", nullable: false),
                    ResumenEjecTrad = table.Column<int>(type: "int", nullable: false),
                    Prioridad = table.Column<bool>(type: "bit", nullable: false),
                    FechaRev = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusRevision = table.Column<int>(type: "int", nullable: false),
                    ConfecConNormativa = table.Column<bool>(type: "bit", nullable: false),
                    NoInforme = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IpsData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MV_Ips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MV_Ips_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MV_Ips_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MV_Ips_PersonalTrabajador_RegistradorId",
                        column: x => x.RegistradorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MV_Ips_PersonalTrabajador_TramitadorId",
                        column: x => x.TramitadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserRoleType = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProvinciaId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distrito_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstitucionDestino",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoInstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    ProvinciaId = table.Column<long>(type: "bigint", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitucionDestino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstitucionDestino_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstitucionDestino_TipoInstitucion_TipoInstitucionId",
                        column: x => x.TipoInstitucionId,
                        principalTable: "TipoInstitucion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_PmrProducto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PmrId = table.Column<long>(type: "bigint", nullable: false),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NomComercial = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_PmrProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_PmrProducto_FMV_Pmr_PmrId",
                        column: x => x.PmrId,
                        principalTable: "FMV_Pmr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FMV_PmrProducto_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_RamNotificacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RamId = table.Column<long>(type: "bigint", nullable: false),
                    CodExterno = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TipoNotificador = table.Column<int>(type: "int", nullable: false),
                    TipoOrgInst = table.Column<int>(type: "int", nullable: false),
                    ProvRegionOrigen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NombreOrgInst = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NumIngresoVigiflow = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    EvaluacionCalidadInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluacionCausalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObservacionInfoNotifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccionesRegulatoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_RamNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_RamNotificacion_FMV_Ram_RamId",
                        column: x => x.RamId,
                        principalTable: "FMV_Ram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Corregimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DistritoId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corregimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corregimiento_Distrito_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_Esavi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCNFV = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CodExt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OrigenNotificacion = table.Column<int>(type: "int", nullable: false),
                    CodigoNotiFacedra = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdFacedra = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaRecibidoCNFV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    TipoNotificacion = table.Column<int>(type: "int", nullable: false),
                    TipoInstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    ProvinciaId = table.Column<long>(type: "bigint", nullable: true),
                    InstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    OtrosDiagnosticos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    HistoriaClinica = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DatosLab = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NombreCompletoPersona = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    InicialesPersona = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MedicamentoContaminante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DetallesCaso = table.Column<int>(type: "int", nullable: false),
                    FechaEvalua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Esavi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Esavi_InstitucionDestino_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "InstitucionDestino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Esavi_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Esavi_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Esavi_TipoInstitucion_TipoInstitucionId",
                        column: x => x.TipoInstitucionId,
                        principalTable: "TipoInstitucion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_Ff",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCNFV = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CodExt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaRecibidoCNFV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    NombreComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NombreDci = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ATC = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubGrupoTerapeutico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaExp = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TipoNotificador = table.Column<int>(type: "int", nullable: false),
                    TipoNotificacion = table.Column<int>(type: "int", nullable: false),
                    TipoInstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    ProvinciaId = table.Column<long>(type: "bigint", nullable: true),
                    InstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    Notificador = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IncidenciaCaso = table.Column<int>(type: "int", nullable: false),
                    FallaReportada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrasEspecificaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaTramite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEvalua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    ResolEmitidas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Ff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Ff_InstitucionDestino_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "InstitucionDestino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ff_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ff_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ff_TipoInstitucion_TipoInstitucionId",
                        column: x => x.TipoInstitucionId,
                        principalTable: "TipoInstitucion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_Ft",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCNFV = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CodExt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaRecibidoCNFV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    NombreComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NombreDci = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ATC = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubGrupoTerapeutico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaExp = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TipoNotificador = table.Column<int>(type: "int", nullable: false),
                    TipoNotificacion = table.Column<int>(type: "int", nullable: false),
                    TipoInstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    ProvinciaId = table.Column<long>(type: "bigint", nullable: true),
                    InstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    InstitucionDestinoId = table.Column<long>(type: "bigint", nullable: true),
                    Notificador = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IncidenciaCaso = table.Column<int>(type: "int", nullable: false),
                    OtrasEspecificaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosPaciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluacionCausalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaTramite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEvalua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    ResolEmitidas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Ft", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Ft_InstitucionDestino_InstitucionDestinoId",
                        column: x => x.InstitucionDestinoId,
                        principalTable: "InstitucionDestino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ft_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ft_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ft_TipoInstitucion_TipoInstitucionId",
                        column: x => x.TipoInstitucionId,
                        principalTable: "TipoInstitucion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_Nota",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumNota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    TipoNota = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionDestinoId = table.Column<long>(type: "bigint", nullable: true),
                    Destinatario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Nota_InstitucionDestino_InstitucionDestinoId",
                        column: x => x.InstitucionDestinoId,
                        principalTable: "InstitucionDestino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Nota_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AUD_Establecimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NumLicencia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false),
                    TipoEstablecimiento = table.Column<int>(type: "int", nullable: false),
                    Clasificacion = table.Column<int>(type: "int", nullable: false),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaExpedida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVigencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVigenciaIni = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVigenciaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoMaquina = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaDuplicado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvinciaId = table.Column<long>(type: "bigint", nullable: false),
                    DistritoId = table.Column<long>(type: "bigint", nullable: true),
                    CorregimientoId = table.Column<long>(type: "bigint", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telefono1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Telefono2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HorariosEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaControlado = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TipoActividad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitanteLicNombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SolicitanteLicCedula = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepLegalNombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RepLegalCedula = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CorregidorNombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NombreSociedad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Farmac1Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Farmac1NumRegistro = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Farmac1Sector = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Farmac1VMedico = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Farmac2Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Farmac2NumRegistro = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Farmac2Sector = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Farmac2VMedico = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_Establecimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUD_Establecimiento_Corregimiento_CorregimientoId",
                        column: x => x.CorregimientoId,
                        principalTable: "Corregimiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_Establecimiento_Distrito_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_Establecimiento_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FMV_EsaviNotificacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsaviId = table.Column<long>(type: "bigint", nullable: false),
                    HayEsavi = table.Column<int>(type: "int", nullable: false),
                    FechaEsavi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Desenlace = table.Column<int>(type: "int", nullable: false),
                    EsaviDescripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TerminoWhoArt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SOC = table.Column<int>(type: "int", nullable: false),
                    Intensidad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Gravedad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OtrosCriterios = table.Column<int>(type: "int", nullable: false),
                    ElegibilidadGravedad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ElegibilidadOtroCriterio = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ElegibleEvaluacionCausal = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProbabilidadAsociacion = table.Column<int>(type: "int", nullable: false),
                    VacunaComercial = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DescripVacuna = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaExp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaVacunacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Indicaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DosisViaAdmin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DosisEsavi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_EsaviNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_EsaviNotificacion_FMV_Esavi_EsaviId",
                        column: x => x.EsaviId,
                        principalTable: "FMV_Esavi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AUD_Inspeccion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumActa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntNumActa = table.Column<int>(type: "int", nullable: false),
                    StatusInspecciones = table.Column<int>(type: "int", nullable: false),
                    TipoActa = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstablecimientoId = table.Column<long>(type: "bigint", nullable: false),
                    UbicacionEstablecimiento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TelefonoEstablecimiento = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AvisoOperación = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RepreLegal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RepreLegalIdentificacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParticEstablecimiento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ParticEstablecimientoCargo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParticEstablecimientoEmail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParticEstablecimientoCIP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InspRutinaVigFarmaciaId = table.Column<long>(type: "bigint", nullable: true),
                    InspAperCambUbicAgenId = table.Column<long>(type: "bigint", nullable: true),
                    InspAperCambUbicFarmId = table.Column<long>(type: "bigint", nullable: true),
                    InspRetiroRetencionId = table.Column<long>(type: "bigint", nullable: true),
                    InspAperFabricanteId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_Inspeccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUD_Inspeccion_AUD_Establecimiento_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "AUD_Establecimiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicAgen_InspAperCambUbicAgenId",
                        column: x => x.InspAperCambUbicAgenId,
                        principalTable: "AUD_InspAperCambUbicAgen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicFarm_InspAperCambUbicFarmId",
                        column: x => x.InspAperCambUbicFarmId,
                        principalTable: "AUD_InspAperCambUbicFarm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_Inspeccion_AUD_InspAperFabricante_InspAperFabricanteId",
                        column: x => x.InspAperFabricanteId,
                        principalTable: "AUD_InspAperFabricante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_Inspeccion_AUD_InspRetiroRetencion_InspRetiroRetencionId",
                        column: x => x.InspRetiroRetencionId,
                        principalTable: "AUD_InspRetiroRetencion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_Inspeccion_AUD_InspRutinaVigFarmaciaTB_InspAperFabricanteId",
                        column: x => x.InspAperFabricanteId,
                        principalTable: "AUD_InspRutinaVigFarmaciaTB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AbsolutePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspeccionId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_AUD_Inspeccion_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "AUD_Inspeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserProfileId",
                table: "AspNetUsers",
                column: "UserProfileId",
                unique: true,
                filter: "[UserProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_InspeccionId",
                table: "Attachment",
                column: "InspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Establecimiento_CorregimientoId",
                table: "AUD_Establecimiento",
                column: "CorregimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Establecimiento_DistritoId",
                table: "AUD_Establecimiento",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Establecimiento_ProvinciaId",
                table: "AUD_Establecimiento",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_EstablecimientoId",
                table: "AUD_Inspeccion",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion",
                column: "InspAperCambUbicAgenId",
                unique: true,
                filter: "[InspAperCambUbicAgenId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspAperCambUbicFarmId",
                table: "AUD_Inspeccion",
                column: "InspAperCambUbicFarmId",
                unique: true,
                filter: "[InspAperCambUbicFarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspAperFabricanteId",
                table: "AUD_Inspeccion",
                column: "InspAperFabricanteId",
                unique: true,
                filter: "[InspAperFabricanteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspRetiroRetencionId",
                table: "AUD_Inspeccion",
                column: "InspRetiroRetencionId",
                unique: true,
                filter: "[InspRetiroRetencionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_ProdRetiroRetencion_FrmRetiroRetencionId",
                table: "AUD_ProdRetiroRetencion",
                column: "FrmRetiroRetencionId");

            migrationBuilder.CreateIndex(
                name: "IX_Corregimiento_DistritoId",
                table: "Corregimiento",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Distrito_ProvinciaId",
                table: "Distrito",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Alerta_EvaluadorId",
                table: "FMV_Alerta",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Alerta_OrigenAlertaId",
                table: "FMV_Alerta",
                column: "OrigenAlertaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_EvaluadorId",
                table: "FMV_Esavi",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_InstitucionId",
                table: "FMV_Esavi",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_ProvinciaId",
                table: "FMV_Esavi",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_TipoInstitucionId",
                table: "FMV_Esavi",
                column: "TipoInstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviNotificacion_EsaviId",
                table: "FMV_EsaviNotificacion",
                column: "EsaviId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ff_EvaluadorId",
                table: "FMV_Ff",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ff_InstitucionId",
                table: "FMV_Ff",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ff_ProvinciaId",
                table: "FMV_Ff",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ff_TipoInstitucionId",
                table: "FMV_Ff",
                column: "TipoInstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_EvaluadorId",
                table: "FMV_Ft",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_InstitucionDestinoId",
                table: "FMV_Ft",
                column: "InstitucionDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_ProvinciaId",
                table: "FMV_Ft",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_TipoInstitucionId",
                table: "FMV_Ft",
                column: "TipoInstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Nota_EvaluadorId",
                table: "FMV_Nota",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Nota_InstitucionDestinoId",
                table: "FMV_Nota",
                column: "InstitucionDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Pmr_EvaluadorId",
                table: "FMV_Pmr",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_PmrProducto_LaboratorioId",
                table: "FMV_PmrProducto",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_PmrProducto_PmrId",
                table: "FMV_PmrProducto",
                column: "PmrId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_EvaluadorId",
                table: "FMV_Ram",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_RamNotificacion_RamId",
                table: "FMV_RamNotificacion",
                column: "RamId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Rfv_LaboratorioId",
                table: "FMV_Rfv",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitucionDestino_ProvinciaId",
                table: "InstitucionDestino",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitucionDestino_TipoInstitucionId",
                table: "InstitucionDestino",
                column: "TipoInstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_MV_Ips_EvaluadorId",
                table: "MV_Ips",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_MV_Ips_LaboratorioId",
                table: "MV_Ips",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_MV_Ips_RegistradorId",
                table: "MV_Ips",
                column: "RegistradorId");

            migrationBuilder.CreateIndex(
                name: "IX_MV_Ips_TramitadorId",
                table: "MV_Ips",
                column: "TramitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_PaisId",
                table: "Provincia",
                column: "PaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadEstablecimiento");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "AUD_ProdRetiroRetencion");

            migrationBuilder.DropTable(
                name: "AUD_TipoEstablecimiento");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "FMV_Alerta");

            migrationBuilder.DropTable(
                name: "FMV_EsaviNotificacion");

            migrationBuilder.DropTable(
                name: "FMV_Ff");

            migrationBuilder.DropTable(
                name: "FMV_Ft");

            migrationBuilder.DropTable(
                name: "FMV_Nota");

            migrationBuilder.DropTable(
                name: "FMV_PmrProducto");

            migrationBuilder.DropTable(
                name: "FMV_RamNotificacion");

            migrationBuilder.DropTable(
                name: "FMV_Rfv");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "MV_Ips");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "ProductoEstablecimiento");

            migrationBuilder.DropTable(
                name: "SmtpCorreo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "FMV_OrigenAlerta");

            migrationBuilder.DropTable(
                name: "FMV_Esavi");

            migrationBuilder.DropTable(
                name: "FMV_Pmr");

            migrationBuilder.DropTable(
                name: "FMV_Ram");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "AUD_Establecimiento");

            migrationBuilder.DropTable(
                name: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropTable(
                name: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropTable(
                name: "AUD_InspAperFabricante");

            migrationBuilder.DropTable(
                name: "AUD_InspRetiroRetencion");

            migrationBuilder.DropTable(
                name: "AUD_InspRutinaVigFarmaciaTB");

            migrationBuilder.DropTable(
                name: "InstitucionDestino");

            migrationBuilder.DropTable(
                name: "PersonalTrabajador");

            migrationBuilder.DropTable(
                name: "Corregimiento");

            migrationBuilder.DropTable(
                name: "TipoInstitucion");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
