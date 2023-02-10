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
    }
}
