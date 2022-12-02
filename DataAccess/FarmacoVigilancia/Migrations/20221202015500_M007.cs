using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.FarmacoVigilancia.Migrations
{
    public partial class M007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMV_FfNotificacion");

            migrationBuilder.RenameColumn(
                name: "FarmacoSospechosoDci",
                table: "FMV_Ff",
                newName: "NombreDci");

            migrationBuilder.RenameColumn(
                name: "FarmacoSospechosoComercial",
                table: "FMV_Ff",
                newName: "NombreComercial");

            migrationBuilder.AddColumn<string>(
                name: "ATC",
                table: "FMV_Ff",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atc2",
                table: "FMV_Ff",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "FMV_Ff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FallaReportada",
                table: "FMV_Ff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEvalua",
                table: "FMV_Ff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaExp",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaTramite",
                table: "FMV_Ff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidenciaCaso",
                table: "FMV_Ff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "InstitucionId",
                table: "FMV_Ff",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lote",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notificador",
                table: "FMV_Ff",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtrasEspecificaciones",
                table: "FMV_Ff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Presentacion",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProvinciaId",
                table: "FMV_Ff",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegSanitario",
                table: "FMV_Ff",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResolEmitidas",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubGrupoTerapeutico",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoInstitucionId",
                table: "FMV_Ff",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoNotificacion",
                table: "FMV_Ff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoNotificador",
                table: "FMV_Ff",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ff_InstitucionDestino_InstitucionId",
                table: "FMV_Ff",
                column: "InstitucionId",
                principalTable: "InstitucionDestino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ff_Provincia_ProvinciaId",
                table: "FMV_Ff",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ff_TipoInstitucion_TipoInstitucionId",
                table: "FMV_Ff",
                column: "TipoInstitucionId",
                principalTable: "TipoInstitucion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ff_InstitucionDestino_InstitucionId",
                table: "FMV_Ff");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ff_Provincia_ProvinciaId",
                table: "FMV_Ff");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ff_TipoInstitucion_TipoInstitucionId",
                table: "FMV_Ff");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ff_InstitucionId",
                table: "FMV_Ff");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ff_ProvinciaId",
                table: "FMV_Ff");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ff_TipoInstitucionId",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "ATC",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "Atc2",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "FallaReportada",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "FechaEvalua",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "FechaExp",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "FechaTramite",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "IncidenciaCaso",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "InstitucionId",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "Lote",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "Notificador",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "OtrasEspecificaciones",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "Presentacion",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "RegSanitario",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "ResolEmitidas",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "SubGrupoTerapeutico",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "TipoInstitucionId",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "TipoNotificacion",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "TipoNotificador",
                table: "FMV_Ff");

            migrationBuilder.RenameColumn(
                name: "NombreDci",
                table: "FMV_Ff",
                newName: "FarmacoSospechosoDci");

            migrationBuilder.RenameColumn(
                name: "NombreComercial",
                table: "FMV_Ff",
                newName: "FarmacoSospechosoComercial");

            migrationBuilder.CreateTable(
                name: "FMV_FfNotificacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FfId = table.Column<long>(type: "bigint", nullable: false),
                    AccRegRecomendada = table.Column<int>(type: "int", nullable: false),
                    Atc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ControlCalidad = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Expira = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FallaReportada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEvalua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaTramite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    Grado = table.Column<int>(type: "int", nullable: false),
                    IncidenciaCaso = table.Column<int>(type: "int", nullable: false),
                    InvestCampo = table.Column<int>(type: "int", nullable: false),
                    InvestDAC = table.Column<int>(type: "int", nullable: false),
                    Lote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Monitoreo = table.Column<int>(type: "int", nullable: false),
                    NombreOrgInst = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NotificacionRFV = table.Column<int>(type: "int", nullable: false),
                    Notificador = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Presentacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ProvRegionOrigen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ResolEmitidas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResultControlCalidad = table.Column<int>(type: "int", nullable: false),
                    RevisionRs = table.Column<int>(type: "int", nullable: false),
                    SubGrupoTer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TipoNotificador = table.Column<int>(type: "int", nullable: false),
                    TipoOrgInst = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_FMV_FfNotificacion_FfId",
                table: "FMV_FfNotificacion",
                column: "FfId");
        }
    }
}
