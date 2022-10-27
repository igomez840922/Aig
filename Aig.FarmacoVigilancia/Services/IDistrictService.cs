using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IDistrictService
    {
        Task<GenericModel<DistritoTB>> FindAll(GenericModel<DistritoTB> model);
        Task<List<DistritoTB>> GetAll();
        Task<DistritoTB> Get(long id);
        Task<DistritoTB> Save(DistritoTB data);
        Task<DistritoTB> Delete(long id);
        Task<int> Count();
    }
}
