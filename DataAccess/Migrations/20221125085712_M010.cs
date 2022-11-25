using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DatosAtendidosPor",
                table: "AUD_InspAperCambUbicFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosAtendidosPor",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosAtendidosPor",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "DatosAtendidosPor",
                table: "AUD_InspAperCambUbicAgen");
        }
    }
}
