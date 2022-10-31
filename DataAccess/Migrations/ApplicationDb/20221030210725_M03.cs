using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.ApplicationDb
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Laboratorio",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoLaboratorio",
                table: "Laboratorio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoUbicacion",
                table: "Laboratorio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PrincActivo",
                table: "Ips",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Rfv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DireccionFisica = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telefonos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Correos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TipoUbicacion = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNotificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rfv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rfv_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rfv_LaboratorioId",
                table: "Rfv",
                column: "LaboratorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rfv");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Laboratorio");

            migrationBuilder.DropColumn(
                name: "TipoLaboratorio",
                table: "Laboratorio");

            migrationBuilder.DropColumn(
                name: "TipoUbicacion",
                table: "Laboratorio");

            migrationBuilder.AlterColumn<string>(
                name: "PrincActivo",
                table: "Ips",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }
    }
}
