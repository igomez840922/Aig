using Aig.Farmacoterapia.Domain.Identity;

namespace Aig.Farmacoterapia.Admin.Wasm.Validation
{
    public class TokenValidator : GenericValidations<TokenRequest>
    {
        public TokenValidator()
        {
            IsNotEmpty(c => c.Email, "Debes ingresar tu correo");
            IsValidEmail(c => c.Email);
            IsNotEmpty(c => c.Password, "Debes ingresar tu contraseña");
        }
    }
}
