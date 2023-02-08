using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface ICorrespondenciaContactoService
    {
        Task<GenericModel<AUD_CorrespondenciaContactoTB>> FindAll(GenericModel<AUD_CorrespondenciaContactoTB> model);
        Task<List<AUD_CorrespondenciaContactoTB>> GetAll();
        Task<AUD_CorrespondenciaContactoTB> Get(long id);
        Task<AUD_CorrespondenciaContactoTB> Save(AUD_CorrespondenciaContactoTB data);
        Task<AUD_CorrespondenciaContactoTB> Delete(long id);
        Task<int> Count();
    }

   
}
