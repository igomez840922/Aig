using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M048 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_EsaviNotificacion_FMV_Esavi_EsaviId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropIndex(
                name: "IX_FMV_EsaviNotificacion_EsaviId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropColumn(
                name: "EsaviId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.AlterColumn<string>(
                name: "IdFacedra",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoNotiFacedra",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Desenlace",
                table: "FMV_Esavi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DosisEsavi",
                table: "FMV_Esavi",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DosisViaAdmin",
                table: "FMV_Esavi",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElegibilidadGravedad",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElegibilidadOtroCriterio",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElegibleEvaluacionCausal",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EsaviDescripcion",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEsavi",
                table: "FMV_Esavi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaExp",
                table: "FMV_Esavi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVacunacion",
                table: "FMV_Esavi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gravedad",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HayEsavi",
                table: "FMV_Esavi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Indicaciones",
                table: "FMV_Esavi",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IntensidadEsaviId",
                table: "FMV_Esavi",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LaboratorioId",
                table: "FMV_Esavi",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lote",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notificador",
                table: "FMV_Esavi",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OtrosCriterios",
                table: "FMV_Esavi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProbabilidadAsociacion",
                table: "FMV_Esavi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegSanitario",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soc",
                table: "FMV_Esavi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SocId",
                table: "FMV_Esavi",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminoWhoArt",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoVacunaId",
                table: "FMV_Esavi",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VacunaComercial",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_IntensidadEsaviId",
                table: "FMV_Esavi",
                column: "IntensidadEsaviId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_LaboratorioId",
                table: "FMV_Esavi",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_TipoVacunaId",
                table: "FMV_Esavi",
                column: "TipoVacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Esavi_IntensidadEsavi_IntensidadEsaviId",
                table: "FMV_Esavi",
                column: "IntensidadEsaviId",
                principalTable: "IntensidadEsavi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Esavi_Laboratorio_LaboratorioId",
                table: "FMV_Esavi",
                column: "LaboratorioId",
                principalTable: "Laboratorio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Esavi_TipoVacuna_TipoVacunaId",
                table: "FMV_Esavi",
                column: "TipoVacunaId",
                principalTable: "TipoVacuna",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Esavi_IntensidadEsavi_IntensidadEsaviId",
                table: "FMV_Esavi");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Esavi_Laboratorio_LaboratorioId",
                table: "FMV_Esavi");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Esavi_TipoVacuna_TipoVacunaId",
                table: "FMV_Esavi");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Esavi_IntensidadEsaviId",
                table: "FMV_Esavi");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Esavi_LaboratorioId",
                table: "FMV_Esavi");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Esavi_TipoVacunaId",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "Desenlace",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "DosisEsavi",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "DosisViaAdmin",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "ElegibilidadGravedad",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "ElegibilidadOtroCriterio",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "ElegibleEvaluacionCausal",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "EsaviDescripcion",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "FechaEsavi",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "FechaExp",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "FechaVacunacion",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "Gravedad",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "HayEsavi",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "Indicaciones",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "IntensidadEsaviId",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "LaboratorioId",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "Lote",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "Notificador",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "OtrosCriterios",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "ProbabilidadAsociacion",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "RegSanitario",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "Soc",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "SocId",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "TerminoWhoArt",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "TipoVacunaId",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "VacunaComercial",
                table: "FMV_Esavi");

            migrationBuilder.AddColumn<long>(
                name: "EsaviId",
                table: "FMV_EsaviNotificacion",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "IdFacedra",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoNotiFacedra",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviNotificacion_EsaviId",
                table: "FMV_EsaviNotificacion",
                column: "EsaviId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_EsaviNotificacion_FMV_Esavi_EsaviId",
                table: "FMV_EsaviNotificacion",
                column: "EsaviId",
                principalTable: "FMV_Esavi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
