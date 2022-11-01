using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class TipoPagoMedicamento
    {
        public int CodigoTp { get; set; }
        public string? NombreTp { get; set; }
        public double? MontoTp { get; set; }
        public string? Estado { get; set; }
    }
}
