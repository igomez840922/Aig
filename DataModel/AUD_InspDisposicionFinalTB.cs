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
        public AUD_InspDisposicionFinalTB()
        {
            GeneralesEmpresa = new AUD_GeneralesEmpresa();
            DatosResponsable = new DatosPersona();

            InventarioMedicamento = new AUD_InventarioMedicamento();

            DatosConclusiones = new AUD_DatosConclusiones();

        }

        private AUD_InspeccionTB inspeccion;
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }


        //Generales Empresa
        private AUD_GeneralesEmpresa generalesEmpresa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_GeneralesEmpresa GeneralesEmpresa { get => generalesEmpresa; set => SetProperty(ref generalesEmpresa, value); }

        //DATOS RESPONSABLE DEL ESTABLECIMIENTO
        private DatosPersona datosResponsable;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona DatosResponsable { get => datosResponsable; set => SetProperty(ref datosResponsable, value); }

        //SOLICITUD DE CIERRE
        private string solicitudCierre;
        public string SolicitudCierre { get => solicitudCierre; set => SetProperty(ref solicitudCierre, value); }


        //Tipo de inspección
        private enum_TipoInspeccionDispFinal tipoInspeccion;
        public enum_TipoInspeccionDispFinal TipoInspeccion { get => tipoInspeccion; set => SetProperty(ref tipoInspeccion, value); }

        //Tipo de Producto
        private enum_TipoProductDispFinal tipoProduct;
        public enum_TipoProductDispFinal TipoProduct { get => tipoProduct; set => SetProperty(ref tipoProduct, value); }

        //Tipo de Verificacion
        private enum_TipoVerificacionDispFinal tipoVerificacion;
        public enum_TipoVerificacionDispFinal TipoVerificacion { get => tipoVerificacion; set => SetProperty(ref tipoVerificacion, value); }

        //N° de nota de SDGSA
        private string numNotaSDGSA;
        [StringLength(250)]
        public string NumNotaSDGSA { get => numNotaSDGSA; set => SetProperty(ref numNotaSDGSA, value); }

        //recibo de pago N°: 
        private string numReciboPago;
        [StringLength(250)]
        public string NumReciboPago { get => numReciboPago; set => SetProperty(ref numReciboPago, value); }

        //recibo de pago N°: 
        private decimal pesoDestruir;
        public decimal PesoDestruir { get => pesoDestruir; set => SetProperty(ref pesoDestruir, value); }

        //Total de cajas/tarimas/bultos a destruir: 
        private int total;
        public int Total { get => total; set => SetProperty(ref total, value); }

        //existencia fisica coincide con el registro en la lista que adjuntó el establecimiento a la solicitud. 
        private bool coincide;
        public bool Coincide { get => coincide; set => SetProperty(ref coincide, value); }

        //Adjunta Lista de Productos
        private bool adjunta;
        public bool Adjunta { get => adjunta; set => SetProperty(ref adjunta, value); }


        //REPORTE DE INVENTARIO DE MEDICAMENTOS
        private AUD_InventarioMedicamento inventarioMedicamento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_InventarioMedicamento InventarioMedicamento { get => inventarioMedicamento; set => SetProperty(ref inventarioMedicamento, value); }


        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }


    }

}
