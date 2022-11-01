using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class PresentacionesCo
    {
        public int Correlativo { get; set; }
        public string? Documento { get; set; }
        public int? CodigoU { get; set; }
        public string Archivo { get; set; } = null!;
        public int? CodigoSol { get; set; }
        public string Tipo { get; set; } = null!;
    }
}
