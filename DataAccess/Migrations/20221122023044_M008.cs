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
                name: "InspRutinaVigFarmaciaId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspRutinaVigFarmaciaTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatosGeneralesFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosFarmaceutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosPersonalTecnico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosExpedienteColaborador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosEstructuraFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosEquipoRegistroFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAnuncioFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRegMovimientoExistenciaFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAlmacenProductosFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosProcedimientoFarmacia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspRutinaVigFarmaciaTB", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspRutinaVigFarmaciaTB_InspAperFabricanteId",
                table: "AUD_Inspeccion",
                column: "InspAperFabricanteId",
                principalTable: "AUD_InspRutinaVigFarmaciaTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspRutinaVigFarmaciaTB_InspAperFabricanteId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspRutinaVigFarmaciaTB");

            migrationBuilder.DropColumn(
                name: "InspRutinaVigFarmaciaId",
                table: "AUD_Inspeccion");
        }
    }
}
