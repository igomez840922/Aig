using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class SeguimientoPublicidad
    {
        public int Correlativo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? ComentariosUsuario { get; set; }
        public string? ComentariosInternos { get; set; }
        public int? CodigoU { get; set; }
        public int? CodigoPublicidad { get; set; }
        public string? Tipo { get; set; }
    }
}
