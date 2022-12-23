using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Identity
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public DateTime LoginStarted { get; set; }
        public string TwoFactorCode { get; set; }
        public string Error { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public bool RememberMachine { get; set; }
    }
}
