using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface IInspectionService
    {
        Task InspectionsSync();
        Task InspectionsUpload();

        /// <summary>
        /// ////////////////////////////////////////////
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<GenericModel<APP_Inspeccion>> FindAll(GenericModel<APP_Inspeccion> model);
        Task<List<APP_Inspeccion>> GetAll();
        Task<APP_Inspeccion> Get(long Id);
        Task<APP_Inspeccion> Save(APP_Inspeccion data);
        Task<APP_Inspeccion> Delete(long Id);

    }
}
