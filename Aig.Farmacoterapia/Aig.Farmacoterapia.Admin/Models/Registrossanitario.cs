using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Registrossanitario
    {
        public int? _ { get; set; }
        public int? NumeroRegistroSanitario { get; set; }
        public int? IdRegistroSanitario { get; set; }
        public int? IdEvaluacion { get; set; }
        public string? RenovacionRegistroNumeracion { get; set; }
        public string? FechaExpedicion { get; set; }
        public string? FechaExpiracion { get; set; }
        public string? NombreProducto { get; set; }
        public string? Fabricante { get; set; }
        public string? PaisFabricante { get; set; }
        public string? ViaAdministracion { get; set; }
        public string? VidaUtil { get; set; }
        public string? DescripcionEnvases { get; set; }
        public string? Presentacion { get; set; }
        public string? NombreDistribuidorNacional { get; set; }
        public string? NombreTitular { get; set; }
        public string? NombreAcondicionadorPrimario { get; set; }
        public string? NombreAcondicionadorSecundario { get; set; }
        public string? Activos { get; set; }
        public int? EstadoRegistro { get; set; }
        public string? TipoProducto { get; set; }
        public string? CondicionVenta { get; set; }
    }
}
