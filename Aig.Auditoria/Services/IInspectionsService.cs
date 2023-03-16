using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IInspectionsService
    {
        Task<GenericModel<InspeccionDTO>> BandejaEntrada(GenericModel<InspeccionDTO> model);
        Task<Stream> ExportToExcel(GenericModel<InspeccionDTO> model);
        Task<GenericModel<AUD_InspeccionTB>> FindAll(GenericModel<AUD_InspeccionTB> model);
        Task<List<AUD_InspeccionTB>> GetAll();
        Task<AUD_InspeccionTB> Get(long id);
        Task<AUD_InspeccionTB> Save(AUD_InspeccionTB data);
        Task<AUD_InspeccionTB> Delete(long id);
        Task<int> Count();
        Task<AUD_InspeccionTB> Save_GeneralData(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_Conclusiones(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Frima(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap13(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap14(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap15(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap16(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap17(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap18(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap19(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Frima(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Frima(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap13(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap14(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap15(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap16(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap17(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap18(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap19(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap20(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Frima(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_Investigaciones_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_Investigaciones_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_Investigaciones_Frima(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_RetiroRetencion_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RetiroRetencion_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RetiroRetencion_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_RetiroRetencion_Frima(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_CierreOperacion_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_CierreOperacion_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_CierreOperacion_Frima(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_DisposicionFinal_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_DisposicionFinal_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_DisposicionFinal_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_DisposicionFinal_Firma(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap13(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap14(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Firma(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap13(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Firma(AUD_InspeccionTB inspeccion);


        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap13(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap14(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap15(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap16(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap17(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap18(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap19(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap20(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap21(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap22(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap23(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap24(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap25(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Firma(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap13(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap14(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap15(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap16(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap17(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap18(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap19(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Firma(AUD_InspeccionTB inspeccion);


        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap13(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap14(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap15(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap16(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap17(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap18(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap19(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap20(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap21(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap22(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap23(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap24(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap25(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap26(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap27(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap28(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap29(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap30(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap31(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap32(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap33(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap34(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap35(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Firma(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap11(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap12(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap13(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap14(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap15(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap16(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap17(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Firma(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_BpmBPA_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Cap6(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Cap7(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Cap8(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Cap9(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Cap10(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_BpmBPA_Firma(AUD_InspeccionTB inspeccion);

        Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Cap2(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Cap3(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Cap4(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Cap5(AUD_InspeccionTB inspeccion);
        Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Firma(AUD_InspeccionTB inspeccion);

    }
}
