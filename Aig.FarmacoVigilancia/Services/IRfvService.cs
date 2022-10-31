using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IRfvService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_RfvTB> model);
        Task<GenericModel<FMV_RfvTB>> FindAll(GenericModel<FMV_RfvTB> model);
        Task<List<FMV_RfvTB>> GetAll();
        Task<FMV_RfvTB> Get(long id);
        Task<FMV_RfvTB> Save(FMV_RfvTB data);
        Task<FMV_RfvTB> Delete(long id);
        Task<int> Count();
    }

   
}
