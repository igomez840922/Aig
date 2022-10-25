using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegSanitario",
                table: "AUD_Inspeccion",
                newName: "RepreLegalIdentificacion");

            migrationBuilder.AddColumn<string>(
                name: "RegSanitario",
                table: "AUD_ProdRetiroRetencion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RetiroRetencionType",
                table: "AUD_InspRetiroRetencion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AvisoOperación",
                table: "AUD_Inspeccion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD1",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD2",
                table: "AUD_Inspeccion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaEstablec1",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaEstablec2",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumRegDNFD1",
                table: "AUD_Inspeccion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumRegDNFD2",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParticEstablecimiento",
                table: "AUD_Inspeccion",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParticEstablecimientoCIP",
                table: "AUD_Inspeccion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParticEstablecimientoCargo",
                table: "AUD_Inspeccion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParticipantesDNFD",
                table: "AUD_Inspeccion",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepreLegal",
                table: "AUD_Inspeccion",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusInspecciones",
                table: "AUD_Inspeccion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UbicacionEstablecimiento",
                table: "AUD_Inspeccion",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegSanitario",
                table: "AUD_ProdRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "RetiroRetencionType",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "AvisoOperación",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD1",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD2",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaEstablec1",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaEstablec2",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "NumRegDNFD1",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "NumRegDNFD2",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "ParticEstablecimiento",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "ParticEstablecimientoCIP",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "ParticEstablecimientoCargo",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "ParticipantesDNFD",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "RepreLegal",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "StatusInspecciones",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "UbicacionEstablecimiento",
                table: "AUD_Inspeccion");

            migrationBuilder.RenameColumn(
                name: "RepreLegalIdentificacion",
                table: "AUD_Inspeccion",
                newName: "RegSanitario");
        }
    }
}
