using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aig.Farmacoterapia.Infrastructure.Migrations
{
    public partial class Y12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AigService",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AigService");
        }
    }
}
