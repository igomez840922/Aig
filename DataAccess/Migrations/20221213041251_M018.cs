using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspRutinaVigAgenciaId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspRutinaVigAgenciaTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarioAlAzar = table.Column<int>(type: "int", nullable: false),
                    InventarioCompleto = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspRutinaVigAgenciaTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspRutinaVigAgenciaId",
                table: "AUD_Inspeccion",
                column: "InspRutinaVigAgenciaId",
                unique: true,
                filter: "[InspRutinaVigAgenciaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspRutinaVigAgenciaTB_InspRutinaVigAgenciaId",
                table: "AUD_Inspeccion",
                column: "InspRutinaVigAgenciaId",
                principalTable: "AUD_InspRutinaVigAgenciaTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspRutinaVigAgenciaTB_InspRutinaVigAgenciaId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspRutinaVigAgenciaId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspRutinaVigAgenciaId",
                table: "AUD_Inspeccion");
        }
    }
}
