using DataAccess;
using DataAccess;
using DataModel;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;

namespace Aig.FarmacoVigilancia.Services
{
    public class EmailService: IEmailService
    {
        private readonly IDalService DalService;

        public EmailService(IDalService dalService)
        {
            DalService = dalService;
        }
        

        public async Task SendEmailAsync(string email, string subject, BodyBuilder bodyBuilder)
        {
            try
            {
                var smtpConfig = DalService.First<SmtpCorreoTB>();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Notificaciones MINSA", smtpConfig.Correo));
                message.To.Add(new MailboxAddress("Usuario", email));
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
            catch (Exception ex)
            {
               // throw ex;
            }
        }

    }
}
