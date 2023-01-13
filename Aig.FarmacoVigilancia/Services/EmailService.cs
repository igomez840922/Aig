using DataAccess;
using DataAccess;
using DataModel;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using static Duende.IdentityServer.Models.IdentityResources;

namespace Aig.FarmacoVigilancia.Services
{
    public class EmailService: IEmailService
    {
        private readonly IDalService DalService;

        public EmailService(IDalService dalService)
        {
            DalService = dalService;
        }
        

        public async Task SendEmailAsync(List<string> lEmails, string subject, BodyBuilder bodyBuilder, string FromAlias=null)
        {
            var smtpConfig = DalService.First<SmtpCorreoTB>();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(string.IsNullOrEmpty(FromAlias)?"Notificaciones MINSA": FromAlias, smtpConfig.Correo));
            foreach (var address in lEmails)
            {
                message.To.Add(new MailboxAddress(address, address));
            }
            message.Subject = subject;
            message.Body = bodyBuilder.ToMessageBody();
            //message.Body = new TextPart("html")
            //{
            //    Text = bodyBuilder.HtmlBody
            //};
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(smtpConfig.SmtpServidor, smtpConfig.SmtpPuerto, false);

                //SMTP server authentication if needed
                client.Authenticate(smtpConfig.Usuario, smtpConfig.Contrasena);

                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }
        }

    }
}
