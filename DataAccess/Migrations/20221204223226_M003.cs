using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvisoOperación",
                table: "AUD_Inspeccion",
                newName: "AvisoOperacion");

            migrationBuilder.AddColumn<long>(
                name: "InspInvestigacionId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_InspInvestigacionTB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetalleVerificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalleInspeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdjuntaActaRetencion = table.Column<int>(type: "int", nullable: false),
                    DatosEstablecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosAtendidosPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosRepresentLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosConclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_InspInvestigacionTB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_InspInvestigacionId",
                table: "AUD_Inspeccion",
                column: "InspInvestigacionId",
                unique: true,
                filter: "[InspInvestigacionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspInvestigacionTB_InspInvestigacionId",
                table: "AUD_Inspeccion",
                column: "InspInvestigacionId",
                principalTable: "AUD_InspInvestigacionTB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion_AUD_InspInvestigacionTB_InspInvestigacionId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "AUD_InspInvestigacionTB");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_InspInvestigacionId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "InspInvestigacionId",
                table: "AUD_Inspeccion");

            migrationBuilder.RenameColumn(
                name: "AvisoOperacion",
                table: "AUD_Inspeccion",
                newName: "AvisoOperación");
        }
    }
}
