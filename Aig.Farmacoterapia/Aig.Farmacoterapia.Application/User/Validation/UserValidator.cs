using Aig.Farmacoterapia.Application.Common.Validation;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.User.Validation
{
    public class UserValidator : GenericValidations<ApplicationUser>
    {  
        private readonly IUserService _userService;
        public UserValidator(IUserService userService)
        {
            _userService = userService;
            IsValidEmail(c => c.UserName)
                .Must((input, source, context) => {
                    context.MessageFormatter.AppendArgument("user", source);
                    return IsUserUnique(input);
                }).WithMessage("El nombre de usuario: {user} ya fue utilizado");
                
            IsNotEmpty(c => c.FirstName, "El nombre es obligatorio");
            IsNotEmpty(c => c.LastName, "El apellido es obligatorio");
            IsNotEmpty(c => c.Password, "La contraseña es obligatoria");
            RuleFor(x => x.PasswordConfirm).Equal(x => x.Password)
                .WithMessage("La confirmación de la contraseña no coincide");
            
            RuleFor(x => x.PhoneNumber).Must((input, source, context) => {
                context.MessageFormatter.AppendArgument("phone", source);
                return IsPhoneUnique(input);
            }).WithMessage("El teléfono: {phone} ya fue utilizado");
        }
        private bool IsUserUnique(ApplicationUser input){
            var result =  _userService.GetUserByName(input.UserName);
            return result == null || result.Id == input.Id;
        }
        private bool IsPhoneUnique(ApplicationUser input)
        {  
            if (string.IsNullOrEmpty(input.PhoneNumber)) return true;
            var result = _userService.GetUserByPhone(input.PhoneNumber);
            return result == null || result.Id == input.Id;
        }
    }
}
