using Aig.Farmacoterapia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class AigEstudios : BaseAuditableEntity
    {
        //public AigEstudios() {
        //    _Medicamentos=new HashSet<AigMedicamentoEstudio>();
        //}
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        
        public DateTime? FechaEvaluacion { get; set; } = DateTime.Today;
        public string? NotaEvaluacion { get; set; }
        public string? AspectosSobresalientes { get; set; }
        public string RegistroProtocolo { get; set; }

        public string InvestigadorPrincipal { get; set; }
        public string Duracion { get; set; }

        public int? Pacientes { get; set; } = 1;
        public string CentroInvestigacion { get; set; }
        public string ComiteBioetica { get; set; }

        private List<AigMedicamentoEstudio>? _Medicamentos;
        public List<AigMedicamentoEstudio>? Medicamentos
        {
            get => _Medicamentos ??= new List<AigMedicamentoEstudio>();
            set
            {
                _Medicamentos ??= new List<AigMedicamentoEstudio>();
                _Medicamentos = value;
            }
        }


        public string? FormDataURL { get; set; }

        public bool ShowDetails { get; set; } = false;
    }

    public class AigMedicamentoEstudio
    {
     
        public string Id { get; set; } 
        public string Factura { get; set; }
        public DateTime? FechaIngreso { get; set; } = DateTime.Today;
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaEvaluacion { get; set; } 

        public string Evaluadores { get; set; }
        public string NotasDNFD { get; set; }

        public string Medicamento { get; set; }
        public int Cantidad { get; set; }
        public string Lote { get; set; }
        public DateTime? Vencimiento { get; set; }

        public string Titular { get; set; }
        public string CodigoPaisTitular { get; set; }

        public string Fabricante { get; set; }
        public string CodigoPaisFabricante { get; set; }

        public string Acondicionador { get; set; }
        public string CodigoPaisAcondicionador { get; set; }

        public string Observacion { get; set; }
    }
}
