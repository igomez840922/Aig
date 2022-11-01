using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IOrigenAlertaService
    {
        Task<GenericModel<FMV_OrigenAlertaTB>> FindAll(GenericModel<FMV_OrigenAlertaTB> model);
        Task<List<FMV_OrigenAlertaTB>> GetAll();
        Task<FMV_OrigenAlertaTB> Get(long id);
        Task<FMV_OrigenAlertaTB> Save(FMV_OrigenAlertaTB data);
        Task<FMV_OrigenAlertaTB> Delete(long id);
        Task<int> Count();
    }

   
}
