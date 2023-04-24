using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M152 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspAperCambUbicBotiquinId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspAperCambUbicBotiquinTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondCaractEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperCambUbicBotiquinTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspAperCambUbicBotiquinId",
                table: "AUD_Inspeccion",
                column: "InspAperCambUbicBotiquinId",
                unique: true,
                filter: "[InspAperCambUbicBotiquinId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicBotiquinTB_InspAperCambUbicBotiquinId",
                table: "AUD_Inspeccion",
                column: "InspAperCambUbicBotiquinId",
                principalTable: "AUD_InspAperCambUbicBotiquinTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicBotiquinTB_InspAperCambUbicBotiquinId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspAperCambUbicBotiquinTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspAperCambUbicBotiquinId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspAperCambUbicBotiquinId",
                table: "AUD_Inspeccion");
        }
    }
}
