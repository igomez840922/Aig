using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluacionCausalidad",
                table: "FMV_Ft");

            migrationBuilder.AlterColumn<string>(
                name: "NombrePaciente",
                table: "FMV_FtDatosPaciente",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<long>(
                name: "EvaluacionCausalidadId",
                table: "FMV_Ft",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportaFallaTerapeutica",
                table: "FMV_Ft",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FtEvaluacionCausalidad",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FtId = table.Column<long>(type: "bigint", nullable: true),
                    FarmCinCompleja = table.Column<int>(type: "int", nullable: false),
                    CondClinicas = table.Column<int>(type: "int", nullable: false),
                    Preescrito = table.Column<int>(type: "int", nullable: false),
                    UsoInad = table.Column<int>(type: "int", nullable: false),
                    EntrenamientoPaciente = table.Column<int>(type: "int", nullable: false),
                    PotInteracciones = table.Column<int>(type: "int", nullable: false),
                    NotificacionFT = table.Column<int>(type: "int", nullable: false),
                    ProBiofarmaceutico = table.Column<int>(type: "int", nullable: false),
                    Deficiencias = table.Column<int>(type: "int", nullable: false),
                    FactAsociados = table.Column<int>(type: "int", nullable: false),
                    EvolucionCausalidad = table.Column<int>(type: "int", nullable: false),
                    CatCausalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FtEvaluacionCausalidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FtEvaluacionCausalidad_FMV_Ft_FtId",
                        column: x => x.FtId,
                        principalTable: "FMV_Ft",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_EvaluacionCausalidadId",
                table: "FMV_Ft",
                column: "EvaluacionCausalidadId",
                unique: true,
                filter: "[EvaluacionCausalidadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FtEvaluacionCausalidad_FtId",
                table: "FtEvaluacionCausalidad",
                column: "FtId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ft_FtEvaluacionCausalidad_EvaluacionCausalidadId",
                table: "FMV_Ft",
                column: "EvaluacionCausalidadId",
                principalTable: "FtEvaluacionCausalidad",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ft_FtEvaluacionCausalidad_EvaluacionCausalidadId",
                table: "FMV_Ft");

            migrationBuilder.DropTable(
                name: "FtEvaluacionCausalidad");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ft_EvaluacionCausalidadId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "EvaluacionCausalidadId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "ReportaFallaTerapeutica",
                table: "FMV_Ft");

            migrationBuilder.AlterColumn<string>(
                name: "NombrePaciente",
                table: "FMV_FtDatosPaciente",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionCausalidad",
                table: "FMV_Ft",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
