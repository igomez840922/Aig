using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M118 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventarioAlAzar",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "InventarioCompleto",
                table: "AUD_InspRutinaVigAgenciaTB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventarioAlAzar",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventarioCompleto",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
