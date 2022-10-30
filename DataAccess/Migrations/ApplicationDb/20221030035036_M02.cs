using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.ApplicationDb
{
    public partial class M02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmrTB_Evaluador_EvaluadorId",
                table: "PmrTB");

            migrationBuilder.DropTable(
                name: "Evaluador");

            migrationBuilder.AlterColumn<string>(
                name: "NomComercial",
                table: "Ram",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateTable(
                name: "PersonalTrabajador",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Evaluador = table.Column<bool>(type: "bit", nullable: false),
                    Tramitador = table.Column<bool>(type: "bit", nullable: false),
                    Registrador = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrabajador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ips",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRegistrador = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistradorId = table.Column<long>(type: "bigint", nullable: true),
                    NomComercial = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PrincActivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EstatusRecepcion = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TramitadorId = table.Column<long>(type: "bigint", nullable: true),
                    EstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    FechaAsigEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    ResumenEjec = table.Column<int>(type: "int", nullable: false),
                    ResumenEjecTrad = table.Column<int>(type: "int", nullable: false),
                    Prioridad = table.Column<bool>(type: "bit", nullable: false),
                    FechaRev = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusRevision = table.Column<int>(type: "int", nullable: false),
                    ConfecConNormativa = table.Column<bool>(type: "bit", nullable: false),
                    NoInforme = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IpsData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ips_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ips_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ips_PersonalTrabajador_RegistradorId",
                        column: x => x.RegistradorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ips_PersonalTrabajador_TramitadorId",
                        column: x => x.TramitadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ips_EvaluadorId",
                table: "Ips",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ips_LaboratorioId",
                table: "Ips",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ips_RegistradorId",
                table: "Ips",
                column: "RegistradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ips_TramitadorId",
                table: "Ips",
                column: "TramitadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmrTB_PersonalTrabajador_EvaluadorId",
                table: "PmrTB",
                column: "EvaluadorId",
                principalTable: "PersonalTrabajador",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmrTB_PersonalTrabajador_EvaluadorId",
                table: "PmrTB");

            migrationBuilder.DropTable(
                name: "Ips");

            migrationBuilder.DropTable(
                name: "PersonalTrabajador");

            migrationBuilder.AlterColumn<string>(
                name: "NomComercial",
                table: "Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "Evaluador",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluador", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PmrTB_Evaluador_EvaluadorId",
                table: "PmrTB",
                column: "EvaluadorId",
                principalTable: "Evaluador",
                principalColumn: "Id");
        }
    }
}
