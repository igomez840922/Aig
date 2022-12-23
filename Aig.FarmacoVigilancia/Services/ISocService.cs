using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface ISocService
    {
        Task<GenericModel<FMV_SocTB>> FindAll(GenericModel<FMV_SocTB> model);
        Task<List<FMV_SocTB>> GetAll();
        Task<FMV_SocTB> Get(long id);
        Task<FMV_SocTB> Save(FMV_SocTB data);
        Task<FMV_SocTB> Delete(long id);
        Task<int> Count();
    }

   
}
