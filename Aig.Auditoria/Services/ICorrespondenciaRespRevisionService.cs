using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface ICorrespondenciaRespRevisionService
    {
        Task<GenericModel<AUD_CorrespondenciaRespRevisionTB>> FindAll(GenericModel<AUD_CorrespondenciaRespRevisionTB> model);
        Task<List<AUD_CorrespondenciaRespRevisionTB>> GetAll();
        Task<AUD_CorrespondenciaRespRevisionTB> Get(long id);
        Task<AUD_CorrespondenciaRespRevisionTB> Save(AUD_CorrespondenciaRespRevisionTB data);
        Task<AUD_CorrespondenciaRespRevisionTB> Delete(long id);
        Task<int> Count();
    }

   
}
