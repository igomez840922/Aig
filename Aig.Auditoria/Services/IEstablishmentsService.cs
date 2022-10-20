using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface ICountriesService
    {
        Task<GenericModel<PaisTB>> FindAll(GenericModel<PaisTB> model);
        Task<List<PaisTB>> GetAll();
        Task<PaisTB> Get(long id);
        Task<PaisTB> Save(PaisTB data);
        Task<PaisTB> Delete(long id);
        Task<int> Count();
    }
}
