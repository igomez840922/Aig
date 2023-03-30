using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M147 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ram2_PersonalTrabajador_PersonalTrabajadorTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_PersonalTrabajadorTBId",
                table: "FMV_Ram2");

            migrationBuilder.DropColumn(
                name: "PersonalTrabajadorTBId",
                table: "FMV_Ram2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PersonalTrabajadorTBId",
                table: "FMV_Ram2",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_PersonalTrabajadorTBId",
                table: "FMV_Ram2",
                column: "PersonalTrabajadorTBId");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ram2_PersonalTrabajador_PersonalTrabajadorTBId",
                table: "FMV_Ram2",
                column: "PersonalTrabajadorTBId",
                principalTable: "PersonalTrabajador",
                principalColumn: "Id");
        }
    }
}
