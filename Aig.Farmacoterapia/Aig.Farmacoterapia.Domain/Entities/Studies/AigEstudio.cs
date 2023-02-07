using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies
{
    public class AigEstudio : AigEstudioBase
    {
        public string AgenciaDistribuidora { get; set; } = string.Empty;
        public AigTramitanteEstudio Tramitante { get; set; } = new AigTramitanteEstudio();
        public string? ObservacionTramitante { get; set; } //Match
        public EstadoEstudio Estado { get; set; } = EstadoEstudio.NotAuthorized;
        public bool Placebo { get; set; } = false;
        public string FrecuenciaImportacion { get; set; } = string.Empty;
        public AigNotaEstudio Nota { get; set; } = new AigNotaEstudio();

        [JsonIgnore]
        public double ElapsedDays = 0;

        private ICollection<AigEstudioEvaluador> _estudioEvaluador;
        [JsonIgnore]
        public virtual ICollection<AigEstudioEvaluador> EstudioEvaluador => _estudioEvaluador ??= new HashSet<AigEstudioEvaluador>();
        public List<string> Evaluators { get; set; }
    }

}
