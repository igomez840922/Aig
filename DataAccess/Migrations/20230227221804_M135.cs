using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M135 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspAperturaCosmetArtesanalTB");

            migrationBuilder.DropColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspAperturaCosmetArtesanalTB");

            migrationBuilder.DropColumn(
                name: "Inconformidades",
                table: "AUD_InspAperturaCosmetArtesanalTB");

            migrationBuilder.RenameColumn(
                name: "Propietario",
                table: "AUD_InspAperturaCosmetArtesanalTB",
                newName: "DatosRepresentLegal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspAperturaCosmetArtesanalTB",
                newName: "Propietario");

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspAperturaCosmetArtesanalTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralesEmpresa",
                table: "AUD_InspAperturaCosmetArtesanalTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Inconformidades",
                table: "AUD_InspAperturaCosmetArtesanalTB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
