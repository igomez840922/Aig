using DataModel.Helper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspDisposicionFinalTB : SystemId
    {
        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos Atendidos Por
        private AUD_DatosAtendidosPor datosAtendidosPor;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAtendidosPor DatosAtendidosPor { get => datosAtendidosPor; set => SetProperty(ref datosAtendidosPor, value); }

        //Datos de la Inspeccion
        private AUD_DatosInspeccionDisposicion datosInspeccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosInspeccionDisposicion DatosInspeccion { get => datosInspeccion; set => SetProperty(ref datosInspeccion, value); }

        //REPORTE DE INVENTARIO DE MEDICAMENTOS
        private AUD_InventarioMedicamento inventarioMedicamento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_InventarioMedicamento InventarioMedicamento { get => inventarioMedicamento; set => SetProperty(ref inventarioMedicamento, value); }

    }

    public class AUD_DatosInspeccionDisposicion : SystemId
    {       
        //Tipo de inspección
        private enum_TipoInspeccionDispFinal tipoInspeccion;
        public enum_TipoInspeccionDispFinal TipoInspeccion { get => tipoInspeccion; set => SetProperty(ref tipoInspeccion, value); }

        //Tipo de Producto
        private enum_TipoProductDispFinal tipoProduct;
        public enum_TipoProductDispFinal TipoProduct { get => tipoProduct; set => SetProperty(ref tipoProduct, value); }

        //Tipo de Verificacion
        private enum_TipoVerificacionDispFinal tipoVerificacion;
        public enum_TipoVerificacionDispFinal TipoVerificacion { get => tipoVerificacion; set => SetProperty(ref tipoVerificacion, value); }

        //SOLICITUD DE CIERRE
        private string solicitudCierre;
        public string SolicitudCierre { get => solicitudCierre; set => SetProperty(ref solicitudCierre, value); }


        //N° de nota de SDGSA
        private string numNotaSDGSA;
        public string NumNotaSDGSA { get => numNotaSDGSA; set => SetProperty(ref numNotaSDGSA, value); }

        //recibo de pago N°: 
        private string numReciboPago;
        public string NumReciboPago { get => numReciboPago; set => SetProperty(ref numReciboPago, value); }

        //recibo de pago N°: 
        private decimal pesoDestruir;
        public decimal PesoDestruir { get => pesoDestruir; set => SetProperty(ref pesoDestruir, value); }

        //Total de cajas/tarimas/bultos a destruir: 
        private string total;
        public string Total { get => total; set => SetProperty(ref total, value); }

        //existencia fisica coincide con el registro en la lista que adjuntó el establecimiento a la solicitud. 
        private bool coincide;
        public bool Coincide { get => coincide; set => SetProperty(ref coincide, value); }

        //Adjunta Lista de Productos
        private bool adjunta;
        public bool Adjunta { get => adjunta; set => SetProperty(ref adjunta, value); }

    }


}
