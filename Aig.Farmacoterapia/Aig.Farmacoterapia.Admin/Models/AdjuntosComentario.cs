using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class AdjuntosComentario
    {
        public int Correlativo { get; set; }
        public int? CodigoU { get; set; }
        public int? CodigoSol { get; set; }
        public string? Comentario { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
