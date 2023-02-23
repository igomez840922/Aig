using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M128 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB");

            migrationBuilder.DropColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB");

            migrationBuilder.DropColumn(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB");

            migrationBuilder.DropColumn(
                name: "RepresentLegal",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB");

            migrationBuilder.RenameColumn(
                name: "RespProduccion",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                newName: "DatosRepresentLegal");

            migrationBuilder.RenameColumn(
                name: "RespControlCalidad",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                newName: "DatosRegente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                newName: "RespProduccion");

            migrationBuilder.RenameColumn(
                name: "DatosRegente",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                newName: "RespControlCalidad");

            migrationBuilder.AddColumn<string>(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepresentLegal",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
