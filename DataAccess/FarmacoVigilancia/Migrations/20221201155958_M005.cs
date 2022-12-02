using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.FarmacoVigilancia.Migrations
{
    public partial class M005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProvinciaId",
                table: "InstitucionDestino",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoInstitucionId",
                table: "InstitucionDestino",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoInstitucion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInstitucion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstitucionDestino_ProvinciaId",
                table: "InstitucionDestino",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitucionDestino_TipoInstitucionId",
                table: "InstitucionDestino",
                column: "TipoInstitucionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstitucionDestino_Provincia_ProvinciaId",
                table: "InstitucionDestino",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstitucionDestino_TipoInstitucion_TipoInstitucionId",
                table: "InstitucionDestino",
                column: "TipoInstitucionId",
                principalTable: "TipoInstitucion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstitucionDestino_Provincia_ProvinciaId",
                table: "InstitucionDestino");

            migrationBuilder.DropForeignKey(
                name: "FK_InstitucionDestino_TipoInstitucion_TipoInstitucionId",
                table: "InstitucionDestino");

            migrationBuilder.DropTable(
                name: "TipoInstitucion");

            migrationBuilder.DropIndex(
                name: "IX_InstitucionDestino_ProvinciaId",
                table: "InstitucionDestino");

            migrationBuilder.DropIndex(
                name: "IX_InstitucionDestino_TipoInstitucionId",
                table: "InstitucionDestino");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "InstitucionDestino");

            migrationBuilder.DropColumn(
                name: "TipoInstitucionId",
                table: "InstitucionDestino");
        }
    }
}
