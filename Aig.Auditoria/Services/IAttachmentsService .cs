using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IAttachmentsService
    {
        Task<GenericModel<AttachmentTB>> FindAll(GenericModel<AttachmentTB> model);
        Task<List<AttachmentTB>> GetAll();
        Task<AttachmentTB> Get(long id);
        Task<AttachmentTB> Save(AttachmentTB data);
        Task<AttachmentTB> Delete(long id);
        Task<int> Count();
    }
}
