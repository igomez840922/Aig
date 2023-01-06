using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IRamService2
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_Ram2TB> model);
        Task<List<FMV_Ram2TB>> FindAll(Expression<Func<FMV_Ram2TB, bool>> match);
        Task<GenericModel<FMV_Ram2TB>> FindAll(GenericModel<FMV_Ram2TB> model);
        Task<List<FMV_Ram2TB>> GetAll();
        Task<FMV_Ram2TB> Get(long id);
        Task<FMV_Ram2TB> Save(FMV_Ram2TB data);
        Task<FMV_Ram2TB> Delete(long id);
        Task<int> Count();
    }

   
}
