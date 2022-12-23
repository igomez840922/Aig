using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SOC",
                table: "FMV_EsaviNotificacion",
                newName: "Soc");

            migrationBuilder.AlterColumn<string>(
                name: "Soc",
                table: "FMV_EsaviNotificacion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "SocId",
                table: "FMV_EsaviNotificacion",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocId",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.RenameColumn(
                name: "Soc",
                table: "FMV_EsaviNotificacion",
                newName: "SOC");

            migrationBuilder.AlterColumn<int>(
                name: "SOC",
                table: "FMV_EsaviNotificacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
