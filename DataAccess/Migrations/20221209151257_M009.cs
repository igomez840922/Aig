using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccionesRegulatoria",
                table: "FMV_RamNotificacion");

            migrationBuilder.DropColumn(
                name: "EvaluacionCalidadInfo",
                table: "FMV_RamNotificacion");

            migrationBuilder.DropColumn(
                name: "EvaluacionCausalidad",
                table: "FMV_RamNotificacion");

            migrationBuilder.DropColumn(
                name: "ObservacionInfoNotifica",
                table: "FMV_RamNotificacion");

            migrationBuilder.RenameColumn(
                name: "ValUnico",
                table: "FMV_Ram",
                newName: "TipoOrgInst");

            migrationBuilder.AddColumn<string>(
                name: "AccionesRegulatoria",
                table: "FMV_Ram",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodExterno",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "FMV_Ram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionCalidadInfo",
                table: "FMV_Ram",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionCausalidad",
                table: "FMV_Ram",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEvaluacion",
                table: "FMV_Ram",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreOrgInst",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumIngresoVigiflow",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservacionInfoNotifica",
                table: "FMV_Ram",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvRegionOrigen",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoNotificador",
                table: "FMV_Ram",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccionesRegulatoria",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "CodExterno",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "EvaluacionCalidadInfo",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "EvaluacionCausalidad",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "FechaEvaluacion",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "NombreOrgInst",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "NumIngresoVigiflow",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "ObservacionInfoNotifica",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "ProvRegionOrigen",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "TipoNotificador",
                table: "FMV_Ram");

            migrationBuilder.RenameColumn(
                name: "TipoOrgInst",
                table: "FMV_Ram",
                newName: "ValUnico");

            migrationBuilder.AddColumn<string>(
                name: "AccionesRegulatoria",
                table: "FMV_RamNotificacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionCalidadInfo",
                table: "FMV_RamNotificacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionCausalidad",
                table: "FMV_RamNotificacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservacionInfoNotifica",
                table: "FMV_RamNotificacion",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
