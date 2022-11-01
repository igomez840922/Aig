using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class SeguimientoExcepcion
    {
        public int Correlativo { get; set; }
        public DateOnly? Fecha { get; set; }
        public string? ComentariosInternos { get; set; }
        public string? ComentariosUsuario { get; set; }
        public int? CodigoU { get; set; }
        public int? CodigoExcepcion { get; set; }
        public string? Tipo { get; set; }
    }
}
