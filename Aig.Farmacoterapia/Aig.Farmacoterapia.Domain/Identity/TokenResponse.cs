using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Identity
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime TokenExpiryTime { get; set; }
    }
}
