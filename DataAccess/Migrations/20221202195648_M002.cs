using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspRutinaVigFarmaciaTB_InspAperFabricanteId",
                table: "AUD_Inspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspRutinaVigFarmaciaId",
                table: "AUD_Inspeccion",
                column: "InspRutinaVigFarmaciaId",
                unique: true,
                filter: "[InspRutinaVigFarmaciaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspRutinaVigFarmaciaTB_InspRutinaVigFarmaciaId",
                table: "AUD_Inspeccion",
                column: "InspRutinaVigFarmaciaId",
                principalTable: "AUD_InspRutinaVigFarmaciaTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspRutinaVigFarmaciaTB_InspRutinaVigFarmaciaId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspRutinaVigFarmaciaId",
                table: "AUD_Inspeccion");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspRutinaVigFarmaciaTB_InspAperFabricanteId",
                table: "AUD_Inspeccion",
                column: "InspAperFabricanteId",
                principalTable: "AUD_InspRutinaVigFarmaciaTB",
                principalColumn: "Id");
        }
    }
}
