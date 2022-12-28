using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface ICorrespondenciaService
    {
        Task<GenericModel<AUD_CorrespondenciaTB>> FindAll(GenericModel<AUD_CorrespondenciaTB> model);
        Task<List<AUD_CorrespondenciaTB>> GetAll();
        Task<AUD_CorrespondenciaTB> Get(long id);
        Task<AUD_CorrespondenciaTB> Save(AUD_CorrespondenciaTB data);
        Task<AUD_CorrespondenciaTB> Delete(long id);
        Task<int> Count();
    }
}
