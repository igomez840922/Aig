using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripVacuna",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.AddColumn<long>(
                name: "TipoVacunaId",
                table: "FMV_EsaviNotificacion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoVacuna",
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
                    table.PrimaryKey("PK_TipoVacuna", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviNotificacion_TipoVacunaId",
                table: "FMV_EsaviNotificacion",
                column: "TipoVacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_EsaviNotificacion_TipoVacuna_TipoVacunaId",
                table: "FMV_EsaviNotificacion",
                column: "TipoVacunaId",
                principalTable: "TipoVacuna",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_EsaviNotificacion_TipoVacuna_TipoVacunaId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropTable(
                name: "TipoVacuna");

            migrationBuilder.DropIndex(
                name: "IX_FMV_EsaviNotificacion_TipoVacunaId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropColumn(
                name: "TipoVacunaId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.AddColumn<string>(
                name: "DescripVacuna",
                table: "FMV_EsaviNotificacion",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
