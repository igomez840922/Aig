using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class SeguimientoMedicamento
    {
        public int Correlativo { get; set; }
        public string? Fecha { get; set; }
        public string? ComentariosInternos { get; set; }
        public string? ComentariosUsuario { get; set; }
        public int? CodigoU { get; set; }
        public int? CodigoSol { get; set; }
        public string? Estado { get; set; }
        public string? Tipo { get; set; }
    }
}
