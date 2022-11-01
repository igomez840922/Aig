using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class RegistrosCo
    {
        public string RegistroSanitario { get; set; } = null!;
        public string? NombreProducto { get; set; }
        public string? FabricanteNombre { get; set; }
        public string? FabricantePais { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string? Folio { get; set; }
        public string? Libro { get; set; }
    }
}
