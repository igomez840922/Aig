using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M115 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosAlmacenProductosFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB");

            migrationBuilder.DropColumn(
                name: "DatosAnuncioFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB");

            migrationBuilder.RenameColumn(
                name: "DatosRegMovimientoExistenciaFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "RegMovimientoExistencia");

            migrationBuilder.RenameColumn(
                name: "DatosProcedimientoFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "Procedimientos");

            migrationBuilder.RenameColumn(
                name: "DatosPersonalTecnico",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "InventarioMedicamento");

            migrationBuilder.RenameColumn(
                name: "DatosGeneralesFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "ExpPersonalFarmacia");

            migrationBuilder.RenameColumn(
                name: "DatosExpedienteColaborador",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "EstructOrganizFarmacia");

            migrationBuilder.RenameColumn(
                name: "DatosEstructuraFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "AreaProdControlados");

            migrationBuilder.RenameColumn(
                name: "DatosEquipoRegistroFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "AreaFisicaFarmacia");

            migrationBuilder.RenameColumn(
                name: "DatosConclusiones",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "AreaAlmacenMedicamentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "VigenteDesde",
                table: "_DatosEstablecimiento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VigenteHasta",
                table: "_DatosEstablecimiento",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VigenteDesde",
                table: "_DatosEstablecimiento");

            migrationBuilder.DropColumn(
                name: "VigenteHasta",
                table: "_DatosEstablecimiento");

            migrationBuilder.RenameColumn(
                name: "RegMovimientoExistencia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosRegMovimientoExistenciaFarmacia");

            migrationBuilder.RenameColumn(
                name: "Procedimientos",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosProcedimientoFarmacia");

            migrationBuilder.RenameColumn(
                name: "InventarioMedicamento",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosPersonalTecnico");

            migrationBuilder.RenameColumn(
                name: "ExpPersonalFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosGeneralesFarmacia");

            migrationBuilder.RenameColumn(
                name: "EstructOrganizFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosExpedienteColaborador");

            migrationBuilder.RenameColumn(
                name: "AreaProdControlados",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosEstructuraFarmacia");

            migrationBuilder.RenameColumn(
                name: "AreaFisicaFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosEquipoRegistroFarmacia");

            migrationBuilder.RenameColumn(
                name: "AreaAlmacenMedicamentos",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosConclusiones");

            migrationBuilder.AddColumn<string>(
                name: "DatosAlmacenProductosFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAnuncioFarmacia",
                table: "AUD_InspRutinaVigFarmaciaTB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
