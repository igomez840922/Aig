using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models {
    public class InspeccionDTO:SystemId {
        //numero de acta...
        private string numActa;
        public string NumActa { get => numActa; set => SetProperty(ref numActa, value); }

        //tipo de acta ... va a determinar el formulario a mostrar
        private enumAUD_TipoActa tipoActa;
        public enumAUD_TipoActa TipoActa { get => tipoActa; set => SetProperty(ref tipoActa, value); }

        //fecha y Hora de inicio del acta
        private DateTime fechaInicio;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get => fechaInicio; set => SetProperty(ref fechaInicio, value); }

        //status del acta
        private enum_StatusInspecciones statusInspecciones;
        public enum_StatusInspecciones StatusInspecciones { get => statusInspecciones; set => SetProperty(ref statusInspecciones, value); }


        //Numero de Licencia -- debe ser campo unico -- LICENCIA_N
        private string numLicencia;
        public string NumLicencia { get => numLicencia; set => SetProperty(ref numLicencia, value); }

        //Recibo Pago
        private string reciboPago;
        public string ReciboPago { get => reciboPago; set => SetProperty(ref reciboPago, value); }

        //Aviso Operaciones
        private string avisoOperaciones;
        public string AvisoOperaciones { get => avisoOperaciones; set => SetProperty(ref avisoOperaciones, value); }

        //nombre establecimiento
        private string nombre;
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Provincia
        private long? provinciaId;
        public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }

    }
}
