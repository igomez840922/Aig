using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class M165 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "UserProfile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "TipoVacuna",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "TipoInstitucion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "SmtpCorreo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "Provincia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "ProductoEstablecimiento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "PersonalTrabajador",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "Pais",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "Laboratorio",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "IntensidadEsavi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "InstitucionDestino",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FtEvaluacionCausalidad",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_TerMedra",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Soc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Rfv",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_RamNotificacion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_RamFarmacoRam",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_RamFarmaco",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Ram2",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Ram",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_PmrProducto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Pmr",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_OrigenAlerta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_NotaDestino",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Nota",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Lote",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_IpsMedicamento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Ips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_FtDatosPaciente",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Ft",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Ff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_EsaviVacunaEsavi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_EsaviVacuna",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_EsaviNotificacion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Esavi2",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Esavi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Contactos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "FMV_Alerta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "Farmaco",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "Distrito",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "Corregimiento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_TipoEstablecimiento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_ProdRetiroRetencion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspRutinaVigFarmaciaTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspRutinaVigAgenciaTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspRetiroRetencion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspInvestigacionTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspGuiBPMFabNatMedicinaTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspGuiaBPMFabricanteMed",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspGuiaBPM_BpaTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_Inspeccion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspDisposicionFinalTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspCierreOperacionTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspAperturaCosmetArtesanalTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspAperFabricanteCosmetMed",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspAperFabricante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspAperCambUbicFarm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspAperCambUbicBotiquinTB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_InspAperCambUbicAgen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_Establecimiento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_CorrespondenciaRespRevision",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_CorrespondenciaContacto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_CorrespondenciaAsunto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "AUD_Correspondencia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "Attachment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "ActividadEstablecimiento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PendingUpdate",
                table: "_DatosEstablecimiento",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "TipoVacuna");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "TipoInstitucion");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "SmtpCorreo");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "Provincia");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "ProductoEstablecimiento");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "PersonalTrabajador");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "Laboratorio");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "IntensidadEsavi");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "InstitucionDestino");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FtEvaluacionCausalidad");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_TerMedra");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Soc");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Rfv");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_RamNotificacion");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_RamFarmacoRam");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_RamFarmaco");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Ram2");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Ram");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_PmrProducto");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Pmr");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_OrigenAlerta");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_NotaDestino");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Nota");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Lote");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_IpsMedicamento");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Ips");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_FtDatosPaciente");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Ft");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Ff");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_EsaviVacunaEsavi");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_EsaviVacuna");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_EsaviNotificacion");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Esavi2");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Esavi");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Contactos");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "FMV_Alerta");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "Farmaco");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "Distrito");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "Corregimiento");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_TipoEstablecimiento");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_ProdRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspRutinaVigFarmaciaTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspRutinaVigAgenciaTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspRetiroRetencion");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspInvestigacionTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspGuiBPMFabNatMedicinaTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspGuiBPMFabCosmeticoMedTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspGuiaBPMLabAcondicionadorTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspGuiaBPMFabricanteMed");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspGuiaBPM_BpaTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_Inspeccion");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspDisposicionFinalTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspCierreOperacionTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspAperturaCosmetArtesanalTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspAperFabricanteCosmetMed");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspAperFabricante");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspAperCambUbicFarm");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspAperCambUbicBotiquinTB");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_InspAperCambUbicAgen");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_Establecimiento");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_CorrespondenciaRespRevision");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_CorrespondenciaContacto");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_CorrespondenciaAsunto");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "AUD_Correspondencia");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "ActividadEstablecimiento");

            migrationBuilder.DropColumn(
                name: "PendingUpdate",
                table: "_DatosEstablecimiento");
        }
    }
}
