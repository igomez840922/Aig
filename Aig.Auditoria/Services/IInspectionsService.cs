using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IInspectionsService
    {
        Task<GenericModel<AUD_InspeccionTB>> FindAll(GenericModel<AUD_InspeccionTB> model);
        Task<List<AUD_InspeccionTB>> GetAll();
        Task<AUD_InspeccionTB> Get(long id);
        Task<AUD_InspeccionTB> Save(AUD_InspeccionTB data);
        Task<AUD_InspeccionTB> Delete(long id);
        Task<int> Count();
    }
}
