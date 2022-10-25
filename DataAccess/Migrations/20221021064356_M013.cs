using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Attachment",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AbsolutePath",
                table: "Attachment",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AUD_InspeccionTBId",
                table: "Attachment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Attachment",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Attachment",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_AUD_InspeccionTBId",
                table: "Attachment",
                column: "AUD_InspeccionTBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_AUD_Inspeccion_AUD_InspeccionTBId",
                table: "Attachment",
                column: "AUD_InspeccionTBId",
                principalTable: "AUD_Inspeccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AUD_Inspeccion_AUD_InspeccionTBId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_AUD_InspeccionTBId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "AUD_InspeccionTBId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Attachment");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Attachment",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AbsolutePath",
                table: "Attachment",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
