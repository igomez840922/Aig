using Aig.Farmacoterapia.Domain.Common;
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
        [JsonPropertyName("Id")]
        public int RecordId { get; set; }

        [JsonPropertyName("IdTipoTabla")]
        public int IdTipoTabla { get; set; }

        [JsonPropertyName("TipoTabla")]
        public object TipoTabla { get; set; }

        [JsonPropertyName("IdEvaluacion")]
        public int IdEvaluacion { get; set; }

        [JsonPropertyName("IdProducto")]
        public int IdProducto { get; set; }

        [JsonPropertyName("Numero")]
        public string Numero { get; set; }

        [JsonPropertyName("RenovacionNumero")]
        public int RenovacionNumero { get; set; }

        [JsonPropertyName("RenovacionTexto")]
        public string RenovacionTexto { get; set; }

        [JsonPropertyName("Libro")]
        public string Libro { get; set; }

        [JsonPropertyName("Folio")]
        public string Folio { get; set; }

        [JsonPropertyName("Producto")]
        public AigMedication Producto { get; set; }

        [JsonPropertyName("Fabricante")]
        public AigMaker Fabricante { get; set; }

        [JsonPropertyName("Distribuidor")]
        public AigDistributor Distribuidor { get; set; }

        [JsonPropertyName("Presentaciones")]
        public List<AigPresentation> Presentaciones { get; set; }

        [JsonPropertyName("Excipientes")]
        public List<AigExcipient> Excipientes { get; set; }

        [JsonPropertyName("FechaExpedicion")]
        public string FechaExpedicion { get; set; }

        [JsonPropertyName("FechaVencimiento")]
        public string FechaVencimiento { get; set; }

        [JsonPropertyName("FechaUltimaActualizacion")]
        public string FechaUltimaActualizacion { get; set; }

        [JsonPropertyName("IdEstado")]
        public int IdEstado { get; set; }

        [JsonPropertyName("Estado")]
        public string Estado { get; set; }

        //----------------------------------------------------------------
        public bool ShowDetails { get; set; } = false;
        public string? DataSheetURL { get; set; }
        public string? ProspectusURL { get; set; }
        public string? PictureData { get; set; }
    }

}
