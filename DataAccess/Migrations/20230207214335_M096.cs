using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M096 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdjuntoIngreso",
                table: "AUD_Correspondencia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdjuntoSeguimiento",
                table: "AUD_Correspondencia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CorrespondenciaResponsableId",
                table: "AUD_Correspondencia",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecNumber",
                table: "AUD_Correspondencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecNumberStr",
                table: "AUD_Correspondencia",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AUD_CorrespondenciaRespRevision",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_CorrespondenciaRespRevision", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Correspondencia_CorrespondenciaResponsableId",
                table: "AUD_Correspondencia",
                column: "CorrespondenciaResponsableId");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Correspondencia_AUD_CorrespondenciaRespRevision_CorrespondenciaResponsableId",
                table: "AUD_Correspondencia",
                column: "CorrespondenciaResponsableId",
                principalTable: "AUD_CorrespondenciaRespRevision",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Correspondencia_AUD_CorrespondenciaRespRevision_CorrespondenciaResponsableId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropTable(
                name: "AUD_CorrespondenciaRespRevision");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Correspondencia_CorrespondenciaResponsableId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "AdjuntoIngreso",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "AdjuntoSeguimiento",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaResponsableId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "SecNumber",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "SecNumberStr",
                table: "AUD_Correspondencia");
        }
    }
}
