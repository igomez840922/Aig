using Aig.Farmacoterapia.Domain.Common;
using System.Text.Json.Serialization;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class AigMedicamento: BaseAuditableEntity
    {
        
        public string NumReg { get; set; }
        public string? NumRen { get; set; }
        public string Nombre { get; set; }
        public string? Presentacion { get; set; }
        public bool Vigente { get; set; } = true;
        public string? Envase { get; set; }
        public string TipoEquivalencia { get; set; }
        public string TipoMedicamento { get; set; }
        public string CondicionVenta { get; set; }
        public DateTime? FechaEmision { get; set; } = DateTime.Today;
        public DateTime? FechaExpiracion{ get; set; } = DateTime.Today;
        public string Principio { get; set; }
        public string? Excipientes{ get; set; }
        public string? Concentracion { get; set; }
        public long? FormaFarmaceuticaId { get; set; }
        public virtual AigFormaFarmaceutica? FormaFarmaceutica { get; set; }
        public long? ViaAdministracionId { get; set; }
        public virtual AigViaAdministracion? ViaAdministracion { get; set; }
        public long? FabricanteId { get; set; }
        public virtual AigFabricante? Fabricante { get; set; }
        public bool ShowDetails { get; set; } = false;
        public string? DataSheetURL { get; set; }
        public string? ProspectusURL { get; set; }
        public string? PictureData { get; set; }
    }
}