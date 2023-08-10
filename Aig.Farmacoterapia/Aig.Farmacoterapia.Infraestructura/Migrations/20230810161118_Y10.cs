using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aig.Farmacoterapia.Infrastructure.Migrations
{
    public partial class Y10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Producto",
                table: "AigRecord",
                newName: "Producto_VidaUtil");

            migrationBuilder.RenameColumn(
                name: "Fabricante",
                table: "AigRecord",
                newName: "Producto_ViaAdministracion");

            migrationBuilder.RenameColumn(
                name: "Distribuidor",
                table: "AigRecord",
                newName: "Producto_PrincipioActivo");

            migrationBuilder.AddColumn<string>(
                name: "Distribuidor_NombreAcondicionadorPrimario",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distribuidor_NombreAcondicionadorSecundario",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distribuidor_NombreDistribuidorNacional",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distribuidor_NombreTitular",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante_Correo",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante_Direccion",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante_Nombre",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante_Pais",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante_PaisISO2",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante_PaisISO3",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producto_ClasificacionMedica",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producto_CondicionVenta",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producto_DescripcionEnvase",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producto_FormaFarmaceutica",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producto_Nombre",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distribuidor_NombreAcondicionadorPrimario",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Distribuidor_NombreAcondicionadorSecundario",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Distribuidor_NombreDistribuidorNacional",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Distribuidor_NombreTitular",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Fabricante_Correo",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Fabricante_Direccion",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Fabricante_Nombre",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Fabricante_Pais",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Fabricante_PaisISO2",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Fabricante_PaisISO3",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Producto_ClasificacionMedica",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Producto_CondicionVenta",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Producto_DescripcionEnvase",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Producto_FormaFarmaceutica",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Producto_Nombre",
                table: "AigRecord");

            migrationBuilder.RenameColumn(
                name: "Producto_VidaUtil",
                table: "AigRecord",
                newName: "Producto");

            migrationBuilder.RenameColumn(
                name: "Producto_ViaAdministracion",
                table: "AigRecord",
                newName: "Fabricante");

            migrationBuilder.RenameColumn(
                name: "Producto_PrincipioActivo",
                table: "AigRecord",
                newName: "Distribuidor");
        }
    }
}
