using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M085 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosPaciente",
                table: "FMV_Ft");

            migrationBuilder.AddColumn<long>(
                name: "DatosPacienteId",
                table: "FMV_Ft",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InspRutinaVigAgenciaId",
                table: "FMV_Ft",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "FMV_Ft",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FMV_FtDatosPaciente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FtId = table.Column<long>(type: "bigint", nullable: true),
                    NombrePaciente = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    InicialesPaciente = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HistClinica = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaTratInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaTratFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Indicacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ViaAdministracion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Concomitantes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_FtDatosPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_FtDatosPaciente_FMV_Ft_FtId",
                        column: x => x.FtId,
                        principalTable: "FMV_Ft",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_DatosPacienteId",
                table: "FMV_Ft",
                column: "DatosPacienteId",
                unique: true,
                filter: "[DatosPacienteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_InspRutinaVigAgenciaId",
                table: "FMV_Ft",
                column: "InspRutinaVigAgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_FtDatosPaciente_FtId",
                table: "FMV_FtDatosPaciente",
                column: "FtId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ft_AUD_InspRutinaVigAgenciaTB_InspRutinaVigAgenciaId",
                table: "FMV_Ft",
                column: "InspRutinaVigAgenciaId",
                principalTable: "AUD_InspRutinaVigAgenciaTB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ft_FMV_FtDatosPaciente_DatosPacienteId",
                table: "FMV_Ft",
                column: "DatosPacienteId",
                principalTable: "FMV_FtDatosPaciente",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ft_AUD_InspRutinaVigAgenciaTB_InspRutinaVigAgenciaId",
                table: "FMV_Ft");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ft_FMV_FtDatosPaciente_DatosPacienteId",
                table: "FMV_Ft");

            migrationBuilder.DropTable(
                name: "FMV_FtDatosPaciente");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ft_DatosPacienteId",
                table: "FMV_Ft");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ft_InspRutinaVigAgenciaId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "DatosPacienteId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "InspRutinaVigAgenciaId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "FMV_Ft");

            migrationBuilder.AddColumn<string>(
                name: "DatosPaciente",
                table: "FMV_Ft",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
