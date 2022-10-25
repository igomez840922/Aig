using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AUD_Inspeccion_AUD_InspeccionTBId",
                table: "Attachment");

            migrationBuilder.RenameColumn(
                name: "AUD_InspeccionTBId",
                table: "Attachment",
                newName: "InspeccionId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_AUD_InspeccionTBId",
                table: "Attachment",
                newName: "IX_Attachment_InspeccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_AUD_Inspeccion_InspeccionId",
                table: "Attachment",
                column: "InspeccionId",
                principalTable: "AUD_Inspeccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AUD_Inspeccion_InspeccionId",
                table: "Attachment");

            migrationBuilder.RenameColumn(
                name: "InspeccionId",
                table: "Attachment",
                newName: "AUD_InspeccionTBId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_InspeccionId",
                table: "Attachment",
                newName: "IX_Attachment_AUD_InspeccionTBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_AUD_Inspeccion_AUD_InspeccionTBId",
                table: "Attachment",
                column: "AUD_InspeccionTBId",
                principalTable: "AUD_Inspeccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
