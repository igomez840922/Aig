using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Application.Common.Validation;
using Aig.Farmacoterapia.Application.Login.Model;
using Aig.Farmacoterapia.Domain.Entities;
using FluentValidation;

namespace Aig.Farmacoterapia.Application.Login.Validation
{
    public class MedicationRouteValidator : GenericValidations<AigViaAdministracion>
    {
        public MedicationRouteValidator()
        {
            IsNotEmpty(c => c.Nombre, "El nombre es obligatorio");
        }
    }
}
