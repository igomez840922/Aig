using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M046 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "FMV_Ff");

            migrationBuilder.AddColumn<long>(
                name: "FabricanteId",
                table: "FMV_Ft",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FabricanteId",
                table: "FMV_Ff",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ft_FabricanteId",
                table: "FMV_Ft",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ff_FabricanteId",
                table: "FMV_Ff",
                column: "FabricanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ff_Laboratorio_FabricanteId",
                table: "FMV_Ff",
                column: "FabricanteId",
                principalTable: "Laboratorio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ft_Laboratorio_FabricanteId",
                table: "FMV_Ft",
                column: "FabricanteId",
                principalTable: "Laboratorio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ff_Laboratorio_FabricanteId",
                table: "FMV_Ff");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ft_Laboratorio_FabricanteId",
                table: "FMV_Ft");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ft_FabricanteId",
                table: "FMV_Ft");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ff_FabricanteId",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "FMV_Ff");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
