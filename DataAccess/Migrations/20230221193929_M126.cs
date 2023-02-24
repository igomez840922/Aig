using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M126 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaAlmacenamiento",
                table: "AUD_InspAperFabricanteCosmetMed");

            migrationBuilder.DropColumn(
                name: "AreaAuxiliar",
                table: "AUD_InspAperFabricanteCosmetMed");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspAperFabricanteCosmetMed");

            migrationBuilder.RenameColumn(
                name: "TipoProductos",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "SistemaCriticoApoyo");

            migrationBuilder.RenameColumn(
                name: "ReclamosProdRetirados",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "ProdFabrican");

            migrationBuilder.RenameColumn(
                name: "Programas",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "InspeccionAuditoria");

            migrationBuilder.RenameColumn(
                name: "ProdAnalisisContrato",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "EstructuraOrganizativa");

            migrationBuilder.RenameColumn(
                name: "OrganizacionPersonal",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "Documantacion");

            migrationBuilder.RenameColumn(
                name: "Locales",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "ControlCalidad");

            migrationBuilder.RenameColumn(
                name: "LaboratorioControlCalidad",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "AreasAuxiliares");

            migrationBuilder.RenameColumn(
                name: "Equipo",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "Almacenes");

            migrationBuilder.RenameColumn(
                name: "DatosEstablecimiento",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "Acondicionamiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SistemaCriticoApoyo",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "TipoProductos");

            migrationBuilder.RenameColumn(
                name: "ProdFabrican",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "ReclamosProdRetirados");

            migrationBuilder.RenameColumn(
                name: "InspeccionAuditoria",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "Programas");

            migrationBuilder.RenameColumn(
                name: "EstructuraOrganizativa",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "ProdAnalisisContrato");

            migrationBuilder.RenameColumn(
                name: "Documantacion",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "OrganizacionPersonal");

            migrationBuilder.RenameColumn(
                name: "ControlCalidad",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "Locales");

            migrationBuilder.RenameColumn(
                name: "AreasAuxiliares",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "LaboratorioControlCalidad");

            migrationBuilder.RenameColumn(
                name: "Almacenes",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "Equipo");

            migrationBuilder.RenameColumn(
                name: "Acondicionamiento",
                table: "AUD_InspAperFabricanteCosmetMed",
                newName: "DatosEstablecimiento");

            migrationBuilder.AddColumn<string>(
                name: "AreaAlmacenamiento",
                table: "AUD_InspAperFabricanteCosmetMed",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaAuxiliar",
                table: "AUD_InspAperFabricanteCosmetMed",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspAperFabricanteCosmetMed",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
