using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M098 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatoEstablecimiento",
                table: "AUD_Inspeccion",
                newName: "ParticipantesDNFD");

            migrationBuilder.AddColumn<long>(
                name: "DatosEstablecimientoId",
                table: "AUD_Inspeccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReciboPago",
                table: "AUD_Establecimiento",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "_DatosEstablecimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstablecimientoId = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumLicencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvisoOperaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciboPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Corregimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DatosEstablecimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DatosEstablecimiento_AUD_Establecimiento_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "AUD_Establecimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Inspeccion_DatosEstablecimientoId",
                table: "AUD_Inspeccion",
                column: "DatosEstablecimientoId",
                unique: true,
                filter: "[DatosEstablecimientoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX__DatosEstablecimiento_EstablecimientoId",
                table: "_DatosEstablecimiento",
                column: "EstablecimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Inspeccion__DatosEstablecimiento_DatosEstablecimientoId",
                table: "AUD_Inspeccion",
                column: "DatosEstablecimientoId",
                principalTable: "_DatosEstablecimiento",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Inspeccion__DatosEstablecimiento_DatosEstablecimientoId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropTable(
                name: "_DatosEstablecimiento");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Inspeccion_DatosEstablecimientoId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "DatosEstablecimientoId",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "ReciboPago",
                table: "AUD_Establecimiento");

            migrationBuilder.RenameColumn(
                name: "ParticipantesDNFD",
                table: "AUD_Inspeccion",
                newName: "DatoEstablecimiento");
        }
    }
}
