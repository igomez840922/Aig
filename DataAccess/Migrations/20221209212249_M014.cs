using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intensidad",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.AddColumn<long>(
                name: "IntensidadEsaviId",
                table: "FMV_EsaviNotificacion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IntensidadEsavi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Gravedad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntensidadEsavi", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_EsaviNotificacion_IntensidadEsaviId",
                table: "FMV_EsaviNotificacion",
                column: "IntensidadEsaviId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_EsaviNotificacion_IntensidadEsavi_IntensidadEsaviId",
                table: "FMV_EsaviNotificacion",
                column: "IntensidadEsaviId",
                principalTable: "IntensidadEsavi",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_EsaviNotificacion_IntensidadEsavi_IntensidadEsaviId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropTable(
                name: "IntensidadEsavi");

            migrationBuilder.DropIndex(
                name: "IX_FMV_EsaviNotificacion_IntensidadEsaviId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropColumn(
                name: "IntensidadEsaviId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.AddColumn<string>(
                name: "Intensidad",
                table: "FMV_EsaviNotificacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
