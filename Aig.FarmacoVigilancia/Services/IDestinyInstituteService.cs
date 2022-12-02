using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IDestinyInstituteService
    {
        Task<List<InstitucionDestinoTB>> FindAll(Expression<Func<InstitucionDestinoTB, bool>> match);

        Task<GenericModel<InstitucionDestinoTB>> FindAll(GenericModel<InstitucionDestinoTB> model);
        Task<List<InstitucionDestinoTB>> GetAll();
        Task<InstitucionDestinoTB> Get(long id);
        Task<InstitucionDestinoTB> Save(InstitucionDestinoTB data);
        Task<InstitucionDestinoTB> Delete(long id);
        Task<int> Count();
    }

   
}
