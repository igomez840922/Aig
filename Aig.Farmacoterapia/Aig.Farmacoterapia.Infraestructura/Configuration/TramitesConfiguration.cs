using Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Configuration
{
    public class TramitesConfiguration : IApiConfiguration
    {
        public string Host { get; set; }
        public int? Port { get; set; }
        public string Token { get; set; } = string.Empty;
        public bool Https { get; set; } = true;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
