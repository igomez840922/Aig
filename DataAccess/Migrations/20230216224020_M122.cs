using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "DatosRegente",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "SeccionOficinaRegional",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspCierreOperacionTB");

            migrationBuilder.DropColumn(
                name: "DatosResponsable",
                table: "AUD_InspCierreOperacionTB");

            migrationBuilder.DropColumn(
                name: "DestinoProductos",
                table: "AUD_InspCierreOperacionTB");

            migrationBuilder.DropColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspCierreOperacionTB");

            migrationBuilder.RenameColumn(
                name: "SolicitudCierre",
                table: "AUD_InspCierreOperacionTB",
                newName: "DatosRepresentLegal");

            migrationBuilder.RenameColumn(
                name: "ObservacionUbicacion",
                table: "AUD_InspCierreOperacionTB",
                newName: "DatosInspeccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspCierreOperacionTB",
                newName: "SolicitudCierre");

            migrationBuilder.RenameColumn(
                name: "DatosInspeccion",
                table: "AUD_InspCierreOperacionTB",
                newName: "ObservacionUbicacion");

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspRetiroRetencion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosRegente",
                table: "AUD_InspRetiroRetencion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeccionOficinaRegional",
                table: "AUD_InspRetiroRetencion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspCierreOperacionTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosResponsable",
                table: "AUD_InspCierreOperacionTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinoProductos",
                table: "AUD_InspCierreOperacionTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralesEmpresa",
                table: "AUD_InspCierreOperacionTB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
