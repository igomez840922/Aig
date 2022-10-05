using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GateWayCoinPayment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnviromentType = table.Column<int>(type: "int", nullable: false),
                    UrlProduction = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UrlSandBox = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PublicKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PrivateKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MerchantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlNotifications = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateWayCoinPayment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GateWayCoinPayment");
        }
    }
}
