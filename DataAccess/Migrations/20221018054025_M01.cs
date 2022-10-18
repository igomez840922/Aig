using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUD_ProdRetiroRetencion_Pais_PaisId",
                table: "AUD_ProdRetiroRetencion");

            migrationBuilder.DropIndex(
                name: "IX_AUD_ProdRetiroRetencion_PaisId",
                table: "AUD_ProdRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "AUD_ProdRetiroRetencion");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "AUD_ProdRetiroRetencion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "AUD_InspRetiroRetencion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeccionOficinaRegional",
                table: "AUD_InspRetiroRetencion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pais",
                table: "AUD_ProdRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "SeccionOficinaRegional",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.AddColumn<long>(
                name: "PaisId",
                table: "AUD_ProdRetiroRetencion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AUD_ProdRetiroRetencion_PaisId",
                table: "AUD_ProdRetiroRetencion",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_AUD_ProdRetiroRetencion_Pais_PaisId",
                table: "AUD_ProdRetiroRetencion",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id");
        }
    }
}
