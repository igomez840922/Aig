using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M158 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ram2_Provincia_ProvinciaTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ram2_TipoInstitucion_TipoInstitucionTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_InstitucionId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_ProvinciaId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_ProvinciaTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_TipoInstitucionId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_TipoInstitucionTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropColumn(
                name: "ProvinciaTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropColumn(
                name: "TipoInstitucionTBId",
                table: "FMV_Ram2");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_InstitucionId",
                table: "FMV_Ram2",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_ProvinciaId",
                table: "FMV_Ram2",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_TipoInstitucionId",
                table: "FMV_Ram2",
                column: "TipoInstitucionId");
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_InstitucionId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_ProvinciaId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_TipoInstitucionId",
                table: "FMV_Ram2");

            migrationBuilder.AddColumn<long>(
                name: "ProvinciaTBId",
                table: "FMV_Ram2",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoInstitucionTBId",
                table: "FMV_Ram2",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_InstitucionId",
                table: "FMV_Ram2",
                column: "InstitucionId",
                unique: true,
                filter: "[InstitucionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_ProvinciaId",
                table: "FMV_Ram2",
                column: "ProvinciaId",
                unique: true,
                filter: "[ProvinciaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_ProvinciaTBId",
                table: "FMV_Ram2",
                column: "ProvinciaTBId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_TipoInstitucionId",
                table: "FMV_Ram2",
                column: "TipoInstitucionId",
                unique: true,
                filter: "[TipoInstitucionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_TipoInstitucionTBId",
                table: "FMV_Ram2",
                column: "TipoInstitucionTBId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ram2_Provincia_ProvinciaTBId",
                table: "FMV_Ram2",
                column: "ProvinciaTBId",
                principalTable: "Provincia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ram2_TipoInstitucion_TipoInstitucionTBId",
                table: "FMV_Ram2",
                column: "TipoInstitucionTBId",
                principalTable: "TipoInstitucion",
                principalColumn: "Id");
            */
        }
    }
}
