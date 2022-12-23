using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M042 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_CodExterno",
                table: "FMV_Ram");

            migrationBuilder.AlterColumn<string>(
                name: "CodExterno",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "TipoNotificacionDesc",
                table: "FMV_Ram",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_CodExterno",
                table: "FMV_Ram",
                column: "CodExterno",
                unique: true,
                filter: "[CodExterno] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram_CodExterno",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "TipoNotificacionDesc",
                table: "FMV_Ram");

            migrationBuilder.AlterColumn<string>(
                name: "CodExterno",
                table: "FMV_Ram",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram_CodExterno",
                table: "FMV_Ram",
                column: "CodExterno",
                unique: true);
        }
    }
}
