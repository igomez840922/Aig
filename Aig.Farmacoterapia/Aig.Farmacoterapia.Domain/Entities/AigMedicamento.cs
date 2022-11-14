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
        public string? NumRen { get; set; }
        public string Nombre { get; set; }
        public string? Presentacion { get; set; }
        public bool Vigente { get; set; }
        public string? Envase { get; set; }
        public string TipoEquivalencia { get; set; }
        public string TipoMedicamento { get; set; }
        [JsonIgnore]
        public DateTime? FechaEmision { get; set; } = DateTime.Today;
        public string CondicionVenta { get; set; }
        [JsonIgnore]
        public DateTime? FechaExpiracion{ get; set; } = DateTime.Today;
        public string Principio { get; set; }
        public string? Excipientes{ get; set; }
        public string? Concentracion { get; set; }
        [JsonIgnore]
        public long? FormaFarmaceuticaId { get; set; }
        public virtual AigFormaFarmaceutica? FormaFarmaceutica { get; set; }
        [JsonIgnore]
        public long? ViaAdministracionId { get; set; }
        public virtual AigViaAdministracion? ViaAdministracion { get; set; }
        [JsonIgnore]
        public long? FabricanteId { get; set; }
        public virtual AigFabricante? Fabricante { get; set; }
        public bool ShowDetails { get; set; } = false;
        public string? DataSheetURL { get; set; }
        public string? ProspectusURL { get; set; }
        public string? PictureData { get; set; }
    }
}