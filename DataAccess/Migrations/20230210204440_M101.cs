using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosAtendidosPor",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosEstablecimiento",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosSenalizacionAvisos",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "ReciboPago",
                table: "AUD_InspAperCambUbicFarm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DatosAtendidosPor",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosEstablecimiento",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosSenalizacionAvisos",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReciboPago",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
