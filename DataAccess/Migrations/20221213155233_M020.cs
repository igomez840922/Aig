using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspCierreOperacionId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspCierreOperacionTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralesEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitudCierre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObservacionUbicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinoProductos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspCierreOperacionTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspCierreOperacionId",
                table: "AUD_Inspeccion",
                column: "InspCierreOperacionId",
                unique: true,
                filter: "[InspCierreOperacionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspCierreOperacionTB_InspCierreOperacionId",
                table: "AUD_Inspeccion",
                column: "InspCierreOperacionId",
                principalTable: "AUD_InspCierreOperacionTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspCierreOperacionTB_InspCierreOperacionId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspCierreOperacionTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspCierreOperacionId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspCierreOperacionId",
                table: "AUD_Inspeccion");
        }
    }
}
