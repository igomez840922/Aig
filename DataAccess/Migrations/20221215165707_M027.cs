using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M027 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabCosmeticoMedTB_InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion");

            migrationBuilder.RenameColumn(
                name: "InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion",
                newName: "InspGuiBPMFabCosmeticoMedId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspGuiBPMFabCosmeticoMedId",
                table: "AUD_Inspeccion",
                column: "InspGuiBPMFabCosmeticoMedId",
                unique: true,
                filter: "[InspGuiBPMFabCosmeticoMedId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabCosmeticoMedTB_InspGuiBPMFabCosmeticoMedId",
                table: "AUD_Inspeccion",
                column: "InspGuiBPMFabCosmeticoMedId",
                principalTable: "AUD_InspGuiBPMFabCosmeticoMedTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabCosmeticoMedTB_InspGuiBPMFabCosmeticoMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspGuiBPMFabCosmeticoMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.RenameColumn(
                name: "InspGuiBPMFabCosmeticoMedId",
                table: "AUD_Inspeccion",
                newName: "InspGuiBPMFabMedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion",
                column: "InspGuiBPMFabMedicamentoId",
                unique: true,
                filter: "[InspGuiBPMFabMedicamentoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabCosmeticoMedTB_InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion",
                column: "InspGuiBPMFabMedicamentoId",
                principalTable: "AUD_InspGuiBPMFabCosmeticoMedTB",
                principalColumn: "Id");
        }
    }
}
