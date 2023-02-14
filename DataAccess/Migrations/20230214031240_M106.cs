using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaAlmacenProdReqCadenaFrio",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaDespachoProductos",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaProductosRetiradosMercado",
                table: "AUD_InspAperCambUbicAgen",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaAlmacenProdReqCadenaFrio",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "AreaDespachoProductos",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "AreaProductosRetiradosMercado",
                table: "AUD_InspAperCambUbicAgen");
        }
    }
}
