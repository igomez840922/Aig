using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M127 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiaBPMFabricanteMed");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspGuiaBPMFabricanteMed");

            migrationBuilder.DropColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiaBPMFabricanteMed");

            migrationBuilder.DropColumn(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiaBPMFabricanteMed");

            migrationBuilder.DropColumn(
                name: "RepresentLegal",
                table: "AUD_InspGuiaBPMFabricanteMed");

            migrationBuilder.RenameColumn(
                name: "RespProduccion",
                table: "AUD_InspGuiaBPMFabricanteMed",
                newName: "DatosRepresentLegal");

            migrationBuilder.RenameColumn(
                name: "RespControlCalidad",
                table: "AUD_InspGuiaBPMFabricanteMed",
                newName: "DatosRegente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspGuiaBPMFabricanteMed",
                newName: "RespProduccion");

            migrationBuilder.RenameColumn(
                name: "DatosRegente",
                table: "AUD_InspGuiaBPMFabricanteMed",
                newName: "RespControlCalidad");

            migrationBuilder.AddColumn<string>(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiaBPMFabricanteMed",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspGuiaBPMFabricanteMed",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiaBPMFabricanteMed",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiaBPMFabricanteMed",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepresentLegal",
                table: "AUD_InspGuiaBPMFabricanteMed",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
