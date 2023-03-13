using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies
{
    public class AigEstudio : AigEstudioBase
    {
        public string Codigo { get; set; } 
        public string AgenciaDistribuidora { get; set; } = string.Empty;
        public AigTramitanteEstudio Tramitante { get; set; } = new AigTramitanteEstudio();
        public string? ObservacionTramitante { get; set; }

        [DefaultValue(EstadoEstudio.Pendiente)]
        public EstadoEstudio Estado { get; set; } = EstadoEstudio.Pendiente;
        public bool Placebo { get; set; } = false;
        public string FrecuenciaImportacion { get; set; } = string.Empty;

        [IgnoreDataMember]
        public AigNotaEstudio Nota { get; set; } = new AigNotaEstudio();

        [JsonIgnore]
        public double ElapsedDays = 0;

        private ICollection<AigEstudioEvaluador> _estudioEvaluador;
        [JsonIgnore]
        public virtual ICollection<AigEstudioEvaluador> EstudioEvaluador => _estudioEvaluador ??= new HashSet<AigEstudioEvaluador>();
       
        [IgnoreDataMember]
        public List<string> Evaluators { get; set; }

        [IgnoreDataMember]
        public string EvaluatorToShow { get; set; }
        
        public long? AigEstudioDNFDId { get; set; }
        [JsonIgnore]
        public virtual AigEstudioDNFD? AigEstudioDNFD { get; set; }

        [IgnoreDataMember]
        public bool Match { get; set; } = true;
        [IgnoreDataMember]
        public string MatchInfo { get; set; } = string.Empty;

        private List<AigEstudioFile>? _Documents; 
        public List<AigEstudioFile>? Documents
        {
            get => _Documents ??= new List<AigEstudioFile>();
            set
            {

                _Documents = value;
            }
        }

    }

}
