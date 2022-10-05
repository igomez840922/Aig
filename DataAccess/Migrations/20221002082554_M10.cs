using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CryptoAmount",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionsAmount",
                table: "CurrencyFiat",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "TransactionsCount",
                table: "CurrencyFiat",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionsAmount",
                table: "CurrencyCrypto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "TransactionsCount",
                table: "CurrencyCrypto",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CryptoAmount",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TransactionsAmount",
                table: "CurrencyFiat");

            migrationBuilder.DropColumn(
                name: "TransactionsCount",
                table: "CurrencyFiat");

            migrationBuilder.DropColumn(
                name: "TransactionsAmount",
                table: "CurrencyCrypto");

            migrationBuilder.DropColumn(
                name: "TransactionsCount",
                table: "CurrencyCrypto");
        }
    }
}
