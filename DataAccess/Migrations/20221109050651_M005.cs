using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirmaDNFD1",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD2",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD3",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD4",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD5",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD6",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD7",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "FirmaDNFD8",
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

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspRetiroRetencion",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD1",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD2",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD3",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD4",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD5",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD6",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD7",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaDNFD8",
                table: "AUD_Inspeccion",
                type: "nvarchar(max)",
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
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
