using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M078 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Establecimiento",
                table: "AUD_Correspondencia",
                newName: "Empresa");

            migrationBuilder.AddColumn<string>(
                name: "EstablecimientoAsignado",
                table: "AUD_Correspondencia",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablecimientoCorregimiento",
                table: "AUD_Correspondencia",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablecimientoNombre",
                table: "AUD_Correspondencia",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablecimientoNumLic",
                table: "AUD_Correspondencia",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablecimientoUbicacion",
                table: "AUD_Correspondencia",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstablecimientoAsignado",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "EstablecimientoCorregimiento",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "EstablecimientoNombre",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "EstablecimientoNumLic",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "EstablecimientoUbicacion",
                table: "AUD_Correspondencia");

            migrationBuilder.RenameColumn(
                name: "Empresa",
                table: "AUD_Correspondencia",
                newName: "Establecimiento");
        }
    }
}
