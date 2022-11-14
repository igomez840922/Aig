using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Interfaces
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
