using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M095 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreDirigido",
                table: "AUD_Correspondencia",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "EmailDirigido",
                table: "AUD_Correspondencia",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<long>(
                name: "CorrespondenciaAsuntoId",
                table: "AUD_Correspondencia",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CorrespondenciaContactoId",
                table: "AUD_Correspondencia",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescTipoCorrespondencia",
                table: "AUD_Correspondencia",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AUD_Correspondencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoCorrespondencia",
                table: "AUD_Correspondencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AUD_CorrespondenciaAsunto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_CorrespondenciaAsunto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUD_CorrespondenciaContacto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_CorrespondenciaContacto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Correspondencia_CorrespondenciaAsuntoId",
                table: "AUD_Correspondencia",
                column: "CorrespondenciaAsuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_AUD_Correspondencia_CorrespondenciaContactoId",
                table: "AUD_Correspondencia",
                column: "CorrespondenciaContactoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Correspondencia_AUD_CorrespondenciaAsunto_CorrespondenciaAsuntoId",
                table: "AUD_Correspondencia",
                column: "CorrespondenciaAsuntoId",
                principalTable: "AUD_CorrespondenciaAsunto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_Correspondencia_AUD_CorrespondenciaContacto_CorrespondenciaContactoId",
                table: "AUD_Correspondencia",
                column: "CorrespondenciaContactoId",
                principalTable: "AUD_CorrespondenciaContacto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Correspondencia_AUD_CorrespondenciaAsunto_CorrespondenciaAsuntoId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropForeignKey(
                name: "FK_AUD_Correspondencia_AUD_CorrespondenciaContacto_CorrespondenciaContactoId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropTable(
                name: "AUD_CorrespondenciaAsunto");

            migrationBuilder.DropTable(
                name: "AUD_CorrespondenciaContacto");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Correspondencia_CorrespondenciaAsuntoId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropIndex(
                name: "IX_AUD_Correspondencia_CorrespondenciaContactoId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaAsuntoId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaContactoId",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "DescTipoCorrespondencia",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "TipoCorrespondencia",
                table: "AUD_Correspondencia");

            migrationBuilder.AlterColumn<string>(
                name: "NombreDirigido",
                table: "AUD_Correspondencia",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailDirigido",
                table: "AUD_Correspondencia",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
