using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.FarmacoVigilancia.Migrations
{
    public partial class M008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMV_FtNotificacion");

            migrationBuilder.RenameColumn(
                name: "FarmacoSospechosoDci",
                table: "FMV_Ft",
                newName: "NombreDci");

            migrationBuilder.RenameColumn(
                name: "FarmacoSospechosoComercial",
                table: "FMV_Ft",
                newName: "NombreComercial");

            migrationBuilder.AddColumn<string>(
                name: "ATC",
                table: "FMV_Ft",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atc2",
                table: "FMV_Ft",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosPaciente",
                table: "FMV_Ft",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "FMV_Ft",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionCausalidad",
                table: "FMV_Ft",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEvalua",
                table: "FMV_Ft",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaExp",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaTramite",
                table: "FMV_Ft",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidenciaCaso",
                table: "FMV_Ft",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "InstitucionDestinoId",
                table: "FMV_Ft",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InstitucionId",
                table: "FMV_Ft",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lote",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notificador",
                table: "FMV_Ft",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtrasEspecificaciones",
                table: "FMV_Ft",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Presentacion",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProvinciaId",
                table: "FMV_Ft",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegSanitario",
                table: "FMV_Ft",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResolEmitidas",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubGrupoTerapeutico",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoInstitucionId",
                table: "FMV_Ft",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoNotificacion",
                table: "FMV_Ft",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoNotificador",
                table: "FMV_Ft",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ft_InstitucionDestino_InstitucionDestinoId",
                table: "FMV_Ft",
                column: "InstitucionDestinoId",
                principalTable: "InstitucionDestino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ft_Provincia_ProvinciaId",
                table: "FMV_Ft",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ft_TipoInstitucion_TipoInstitucionId",
                table: "FMV_Ft",
                column: "TipoInstitucionId",
                principalTable: "TipoInstitucion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ft_InstitucionDestino_InstitucionDestinoId",
                table: "FMV_Ft");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ft_Provincia_ProvinciaId",
                table: "FMV_Ft");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ft_TipoInstitucion_TipoInstitucionId",
                table: "FMV_Ft");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ft_InstitucionDestinoId",
                table: "FMV_Ft");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ft_ProvinciaId",
                table: "FMV_Ft");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ft_TipoInstitucionId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "ATC",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Atc2",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "DatosPaciente",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "EvaluacionCausalidad",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "FechaEvalua",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "FechaExp",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "FechaTramite",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "IncidenciaCaso",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "InstitucionDestinoId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "InstitucionId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Lote",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Notificador",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "OtrasEspecificaciones",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Presentacion",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "RegSanitario",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "ResolEmitidas",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "SubGrupoTerapeutico",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "TipoInstitucionId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "TipoNotificacion",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "TipoNotificador",
                table: "FMV_Ft");

            migrationBuilder.RenameColumn(
                name: "NombreDci",
                table: "FMV_Ft",
                newName: "FarmacoSospechosoDci");

            migrationBuilder.RenameColumn(
                name: "NombreComercial",
                table: "FMV_Ft",
                newName: "FarmacoSospechosoComercial");

            migrationBuilder.CreateTable(
                name: "FMV_FtNotificacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FtId = table.Column<long>(type: "bigint", nullable: false),
                    Atc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    EvaluacionCausalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expira = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FallaReportada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEvalua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaTramite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    IncidenciaCaso = table.Column<int>(type: "int", nullable: false),
                    Lote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NombreOrgInst = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Notificador = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Presentacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ProvRegionOrigen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ResolEmitidas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubGrupoTer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TipoNotificador = table.Column<int>(type: "int", nullable: false),
                    TipoOrgInst = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_FMV_FtNotificacion_FtId",
                table: "FMV_FtNotificacion",
                column: "FtId");
        }
    }
}
