using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Acondicionador
    {
        public int CodigoAcondicionador { get; set; }
        public int? CodigoSol { get; set; }
        public string TipoacondicionadorSol { get; set; } = null!;
        public string AcondicionadorSol { get; set; } = null!;
        public string CodigoPAcondicionador { get; set; } = null!;
        public string DireccionAcondicionador { get; set; } = null!;
        public string CorreoAcondicionador { get; set; } = null!;
    }
}
