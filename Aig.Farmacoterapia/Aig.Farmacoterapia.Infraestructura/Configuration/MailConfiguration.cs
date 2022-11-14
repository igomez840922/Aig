using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Configuration
{
    public class MailConfiguration
    {
#pragma warning disable CS8618 // Non-nullable property 'From' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string From { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'From' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Host' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Host { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Host' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public int Port { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'UserName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string UserName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'UserName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Password { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'DisplayName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string DisplayName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'DisplayName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
