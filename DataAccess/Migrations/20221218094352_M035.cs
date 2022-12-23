using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M035 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Nota_InstitucionDestino_InstitucionDestinoId",
                table: "FMV_Nota");

            migrationBuilder.RenameColumn(
                name: "InstitucionDestinoId",
                table: "FMV_Nota",
                newName: "InstitucionDestinoTBId");

            migrationBuilder.RenameIndex(
                name: "IX_FMV_Nota_InstitucionDestinoId",
                table: "FMV_Nota",
                newName: "IX_FMV_Nota_InstitucionDestinoTBId");

            migrationBuilder.AlterColumn<string>(
                name: "Destinatario",
                table: "FMV_Nota",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instituciones",
                table: "FMV_Nota",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Nota_InstitucionDestino_InstitucionDestinoTBId",
                table: "FMV_Nota",
                column: "InstitucionDestinoTBId",
                principalTable: "InstitucionDestino",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Nota_InstitucionDestino_InstitucionDestinoTBId",
                table: "FMV_Nota");

            migrationBuilder.DropColumn(
                name: "Instituciones",
                table: "FMV_Nota");

            migrationBuilder.RenameColumn(
                name: "InstitucionDestinoTBId",
                table: "FMV_Nota",
                newName: "InstitucionDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_FMV_Nota_InstitucionDestinoTBId",
                table: "FMV_Nota",
                newName: "IX_FMV_Nota_InstitucionDestinoId");

            migrationBuilder.AlterColumn<string>(
                name: "Destinatario",
                table: "FMV_Nota",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Nota_InstitucionDestino_InstitucionDestinoId",
                table: "FMV_Nota",
                column: "InstitucionDestinoId",
                principalTable: "InstitucionDestino",
                principalColumn: "Id");
        }
    }
}
