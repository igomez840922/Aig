using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface ITipoInstitucionService
    {
        Task<GenericModel<TipoInstitucionTB>> FindAll(GenericModel<TipoInstitucionTB> model);
        Task<List<TipoInstitucionTB>> GetAll();
        Task<TipoInstitucionTB> Get(long id);
        Task<TipoInstitucionTB> Save(TipoInstitucionTB data);
        Task<TipoInstitucionTB> Delete(long id);
        Task<int> Count();
    }

   
}
