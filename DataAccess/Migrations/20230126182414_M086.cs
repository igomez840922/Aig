using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M086 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPMFabricanteMedTB_InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUD_InspGuiaBPMFabricanteMedTB",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.RenameTable(
                name: "AUD_InspGuiaBPMFabricanteMedTB",
                newName: "AUD_InspGuiaBPMFabricanteMed");

            migrationBuilder.AddColumn<long>(
                name: "InspAperFabricanteCosmetMedId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUD_InspGuiaBPMFabricanteMed",
                table: "AUD_InspGuiaBPMFabricanteMed",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AUD_InspAperFabricanteCosmetMed",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatosEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoProductos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizacionPersonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Programas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdAnalisisContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReclamosProdRetirados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaProduccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratorioControlCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaAlmacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaAuxiliar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspAperFabricanteCosmetMed", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspAperFabricanteCosmetMedId",
                table: "AUD_Inspeccion",
                column: "InspAperFabricanteCosmetMedId",
                unique: true,
                filter: "[InspAperFabricanteCosmetMedId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperFabricanteCosmetMed_InspAperFabricanteCosmetMedId",
                table: "AUD_Inspeccion",
                column: "InspAperFabricanteCosmetMedId",
                principalTable: "AUD_InspAperFabricanteCosmetMed",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPMFabricanteMed_InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion",
                column: "InspGuiaBPMFabricanteMedId",
                principalTable: "AUD_InspGuiaBPMFabricanteMed",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspAperFabricanteCosmetMed_InspAperFabricanteCosmetMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPMFabricanteMed_InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspAperFabricanteCosmetMed");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspAperFabricanteCosmetMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUD_InspGuiaBPMFabricanteMed",
                table: "AUD_InspGuiaBPMFabricanteMed");

            migrationBuilder.DropColumn(
                name: "InspAperFabricanteCosmetMedId",
                table: "AUD_Inspeccion");

            migrationBuilder.RenameTable(
                name: "AUD_InspGuiaBPMFabricanteMed",
                newName: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUD_InspGuiaBPMFabricanteMedTB",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPMFabricanteMedTB_InspGuiaBPMFabricanteMedId",
                table: "AUD_Inspeccion",
                column: "InspGuiaBPMFabricanteMedId",
                principalTable: "AUD_InspGuiaBPMFabricanteMedTB",
                principalColumn: "Id");
        }
    }
}
