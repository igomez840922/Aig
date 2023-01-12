using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IESAVI2Service
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_Esavi2TB> model);
        Task<List<FMV_Esavi2TB>> FindAll(Expression<Func<FMV_Esavi2TB, bool>> match);
        Task<GenericModel<FMV_Esavi2TB>> FindAll(GenericModel<FMV_Esavi2TB> model);
        Task<List<FMV_Esavi2TB>> GetAll();
        Task<FMV_Esavi2TB> Get(long id);
        Task<FMV_Esavi2TB> Save(FMV_Esavi2TB data);
        Task<FMV_Esavi2TB> Delete(long id);
        Task<int> Count();
    }

   
}
