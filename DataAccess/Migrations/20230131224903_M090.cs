using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M090 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_IpsMedicamento_MV_Ips_IpsId",
                table: "FMV_IpsMedicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_MV_Ips_Laboratorio_LaboratorioId",
                table: "MV_Ips");

            migrationBuilder.DropForeignKey(
                name: "FK_MV_Ips_PersonalTrabajador_EvaluadorId",
                table: "MV_Ips");

            migrationBuilder.DropForeignKey(
                name: "FK_MV_Ips_PersonalTrabajador_RegistradorId",
                table: "MV_Ips");

            migrationBuilder.DropForeignKey(
                name: "FK_MV_Ips_PersonalTrabajador_TramitadorId",
                table: "MV_Ips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MV_Ips",
                table: "MV_Ips");

            migrationBuilder.DropColumn(
                name: "NomComercial",
                table: "MV_Ips");

            migrationBuilder.DropColumn(
                name: "NomDCI",
                table: "MV_Ips");

            migrationBuilder.DropColumn(
                name: "RegSanitario",
                table: "MV_Ips");

            migrationBuilder.RenameTable(
                name: "MV_Ips",
                newName: "FMV_Ips");

            migrationBuilder.RenameColumn(
                name: "LaboratorioId",
                table: "FMV_Ips",
                newName: "LaboratorioTBId");

            migrationBuilder.RenameIndex(
                name: "IX_MV_Ips_TramitadorId",
                table: "FMV_Ips",
                newName: "IX_FMV_Ips_TramitadorId");

            migrationBuilder.RenameIndex(
                name: "IX_MV_Ips_RegistradorId",
                table: "FMV_Ips",
                newName: "IX_FMV_Ips_RegistradorId");

            migrationBuilder.RenameIndex(
                name: "IX_MV_Ips_LaboratorioId",
                table: "FMV_Ips",
                newName: "IX_FMV_Ips_LaboratorioTBId");

            migrationBuilder.RenameIndex(
                name: "IX_MV_Ips_EvaluadorId",
                table: "FMV_Ips",
                newName: "IX_FMV_Ips_EvaluadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FMV_Ips",
                table: "FMV_Ips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ips_Laboratorio_LaboratorioTBId",
                table: "FMV_Ips",
                column: "LaboratorioTBId",
                principalTable: "Laboratorio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ips_PersonalTrabajador_EvaluadorId",
                table: "FMV_Ips",
                column: "EvaluadorId",
                principalTable: "PersonalTrabajador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ips_PersonalTrabajador_RegistradorId",
                table: "FMV_Ips",
                column: "RegistradorId",
                principalTable: "PersonalTrabajador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_Ips_PersonalTrabajador_TramitadorId",
                table: "FMV_Ips",
                column: "TramitadorId",
                principalTable: "PersonalTrabajador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_IpsMedicamento_FMV_Ips_IpsId",
                table: "FMV_IpsMedicamento",
                column: "IpsId",
                principalTable: "FMV_Ips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ips_Laboratorio_LaboratorioTBId",
                table: "FMV_Ips");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ips_PersonalTrabajador_EvaluadorId",
                table: "FMV_Ips");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ips_PersonalTrabajador_RegistradorId",
                table: "FMV_Ips");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_Ips_PersonalTrabajador_TramitadorId",
                table: "FMV_Ips");

            migrationBuilder.DropForeignKey(
                name: "FK_FMV_IpsMedicamento_FMV_Ips_IpsId",
                table: "FMV_IpsMedicamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FMV_Ips",
                table: "FMV_Ips");

            migrationBuilder.RenameTable(
                name: "FMV_Ips",
                newName: "MV_Ips");

            migrationBuilder.RenameColumn(
                name: "LaboratorioTBId",
                table: "MV_Ips",
                newName: "LaboratorioId");

            migrationBuilder.RenameIndex(
                name: "IX_FMV_Ips_TramitadorId",
                table: "MV_Ips",
                newName: "IX_MV_Ips_TramitadorId");

            migrationBuilder.RenameIndex(
                name: "IX_FMV_Ips_RegistradorId",
                table: "MV_Ips",
                newName: "IX_MV_Ips_RegistradorId");

            migrationBuilder.RenameIndex(
                name: "IX_FMV_Ips_LaboratorioTBId",
                table: "MV_Ips",
                newName: "IX_MV_Ips_LaboratorioId");

            migrationBuilder.RenameIndex(
                name: "IX_FMV_Ips_EvaluadorId",
                table: "MV_Ips",
                newName: "IX_MV_Ips_EvaluadorId");

            migrationBuilder.AddColumn<string>(
                name: "NomComercial",
                table: "MV_Ips",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomDCI",
                table: "MV_Ips",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegSanitario",
                table: "MV_Ips",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MV_Ips",
                table: "MV_Ips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FMV_IpsMedicamento_MV_Ips_IpsId",
                table: "FMV_IpsMedicamento",
                column: "IpsId",
                principalTable: "MV_Ips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MV_Ips_Laboratorio_LaboratorioId",
                table: "MV_Ips",
                column: "LaboratorioId",
                principalTable: "Laboratorio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MV_Ips_PersonalTrabajador_EvaluadorId",
                table: "MV_Ips",
                column: "EvaluadorId",
                principalTable: "PersonalTrabajador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MV_Ips_PersonalTrabajador_RegistradorId",
                table: "MV_Ips",
                column: "RegistradorId",
                principalTable: "PersonalTrabajador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MV_Ips_PersonalTrabajador_TramitadorId",
                table: "MV_Ips",
                column: "TramitadorId",
                principalTable: "PersonalTrabajador",
                principalColumn: "Id");
        }
    }
}
