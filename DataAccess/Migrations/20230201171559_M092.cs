using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M092 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_CodigoNotiFacedra",
                table: "FMV_Ram2");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRamFin",
                table: "FMV_RamFarmacoRam",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FarmacoSospechosoComercial",
                table: "FMV_RamFarmaco",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaTratamientoFin",
                table: "FMV_RamFarmaco",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoNotiFacedra",
                table: "FMV_Ram2",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_CodigoNotiFacedra",
                table: "FMV_Ram2",
                column: "CodigoNotiFacedra",
                unique: true,
                filter: "[CodigoNotiFacedra] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FMV_Ram2_CodigoNotiFacedra",
                table: "FMV_Ram2");

            migrationBuilder.DropColumn(
                name: "FechaRamFin",
                table: "FMV_RamFarmacoRam");

            migrationBuilder.DropColumn(
                name: "FechaTratamientoFin",
                table: "FMV_RamFarmaco");

            migrationBuilder.AlterColumn<string>(
                name: "FarmacoSospechosoComercial",
                table: "FMV_RamFarmaco",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoNotiFacedra",
                table: "FMV_Ram2",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_CodigoNotiFacedra",
                table: "FMV_Ram2",
                column: "CodigoNotiFacedra",
                unique: true);
        }
    }
}
