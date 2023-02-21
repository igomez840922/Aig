using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M114 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosActProd",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "DatosAtendidosPor",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "DatosCondicionesLocal",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "DatosEstablecimiento",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "ReciboPago",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.AddColumn<string>(
                name: "HorariosAtencion",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorariosAtencion",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.AddColumn<string>(
                name: "DatosActProd",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAtendidosPor",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosCondicionesLocal",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosEstablecimiento",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosRepresentLegal",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReciboPago",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
