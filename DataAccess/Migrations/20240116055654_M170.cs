using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M170 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actividad",
                table: "AUD_Establecimiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Corregidor",
                table: "AUD_Establecimiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirAdministrativa",
                table: "AUD_Establecimiento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actividad",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "Corregidor",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "DirAdministrativa",
                table: "AUD_Establecimiento");
        }
    }
}
