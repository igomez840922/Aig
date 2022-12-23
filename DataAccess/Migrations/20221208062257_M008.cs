using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspAperturaCosmetArtesanalId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspAperturaCosmetArtesanalTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralesEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propietario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaAlmacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inconformidades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperturaCosmetArtesanalTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspAperturaCosmetArtesanalId",
                table: "AUD_Inspeccion",
                column: "InspAperturaCosmetArtesanalId",
                unique: true,
                filter: "[InspAperturaCosmetArtesanalId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperturaCosmetArtesanalTB_InspAperturaCosmetArtesanalId",
                table: "AUD_Inspeccion",
                column: "InspAperturaCosmetArtesanalId",
                principalTable: "AUD_InspAperturaCosmetArtesanalTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperturaCosmetArtesanalTB_InspAperturaCosmetArtesanalId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspAperturaCosmetArtesanalTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspAperturaCosmetArtesanalId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspAperturaCosmetArtesanalId",
                table: "AUD_Inspeccion");
        }
    }
}
