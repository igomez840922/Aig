using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class NewPresentacione
    {
        public int _ { get; set; }
        public int? IdRegistroSanitario { get; set; }
        public int? IdEvaluacion { get; set; }
        public string? DescripcionPresenta { get; set; }
        public string? DescripcionPresentacion { get; set; }
    }
}
