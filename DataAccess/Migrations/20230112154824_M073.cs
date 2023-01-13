using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M073 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FMV_Esavi2",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigenNotificacion = table.Column<int>(type: "int", nullable: false),
                    CodigoNotiFacedra = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdFacedra = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CodExt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CodCNFV = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaRecibidoCNFV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    TipoNotificacion = table.Column<int>(type: "int", nullable: false),
                    Notificador = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TipoInstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    ProvinciaId = table.Column<long>(type: "bigint", nullable: true),
                    InstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    InstitucionDestinoId = table.Column<long>(type: "bigint", nullable: true),
                    NombreCompletoPersona = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    InicialesPersona = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaClinica = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OtrosDiagnosticos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Concominantes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosLab = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaEvalua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Adjunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Esavi2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Esavi2_InstitucionDestino_InstitucionDestinoId",
                        column: x => x.InstitucionDestinoId,
                        principalTable: "InstitucionDestino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Esavi2_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Esavi2_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Esavi2_TipoInstitucion_TipoInstitucionId",
                        column: x => x.TipoInstitucionId,
                        principalTable: "TipoInstitucion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_EsaviVacuna",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsaviId = table.Column<long>(type: "bigint", nullable: true),
                    VacunaComercial = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TipoVacunaId = table.Column<long>(type: "bigint", nullable: true),
                    LaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaExp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaVacunacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Indicaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DosisViaAdmin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DosisPresenta = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_EsaviVacuna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_EsaviVacuna_FMV_Esavi2_EsaviId",
                        column: x => x.EsaviId,
                        principalTable: "FMV_Esavi2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FMV_EsaviVacuna_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_EsaviVacuna_TipoVacuna_TipoVacunaId",
                        column: x => x.TipoVacunaId,
                        principalTable: "TipoVacuna",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_EsaviVacunaEsavi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsaviVacunaId = table.Column<long>(type: "bigint", nullable: true),
                    HayEsavi = table.Column<int>(type: "int", nullable: false),
                    EsaviDescripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaEsavi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Desenlace = table.Column<int>(type: "int", nullable: false),
                    SocId = table.Column<long>(type: "bigint", nullable: true),
                    Soc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerMedraId = table.Column<long>(type: "bigint", nullable: true),
                    TerWhoArt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntensidadEsaviId = table.Column<long>(type: "bigint", nullable: true),
                    Gravedad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InvDetalleCaso = table.Column<int>(type: "int", nullable: false),
                    OtrosCriterios = table.Column<int>(type: "int", nullable: false),
                    ElegibilidadGravedad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ElegibilidadOtroCriterio = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ElegibleEvaluacionCausal = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProbabilidadAsociacion = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_EsaviVacunaEsavi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_EsaviVacunaEsavi_FMV_EsaviVacuna_EsaviVacunaId",
                        column: x => x.EsaviVacunaId,
                        principalTable: "FMV_EsaviVacuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FMV_EsaviVacunaEsavi_IntensidadEsavi_IntensidadEsaviId",
                        column: x => x.IntensidadEsaviId,
                        principalTable: "IntensidadEsavi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi2_EvaluadorId",
                table: "FMV_Esavi2",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi2_InstitucionDestinoId",
                table: "FMV_Esavi2",
                column: "InstitucionDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi2_ProvinciaId",
                table: "FMV_Esavi2",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi2_TipoInstitucionId",
                table: "FMV_Esavi2",
                column: "TipoInstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviVacuna_EsaviId",
                table: "FMV_EsaviVacuna",
                column: "EsaviId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviVacuna_LaboratorioId",
                table: "FMV_EsaviVacuna",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviVacuna_TipoVacunaId",
                table: "FMV_EsaviVacuna",
                column: "TipoVacunaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviVacunaEsavi_EsaviVacunaId",
                table: "FMV_EsaviVacunaEsavi",
                column: "EsaviVacunaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviVacunaEsavi_IntensidadEsaviId",
                table: "FMV_EsaviVacunaEsavi",
                column: "IntensidadEsaviId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMV_EsaviVacunaEsavi");

            migrationBuilder.DropTable(
                name: "FMV_EsaviVacuna");

            migrationBuilder.DropTable(
                name: "FMV_Esavi2");
        }
    }
}
