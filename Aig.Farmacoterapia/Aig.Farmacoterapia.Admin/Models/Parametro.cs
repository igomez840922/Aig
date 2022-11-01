using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Parametro
    {
        public string Correo { get; set; } = null!;
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
        public int? Puerto { get; set; }
        public string? Servidor { get; set; }
        public string? RutaArchivos { get; set; }
        public string? Leyenda { get; set; }
    }
}
