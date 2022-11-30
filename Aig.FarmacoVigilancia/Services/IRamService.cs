using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IRamService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_RamTB> model);

        Task<GenericModel<FMV_RamTB>> FindAll(GenericModel<FMV_RamTB> model);
        Task<List<FMV_RamTB>> GetAll();
        Task<FMV_RamTB> Get(long id);
        Task<FMV_RamTB> Save(FMV_RamTB data);
        Task<FMV_RamTB> Delete(long id);
        Task<int> Count();
    }

   
}
