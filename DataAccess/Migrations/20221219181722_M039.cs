using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M039 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "FMV_Rfv");

            migrationBuilder.AddColumn<int>(
                name: "TipoCargo",
                table: "FMV_Rfv",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoCargo",
                table: "FMV_Rfv");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "FMV_Rfv",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
