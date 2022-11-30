using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.FarmacoVigilancia.Migrations
{
    public partial class M002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FMV_Ff",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCNFV = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CodExt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaRecibidoCNFV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    FarmacoSospechosoComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FarmacoSospechosoDci = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
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
                        name: "FK_FMV_Ff_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_FfNotificacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FfId = table.Column<long>(type: "bigint", nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubGrupoTer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Expira = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TipoNotificador = table.Column<int>(type: "int", nullable: false),
                    TipoOrgInst = table.Column<int>(type: "int", nullable: false),
                    ProvRegionOrigen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NombreOrgInst = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Notificador = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IncidenciaCaso = table.Column<int>(type: "int", nullable: false),
                    FallaReportada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisionRs = table.Column<int>(type: "int", nullable: false),
                    Monitoreo = table.Column<int>(type: "int", nullable: false),
                    NotificacionRFV = table.Column<int>(type: "int", nullable: false),
                    ControlCalidad = table.Column<int>(type: "int", nullable: false),
                    ResultControlCalidad = table.Column<int>(type: "int", nullable: false),
                    InvestCampo = table.Column<int>(type: "int", nullable: false),
                    InvestDAC = table.Column<int>(type: "int", nullable: false),
                    AccRegRecomendada = table.Column<int>(type: "int", nullable: false),
                    Grado = table.Column<int>(type: "int", nullable: false),
                    FechaTramite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEvalua = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_FMV_FfNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_FfNotificacion_FMV_Ff_FfId",
                        column: x => x.FfId,
                        principalTable: "FMV_Ff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ff_EvaluadorId",
                table: "FMV_Ff",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_FfNotificacion_FfId",
                table: "FMV_FfNotificacion",
                column: "FfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMV_FfNotificacion");

            migrationBuilder.DropTable(
                name: "FMV_Ff");
        }
    }
}
