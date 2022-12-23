using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspDisposicionFinalId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspDisposicionFinalTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralesEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitudCierre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoInspeccion = table.Column<int>(type: "int", nullable: false),
                    TipoProduct = table.Column<int>(type: "int", nullable: false),
                    TipoVerificacion = table.Column<int>(type: "int", nullable: false),
                    NumNotaSDGSA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NumReciboPago = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PesoDestruir = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Coincide = table.Column<bool>(type: "bit", nullable: false),
                    Adjunta = table.Column<bool>(type: "bit", nullable: false),
                    InventarioMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspDisposicionFinalTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspDisposicionFinalId",
                table: "AUD_Inspeccion",
                column: "InspDisposicionFinalId",
                unique: true,
                filter: "[InspDisposicionFinalId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspDisposicionFinalTB_InspDisposicionFinalId",
                table: "AUD_Inspeccion",
                column: "InspDisposicionFinalId",
                principalTable: "AUD_InspDisposicionFinalTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspDisposicionFinalTB_InspDisposicionFinalId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspDisposicionFinalId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspDisposicionFinalId",
                table: "AUD_Inspeccion");
        }
    }
}
