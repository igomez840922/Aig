using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface ISmtpCorreoService
    {
        Task<GenericModel<SmtpCorreoTB>> FindAll(GenericModel<SmtpCorreoTB> model);
        Task<List<SmtpCorreoTB>> GetAll();
        Task<SmtpCorreoTB> Get(long id);
        Task<SmtpCorreoTB> GetDefault();
        Task<SmtpCorreoTB> Save(SmtpCorreoTB data);
        Task<SmtpCorreoTB> Delete(long id);
        Task<int> Count();
    }
}
