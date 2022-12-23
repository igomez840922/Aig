using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface INotaDestinoService
    {
        Task<List<FMV_NotaDestinoTB>> FindAll(Expression<Func<FMV_NotaDestinoTB, bool>> match);
        Task<GenericModel<FMV_NotaDestinoTB>> FindAll(GenericModel<FMV_NotaDestinoTB> model);
        Task<List<FMV_NotaDestinoTB>> GetAll();
        Task<FMV_NotaDestinoTB> Get(long id);
        Task<FMV_NotaDestinoTB> Save(FMV_NotaDestinoTB data);
        Task<FMV_NotaDestinoTB> Delete(long id);
        Task<int> Count();
    }

   
}
