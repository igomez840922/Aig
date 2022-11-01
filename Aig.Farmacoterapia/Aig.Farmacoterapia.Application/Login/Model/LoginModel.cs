using Aig.Farmacoterapia.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Login.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public DateTime LoginStarted { get; set; }
        public string TwoFactorCode { get; set; }
        public string Error { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public ApplicationUser User { get; set; }
        public bool RememberMachine { get; set; }


    }
}
