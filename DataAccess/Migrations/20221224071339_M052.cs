using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M052 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspGuiaBPMLabAcondicionadorId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspGuiaBPMLabAcondicionadorTB",
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
                    OrganizacionPersonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdifInstalaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Almacenes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaAcondicionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquiposGeneralidades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatProducts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acondicionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GarantiaCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlCalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdAnalisisContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValGenerales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuejasReclamos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoInspecAuditCal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspGuiaBPMLabAcondicionadorTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspGuiaBPMLabAcondicionadorId",
                table: "AUD_Inspeccion",
                column: "InspGuiaBPMLabAcondicionadorId",
                unique: true,
                filter: "[InspGuiaBPMLabAcondicionadorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPMLabAcondicionadorTB_InspGuiaBPMLabAcondicionadorId",
                table: "AUD_Inspeccion",
                column: "InspGuiaBPMLabAcondicionadorId",
                principalTable: "AUD_InspGuiaBPMLabAcondicionadorTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPMLabAcondicionadorTB_InspGuiaBPMLabAcondicionadorId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspGuiaBPMLabAcondicionadorTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspGuiaBPMLabAcondicionadorId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspGuiaBPMLabAcondicionadorId",
                table: "AUD_Inspeccion");
        }
    }
}
