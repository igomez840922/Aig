using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.ApplicationDb
{
    public partial class M05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrigenAlerta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigenAlerta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertaNotaSeguridad",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEvaluador = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    OrigenAlertaId = table.Column<long>(type: "bigint", nullable: true),
                    TipoAlerta = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DCI = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecomProfPaciente = table.Column<bool>(type: "bit", nullable: false),
                    ActualizaMonografias = table.Column<bool>(type: "bit", nullable: false),
                    ConsentFirmado = table.Column<bool>(type: "bit", nullable: false),
                    SuspencionRetiroLote = table.Column<bool>(type: "bit", nullable: false),
                    SuspencCancelRegSanitario = table.Column<bool>(type: "bit", nullable: false),
                    OtrasConsideraciones = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    NumNota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertaNotaSeguridad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertaNotaSeguridad_OrigenAlerta_OrigenAlertaId",
                        column: x => x.OrigenAlertaId,
                        principalTable: "OrigenAlerta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AlertaNotaSeguridad_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertaNotaSeguridad_EvaluadorId",
                table: "AlertaNotaSeguridad",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertaNotaSeguridad_OrigenAlertaId",
                table: "AlertaNotaSeguridad",
                column: "OrigenAlertaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertaNotaSeguridad");

            migrationBuilder.DropTable(
                name: "OrigenAlerta");
        }
    }
}
