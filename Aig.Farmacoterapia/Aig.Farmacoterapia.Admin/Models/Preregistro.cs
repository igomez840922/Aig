using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Preregistro
    {
        public int CodigoT { get; set; }
        public string? Cedula { get; set; }
        public string? NumeroIdoneidad { get; set; }
        public string? Direccion { get; set; }
        public string? Celular { get; set; }
        public string? TelefonoOficina { get; set; }
        public string? NombreApellido { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? IdUsuario { get; set; }
        public string? Idoneidad { get; set; }
        public string? Estado { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Correo { get; set; }
        public string? NumeroSolicitud { get; set; }
        public int? CodigoU { get; set; }
        public string? TipoIdoneidad { get; set; }
    }
}
