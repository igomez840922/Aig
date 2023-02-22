using Aig.Farmacoterapia.Domain.Identity;

namespace Aig.Farmacoterapia.Admin.Wasm.Validation
{
    public class IdentityValidator : GenericValidations<TokenRequest>
    {
        public IdentityValidator()
        {
            IsNotEmpty(c => c.Email, "Debes ingresar tu correo");
            IsValidEmail(c => c.Email);
            IsNotEmpty(c => c.Password, "Debes ingresar tu contraseña");
        }
    }
}
