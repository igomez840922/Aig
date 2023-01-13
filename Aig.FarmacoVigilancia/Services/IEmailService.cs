using DataModel;
using DataModel.Models;
using MimeKit;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<string> lEmails, string subject, BodyBuilder bodyBuilder,string FromAlias= null);
    }
}

