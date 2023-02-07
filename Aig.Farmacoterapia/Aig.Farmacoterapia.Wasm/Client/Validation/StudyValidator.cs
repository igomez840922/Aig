using FluentValidation;
using Aig.Farmacoterapia.Domain.Entities.Studies;

namespace Aig.Farmacoterapia.Wasm.Client.Validation
{
    public class StudyValidator : GenericValidations<AigEstudio>
    {
        public StudyValidator()
        {
            IsNotEmpty(c => c.Codigo, "El código es obligatorio");
            IsNotEmpty(c => c.Titulo, "El título del estudio es obligatorio");
            IsNotEmpty(c => c.CentroInvestigacion, "El Centro de Investigación es obligatorio");
            IsNotEmpty(c => c.Patrocinador, "El Patrocinador es obligatorio");
            IsNotEmpty(c => c.InvestigadorPrincipal, "El Investigador Principal es obligatorio");
            IsNotEmpty(c => c.Duracion, "La duración del Estudio es obligatorio");
            IsNotEmpty(c => c.Poblacion, "La población a estudiar es obligatoria");
            RuleFor(x => x.Participantes).NotNull()
                .WithMessage("La cantidad de pacientes es obligatoria")
                .GreaterThan(0)
                .WithMessage("La cantidad de pacientes no es válida");

            IsNotEmpty(c => c.AgenciaDistribuidora, "La agencia distribuidora es obligatoria");
            IsNotEmpty(c => c.FrecuenciaImportacion, "La frecuencia de importación es obligatoria");
            
        }

    }
    public class StudyDNFDValidator : GenericValidations<AigEstudioDNFD>
    {
        public StudyDNFDValidator()
        {
            IsNotEmpty(c => c.Codigo, "El código es obligatorio");
            IsNotEmpty(c => c.Titulo, "El título del estudio es obligatorio");
            IsNotEmpty(c => c.CentroInvestigacion, "El Centro de Investigación es obligatorio");
            IsNotEmpty(c => c.Patrocinador, "El Patrocinador es obligatorio");
            IsNotEmpty(c => c.InvestigadorPrincipal, "El Investigador Principal es obligatorio");
            IsNotEmpty(c => c.Duracion, "La duración del Estudio es obligatorio");
            IsNotEmpty(c => c.Poblacion, "La población a estudiar es obligatoria");
            RuleFor(x => x.Participantes).NotNull()
                .WithMessage("La cantidad de pacientes es obligatoria")
                .GreaterThan(0)
                .WithMessage("La cantidad de pacientes no es válida");

            IsNotEmpty(c => c.RegistroProtocoloDIGESA, "El Número de registro DIGESA es obligatorio");
            IsNotEmpty(c => c.ComiteBioetica, "El comité de bioetica es obligatorio");

        }

    }

    public class StudiesItemValidator : GenericValidations<AigProductoEstudio>
    {
        public StudiesItemValidator()
        {
            IsNotEmpty(c => c.Nombre, "El nombre del producto es obligatorio");
            IsNotEmpty(c => c.Factura, "El número de factura es obligatoria");
            IsNotEmpty(c => c.Lote, "El lote es obligatorio");
            IsNotNull(c => c.Expiracion!, "La fecha de vencimiento es obligatoria");
            IsNotEmpty(c => c.PrincipioActivo, "El principio activo es obligatorio");
            IsNotEmpty(c => c.FormaFarmaceutica, "La forma farmacéutica es obligatoria");
            IsNotEmpty(c => c.ViaAdministracion, "La vía de administración es obligatoria");
            IsNotEmpty(c => c.Presentacion, "La presentación del producto es obligatoria");
            RuleFor(x => x.Cantidad).NotNull()
                .WithMessage("La cantidad aprobada es obligatoria")
                .GreaterThan(0)
                .WithMessage("La cantidad aprobada no es válida");
        }

    }
}