using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IIpsService
    {
        Task<GenericModel<FMV_IpsTB>> FindAll(GenericModel<FMV_IpsTB> model);
        Task<List<FMV_IpsTB>> GetAll();
        Task<FMV_IpsTB> Get(long id);
        Task<FMV_IpsTB> Save(FMV_IpsTB data);
        Task<FMV_IpsTB> Delete(long id);
        Task<int> Count();
    }

   
}
