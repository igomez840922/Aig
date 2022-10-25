using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegSanitario",
                table: "AUD_ProdRetiroRetencion");

            migrationBuilder.AddColumn<string>(
                name: "RegSanitario",
                table: "AUD_Inspeccion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegSanitario",
                table: "AUD_Inspeccion");

            migrationBuilder.AddColumn<string>(
                name: "RegSanitario",
                table: "AUD_ProdRetiroRetencion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
