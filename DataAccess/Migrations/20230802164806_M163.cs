using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M163 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaAdministrativa",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.RenameColumn(
                name: "Procedimientos",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "DatosAreaAlmacenamientoAlcohol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatosAreaAlmacenamientoAlcohol",
                table: "AUD_InspRutinaVigFarmaciaTB",
                newName: "Procedimientos");

            migrationBuilder.AddColumn<string>(
                name: "AreaAdministrativa",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
