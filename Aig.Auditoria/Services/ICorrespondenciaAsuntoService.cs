using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface ICorrespondenciaAsuntoService
    {
        Task<GenericModel<AUD_CorrespondenciaAsuntoTB>> FindAll(GenericModel<AUD_CorrespondenciaAsuntoTB> model);
        Task<List<AUD_CorrespondenciaAsuntoTB>> GetAll();
        Task<AUD_CorrespondenciaAsuntoTB> Get(long id);
        Task<AUD_CorrespondenciaAsuntoTB> Save(AUD_CorrespondenciaAsuntoTB data);
        Task<AUD_CorrespondenciaAsuntoTB> Delete(long id);
        Task<int> Count();
    }

   
}
