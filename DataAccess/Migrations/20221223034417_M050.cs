using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M050 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosisEsavi",
                table: "FMV_Esavi");

            migrationBuilder.AlterColumn<string>(
                name: "VacunaComercial",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DosisPresenta",
                table: "FMV_Esavi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosisPresenta",
                table: "FMV_Esavi");

            migrationBuilder.AlterColumn<string>(
                name: "VacunaComercial",
                table: "FMV_Esavi",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "DosisEsavi",
                table: "FMV_Esavi",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
