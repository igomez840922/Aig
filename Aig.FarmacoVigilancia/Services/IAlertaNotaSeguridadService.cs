using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IAlertaNotaSeguridadService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_AlertaNotaSeguridadTB> model);
        Task<GenericModel<FMV_AlertaNotaSeguridadTB>> FindAll(GenericModel<FMV_AlertaNotaSeguridadTB> model);
        Task<List<FMV_AlertaNotaSeguridadTB>> GetAll();
        Task<FMV_AlertaNotaSeguridadTB> Get(long id);
        Task<FMV_AlertaNotaSeguridadTB> Save(FMV_AlertaNotaSeguridadTB data);
        Task<FMV_AlertaNotaSeguridadTB> Delete(long id);
        Task<int> Count();
    }

   
}
