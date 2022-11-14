using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Mail
{
    public class MailRequest
    {
#pragma warning disable CS8618 // Non-nullable property 'To' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string To { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'To' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Subject' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Subject { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Subject' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Body' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Body { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Body' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'From' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string From { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'From' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
