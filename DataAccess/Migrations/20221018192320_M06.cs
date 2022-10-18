using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_EstablecimientoId",
                table: "AUD_Inspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_EstablecimientoId",
                table: "AUD_Inspeccion",
                column: "EstablecimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_EstablecimientoId",
                table: "AUD_Inspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_EstablecimientoId",
                table: "AUD_Inspeccion",
                column: "EstablecimientoId",
                unique: true,
                filter: "[EstablecimientoId] IS NOT NULL");
        }
    }
}
