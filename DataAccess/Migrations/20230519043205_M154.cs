using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M154 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaExpLicEspecial",
                table: "AUD_InspGuiaBPM_BpaTB",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicEspSustanciasCtr",
                table: "AUD_InspGuiaBPM_BpaTB",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaExpLicEspecial",
                table: "AUD_InspGuiaBPM_BpaTB");

            migrationBuilder.DropColumn(
                name: "LicEspSustanciasCtr",
                table: "AUD_InspGuiaBPM_BpaTB");
        }
    }
}
