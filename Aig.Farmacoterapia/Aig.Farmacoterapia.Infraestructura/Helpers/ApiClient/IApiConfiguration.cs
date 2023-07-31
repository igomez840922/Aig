using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient
{
    public interface IApiConfiguration
    {
        public string Host { get; set; }
        public int? Port { get; set; }
        public string Token { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool Https { get; set; }
      
    }
}
