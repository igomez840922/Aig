using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M076 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RamDesc",
                table: "FMV_Ram2",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EsaviDesc",
                table: "FMV_Esavi2",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RamDesc",
                table: "FMV_Ram2");

            migrationBuilder.DropColumn(
                name: "EsaviDesc",
                table: "FMV_Esavi2");
        }
    }
}
