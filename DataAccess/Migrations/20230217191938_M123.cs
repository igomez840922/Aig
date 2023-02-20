using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adjunta",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "Coincide",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "DatosResponsable",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "NumNotaSDGSA",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "NumReciboPago",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "PesoDestruir",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "TipoInspeccion",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "TipoProduct",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "TipoVerificacion",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.RenameColumn(
                name: "SolicitudCierre",
                table: "AUD_InspDisposicionFinalTB",
                newName: "DatosInspeccion");

            migrationBuilder.RenameColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspDisposicionFinalTB",
                newName: "DatosAtendidosPor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosInspeccion",
                table: "AUD_InspDisposicionFinalTB",
                newName: "SolicitudCierre");

            migrationBuilder.RenameColumn(
                name: "DatosAtendidosPor",
                table: "AUD_InspDisposicionFinalTB",
                newName: "GeneralesEmpresa");

            migrationBuilder.AddColumn<bool>(
                name: "Adjunta",
                table: "AUD_InspDisposicionFinalTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Coincide",
                table: "AUD_InspDisposicionFinalTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspDisposicionFinalTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosResponsable",
                table: "AUD_InspDisposicionFinalTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumNotaSDGSA",
                table: "AUD_InspDisposicionFinalTB",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumReciboPago",
                table: "AUD_InspDisposicionFinalTB",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PesoDestruir",
                table: "AUD_InspDisposicionFinalTB",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TipoInspeccion",
                table: "AUD_InspDisposicionFinalTB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoProduct",
                table: "AUD_InspDisposicionFinalTB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoVerificacion",
                table: "AUD_InspDisposicionFinalTB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "AUD_InspDisposicionFinalTB",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
