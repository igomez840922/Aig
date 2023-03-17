using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{

    public class AUD_DatosEstablecimientoTB:SystemId
    {
        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }


        //Establecimiento
        private long? establecimientoId;
        [Required(ErrorMessage = "requerido")]
        public long? EstablecimientoId { get => establecimientoId; set => SetProperty(ref establecimientoId, value); }

        private AUD_EstablecimientoTB? establecimiento;
        [System.Text.Json.Serialization.JsonIgnore]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_EstablecimientoTB? Establecimiento { get => establecimiento; set => SetProperty(ref establecimiento, value); }

        //ubicacion
        private string nombre;
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Numero de Licencia -- debe ser campo unico -- LICENCIA_N
        private string numLicencia;
        public string NumLicencia { get => numLicencia; set => SetProperty(ref numLicencia, value); }

        private DateTime? vigenteDesde;
        public DateTime? VigenteDesde { get => vigenteDesde; set => SetProperty(ref vigenteDesde, value); }

        private DateTime? vigenteHasta;
        public DateTime? VigenteHasta { get => vigenteHasta; set => SetProperty(ref vigenteHasta, value); }

        //Aviso Operaciones
        private string avisoOperaciones;
        public string AvisoOperaciones { get => avisoOperaciones; set => SetProperty(ref avisoOperaciones, value); }

        //Recibo Pago
        private string reciboPago;
        public string ReciboPago { get => reciboPago; set => SetProperty(ref reciboPago, value); }

        //Provincia -- PROV
        private long? provinciaId;
        public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }

        //provincia
        private ProvinciaTB? provincia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public ProvinciaTB? Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        //distrito
        private DistritoTB? distrito;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DistritoTB? Distrito { get => distrito; set => SetProperty(ref distrito, value); }

        //distrito
        private CorregimientoTB? corregimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public CorregimientoTB? Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }

        //ubicacion
        private string direccion;
        public string Direccion { get => direccion; set => SetProperty(ref direccion, value); }

        //telefono1
        private string telefono;
        [StringLength(250)]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        //correo
        private string correo;
        [StringLength(250)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Correo { get => correo; set => SetProperty(ref correo, value); }


    }
}
