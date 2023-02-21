using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M089 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cargo",
                table: "FMV_Contactos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.CreateTable(
                name: "FMV_IpsMedicamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpsId = table.Column<long>(type: "bigint", nullable: true),
                    NomComercial = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NomDCI = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RegSanitario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_IpsMedicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_IpsMedicamento_Laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_IpsMedicamento_MV_Ips_IpsId",
                        column: x => x.IpsId,
                        principalTable: "MV_Ips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_IpsMedicamento_IpsId",
                table: "FMV_IpsMedicamento",
                column: "IpsId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_IpsMedicamento_LaboratorioId",
                table: "FMV_IpsMedicamento",
                column: "LaboratorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMV_IpsMedicamento");

            migrationBuilder.AlterColumn<string>(
                name: "Cargo",
                table: "FMV_Contactos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
