using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Establecimiento_AUD_TipoEstablecimiento_TipoEstablecimientoId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Establecimiento_TipoEstablecimientoId",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "TipoEstablecimientoId",
                table: "AUD_Establecimiento");

            migrationBuilder.AddColumn<int>(
                name: "TipoEstablecimiento",
                table: "AUD_Establecimiento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoEstablecimiento",
                table: "AUD_Establecimiento");

            migrationBuilder.AddColumn<long>(
                name: "TipoEstablecimientoId",
                table: "AUD_Establecimiento",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Establecimiento_TipoEstablecimientoId",
                table: "AUD_Establecimiento",
                column: "TipoEstablecimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Establecimiento_AUD_TipoEstablecimiento_TipoEstablecimientoId",
                table: "AUD_Establecimiento",
                column: "TipoEstablecimientoId",
                principalTable: "AUD_TipoEstablecimiento",
                principalColumn: "Id");
        }
    }
}
