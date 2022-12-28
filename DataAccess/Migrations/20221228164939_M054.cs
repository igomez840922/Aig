using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M054 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUD_Correspondencia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Establecimiento = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NumDocRecibido = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRevision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DptoSeccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreDirigido = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreRecibido = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FirmaRecibido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRecibo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespuestaCaso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumDocRespuesta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUD_Correspondencia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUD_Correspondencia");
        }
    }
}
