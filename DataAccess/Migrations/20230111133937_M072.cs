using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M072 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Concentracion",
                table: "FMV_Ft",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Concominantes",
                table: "FMV_Ft",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormaFarmaceutica",
                table: "FMV_Ft",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concentracion",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Concominantes",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "FormaFarmaceutica",
                table: "FMV_Ft");
        }
    }
}
