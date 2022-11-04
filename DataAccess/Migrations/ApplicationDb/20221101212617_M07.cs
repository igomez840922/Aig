using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.ApplicationDb
{
    public partial class M07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertaNotaSeguridad");

            migrationBuilder.CreateTable(
                name: "Alerta",
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
                    table.PrimaryKey("PK_Alerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerta_OrigenAlerta_OrigenAlertaId",
                        column: x => x.OrigenAlertaId,
                        principalTable: "OrigenAlerta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alerta_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_EvaluadorId",
                table: "Alerta",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_OrigenAlertaId",
                table: "Alerta",
                column: "OrigenAlertaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerta");

            migrationBuilder.CreateTable(
                name: "AlertaNotaSeguridad",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    OrigenAlertaId = table.Column<long>(type: "bigint", nullable: true),
                    ActualizaMonografias = table.Column<bool>(type: "bit", nullable: false),
                    ConsentFirmado = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DCI = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaEntregaEvaluador = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    NumNota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrasConsideraciones = table.Column<bool>(type: "bit", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RecomProfPaciente = table.Column<bool>(type: "bit", nullable: false),
                    SuspencCancelRegSanitario = table.Column<bool>(type: "bit", nullable: false),
                    SuspencionRetiroLote = table.Column<bool>(type: "bit", nullable: false),
                    TipoAlerta = table.Column<int>(type: "int", nullable: false),
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
    }
}
