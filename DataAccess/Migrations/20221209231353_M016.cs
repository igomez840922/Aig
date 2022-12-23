using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.AddColumn<long>(
                name: "LaboratorioId",
                table: "FMV_EsaviNotificacion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviNotificacion_LaboratorioId",
                table: "FMV_EsaviNotificacion",
                column: "LaboratorioId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_EsaviNotificacion_Laboratorio_LaboratorioId",
                table: "FMV_EsaviNotificacion",
                column: "LaboratorioId",
                principalTable: "Laboratorio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_EsaviNotificacion_Laboratorio_LaboratorioId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropIndex(
                name: "IX_FMV_EsaviNotificacion_LaboratorioId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropColumn(
                name: "LaboratorioId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "FMV_EsaviNotificacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
