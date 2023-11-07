using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M168 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetiroRetencionType",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.AddColumn<string>(
                name: "DatosRetiroRetencion",
                table: "AUD_InspRetiroRetencion",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosRetiroRetencion",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.AddColumn<int>(
                name: "RetiroRetencionType",
                table: "AUD_InspRetiroRetencion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
