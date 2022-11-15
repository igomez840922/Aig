using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipantesDNFD",
                table: "AUD_Inspeccion");

            migrationBuilder.AddColumn<long>(
                name: "InspAperCambUbicAgenId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspAperCambUbicAgenTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciboPago = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DatosEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosCondicionesLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperCambUbicAgenTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion",
                column: "InspAperCambUbicAgenId",
                unique: true,
                filter: "[InspAperCambUbicAgenId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicAgenTB_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion",
                column: "InspAperCambUbicAgenId",
                principalTable: "AUD_InspAperCambUbicAgenTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicAgenTB_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspAperCambUbicAgenTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspAperCambUbicAgenId",
                table: "AUD_Inspeccion");

            migrationBuilder.AddColumn<string>(
                name: "ParticipantesDNFD",
                table: "AUD_Inspeccion",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
