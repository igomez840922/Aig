using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspGuiBPMFabNatMedicinaId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspGuiBPMFabNatMedicinaTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoInspeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditoriaSanitaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegenteFarmaceutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrosFuncionarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralesEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthFuncionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponPersonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacitacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HigieneSalud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UbicacionDisenoConstruc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Almacenes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaRecepLimpieza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaSecadoMolienda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaDispensadoMatPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaProduccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaEnvasadoEmpaque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaAuxiliares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaControlCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Generalidades8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calibracion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaAgua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaAire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Generalidades9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispensadoMatPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatAcondicionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdAGranel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdTerminados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdRechazados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdDevueltos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Generalidades10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentosExigido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedimientoReg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdControlProceso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Generalidades12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GarantiaCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Generalidades13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Muestreo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetodologiaAnalitica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialesReferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estabilidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Generalidades14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Retiros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Generalidades15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contratante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contratista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditoriaCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspGuiBPMFabNatMedicinaTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspGuiBPMFabNatMedicinaId",
                table: "AUD_Inspeccion",
                column: "InspGuiBPMFabNatMedicinaId",
                unique: true,
                filter: "[InspGuiBPMFabNatMedicinaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabNatMedicinaTB_InspGuiBPMFabNatMedicinaId",
                table: "AUD_Inspeccion",
                column: "InspGuiBPMFabNatMedicinaId",
                principalTable: "AUD_InspGuiBPMFabNatMedicinaTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabNatMedicinaTB_InspGuiBPMFabNatMedicinaId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspGuiBPMFabNatMedicinaTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspGuiBPMFabNatMedicinaId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspGuiBPMFabNatMedicinaId",
                table: "AUD_Inspeccion");
        }
    }
}
