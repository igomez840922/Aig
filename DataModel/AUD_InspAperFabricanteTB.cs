using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspAperFabricanteTB:SystemId
    {
        public AUD_InspAperFabricanteTB()
        {
            DatosEstablecimiento = new AUD_DatosEstablecimiento();
            DatosSolicitante = new AUD_DatosSolicitante();
            DatosRegente = new AUD_DatosRegente();
            DatosRepresentLegal = new AUD_DatosRepresentLegal();
            DatosDocumentacion = new AUD_DatosDocumentacion();
            DatosProcedimientoPrograma = new AUD_DatosProcedimientoPrograma();
            DatosAutoInspeccion = new AUD_DatosAutoInspeccion();
            DatosProdAnalisisContrato = new AUD_DatosProdAnalisisContrato();
            DatosReclamoProductoRetirado = new AUD_DatosReclamoProductoRetirado();
            DatosLocal = new AUD_DatosLocal();
            DatosAreaProduccion = new AUD_DatosAreaProduccion();
            DatosEquipos = new AUD_DatosEquipos();
            DatosAreaLabCtrCalidad = new AUD_DatosAreaLabCtrCalidad();
            DatosAreaAlmacenamiento = new AUD_DatosAreaAlmacenamiento();
            DatosAreaAuxiliares=new AUD_DatosAreaAuxiliares();

            DatosConclusiones = new AUD_DatosConclusiones();
        }

        private AUD_InspeccionTB inspeccion;
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //codigo
        private string tipoProductos;
        [StringLength(250)]
        public string TipoProductos { get => tipoProductos; set => SetProperty(ref tipoProductos, value); }

        //Datos del Establecimiento
        private AUD_DatosEstablecimiento datosEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEstablecimiento DatosEstablecimiento { get => datosEstablecimiento; set => SetProperty(ref datosEstablecimiento, value); }

        //Datos del Solicitante
        private AUD_DatosSolicitante datosSolicitante;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosSolicitante DatosSolicitante { get => datosSolicitante; set => SetProperty(ref datosSolicitante, value); }

        //Datos del Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Datos del Regente
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Datos Documentación
        private AUD_DatosDocumentacion datosDocumentacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosDocumentacion DatosDocumentacion { get => datosDocumentacion; set => SetProperty(ref datosDocumentacion, value); }

        //Procedimientos y Programas
        private AUD_DatosProcedimientoPrograma datosProcedimientoPrograma;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosProcedimientoPrograma DatosProcedimientoPrograma { get => datosProcedimientoPrograma; set => SetProperty(ref datosProcedimientoPrograma, value); }

        //Auto inspección
        private AUD_DatosAutoInspeccion datosAutoInspeccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAutoInspeccion DatosAutoInspeccion { get => datosAutoInspeccion; set => SetProperty(ref datosAutoInspeccion, value); }

        // PRODUCCIÓN Y ANÁLISIS POR CONTRATO
        private AUD_DatosProdAnalisisContrato datosProdAnalisisContrato;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosProdAnalisisContrato DatosProdAnalisisContrato { get => datosProdAnalisisContrato; set => SetProperty(ref datosProdAnalisisContrato, value); }

        // RECLAMOS Y PRODUCTOS RETIRADOS DEL MERCADO
        private AUD_DatosReclamoProductoRetirado datosReclamoProductoRetirado;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosReclamoProductoRetirado DatosReclamoProductoRetirado { get => datosReclamoProductoRetirado; set => SetProperty(ref datosReclamoProductoRetirado, value); }

        // Local
        private AUD_DatosLocal datosLocal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosLocal DatosLocal { get => datosLocal; set => SetProperty(ref datosLocal, value); }

        // Area Producción
        private AUD_DatosAreaProduccion datosAreaProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAreaProduccion DatosAreaProduccion { get => datosAreaProduccion; set => SetProperty(ref datosAreaProduccion, value); }

        // Area Equipo
        private AUD_DatosEquipos datosEquipos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEquipos DatosEquipos { get => datosEquipos; set => SetProperty(ref datosEquipos, value); }

        // Laboratorio de Control de Calidad
        private AUD_DatosAreaLabCtrCalidad datosAreaLabCtrCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAreaLabCtrCalidad DatosAreaLabCtrCalidad { get => datosAreaLabCtrCalidad; set => SetProperty(ref datosAreaLabCtrCalidad, value); }

        // Áreas de Almacenamiento
        private AUD_DatosAreaAlmacenamiento datosAreaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAreaAlmacenamiento DatosAreaAlmacenamiento { get => datosAreaAlmacenamiento; set => SetProperty(ref datosAreaAlmacenamiento, value); }

        // Áreas de Auxiliares
        private AUD_DatosAreaAuxiliares datosAreaAuxiliares;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAreaAuxiliares DatosAreaAuxiliares { get => datosAreaAuxiliares; set => SetProperty(ref datosAreaAuxiliares, value); }
        

        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }

    }
}
