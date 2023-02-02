using Aig.Farmacoterapia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies
{
    public class AigEstudioBase : BaseAuditableEntity
    {
        public DateTime? FechaIngreso { get; set; } = DateTime.Today;  //Match 
        public DateTime? FechaAsignacion { get; set; } = DateTime.Today;
        public string Codigo { get; set; } //Match 
        public string Titulo { get; set; } //Match 
        public string CentroInvestigacion { get; set; } //Match 
        public string InvestigadorPrincipal { get; set; }//Match 
        public string Patrocinador { get; set; }//Match 
        public int Participantes { get; set; } = 0;//Match
        public string Duracion { get; set; }//Match
        public string Poblacion { get; set; }//Match

        private List<AigProductoEstudio> _Medicamentos; //Match
        public List<AigProductoEstudio> Medicamentos
        {
            get => _Medicamentos ??= new List<AigProductoEstudio>();
            set
            {
                //_Medicamentos ??= new List<AigProductoEstudio>();
                _Medicamentos = value;
            }
        }

        [JsonIgnore]
        public bool ShowDetails { get; set; } = false;
        [JsonIgnore]
        public string ProductsMetadata { get; set; } = string.Empty;
    }

}
