using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface ITipoVacunaService
    {
        Task<GenericModel<TipoVacunaTB>> FindAll(GenericModel<TipoVacunaTB> model);
        Task<List<TipoVacunaTB>> GetAll();
        Task<TipoVacunaTB> Get(long id);
        Task<TipoVacunaTB> Save(TipoVacunaTB data);
        Task<TipoVacunaTB> Delete(long id);
        Task<int> Count();
    }

   
}
