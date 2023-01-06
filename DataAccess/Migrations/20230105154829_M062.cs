using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M062 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreDirigido",
                table: "AUD_Correspondencia",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DptoSeccionType",
                table: "AUD_Correspondencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailDirigido",
                table: "AUD_Correspondencia",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FMV_Ram2",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRecibidoCNFV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaEva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluadorId = table.Column<long>(type: "bigint", nullable: true),
                    RamType = table.Column<int>(type: "int", nullable: false),
                    RamOrigenType = table.Column<int>(type: "int", nullable: false),
                    CodigoNotiFacedra = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdFacedra = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CodigoCNFV = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CodExterno = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Grado = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TipoNotificacion = table.Column<int>(type: "int", nullable: false),
                    TipoNotificacionDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TipoInstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    ProvinciaId = table.Column<long>(type: "bigint", nullable: true),
                    InstitucionId = table.Column<long>(type: "bigint", nullable: true),
                    InstitucionDestinoId = table.Column<long>(type: "bigint", nullable: true),
                    InicialesPaciente = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HistClinica = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OtrosDiagnosticos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DatosLab = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ObservacionInfoNotifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccionesRegulatoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_Ram2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_Ram2_InstitucionDestino_InstitucionDestinoId",
                        column: x => x.InstitucionDestinoId,
                        principalTable: "InstitucionDestino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ram2_PersonalTrabajador_EvaluadorId",
                        column: x => x.EvaluadorId,
                        principalTable: "PersonalTrabajador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ram2_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FMV_Ram2_TipoInstitucion_TipoInstitucionId",
                        column: x => x.TipoInstitucionId,
                        principalTable: "TipoInstitucion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FMV_RamFarmaco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RamId = table.Column<long>(type: "bigint", nullable: true),
                    FarmacoSospechosoComercial = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FarmacoSospechosoDci = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Atc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubGrupoTerapeutico = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ViaAdministracion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Indicacion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FechaTratamiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConductaDosis = table.Column<int>(type: "int", nullable: false),
                    ConductaTerapia = table.Column<int>(type: "int", nullable: false),
                    Reexposicion = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_RamFarmaco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_RamFarmaco_FMV_Ram2_RamId",
                        column: x => x.RamId,
                        principalTable: "FMV_Ram2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FMV_RamFarmacoRam",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmacoId = table.Column<long>(type: "bigint", nullable: true),
                    Ram = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TerWhoArt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocId = table.Column<long>(type: "bigint", nullable: true),
                    Soc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concomitantes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRam = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Desenlace = table.Column<int>(type: "int", nullable: false),
                    EvoDosis = table.Column<int>(type: "int", nullable: false),
                    EvoTerapia = table.Column<int>(type: "int", nullable: false),
                    ConReexposicion = table.Column<int>(type: "int", nullable: false),
                    RamUnaDosis = table.Column<int>(type: "int", nullable: false),
                    SecTemporal = table.Column<int>(type: "int", nullable: false),
                    Stemp = table.Column<int>(type: "int", nullable: false),
                    ConPrevio = table.Column<int>(type: "int", nullable: false),
                    Cprev = table.Column<int>(type: "int", nullable: false),
                    EfecRetirada = table.Column<int>(type: "int", nullable: false),
                    Reti = table.Column<int>(type: "int", nullable: false),
                    EfecReexposicion = table.Column<int>(type: "int", nullable: false),
                    Reex = table.Column<int>(type: "int", nullable: false),
                    CausasAlter = table.Column<int>(type: "int", nullable: false),
                    Alter = table.Column<int>(type: "int", nullable: false),
                    FactContribuyentes = table.Column<int>(type: "int", nullable: false),
                    Facon = table.Column<int>(type: "int", nullable: false),
                    ExpComplementarias = table.Column<int>(type: "int", nullable: false),
                    Xplc = table.Column<int>(type: "int", nullable: false),
                    IntRam = table.Column<int>(type: "int", nullable: false),
                    Gravedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FromSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMV_RamFarmacoRam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMV_RamFarmacoRam_FMV_RamFarmaco_FarmacoId",
                        column: x => x.FarmacoId,
                        principalTable: "FMV_RamFarmaco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_CodExterno",
                table: "FMV_Ram2",
                column: "CodExterno",
                unique: true,
                filter: "[CodExterno] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_CodigoCNFV",
                table: "FMV_Ram2",
                column: "CodigoCNFV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_CodigoNotiFacedra",
                table: "FMV_Ram2",
                column: "CodigoNotiFacedra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_EvaluadorId",
                table: "FMV_Ram2",
                column: "EvaluadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_IdFacedra",
                table: "FMV_Ram2",
                column: "IdFacedra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_InstitucionDestinoId",
                table: "FMV_Ram2",
                column: "InstitucionDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_ProvinciaId",
                table: "FMV_Ram2",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_Ram2_TipoInstitucionId",
                table: "FMV_Ram2",
                column: "TipoInstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_RamFarmaco_RamId",
                table: "FMV_RamFarmaco",
                column: "RamId");

            migrationBuilder.CreateIndex(
                name: "IX_FMV_RamFarmacoRam_FarmacoId",
                table: "FMV_RamFarmacoRam",
                column: "FarmacoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMV_RamFarmacoRam");

            migrationBuilder.DropTable(
                name: "FMV_RamFarmaco");

            migrationBuilder.DropTable(
                name: "FMV_Ram2");

            migrationBuilder.DropColumn(
                name: "DptoSeccionType",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "EmailDirigido",
                table: "AUD_Correspondencia");

            migrationBuilder.AlterColumn<string>(
                name: "NombreDirigido",
                table: "AUD_Correspondencia",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }
    }
}
