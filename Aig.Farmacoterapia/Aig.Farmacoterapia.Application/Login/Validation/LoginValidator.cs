using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Application.Common.Validation;
using Aig.Farmacoterapia.Application.Login.Model;
using FluentValidation;

namespace Aig.Farmacoterapia.Application.Login.Validation
{
    public class LoginValidator : GenericValidations<LoginModel>
    {
        public LoginValidator()
        {
            IsNotEmpty(c => c.UserName, "Debes ingresar tu nombre de usuario");
            IsNotEmpty(c => c.Password, "Debes ingresar tu contraseña");
        }
    }
}
