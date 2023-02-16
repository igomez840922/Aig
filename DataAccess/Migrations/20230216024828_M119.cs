using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M119 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdjuntaActaRetencion",
                table: "AUD_InspInvestigacionTB");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspInvestigacionTB");

            migrationBuilder.DropColumn(
                name: "DatosEstablecimiento",
                table: "AUD_InspInvestigacionTB");

            migrationBuilder.DropColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspInvestigacionTB");

            migrationBuilder.DropColumn(
                name: "DetalleInspeccion",
                table: "AUD_InspInvestigacionTB");

            migrationBuilder.DropColumn(
                name: "MovilizarProductos",
                table: "AUD_InspInvestigacionTB");

            migrationBuilder.RenameColumn(
                name: "DetalleVerificacion",
                table: "AUD_InspInvestigacionTB",
                newName: "DetallesInvestigacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetallesInvestigacion",
                table: "AUD_InspInvestigacionTB",
                newName: "DetalleVerificacion");

            migrationBuilder.AddColumn<int>(
                name: "AdjuntaActaRetencion",
                table: "AUD_InspInvestigacionTB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspInvestigacionTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosEstablecimiento",
                table: "AUD_InspInvestigacionTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosRepresentLegal",
                table: "AUD_InspInvestigacionTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetalleInspeccion",
                table: "AUD_InspInvestigacionTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovilizarProductos",
                table: "AUD_InspInvestigacionTB",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
