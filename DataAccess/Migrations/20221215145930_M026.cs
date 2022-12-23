using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Almacenes",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaAcondicionamiento",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaDispMatPrima",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaProduccion",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutoInspecAuditCal",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClasifActComerciales",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClasifEstablecimiento",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControlCalidad",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatosConclusiones",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Documentacion",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EdifInstalaciones",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipos",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquiposGeneralidades",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FabProdFarmEsteril_A",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FabProdFarmEsteril_A2",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FabProdFarmEsteril_A3",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FabProdFarmEsteril_Gen",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GarantiaCalidad",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lactamicos",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatProducts",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizacionPersonal",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtrosFuncionarios",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdAnalisisContrato",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdCitostatico",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Produccion",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuejasGenerales",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuejasReclamos",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepresentLegal",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequisitosLegales",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RespControlCalidad",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RespProduccion",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValGenerales",
                table: "AUD_InspGuiaBPMFabricanteMedTB",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Almacenes",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "AreaAcondicionamiento",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "AreaDispMatPrima",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "AreaProduccion",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "AuditoriaSanitaria",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "AutoInspecAuditCal",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "ClasifActComerciales",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "ClasifEstablecimiento",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "ControlCalidad",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "DatosConclusiones",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "Documentacion",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "EdifInstalaciones",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "Equipos",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "EquiposGeneralidades",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "FabProdFarmEsteril_A",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "FabProdFarmEsteril_A2",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "FabProdFarmEsteril_A3",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "FabProdFarmEsteril_Gen",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "GarantiaCalidad",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "GeneralesEmpresa",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "Lactamicos",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "MatProducts",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "OrganizacionPersonal",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "OtrosFuncionarios",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "ProdAnalisisContrato",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "ProdCitostatico",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "Produccion",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "QuejasGenerales",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "QuejasReclamos",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "RegenteFarmaceutico",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "RepresentLegal",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "RequisitosLegales",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "RespControlCalidad",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "RespProduccion",
                table: "AUD_InspGuiaBPMFabricanteMedTB");

            migrationBuilder.DropColumn(
                name: "ValGenerales",
                table: "AUD_InspGuiaBPMFabricanteMedTB");
        }
    }
}
