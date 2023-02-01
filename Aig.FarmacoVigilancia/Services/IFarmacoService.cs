using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IFarmacoService
    {
        Task<GenericModel<FarmacoTB>> FindAll(GenericModel<FarmacoTB> model);
        Task<List<FarmacoTB>> GetAll();
        Task<FarmacoTB> Get(long id);
        Task<FarmacoTB> Save(FarmacoTB data);
        Task<FarmacoTB> Delete(long id);
        Task<int> Count();
    }

   
}
