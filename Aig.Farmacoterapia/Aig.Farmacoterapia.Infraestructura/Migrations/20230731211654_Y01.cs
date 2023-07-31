using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aig.Farmacoterapia.Infrastructure.Migrations
{
    public partial class Y01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "AigRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RenovacionNumero = table.Column<int>(type: "int", nullable: false),
                    RenovacionTexto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Libro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribuidor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Presentaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excipientes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaExpedicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaUltimaActualizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSheetURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProspectusURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AigRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AigRecord");

            migrationBuilder.DropColumn(
                name: "Documents",
                table: "AigEstudio");

            migrationBuilder.DropColumn(
                name: "Nota_DirectoraNacional",
                table: "AigEstudio");

            migrationBuilder.DropColumn(
                name: "Nota_Jefe",
                table: "AigEstudio");

            migrationBuilder.DropColumn(
                name: "Nota_Lines",
                table: "AigEstudio");
        }
    }
}
