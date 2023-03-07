using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M142 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetalleFalla",
                table: "FMV_Ff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FMV_Lote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FfId = table.Column<long>(type: "bigint", nullable: true),
                    FtId = table.Column<long>(type: "bigint", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaExpira = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Lote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Lote_FMV_Ff_FfId",
                        column: x => x.FfId,
                        principalTable: "FMV_Ff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FMV_Lote_FMV_Ft_FtId",
                        column: x => x.FtId,
                        principalTable: "FMV_Ft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Lote_FfId",
                table: "FMV_Lote",
                column: "FfId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Lote_FtId",
                table: "FMV_Lote",
                column: "FtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMV_Lote");

            migrationBuilder.DropColumn(
                name: "DetalleFalla",
                table: "FMV_Ff");
        }
    }
}
