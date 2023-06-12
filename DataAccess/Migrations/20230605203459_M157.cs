using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M157 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_FMV_Ram2_ProvinciaTBId",
                table: "FMV_Ram2",
                column: "ProvinciaTBId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ram2_Provincia_ProvinciaTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ram2_TipoInstitucion_TipoInstitucionTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_ProvinciaTBId",
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
        }
    }
}
