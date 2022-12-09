using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IIntensidadEsaviService
    {
        Task<GenericModel<IntensidadEsaviTB>> FindAll(GenericModel<IntensidadEsaviTB> model);
        Task<List<IntensidadEsaviTB>> GetAll();
        Task<IntensidadEsaviTB> Get(long id);
        Task<IntensidadEsaviTB> Save(IntensidadEsaviTB data);
        Task<IntensidadEsaviTB> Delete(long id);
        Task<int> Count();
    }

   
}
