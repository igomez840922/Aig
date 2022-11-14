using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Identity
{
    public class TokenResponse
    {
#pragma warning disable CS8618 // Non-nullable property 'Token' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Token { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Token' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public DateTime TokenExpiryTime { get; set; }
    }
}
