using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aig.Farmacoterapia.Infrastructure.Migrations
{
    public partial class Y13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Distribuidor_PaisAcondicionadorPrimario",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Distribuidor_PaisAcondicionadorSecundario",
                table: "AigRecord",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distribuidor_PaisAcondicionadorPrimario",
                table: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Distribuidor_PaisAcondicionadorSecundario",
                table: "AigRecord");
        }
    }
}
