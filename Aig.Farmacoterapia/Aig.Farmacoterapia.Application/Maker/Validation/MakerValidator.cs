using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Application.Common.Validation;
using Aig.Farmacoterapia.Domain.Entities;
using FluentValidation;

namespace Aig.Farmacoterapia.Application.Login.Validation
{
    public class MakerValidator : GenericValidations<AigFabricante>
    {
        public MakerValidator()
        {
            IsNotEmpty(c => c.Nombre, "El nombre es obligatorio");
            IsNotEmpty(c => c.Correo, "El correo es obligatorio");
            IsValidEmail(c => c.Correo);
            RuleFor(x => x.Pais).NotNull().WithMessage("El país es obligatorio");
            IsNotEmpty(c => c.Direccion, "La dirección es obligatoria");
        }
    }
}
