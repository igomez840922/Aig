using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Application.Common.Validation;
using Aig.Farmacoterapia.Domain.Entities;
using FluentValidation;

namespace Aig.Farmacoterapia.Application.Studies
{
    public class StudiesValidator : GenericValidations<AigEstudios>
    {
        public StudiesValidator()
        {
            IsNotEmpty(c => c.Nombre, "El título es obligatorio");
            IsNotEmpty(c => c.RegistroProtocolo, "El número de registro DIGESA es obligatorio");
            IsNotEmpty(c => c.CentroInvestigacion, "El Centro de Investigación es obligatorio");
            IsNotEmpty(c => c.InvestigadorPrincipal, "El Investigador Principal es obligatorio");
            IsNotEmpty(c => c.ComiteBioetica, "El Comité de Bioética es obligatorio");
            IsNotEmpty(c => c.Duracion, "La duración del Estudio es obligatorio");

            IsNotEmpty(c => c.Codigo, "El código es obligatorio");

            RuleFor(x => x.Pacientes).NotNull()
                .WithMessage("La cantidad de pacientes es obligatoria")
                .GreaterThan(0)
                .WithMessage("La cantidad de pacientes no es válida");
        }

    }

    public class StudiesItemValidator : GenericValidations<AigMedicamentoEstudio>
    {
        public StudiesItemValidator()
        {
            IsNotEmpty(c => c.Medicamento, "El medicamento es obligatorio");
            IsNotEmpty(c => c.Factura, "El número de factura es obligatoria");
            IsNotEmpty(c => c.Lote, "El lote es obligatorio");
            IsNotNull(c => c.Vencimiento!, "La fecha de vencimiento es obligatoria");
            IsNotNull(c => c.FechaAsignacion!, "La fecha de asignación es obligatoria");
            IsNotNull(c => c.FechaEvaluacion!, "La fecha de evaluación es obligatoria");
            IsNotEmpty(c => c.Titular, "El titular es obligatorio");
            IsNotEmpty(c => c.CodigoPaisTitular, "El país del titular es obligatorio");
            IsNotEmpty(c => c.Fabricante, "El fabricante es obligatoria");
            IsNotEmpty(c => c.CodigoPaisFabricante, "El país del fabricante es obligatorio");
            IsNotEmpty(c => c.Acondicionador, "El acondicionador es obligatorio");
            IsNotEmpty(c => c.CodigoPaisAcondicionador, "El país del acondicionador es obligatorio");
            RuleFor(x => x.Cantidad).NotNull()
                .WithMessage("La cantidad aprobada es obligatoria")
                .GreaterThan(0)
                .WithMessage("La cantidad aprobada no es válida");
        }

    }
    
}
