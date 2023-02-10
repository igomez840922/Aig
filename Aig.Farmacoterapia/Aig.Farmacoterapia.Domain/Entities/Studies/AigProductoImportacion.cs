using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies
{
    public class AigProductoEstudio
    {
        [IgnoreDataMember]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Factura { get; set; }
        public string Nombre { get; set; }
        public string PrincipioActivo { get; set; }
        public string Concentracion { get; set; }
        public string FormaFarmaceutica { get; set; }
        public string ViaAdministracion { get; set; }
        public string Presentacion { get; set; }
        public string Lote { get; set; }
        public DateTime? Expiracion { get; set; } = DateTime.Now;
        public int Cantidad { get; set; } = 1;
        public AigFabricanteEstudio Fabricante { get; set; } = new AigFabricanteEstudio();
        public AigAcondicionadorEstudio Acondicionador { get; set; } = new AigAcondicionadorEstudio();
    }
}