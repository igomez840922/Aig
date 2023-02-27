using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M131 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoInspec",
                table: "AUD_InspGuiaBPM_BpaTB");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspGuiaBPM_BpaTB");

            migrationBuilder.DropColumn(
                name: "DispGenerlestablecimiento",
                table: "AUD_InspGuiaBPM_BpaTB");

            migrationBuilder.RenameColumn(
                name: "RepresentLegal",
                table: "AUD_InspGuiaBPM_BpaTB",
                newName: "DatosRepresentLegal");

            migrationBuilder.RenameColumn(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiaBPM_BpaTB",
                newName: "DatosRegente");

            migrationBuilder.RenameColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiaBPM_BpaTB",
                newName: "ActComercialAprobada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspGuiaBPM_BpaTB",
                newName: "RepresentLegal");

            migrationBuilder.RenameColumn(
                name: "DatosRegente",
                table: "AUD_InspGuiaBPM_BpaTB",
                newName: "RegenteFarmaceutico");

            migrationBuilder.RenameColumn(
                name: "ActComercialAprobada",
                table: "AUD_InspGuiaBPM_BpaTB",
                newName: "GeneralesEmpresa");

            migrationBuilder.AddColumn<string>(
                name: "AutoInspec",
                table: "AUD_InspGuiaBPM_BpaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspGuiaBPM_BpaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DispGenerlestablecimiento",
                table: "AUD_InspGuiaBPM_BpaTB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
