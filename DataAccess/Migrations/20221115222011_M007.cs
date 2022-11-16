using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicAgenTB_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUD_InspAperCambUbicAgenTB",
                table: "AUD_InspAperCambUbicAgenTB");

            migrationBuilder.RenameTable(
                name: "AUD_InspAperCambUbicAgenTB",
                newName: "AUD_InspAperCambUbicAgen");

            migrationBuilder.AddColumn<long>(
                name: "InspAperFabricanteId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUD_InspAperCambUbicAgen",
                table: "AUD_InspAperCambUbicAgen",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AUD_InspAperFabricante",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProductos = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DatosEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosDocumentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosProcedimientoPrograma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAutoInspeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosProdAnalisisContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosReclamoProductoRetirado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaProduccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosEquipos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaLabCtrCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaAlmacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAreaAuxiliares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperFabricante", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspAperFabricanteId",
                table: "AUD_Inspeccion",
                column: "InspAperFabricanteId",
                unique: true,
                filter: "[InspAperFabricanteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicAgen_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion",
                column: "InspAperCambUbicAgenId",
                principalTable: "AUD_InspAperCambUbicAgen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperFabricante_InspAperFabricanteId",
                table: "AUD_Inspeccion",
                column: "InspAperFabricanteId",
                principalTable: "AUD_InspAperFabricante",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicAgen_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperFabricante_InspAperFabricanteId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspAperFabricante");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspAperFabricanteId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUD_InspAperCambUbicAgen",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "InspAperFabricanteId",
                table: "AUD_Inspeccion");

            migrationBuilder.RenameTable(
                name: "AUD_InspAperCambUbicAgen",
                newName: "AUD_InspAperCambUbicAgenTB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUD_InspAperCambUbicAgenTB",
                table: "AUD_InspAperCambUbicAgenTB",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperCambUbicAgenTB_InspAperCambUbicAgenId",
                table: "AUD_Inspeccion",
                column: "InspAperCambUbicAgenId",
                principalTable: "AUD_InspAperCambUbicAgenTB",
                principalColumn: "Id");
        }
    }
}
