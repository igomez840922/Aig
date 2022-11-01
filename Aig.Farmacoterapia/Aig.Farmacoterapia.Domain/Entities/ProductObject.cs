using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class ProductObject: BaseAuditableEntity
    {
        public string Code { get; set; }
        public string AuthorizationNum { get; set; }
        public string Presentation { get; set; }
        public TipoEstado AuthorizationStatus { get; set; }
        public bool MedicalPrescription { get; set; }
        public bool AdditionalTracking { get; set; }
        public bool Orphan { get; set; }
        public bool Biosimilar { get; set; }
        public bool Marketed { get; set; }
        public bool ParallelImports { get; set; }
        public DateTime? AuthorizationDate { get; set; }
        public string? Image { get; set; }
        public DataSheet? DataSheet { get; set; }
        public DataSheet? DataSheetHtml { get; set; }
        public Prospectus? Prospectus { get; set; }
    }
}
