using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class AigMedicamento: BaseAuditableEntity
    {
        public string NumReg { get; set; }
        public string Nombre { get; set; }
        public TipoEstado Estado { get; set; }
        public TipoEquivalencia TipoEquivalencia { get; set; }
        [JsonIgnore]
        public DateOnly? FechaEmisiónRegistro { get; set; }
        public string TipoMedicamento { get; set; }
        public string CondicionVenta { get; set; }
        [JsonIgnore]
        public DateOnly? ExpiraciónRegistro { get; set; }
        public string Principio { get; set; }
        public string Excipientes{ get; set; }
        public string Concentracion { get; set; }
        public string Via { get; set; }
        [JsonIgnore]
        public int? FormaFarmaceuticaId { get; set; }
        public virtual AigFormaFarmaceutica? FormaFarmaceutica { get; set; }
        [JsonIgnore]
        public int? FabricanteId { get; set; }
        public virtual AigFabricante? Fabricante { get; set; }
        public bool ShowDetails { get; set; } = false;
      
    }
}