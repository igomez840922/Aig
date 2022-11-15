using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoInspeccion",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.AddColumn<string>(
                name: "TelefonoEstablecimiento",
                table: "AUD_Inspeccion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefonoEstablecimiento",
                table: "AUD_Inspeccion");

            migrationBuilder.AddColumn<int>(
                name: "TipoInspeccion",
                table: "AUD_InspAperCambUbicFarm",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
