using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IFTService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_FtTB> model);
        Task<List<FMV_FtTB>> FindAll(Expression<Func<FMV_FtTB, bool>> match);
        Task<GenericModel<FMV_FtTB>> FindAll(GenericModel<FMV_FtTB> model);
        Task<List<FMV_FtTB>> GetAll();
        Task<FMV_FtTB> Get(long id);
        Task<FMV_FtTB> Save(FMV_FtTB data);
        Task<FMV_FtTB> Delete(long id);
        Task<int> Count();
    }

   
}
