using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M088 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Biologico",
                table: "MV_Ips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Innovador",
                table: "MV_Ips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomDCI",
                table: "MV_Ips",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReqIntercam",
                table: "MV_Ips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "MV_Ips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biologico",
                table: "MV_Ips");

            migrationBuilder.DropColumn(
                name: "Innovador",
                table: "MV_Ips");

            migrationBuilder.DropColumn(
                name: "NomDCI",
                table: "MV_Ips");

            migrationBuilder.DropColumn(
                name: "ReqIntercam",
                table: "MV_Ips");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "MV_Ips");
        }
    }
}
