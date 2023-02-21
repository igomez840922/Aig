using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actividades",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Productos",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actividades",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "Productos",
                table: "AUD_InspAperCambUbicAgen");
        }
    }
}
