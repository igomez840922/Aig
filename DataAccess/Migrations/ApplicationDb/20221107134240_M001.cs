using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.ApplicationDb
{
    public partial class M001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AUD_InspAperCambUbicFarmTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoInspeccion = table.Column<int>(type: "int", nullable: false),
                    ReciboPago = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperCambUbicFarmTB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUD_InspRetiroRetencionTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeccionOficinaRegional = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RetiroRetencionType = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspRetiroRetencionTB", x => x.Id);
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
                name: "InstitucionDestino",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "OrigenAlerta",
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
                    table.PrimaryKey("PK_OrigenAlerta", x => x.Id);
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
                name: "AUD_ProdRetiroRetencionTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrmRetiroRetencionId = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PresentacionComercial = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaExp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CantidadRetenida = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CantidadRetirada = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Destino = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_ProdRetiroRetencionTB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUD_ProdRetiroRetencionTB_AUD_InspRetiroRetencionTB_FrmRetiroRetencionId",
                        column: x => x.FrmRetiroRetencionId,
                        principalTable: "AUD_InspRetiroRetencionTB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rfv",
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
                    table.PrimaryKey("PK_Rfv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rfv_Laboratorio_LaboratorioId",
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
                name: "Alerta",
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
                    table.PrimaryKey("PK_Alerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerta_OrigenAlerta_OrigenAlertaId",
                        column: x => x.OrigenAlertaId,
                        principalTable: "OrigenAlerta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alerta_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ips",
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
                    table.PrimaryKey("PK_Ips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ips_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ips_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ips_PersonalTrabajador_RegistradorId",
                        column: x => x.RegistradorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ips_PersonalTrabajador_TramitadorId",
                        column: x => x.TramitadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nota",
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
                    table.PrimaryKey("PK_Nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nota_InstitucionDestino_InstitucionDestinoId",
                        column: x => x.InstitucionDestinoId,
                        principalTable: "InstitucionDestino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nota_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PmrTB",
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
                    table.PrimaryKey("PK_PmrTB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmrTB_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
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
                name: "Ram",
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
                    table.PrimaryKey("PK_Ram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ram_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ram_PmrTB_PmrId",
                        column: x => x.PmrId,
                        principalTable: "PmrTB",
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
                name: "AUD_EstablecimientoTB",
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
                    table.PrimaryKey("PK_AUD_EstablecimientoTB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUD_EstablecimientoTB_Corregimiento_CorregimientoId",
                        column: x => x.CorregimientoId,
                        principalTable: "Corregimiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_EstablecimientoTB_Distrito_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_EstablecimientoTB_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AUD_InspeccionTB",
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
                    LicenseNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AvisoOperación = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RepreLegal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RepreLegalIdentificacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParticipantesDNFD = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ParticEstablecimiento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ParticEstablecimientoCargo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParticEstablecimientoEmail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParticEstablecimientoCIP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FirmaDNFD1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumRegDNFD1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FirmaDNFD2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumRegDNFD2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FirmaDNFD3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaDNFD4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaDNFD5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaDNFD6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaDNFD7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaDNFD8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaEstablec1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaEstablec2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspAperCambUbicFarmId = table.Column<long>(type: "bigint", nullable: true),
                    InspRetiroRetencionId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspeccionTB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUD_InspeccionTB_AUD_EstablecimientoTB_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "AUD_EstablecimientoTB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AUD_InspeccionTB_AUD_InspAperCambUbicFarmTB_InspAperCambUbicFarmId",
                        column: x => x.InspAperCambUbicFarmId,
                        principalTable: "AUD_InspAperCambUbicFarmTB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AUD_InspeccionTB_AUD_InspRetiroRetencionTB_InspRetiroRetencionId",
                        column: x => x.InspRetiroRetencionId,
                        principalTable: "AUD_InspRetiroRetencionTB",
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
                        name: "FK_Attachment_AUD_InspeccionTB_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "AUD_InspeccionTB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_EvaluadorId",
                table: "Alerta",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_OrigenAlertaId",
                table: "Alerta",
                column: "OrigenAlertaId");

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
                name: "IX_AUD_EstablecimientoTB_CorregimientoId",
                table: "AUD_EstablecimientoTB",
                column: "CorregimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_EstablecimientoTB_DistritoId",
                table: "AUD_EstablecimientoTB",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_EstablecimientoTB_ProvinciaId",
                table: "AUD_EstablecimientoTB",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_InspeccionTB_EstablecimientoId",
                table: "AUD_InspeccionTB",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_InspeccionTB_InspAperCambUbicFarmId",
                table: "AUD_InspeccionTB",
                column: "InspAperCambUbicFarmId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_InspeccionTB_InspRetiroRetencionId",
                table: "AUD_InspeccionTB",
                column: "InspRetiroRetencionId",
                unique: true,
                filter: "[InspRetiroRetencionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_ProdRetiroRetencionTB_FrmRetiroRetencionId",
                table: "AUD_ProdRetiroRetencionTB",
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
                name: "IX_Ips_EvaluadorId",
                table: "Ips",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ips_LaboratorioId",
                table: "Ips",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ips_RegistradorId",
                table: "Ips",
                column: "RegistradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ips_TramitadorId",
                table: "Ips",
                column: "TramitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_EvaluadorId",
                table: "Nota",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_InstitucionDestinoId",
                table: "Nota",
                column: "InstitucionDestinoId");

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
                name: "IX_PmrTB_EvaluadorId",
                table: "PmrTB",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_PaisId",
                table: "Provincia",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Ram_LaboratorioId",
                table: "Ram",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ram_PmrId",
                table: "Ram",
                column: "PmrId");

            migrationBuilder.CreateIndex(
                name: "IX_Rfv_LaboratorioId",
                table: "Rfv",
                column: "LaboratorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerta");

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
                name: "AUD_ProdRetiroRetencionTB");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Ips");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Ram");

            migrationBuilder.DropTable(
                name: "Rfv");

            migrationBuilder.DropTable(
                name: "SmtpCorreo");

            migrationBuilder.DropTable(
                name: "OrigenAlerta");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AUD_InspeccionTB");

            migrationBuilder.DropTable(
                name: "InstitucionDestino");

            migrationBuilder.DropTable(
                name: "PmrTB");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "AUD_EstablecimientoTB");

            migrationBuilder.DropTable(
                name: "AUD_InspAperCambUbicFarmTB");

            migrationBuilder.DropTable(
                name: "AUD_InspRetiroRetencionTB");

            migrationBuilder.DropTable(
                name: "PersonalTrabajador");

            migrationBuilder.DropTable(
                name: "Corregimiento");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
