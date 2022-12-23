using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActividadDistribucion",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaAlmCadenaFrio",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaAlmacenamiento",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaDespachoProductos",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaDesperdicio",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaProdDevueltos",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaRecepProductos",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaSustanciasControladas",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosRegente",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosRepresentLegal",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenEstablecimiento",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralesEmpresa",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventarioMedicamento",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Procedimientos",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transporte",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActividadDistribucion",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaAlmCadenaFrio",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaAlmacenamiento",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaDespachoProductos",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaDesperdicio",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaProdDevueltos",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaRecepProductos",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaSustanciasControladas",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "DatosRegente",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "DatosRepresentLegal",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "GenEstablecimiento",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "InventarioMedicamento",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "Procedimientos",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "Transporte",
                table: "AUD_InspRutinaVigAgenciaTB");
        }
    }
}
