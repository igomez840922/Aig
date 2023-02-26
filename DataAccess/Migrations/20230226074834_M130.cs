using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M130 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiBPMFabNatMedicinaTB");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspGuiBPMFabNatMedicinaTB");

            migrationBuilder.DropColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiBPMFabNatMedicinaTB");

            migrationBuilder.DropColumn(
                name: "MotivoInspeccion",
                table: "AUD_InspGuiBPMFabNatMedicinaTB");

            migrationBuilder.RenameColumn(
                name: "RepresentLegal",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                newName: "DatosRepresentLegal");

            migrationBuilder.RenameColumn(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                newName: "DatosRegente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                newName: "RepresentLegal");

            migrationBuilder.RenameColumn(
                name: "DatosRegente",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                newName: "RegenteFarmaceutico");

            migrationBuilder.AddColumn<string>(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivoInspeccion",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
