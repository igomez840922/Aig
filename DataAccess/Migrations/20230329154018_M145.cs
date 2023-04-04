using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M145 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FMV_Ram2_InstitucionDestino_InstitucionDestinoId",
            //    table: "FMV_Ram2");

            //migrationBuilder.DropIndex(
            //    name: "IX_FMV_Ram2_EvaluadorId",
            //    table: "FMV_Ram2");

            //migrationBuilder.DropIndex(
            //    name: "IX_FMV_Ram2_ProvinciaId",
            //    table: "FMV_Ram2");

            //migrationBuilder.DropIndex(
            //    name: "IX_FMV_Ram2_TipoInstitucionId",
            //    table: "FMV_Ram2");

            //migrationBuilder.RenameColumn(
            //    name: "InstitucionDestinoId",
            //    table: "FMV_Ram2",
            //    newName: "PersonalTrabajadorTBId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_FMV_Ram2_InstitucionDestinoId",
            //    table: "FMV_Ram2",
            //    newName: "IX_FMV_Ram2_PersonalTrabajadorTBId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FMV_Ram2_EvaluadorId",
            //    table: "FMV_Ram2",
            //    column: "EvaluadorId",
            //    unique: true,
            //    filter: "[EvaluadorId] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FMV_Ram2_InstitucionId",
            //    table: "FMV_Ram2",
            //    column: "InstitucionId",
            //    unique: true,
            //    filter: "[InstitucionId] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FMV_Ram2_ProvinciaId",
            //    table: "FMV_Ram2",
            //    column: "ProvinciaId",
            //    unique: true,
            //    filter: "[ProvinciaId] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FMV_Ram2_TipoInstitucionId",
            //    table: "FMV_Ram2",
            //    column: "TipoInstitucionId",
            //    unique: true,
            //    filter: "[TipoInstitucionId] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FMV_Ram2_InstitucionDestino_InstitucionId",
            //    table: "FMV_Ram2",
            //    column: "InstitucionId",
            //    principalTable: "InstitucionDestino",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FMV_Ram2_PersonalTrabajador_PersonalTrabajadorTBId",
            //    table: "FMV_Ram2",
            //    column: "PersonalTrabajadorTBId",
            //    principalTable: "PersonalTrabajador",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FMV_Ram2_InstitucionDestino_InstitucionId",
            //    table: "FMV_Ram2");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_FMV_Ram2_PersonalTrabajador_PersonalTrabajadorTBId",
            //    table: "FMV_Ram2");

            //migrationBuilder.DropIndex(
            //    name: "IX_FMV_Ram2_EvaluadorId",
            //    table: "FMV_Ram2");

            //migrationBuilder.DropIndex(
            //    name: "IX_FMV_Ram2_InstitucionId",
            //    table: "FMV_Ram2");

            //migrationBuilder.DropIndex(
            //    name: "IX_FMV_Ram2_ProvinciaId",
            //    table: "FMV_Ram2");

            //migrationBuilder.DropIndex(
            //    name: "IX_FMV_Ram2_TipoInstitucionId",
            //    table: "FMV_Ram2");

            //migrationBuilder.RenameColumn(
            //    name: "PersonalTrabajadorTBId",
            //    table: "FMV_Ram2",
            //    newName: "InstitucionDestinoId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_FMV_Ram2_PersonalTrabajadorTBId",
            //    table: "FMV_Ram2",
            //    newName: "IX_FMV_Ram2_InstitucionDestinoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FMV_Ram2_EvaluadorId",
            //    table: "FMV_Ram2",
            //    column: "EvaluadorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FMV_Ram2_ProvinciaId",
            //    table: "FMV_Ram2",
            //    column: "ProvinciaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FMV_Ram2_TipoInstitucionId",
            //    table: "FMV_Ram2",
            //    column: "TipoInstitucionId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FMV_Ram2_InstitucionDestino_InstitucionDestinoId",
            //    table: "FMV_Ram2",
            //    column: "InstitucionDestinoId",
            //    principalTable: "InstitucionDestino",
            //    principalColumn: "Id");
        }
    }
}
