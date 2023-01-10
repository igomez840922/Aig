using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M066 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_IdFacedra",
                table: "FMV_Ram2");

            migrationBuilder.AlterColumn<string>(
                name: "IdFacedra",
                table: "FMV_Ram2",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_IdFacedra",
                table: "FMV_Ram2",
                column: "IdFacedra",
                unique: true,
                filter: "[IdFacedra] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_IdFacedra",
                table: "FMV_Ram2");

            migrationBuilder.AlterColumn<string>(
                name: "IdFacedra",
                table: "FMV_Ram2",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_IdFacedra",
                table: "FMV_Ram2",
                column: "IdFacedra",
                unique: true);
        }
    }
}
