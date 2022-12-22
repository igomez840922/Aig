using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IFFService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_FfTB> model);

        Task<List<FMV_FfTB>> FindAll(Expression<Func<FMV_FfTB, bool>> match);
        Task<GenericModel<FMV_FfTB>> FindAll(GenericModel<FMV_FfTB> model);
        Task<List<FMV_FfTB>> GetAll();
        Task<FMV_FfTB> Get(long id);
        Task<FMV_FfTB> Save(FMV_FfTB data);
        Task<FMV_FfTB> Delete(long id);
        Task<int> Count();
    }

   
}
