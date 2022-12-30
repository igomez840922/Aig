using DataModel;
using DataModel.Models;
using MimeKit;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(List<string> lEmails, string subject, BodyBuilder bodyBuilder);
    }
}

