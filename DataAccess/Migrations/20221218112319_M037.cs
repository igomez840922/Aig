using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M037 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_PmrProducto_FMV_Pmr_PmrId",
                table: "FMV_PmrProducto");

            migrationBuilder.DropIndex(
                name: "IX_FMV_PmrProducto_PmrId",
                table: "FMV_PmrProducto");

            migrationBuilder.DropColumn(
                name: "PmrId",
                table: "FMV_PmrProducto");

            migrationBuilder.AddColumn<string>(
                name: "Adjunto",
                table: "FMV_Pmr",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PmrProductoId",
                table: "FMV_Pmr",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Pmr_PmrProductoId",
                table: "FMV_Pmr",
                column: "PmrProductoId",
                unique: true,
                filter: "[PmrProductoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Pmr_FMV_PmrProducto_PmrProductoId",
                table: "FMV_Pmr",
                column: "PmrProductoId",
                principalTable: "FMV_PmrProducto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Pmr_FMV_PmrProducto_PmrProductoId",
                table: "FMV_Pmr");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Pmr_PmrProductoId",
                table: "FMV_Pmr");

            migrationBuilder.DropColumn(
                name: "Adjunto",
                table: "FMV_Pmr");

            migrationBuilder.DropColumn(
                name: "PmrProductoId",
                table: "FMV_Pmr");

            migrationBuilder.AddColumn<long>(
                name: "PmrId",
                table: "FMV_PmrProducto",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_PmrProducto_PmrId",
                table: "FMV_PmrProducto",
                column: "PmrId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_PmrProducto_FMV_Pmr_PmrId",
                table: "FMV_PmrProducto",
                column: "PmrId",
                principalTable: "FMV_Pmr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
