using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IInspectionsService
    {
        Task<Stream> ExportToExcel(GenericModel<AUD_InspeccionTB> model);
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

    }
}
