using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M099 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__DatosEstablecimiento_AUD_Establecimiento_EstablecimientoId",
                table: "_DatosEstablecimiento");

            migrationBuilder.DropIndex(
                name: "IX__DatosEstablecimiento_EstablecimientoId",
                table: "_DatosEstablecimiento");

            migrationBuilder.AddColumn<string>(
                name: "Establecimiento",
                table: "_DatosEstablecimiento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Establecimiento",
                table: "_DatosEstablecimiento");

            migrationBuilder.CreateIndex(
                name: "IX__DatosEstablecimiento_EstablecimientoId",
                table: "_DatosEstablecimiento",
                column: "EstablecimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK__DatosEstablecimiento_AUD_Establecimiento_EstablecimientoId",
                table: "_DatosEstablecimiento",
                column: "EstablecimientoId",
                principalTable: "AUD_Establecimiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
