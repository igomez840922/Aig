using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreOrgInst",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "ProvRegionOrigen",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "TipoNotificador",
                table: "FMV_Ram");

            migrationBuilder.RenameColumn(
                name: "TipoOrgInst",
                table: "FMV_Ram",
                newName: "TipoNotificacion");

            migrationBuilder.AddColumn<long>(
                name: "InstitucionId",
                table: "FMV_Ram",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProvinciaId",
                table: "FMV_Ram",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoInstitucionId",
                table: "FMV_Ram",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_InstitucionId",
                table: "FMV_Ram",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_ProvinciaId",
                table: "FMV_Ram",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_TipoInstitucionId",
                table: "FMV_Ram",
                column: "TipoInstitucionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ram_InstitucionDestino_InstitucionId",
                table: "FMV_Ram",
                column: "InstitucionId",
                principalTable: "InstitucionDestino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ram_Provincia_ProvinciaId",
                table: "FMV_Ram",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ram_TipoInstitucion_TipoInstitucionId",
                table: "FMV_Ram",
                column: "TipoInstitucionId",
                principalTable: "TipoInstitucion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ram_InstitucionDestino_InstitucionId",
                table: "FMV_Ram");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ram_Provincia_ProvinciaId",
                table: "FMV_Ram");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ram_TipoInstitucion_TipoInstitucionId",
                table: "FMV_Ram");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_InstitucionId",
                table: "FMV_Ram");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_ProvinciaId",
                table: "FMV_Ram");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_TipoInstitucionId",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "InstitucionId",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "TipoInstitucionId",
                table: "FMV_Ram");

            migrationBuilder.RenameColumn(
                name: "TipoNotificacion",
                table: "FMV_Ram",
                newName: "TipoOrgInst");

            migrationBuilder.AddColumn<string>(
                name: "NombreOrgInst",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvRegionOrigen",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoNotificador",
                table: "FMV_Ram",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
