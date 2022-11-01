using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Etiqueta
    {
        public int Correlativo { get; set; }
        public int? CodigoSol { get; set; }
        public string PresentacionesSol { get; set; } = null!;
        public string EtiquetaSol { get; set; } = null!;
        public string Archivo { get; set; } = null!;
        public int? CodigoU { get; set; }
    }
}
