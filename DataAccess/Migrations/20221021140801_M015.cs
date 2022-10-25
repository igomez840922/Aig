using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "AUD_Inspeccion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "AUD_Inspeccion");

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "AUD_InspRetiroRetencion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
