using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M075 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaExp",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "FechaExp",
                table: "FMV_Ff");

            migrationBuilder.AddColumn<int>(
                name: "EmailReadStatus",
                table: "FMV_Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmailReadTimes",
                table: "FMV_Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmailStatus",
                table: "FMV_Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaExpira",
                table: "FMV_Ft",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaExpira",
                table: "FMV_Ff",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailReadStatus",
                table: "FMV_Nota");

            migrationBuilder.DropColumn(
                name: "EmailReadTimes",
                table: "FMV_Nota");

            migrationBuilder.DropColumn(
                name: "EmailStatus",
                table: "FMV_Nota");

            migrationBuilder.DropColumn(
                name: "FechaExpira",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "FechaExpira",
                table: "FMV_Ff");

            migrationBuilder.AddColumn<string>(
                name: "FechaExp",
                table: "FMV_Ft",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaExp",
                table: "FMV_Ff",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
