using Aig.Farmacoterapia.Domain.Identity;

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
}
