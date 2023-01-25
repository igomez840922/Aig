using Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.User;
using Aig.Farmacoterapia.Domain.Identity;
using FluentValidation;
using FluentValidation.Validators;

namespace Aig.Farmacoterapia.Wasm.Client.Validation
{
    public class UserValidator : GenericValidations<UpdateProfileRequest>
    {
        public UserValidator()
        {
            IsNotEmpty(c => c.Email, "Debes ingresar tu correo");
            IsNotEmpty(c => c.FirstName, "Debes ingresar tu nombre");
            IsNotEmpty(c => c.PhoneNumber, "El teléfono es obligatorio");
        }
    }
    public class ChangePasswordValidator : GenericValidations<ChangePasswordRequest>
    {
        public ChangePasswordValidator()
        {
            IsNotEmpty(c => c.NewPassword, "La contraseña es obligatoria");
            RuleFor(x => x.ConfirmNewPassword).Equal(x => x.NewPassword)
                .WithMessage("La confirmación de la contraseña no coincide");
        }
    }

  
    public class RegisterUserValidator : GenericValidations<RegisterRequest>
    {
        private readonly IUserManager _userService;
        public RegisterUserValidator(IUserManager userService)
        {
            _userService = userService;
            RuleFor(x => x.UserName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("El nombre de usuario es obligatorio")
                .EmailAddress().WithMessage("El usuario debe ser una dirección de correo válida");
            IsNotEmpty(c => c.Password, "La contraseña es obligatoria");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password)
                .WithMessage("La confirmación de la contraseña no coincide");
            IsNotEmpty(c => c.FirstName, "El nombre es obligatorio");
            IsNotEmpty(c => c.LastName, "El apellido es obligatorio");
            IsNotEmpty(c => c.PhoneNumber, "El teléfono es obligatorio");
        }

    }
}
