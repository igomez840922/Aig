using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M117 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "Productos");

            migrationBuilder.RenameColumn(
                name: "GenEstablecimiento",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "CondCaractEstablecimiento");

            migrationBuilder.RenameColumn(
                name: "DatosConclusiones",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaRecepcionProducto");

            migrationBuilder.RenameColumn(
                name: "AreaSustanciasControladas",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaProductosRetiradosMercado");

            migrationBuilder.RenameColumn(
                name: "AreaRecepProductos",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaProductosDevueltosVencidos");

            migrationBuilder.RenameColumn(
                name: "AreaProdDevueltos",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaAlmacenProdVolatiles");

            migrationBuilder.RenameColumn(
                name: "AreaDesperdicio",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaAlmacenProdSujetosControl");

            migrationBuilder.RenameColumn(
                name: "AreaAlmCadenaFrio",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaAlmacenProdReqCadenaFrio");

            migrationBuilder.RenameColumn(
                name: "ActividadDistribucion",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaAlmacenPlaguicidas");

            migrationBuilder.AddColumn<string>(
                name: "Actividades",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaAdministrativa",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaAlmacenMateriaPrima",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actividades",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaAdministrativa",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "AreaAlmacenMateriaPrima",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.RenameColumn(
                name: "Productos",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "GeneralesEmpresa");

            migrationBuilder.RenameColumn(
                name: "CondCaractEstablecimiento",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "GenEstablecimiento");

            migrationBuilder.RenameColumn(
                name: "AreaRecepcionProducto",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "DatosConclusiones");

            migrationBuilder.RenameColumn(
                name: "AreaProductosRetiradosMercado",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaSustanciasControladas");

            migrationBuilder.RenameColumn(
                name: "AreaProductosDevueltosVencidos",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaRecepProductos");

            migrationBuilder.RenameColumn(
                name: "AreaAlmacenProdVolatiles",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaProdDevueltos");

            migrationBuilder.RenameColumn(
                name: "AreaAlmacenProdSujetosControl",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaDesperdicio");

            migrationBuilder.RenameColumn(
                name: "AreaAlmacenProdReqCadenaFrio",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "AreaAlmCadenaFrio");

            migrationBuilder.RenameColumn(
                name: "AreaAlmacenPlaguicidas",
                table: "AUD_InspRutinaVigAgenciaTB",
                newName: "ActividadDistribucion");
        }
    }
}
