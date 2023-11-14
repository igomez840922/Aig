using DataModel;
using DataModel.Models;
using MimeKit;

namespace Aig.Auditoria.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<string> emails, string subject, BodyBuilder bodyBuilder);
    }
}

