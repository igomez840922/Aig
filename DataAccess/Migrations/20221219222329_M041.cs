using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M041 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdFacedra",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoNotiFacedra",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ram",
                table: "FMV_Ram",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_CodExterno",
                table: "FMV_Ram",
                column: "CodExterno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_CodigoCNFV",
                table: "FMV_Ram",
                column: "CodigoCNFV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_CodigoNotiFacedra",
                table: "FMV_Ram",
                column: "CodigoNotiFacedra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_IdFacedra",
                table: "FMV_Ram",
                column: "IdFacedra",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_CodExterno",
                table: "FMV_Ram");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_CodigoCNFV",
                table: "FMV_Ram");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_CodigoNotiFacedra",
                table: "FMV_Ram");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_IdFacedra",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "FMV_Ram");

            migrationBuilder.AlterColumn<string>(
                name: "IdFacedra",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoNotiFacedra",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }
    }
}
