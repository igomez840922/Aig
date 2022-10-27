using DataModel;
using DataModel.Models;
using MimeKit;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, BodyBuilder bodyBuilder);
    }
}

