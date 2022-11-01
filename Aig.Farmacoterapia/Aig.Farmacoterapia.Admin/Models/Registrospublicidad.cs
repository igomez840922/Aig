using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Registrospublicidad
    {
        public int Correlativo { get; set; }
        public string? Registro { get; set; }
        public string? Fabricante { get; set; }
        public string? Pais { get; set; }
        public int? CodigoU { get; set; }
        public int? CodigoPu { get; set; }
        public string? Producto { get; set; }
        public string? Estado { get; set; }
    }
}
