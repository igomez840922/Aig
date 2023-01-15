using Aig.Farmacoterapia.Admin.Wasm.Infrastructure.Managers.User;
using Aig.Farmacoterapia.Domain.Identity;
using FluentValidation;

namespace Aig.Farmacoterapia.Admin.Wasm.Validation
{
    public class UpdateProfileValidator : GenericValidations<UpdateProfileRequest>
    {
        public UpdateProfileValidator()
        {
            IsNotEmpty(c => c.Email, "Debes ingresar tu correo");
            IsNotEmpty(c => c.FirstName, "Debes ingresar tu nombre");
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
                .EmailAddress().WithMessage("El nombre de usuario debe ser una dirección de correo válida")
              .MustAsync(async (input, source, context, cancellation) =>{
                 context.MessageFormatter.AppendArgument("user", source);
                 bool exists = !string.IsNullOrEmpty(source) && await IsUserUniqueAsync(input);
                 return !exists;
             }).WithMessage("El nombre de usuario: {user} ya fue utilizado");

            IsNotEmpty(c => c.FirstName, "El nombre es obligatorio");
            IsNotEmpty(c => c.LastName, "El apellido es obligatorio");
            IsNotEmpty(c => c.Password, "La contraseña es obligatoria");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password)
                .WithMessage("La confirmación de la contraseña no coincide");

            RuleFor(x => x.PhoneNumber).MustAsync(async (input, source, context, cancellation) => {
                context.MessageFormatter.AppendArgument("phone", source);
                return !string.IsNullOrEmpty(source) && await IsPhoneUnique(input);
            }).WithMessage("El teléfono: {phone} ya fue utilizado");
        }
        private async Task<bool> IsUserUniqueAsync(RegisterRequest input)
        {
            var result = await _userService.UsernameExists(input.UserName);
            return result.Data;
        }
        private async Task<bool> IsPhoneUnique(RegisterRequest input)
        {
            var result = await _userService.PhoneExists(input.PhoneNumber);
            return result.Data;
        }
    }
    
}
