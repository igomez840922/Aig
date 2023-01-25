using Aig.Farmacoterapia.Domain.Entities;
using FluentValidation;

namespace Aig.Farmacoterapia.Wasm.Client.Validation
{
    public class MedicamentValidator : GenericValidations<AigMedicamento>
    {
        public MedicamentValidator()
        {
            IsNotEmpty(c => c.NumReg, "El registro es obligatorio");
            IsNotEmpty(c => c.Nombre, "El medicamento es obligatorio");
            RuleFor(x => x.CondicionVenta).NotNull().WithMessage("La condición de venta es obligatoria");
            RuleFor(x => x.FormaFarmaceutica).NotNull().WithMessage("La forma farmacéutica es obligatoria");
            RuleFor(x => x.ViaAdministracion).NotNull().WithMessage("La vía de administración es obligatoria");
            RuleFor(x => x.TipoEquivalencia).NotNull().WithMessage("La clasificación es obligatoria");
            RuleFor(x => x.TipoMedicamento).NotNull().WithMessage("El tipo de medicamento es obligatorio");
            RuleFor(x => x.Fabricante).NotNull().WithMessage("El fabricante es obligatorio");
            RuleFor(x => x.Principio).NotNull().WithMessage("El principio activo es obligatorio");
        }

    }
}
