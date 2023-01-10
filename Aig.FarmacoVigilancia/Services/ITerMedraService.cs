using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface ITerMedraService
    {
        Task<List<FMV_TerMedraTB>> FindAll(Expression<Func<FMV_TerMedraTB, bool>> match);
        Task<GenericModel<FMV_TerMedraTB>> FindAll(GenericModel<FMV_TerMedraTB> model);
        Task<List<FMV_TerMedraTB>> GetAll();
        Task<FMV_TerMedraTB> Get(long id);
        Task<FMV_TerMedraTB> Save(FMV_TerMedraTB data);
        Task<FMV_TerMedraTB> Delete(long id);
        Task<int> Count();
    }

   
}
