using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class NewExipiente
    {
        public int? _ { get; set; }
        public int? IdProducto { get; set; }
        public int? IdEvaluacion { get; set; }
        public string? DescripcionExcipiente { get; set; }
        public string? ConcentracionExcipiente { get; set; }
    }
}
