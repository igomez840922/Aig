using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M129 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB");

            migrationBuilder.DropColumn(
                name: "ClasifEstablecimiento2",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB");

            migrationBuilder.DropColumn(
                name: "GenEstructuraOrganizativa",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB");

            migrationBuilder.DropColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB");

            migrationBuilder.DropColumn(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB");

            migrationBuilder.RenameColumn(
                name: "RespProduccion",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                newName: "DatosRepresentLegal");

            migrationBuilder.RenameColumn(
                name: "RespControlCalidad",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                newName: "DatosRegente");

            migrationBuilder.RenameColumn(
                name: "RepresentLegal",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                newName: "AdminInfoGeneral");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                newName: "RespProduccion");

            migrationBuilder.RenameColumn(
                name: "DatosRegente",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                newName: "RespControlCalidad");

            migrationBuilder.RenameColumn(
                name: "AdminInfoGeneral",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                newName: "RepresentLegal");

            migrationBuilder.AddColumn<string>(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClasifEstablecimiento2",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenEstructuraOrganizativa",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
