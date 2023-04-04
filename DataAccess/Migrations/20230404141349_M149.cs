using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M149 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_EvaluadorId",
                table: "FMV_Ram2");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_EvaluadorId",
                table: "FMV_Ram2",
                column: "EvaluadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_EvaluadorId",
                table: "FMV_Ram2");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_EvaluadorId",
                table: "FMV_Ram2",
                column: "EvaluadorId",
                unique: true,
                filter: "[EvaluadorId] IS NOT NULL");
        }
    }
}
