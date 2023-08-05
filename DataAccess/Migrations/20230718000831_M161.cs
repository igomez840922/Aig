using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M161 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Regente",
                table: "AUD_Establecimiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepresentanteLegal",
                table: "AUD_Establecimiento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Regente",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "RepresentanteLegal",
                table: "AUD_Establecimiento");
        }
    }
}
