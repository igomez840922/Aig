using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmtpCorreo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SmtpServidor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SmtpPuerto = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpCorreo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmtpCorreo");
        }
    }
}
