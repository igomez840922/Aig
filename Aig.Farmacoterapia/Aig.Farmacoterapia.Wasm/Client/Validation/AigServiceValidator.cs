using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using FluentValidation;

namespace Aig.Farmacoterapia.Wasm.Client.Validation
{
    public class AigServiceValidator : GenericValidations<AigService>
    {
        public AigServiceValidator()
        {
            IsNotEmpty(c => c.Code, "El Dato es obligatorio");
            IsNotEmpty(c => c.Host, "El Dato es obligatorio");
            RuleFor(x => x.LastRun).NotNull().WithMessage("El Dato es obligatorio");
            RuleFor(p => p.UpdateTime).GreaterThan(0).WithMessage("El Dato es obligatorio y debe ser > 0");
        }
    }
}
