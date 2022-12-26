using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class _053 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InspGuiaBPM_BpaId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspGuiaBPM_BpaTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralesEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegenteFarmaceutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUltimaInspeccion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropositoInsp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrosFuncionarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioEstFarmaceutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioRegFarmaceutica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispGenerlestablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreasEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distribucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransProdFarmaceuticos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoInspec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspGuiaBPM_BpaTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspGuiaBPM_BpaId",
                table: "AUD_Inspeccion",
                column: "InspGuiaBPM_BpaId",
                unique: true,
                filter: "[InspGuiaBPM_BpaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPM_BpaTB_InspGuiaBPM_BpaId",
                table: "AUD_Inspeccion",
                column: "InspGuiaBPM_BpaId",
                principalTable: "AUD_InspGuiaBPM_BpaTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspGuiaBPM_BpaTB_InspGuiaBPM_BpaId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspGuiaBPM_BpaTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspGuiaBPM_BpaId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspGuiaBPM_BpaId",
                table: "AUD_Inspeccion");
        }
    }
}
