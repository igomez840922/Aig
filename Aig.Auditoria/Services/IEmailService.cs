using DataModel;
using DataModel.Models;
using MimeKit;

namespace Aig.Auditoria.Services
{
    public interface IEmailService
    {

        Task SendEmailAsync(string email, string subject, BodyBuilder bodyBuilder);
    }
}

