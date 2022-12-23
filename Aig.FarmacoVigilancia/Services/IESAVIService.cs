using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IESAVIService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_EsaviTB> model);
        Task<List<FMV_EsaviTB>> FindAll(Expression<Func<FMV_EsaviTB, bool>> match);
        Task<GenericModel<FMV_EsaviTB>> FindAll(GenericModel<FMV_EsaviTB> model);
        Task<List<FMV_EsaviTB>> GetAll();
        Task<FMV_EsaviTB> Get(long id);
        Task<FMV_EsaviTB> Save(FMV_EsaviTB data);
        Task<FMV_EsaviTB> Delete(long id);
        Task<int> Count();
    }

   
}
