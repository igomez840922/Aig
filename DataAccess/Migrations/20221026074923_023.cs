using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class _023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Establecimiento_Provincia_ProvinciaId",
                table: "AUD_Establecimiento");

            migrationBuilder.AlterColumn<long>(
                name: "ProvinciaId",
                table: "AUD_Establecimiento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Establecimiento_Provincia_ProvinciaId",
                table: "AUD_Establecimiento",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Establecimiento_Provincia_ProvinciaId",
                table: "AUD_Establecimiento");

            migrationBuilder.AlterColumn<long>(
                name: "ProvinciaId",
                table: "AUD_Establecimiento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Establecimiento_Provincia_ProvinciaId",
                table: "AUD_Establecimiento",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id");
        }
    }
}
