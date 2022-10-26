using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IProvicesService
    {
        Task<GenericModel<ProvinciaTB>> FindAll(GenericModel<ProvinciaTB> model);
        Task<List<ProvinciaTB>> GetAll();
        Task<ProvinciaTB> Get(long id);
        Task<ProvinciaTB> Save(ProvinciaTB data);
        Task<ProvinciaTB> Delete(long id);
        Task<int> Count();
    }
}
