using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class PresentacionesComentariosCo
    {
        public int Correlativo { get; set; }
        public int? CodigoU { get; set; }
        public int? CodigoSol { get; set; }
        public string? Comentario { get; set; }
        public string? Tipo { get; set; }
        public string? Nombre { get; set; }
        public string? Archivo { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
