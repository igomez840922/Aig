using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosAreaDispensado",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "DatosAreaExterna",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "DatosAreaInterna",
                table: "AUD_InspAperFabricante");
        }
    }
}
