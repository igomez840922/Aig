using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.FarmacoVigilancia.Migrations
{
    public partial class M004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    TipoOrgInst = table.Column<int>(type: "int", nullable: false),
                    ProvRegionOrigen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NombreOrgInst = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                        name: "FK_FMV_Esavi_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
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
                    FarmacoSospechosoComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FarmacoSospechosoDci = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
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
                        name: "FK_FMV_Ft_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
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
                name: "FMV_FtNotificacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FtId = table.Column<long>(type: "bigint", nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Atc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubGrupoTer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Expira = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TipoNotificador = table.Column<int>(type: "int", nullable: false),
                    TipoOrgInst = table.Column<int>(type: "int", nullable: false),
                    ProvRegionOrigen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NombreOrgInst = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Notificador = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IncidenciaCaso = table.Column<int>(type: "int", nullable: false),
                    FallaReportada = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_FMV_FtNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_FtNotificacion_FMV_Ft_FtId",
                        column: x => x.FtId,
                        principalTable: "FMV_Ft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_EvaluadorId",
                table: "FMV_Esavi",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviNotificacion_EsaviId",
                table: "FMV_EsaviNotificacion",
                column: "EsaviId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_EvaluadorId",
                table: "FMV_Ft",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_FtNotificacion_FtId",
                table: "FMV_FtNotificacion",
                column: "FtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMV_EsaviNotificacion");

            migrationBuilder.DropTable(
                name: "FMV_FtNotificacion");

            migrationBuilder.DropTable(
                name: "FMV_Esavi");

            migrationBuilder.DropTable(
                name: "FMV_Ft");
        }
    }
}
