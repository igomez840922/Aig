using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IPmrService
    {
        Task<GenericModel<FMV_PmrTB>> FindAll(GenericModel<FMV_PmrTB> model);
        Task<List<FMV_PmrTB>> GetAll();
        Task<FMV_PmrTB> Get(long id);
        Task<FMV_PmrTB> Save(FMV_PmrTB data);
        Task<FMV_PmrTB> Delete(long id);
        Task<int> Count();
    }

   
}
