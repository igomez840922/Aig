using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M132 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutoInspec",
                table: "AUD_InspGuiaBPM_BpaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DispGenerlestablecimiento",
                table: "AUD_InspGuiaBPM_BpaTB",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoInspec",
                table: "AUD_InspGuiaBPM_BpaTB");

            migrationBuilder.DropColumn(
                name: "DispGenerlestablecimiento",
                table: "AUD_InspGuiaBPM_BpaTB");
        }
    }
}
