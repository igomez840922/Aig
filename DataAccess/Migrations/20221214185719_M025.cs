using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspGuiaBPMFabricanteMedTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcesoVigilanciaSanit = table.Column<int>(type: "int", nullable: false),
                    FechaUltimaVista = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspGuiaBPMFabricanteMedTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion",
                column: "InspGuiaBPMFabricanteMedId",
                unique: true,
                filter: "[InspGuiaBPMFabricanteMedId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPMFabricanteMedTB_InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion",
                column: "InspGuiaBPMFabricanteMedId",
                principalTable: "AUD_InspGuiaBPMFabricanteMedTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPMFabricanteMedTB_InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion");
        }
    }
}
