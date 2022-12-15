using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabMedicamentoTB_InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspGuiBPMFabMedicamentoTB");

            migrationBuilder.CreateTable(
                name: "AUD_InspGuiBPMFabCosmeticoMedTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditoriaSanitaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegenteFarmaceutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrosFuncionarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralesEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespProduccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespControlCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequisitosLegales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcesoVigilanciaSanit = table.Column<int>(type: "int", nullable: false),
                    FechaUltimaVista = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClasifActComerciales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClasifEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClasifEstablecimiento2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenEstructuraOrganizativa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondExtAlmacenas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondIntAlmacenas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaRecepMateriaPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenMateriaPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenMatAcondicionamineto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecepProductoTerminado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenProductoTerminado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoDevueltoRechazado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistProductoTerminado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManejoQuejaReclamos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetiroProcMercado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaInstAgua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OsmosisInversa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaDeIonizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalibraVerifEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MantAreaEquipos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaProdCondExternas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaProdCondInternas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaOrganizaDocumentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaDispensionOrdFab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FabProdDesinfectante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FabPlaguicida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FabCosmeticos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaEnvasado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaEtiquetadoEmpaque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabControlCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalisisContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspeccionAudito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspGuiBPMFabCosmeticoMedTB", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabCosmeticoMedTB_InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion",
                column: "InspGuiBPMFabMedicamentoId",
                principalTable: "AUD_InspGuiBPMFabCosmeticoMedTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabCosmeticoMedTB_InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspGuiBPMFabCosmeticoMedTB");

            migrationBuilder.CreateTable(
                name: "AUD_InspGuiBPMFabMedicamentoTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlmacenMatAcondicionamineto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenMateriaPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenProductoTerminado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalisisContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaDispensionOrdFab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaEnvasado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaEtiquetadoEmpaque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaOrganizaDocumentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaProdCondExternas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaProdCondInternas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaRecepMateriaPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditoriaSanitaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalibraVerifEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClasifActComerciales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClasifEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClasifEstablecimiento2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondExtAlmacenas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondIntAlmacenas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    DistProductoTerminado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FabCosmeticos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FabPlaguicida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FabProdDesinfectante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUltimaVista = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    GenEstructuraOrganizativa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralesEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspeccionAudito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabControlCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManejoQuejaReclamos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MantAreaEquipos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OsmosisInversa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrosFuncionarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcesoVigilanciaSanit = table.Column<int>(type: "int", nullable: false),
                    ProductoDevueltoRechazado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecepProductoTerminado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegenteFarmaceutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequisitosLegales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespControlCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespProduccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetiroProcMercado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaDeIonizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaInstAgua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspGuiBPMFabMedicamentoTB", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiBPMFabMedicamentoTB_InspGuiBPMFabMedicamentoId",
                table: "AUD_Inspeccion",
                column: "InspGuiBPMFabMedicamentoId",
                principalTable: "AUD_InspGuiBPMFabMedicamentoTB",
                principalColumn: "Id");
        }
    }
}
