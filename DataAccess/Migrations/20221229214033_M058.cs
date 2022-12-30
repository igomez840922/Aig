using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M058 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destinatario",
                table: "FMV_Nota");

            migrationBuilder.AddColumn<string>(
                name: "NotaContactos",
                table: "FMV_Nota",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaContactos",
                table: "FMV_Nota");

            migrationBuilder.AddColumn<string>(
                name: "Destinatario",
                table: "FMV_Nota",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
