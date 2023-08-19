using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Products
{
    public class AigRecord: BaseAuditableEntity
    {
        public int RecordId { get; set; }
        public int IdProducto { get; set; }
        public string Numero { get; set; }
        public int RenovacionNumero { get; set; }
        public string RenovacionTexto { get; set; }
        public string Libro { get; set; }
        public string Folio { get; set; }
        public AigMedication Producto { get; set; }
        public AigMaker? Fabricante { get; set; }
        public AigDistributor? Distribuidor { get; set; }
        public List<AigPresentation> Presentaciones { get; set; }
        public List<AigExcipient> Excipientes { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public string Estado { get; set; }
        public ServiceType? Servicio { get; set; }

        //----------------------------------------------------------------
        public bool ShowDetails { get; set; } = false;
        public string? DataSheetURL { get; set; }
        public string? ProspectusURL { get; set; }
        public string? PictureData { get; set; }
    }

}
