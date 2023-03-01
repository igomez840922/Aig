using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M137 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_CodExterno",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_CodigoCNFV",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_CodigoNotiFacedra",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_IdFacedra",
                table: "FMV_Ram2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_CodExterno",
                table: "FMV_Ram2",
                column: "CodExterno",
                unique: true,
                filter: "[CodExterno] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_CodigoCNFV",
                table: "FMV_Ram2",
                column: "CodigoCNFV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_CodigoNotiFacedra",
                table: "FMV_Ram2",
                column: "CodigoNotiFacedra",
                unique: true,
                filter: "[CodigoNotiFacedra] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_IdFacedra",
                table: "FMV_Ram2",
                column: "IdFacedra",
                unique: true,
                filter: "[IdFacedra] IS NOT NULL");
        }
    }
}
