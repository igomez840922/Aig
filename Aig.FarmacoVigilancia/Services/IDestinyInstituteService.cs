using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IDestinyInstituteService
    {
        Task<GenericModel<InstitucionDestinoTB>> FindAll(GenericModel<InstitucionDestinoTB> model);
        Task<List<InstitucionDestinoTB>> GetAll();
        Task<InstitucionDestinoTB> Get(long id);
        Task<InstitucionDestinoTB> Save(InstitucionDestinoTB data);
        Task<InstitucionDestinoTB> Delete(long id);
        Task<int> Count();
    }

   
}
