using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.FarmacoVigilancia.Migrations
{
    public partial class M006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreOrgInst",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "ProvRegionOrigen",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "TipoOrgInst",
                table: "FMV_Esavi");

            migrationBuilder.AddColumn<long>(
                name: "InstitucionId",
                table: "FMV_Esavi",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProvinciaId",
                table: "FMV_Esavi",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoInstitucionId",
                table: "FMV_Esavi",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_InstitucionId",
                table: "FMV_Esavi",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_ProvinciaId",
                table: "FMV_Esavi",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Esavi_TipoInstitucionId",
                table: "FMV_Esavi",
                column: "TipoInstitucionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Esavi_InstitucionDestino_InstitucionId",
                table: "FMV_Esavi",
                column: "InstitucionId",
                principalTable: "InstitucionDestino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Esavi_Provincia_ProvinciaId",
                table: "FMV_Esavi",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Esavi_TipoInstitucion_TipoInstitucionId",
                table: "FMV_Esavi",
                column: "TipoInstitucionId",
                principalTable: "TipoInstitucion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Esavi_InstitucionDestino_InstitucionId",
                table: "FMV_Esavi");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Esavi_Provincia_ProvinciaId",
                table: "FMV_Esavi");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Esavi_TipoInstitucion_TipoInstitucionId",
                table: "FMV_Esavi");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Esavi_InstitucionId",
                table: "FMV_Esavi");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Esavi_ProvinciaId",
                table: "FMV_Esavi");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Esavi_TipoInstitucionId",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "InstitucionId",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "TipoInstitucionId",
                table: "FMV_Esavi");

            migrationBuilder.AddColumn<string>(
                name: "NombreOrgInst",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvRegionOrigen",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoOrgInst",
                table: "FMV_Esavi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
