using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M124 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosAreaAlmacenamiento",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "DatosAreaAuxiliares",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "DatosAreaDispensado",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "DatosAreaExterna",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "DatosAreaInterna",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "DatosAreaLabCtrCalidad",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "TipoProductos",
                table: "AUD_InspAperFabricante");

            migrationBuilder.RenameColumn(
                name: "DatosSolicitante",
                table: "AUD_InspAperFabricante",
                newName: "ProdFabrican");

            migrationBuilder.RenameColumn(
                name: "DatosReclamoProductoRetirado",
                table: "AUD_InspAperFabricante",
                newName: "Personal");

            migrationBuilder.RenameColumn(
                name: "DatosProdAnalisisContrato",
                table: "AUD_InspAperFabricante",
                newName: "MaterialesProductos");

            migrationBuilder.RenameColumn(
                name: "DatosProcedimientoPrograma",
                table: "AUD_InspAperFabricante",
                newName: "Instalaciones");

            migrationBuilder.RenameColumn(
                name: "DatosLocal",
                table: "AUD_InspAperFabricante",
                newName: "Equipos");

            migrationBuilder.RenameColumn(
                name: "DatosEstablecimiento",
                table: "AUD_InspAperFabricante",
                newName: "ControlCalidad");

            migrationBuilder.RenameColumn(
                name: "DatosEquipos",
                table: "AUD_InspAperFabricante",
                newName: "AreaProduccion");

            migrationBuilder.RenameColumn(
                name: "DatosDocumentacion",
                table: "AUD_InspAperFabricante",
                newName: "AreaDispMateriaPrima");

            migrationBuilder.RenameColumn(
                name: "DatosConclusiones",
                table: "AUD_InspAperFabricante",
                newName: "AreaAuxiliares");

            migrationBuilder.RenameColumn(
                name: "DatosAutoInspeccion",
                table: "AUD_InspAperFabricante",
                newName: "AreaAlmacenamiento");

            migrationBuilder.RenameColumn(
                name: "DatosAreaProduccion",
                table: "AUD_InspAperFabricante",
                newName: "AreaAcondSecundario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdFabrican",
                table: "AUD_InspAperFabricante",
                newName: "DatosSolicitante");

            migrationBuilder.RenameColumn(
                name: "Personal",
                table: "AUD_InspAperFabricante",
                newName: "DatosReclamoProductoRetirado");

            migrationBuilder.RenameColumn(
                name: "MaterialesProductos",
                table: "AUD_InspAperFabricante",
                newName: "DatosProdAnalisisContrato");

            migrationBuilder.RenameColumn(
                name: "Instalaciones",
                table: "AUD_InspAperFabricante",
                newName: "DatosProcedimientoPrograma");

            migrationBuilder.RenameColumn(
                name: "Equipos",
                table: "AUD_InspAperFabricante",
                newName: "DatosLocal");

            migrationBuilder.RenameColumn(
                name: "ControlCalidad",
                table: "AUD_InspAperFabricante",
                newName: "DatosEstablecimiento");

            migrationBuilder.RenameColumn(
                name: "AreaProduccion",
                table: "AUD_InspAperFabricante",
                newName: "DatosEquipos");

            migrationBuilder.RenameColumn(
                name: "AreaDispMateriaPrima",
                table: "AUD_InspAperFabricante",
                newName: "DatosDocumentacion");

            migrationBuilder.RenameColumn(
                name: "AreaAuxiliares",
                table: "AUD_InspAperFabricante",
                newName: "DatosConclusiones");

            migrationBuilder.RenameColumn(
                name: "AreaAlmacenamiento",
                table: "AUD_InspAperFabricante",
                newName: "DatosAutoInspeccion");

            migrationBuilder.RenameColumn(
                name: "AreaAcondSecundario",
                table: "AUD_InspAperFabricante",
                newName: "DatosAreaProduccion");

            migrationBuilder.AddColumn<string>(
                name: "DatosAreaAlmacenamiento",
                table: "AUD_InspAperFabricante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAreaAuxiliares",
                table: "AUD_InspAperFabricante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAreaDispensado",
                table: "AUD_InspAperFabricante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAreaExterna",
                table: "AUD_InspAperFabricante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAreaInterna",
                table: "AUD_InspAperFabricante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAreaLabCtrCalidad",
                table: "AUD_InspAperFabricante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoProductos",
                table: "AUD_InspAperFabricante",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
