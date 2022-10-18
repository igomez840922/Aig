using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Establecimiento_Corregimiento_CorregimientoId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Establecimiento_Distrito_DistritoId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Establecimiento_Provincia_ProvinciaId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Establecimiento_CorregimientoId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Establecimiento_DistritoId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Establecimiento_ProvinciaId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "CorregimientoId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "AUD_Establecimiento");

            migrationBuilder.AddColumn<string>(
                name: "Corregimiento",
                table: "AUD_Establecimiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "AUD_Establecimiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "AUD_Establecimiento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Corregimiento",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "AUD_Establecimiento");

            migrationBuilder.AddColumn<long>(
                name: "CorregimientoId",
                table: "AUD_Establecimiento",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DistritoId",
                table: "AUD_Establecimiento",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProvinciaId",
                table: "AUD_Establecimiento",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Establecimiento_CorregimientoId",
                table: "AUD_Establecimiento",
                column: "CorregimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Establecimiento_DistritoId",
                table: "AUD_Establecimiento",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Establecimiento_ProvinciaId",
                table: "AUD_Establecimiento",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Establecimiento_Corregimiento_CorregimientoId",
                table: "AUD_Establecimiento",
                column: "CorregimientoId",
                principalTable: "Corregimiento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Establecimiento_Distrito_DistritoId",
                table: "AUD_Establecimiento",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Establecimiento_Provincia_ProvinciaId",
                table: "AUD_Establecimiento",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id");
        }
    }
}
