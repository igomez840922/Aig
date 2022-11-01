using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Excepcion
    {
        public int Correlativo { get; set; }
        public string? Cedula { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Contacto { get; set; }
        public string? Correo { get; set; }
        public string? TipoTramite { get; set; }
        public string? TipoExcepcion { get; set; }
        public string? Producto { get; set; }
        public string? Principio { get; set; }
        public string? Forma { get; set; }
        public string? Laboratorio { get; set; }
        public int? CodigoPLaboratorio { get; set; }
        public string? Titular { get; set; }
        public int? CodigoPTitular { get; set; }
        public string? NombreTramita { get; set; }
        public string? Cantidad { get; set; }
        public string? Presentacion { get; set; }
        public string? Lote { get; set; }
        public string? FechaExpiracion { get; set; }
        public string? Tasa { get; set; }
        public string? Nota { get; set; }
        public string? Certificado { get; set; }
        public string? Receta { get; set; }
        public string? Registro { get; set; }
        public string? Declaracion { get; set; }
        public string? OtrosDocumentos { get; set; }
        public string? Acondicionador { get; set; }
        public int? CodigoPAcondicionador { get; set; }
        public DateTime? Fecha { get; set; }
        public int? CodigoU { get; set; }
        public string? Estado { get; set; }
        public string? NumeroSolicitud { get; set; }
        public string? Analisis { get; set; }
        public string? DetalleCantidad { get; set; }
        public string? ArchivoFirmado { get; set; }
        public string? NombreDistribuidora { get; set; }
        public string? NombrePaciente { get; set; }
    }
}
