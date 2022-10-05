using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GateWayAlfaCoin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnviromentType = table.Column<int>(type: "int", nullable: false),
                    UrlProduction = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UrlSandBox = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ApiToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateWayAlfaCoin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GateWayBitPay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnviromentType = table.Column<int>(type: "int", nullable: false),
                    UrlProduction = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UrlSandBox = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ApiToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateWayBitPay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GateWayCoinBase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnviromentType = table.Column<int>(type: "int", nullable: false),
                    UrlProduction = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UrlSandBox = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateWayCoinBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GateWayCoinGate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnviromentType = table.Column<int>(type: "int", nullable: false),
                    UrlProduction = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UrlSandBox = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ApiToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateWayCoinGate", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GateWayAlfaCoin");

            migrationBuilder.DropTable(
                name: "GateWayBitPay");

            migrationBuilder.DropTable(
                name: "GateWayCoinBase");

            migrationBuilder.DropTable(
                name: "GateWayCoinGate");
        }
    }
}
