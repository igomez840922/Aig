using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DatosAreaAlmacenamiento",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAreaFisica",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAreaProductosControlados",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosInfraEstructura",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosPreguntasGenericas",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosSenalizacionAvisos",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosAreaAlmacenamiento",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosAreaFisica",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosAreaProductosControlados",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosInfraEstructura",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosPreguntasGenericas",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosSenalizacionAvisos",
                table: "AUD_InspAperCambUbicFarm");
        }
    }
}
