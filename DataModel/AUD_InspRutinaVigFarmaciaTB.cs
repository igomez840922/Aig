using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspRutinaVigFarmaciaTB : SystemId
    {
        public AUD_InspRutinaVigFarmaciaTB()
        {
            DatosGeneralesFarmacia = new AUD_DatosGeneralesFarmacia();
            //DatosSolicitante = new AUD_DatosSolicitante();
            DatosRegente = new AUD_DatosRegente();
            DatosFarmaceutico = new AUD_DatosFarmaceutico();
            DatosRepresentLegal = new AUD_DatosRepresentLegal();
            DatosPersonalTecnico = new AUD_DatosPersonalTecnico();
            DatosExpedienteColaborador = new AUD_DatosExpedienteColaborador();
            DatosEstructuraFarmacia = new AUD_DatosEstructuraFarmacia();
            DatosEquipoRegistroFarmacia = new AUD_DatosEquipoRegistroFarmacia();
            DatosAnuncioFarmacia = new AUD_DatosAnuncioFarmacia();
            DatosRegMovimientoExistenciaFarmacia = new AUD_DatosRegMovimientoExistenciaFarmacia();
            DatosAlmacenProductosFarmacia = new AUD_DatosAlmacenProductosFarmacia();
            DatosProcedimientoFarmacia = new AUD_DatosProcedimientoFarmacia();

            DatosConclusiones = new AUD_DatosConclusiones();
        }

        private AUD_InspeccionTB inspeccion;
        [JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //GENERALIDADES DE LA FARMACIA
        private AUD_DatosGeneralesFarmacia datosGeneralesFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosGeneralesFarmacia DatosGeneralesFarmacia { get => datosGeneralesFarmacia; set => SetProperty(ref datosGeneralesFarmacia, value); }

        ////Datos del Solicitante
        //private AUD_DatosSolicitante datosSolicitante;
        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //public AUD_DatosSolicitante DatosSolicitante { get => datosSolicitante; set => SetProperty(ref datosSolicitante, value); }

        //DATOS GENERALES DEL REGENTE FARMACÉUTICO
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //FARMACÉUTICO DE TURNO
        private AUD_DatosFarmaceutico datosFarmaceutico;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosFarmaceutico DatosFarmaceutico { get => datosFarmaceutico; set => SetProperty(ref datosFarmaceutico, value); }

        //Datos del Representante Legal
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //PERSONAL TÉCNICO EN FARMACIA
        private AUD_DatosPersonalTecnico datosPersonalTecnico;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosPersonalTecnico DatosPersonalTecnico { get => datosPersonalTecnico; set => SetProperty(ref datosPersonalTecnico, value); }

        //Expediente personal de cada colaborador 
        private AUD_DatosExpedienteColaborador datosExpedienteColaborador;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosExpedienteColaborador DatosExpedienteColaborador { get => datosExpedienteColaborador; set => SetProperty(ref datosExpedienteColaborador, value); }

        //ESTRUCTURA DE LA FARMACIA
        private AUD_DatosEstructuraFarmacia datosEstructuraFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEstructuraFarmacia DatosEstructuraFarmacia { get => datosEstructuraFarmacia; set => SetProperty(ref datosEstructuraFarmacia, value); }

        //EQUIPO Y REGISTRO DE LA FARMACIA 
        private AUD_DatosEquipoRegistroFarmacia datosEquipoRegistroFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEquipoRegistroFarmacia DatosEquipoRegistroFarmacia { get => datosEquipoRegistroFarmacia; set => SetProperty(ref datosEquipoRegistroFarmacia, value); }

        //VERIFICAR, anuncio visible y legible
        private AUD_DatosAnuncioFarmacia datosAnuncioFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAnuncioFarmacia DatosAnuncioFarmacia { get => datosAnuncioFarmacia; set => SetProperty(ref datosAnuncioFarmacia, value); }

        //REGISTRO DE MOVIMIENTO DE EXISTENCIA
        private AUD_DatosRegMovimientoExistenciaFarmacia datosRegMovimientoExistenciaFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegMovimientoExistenciaFarmacia DatosRegMovimientoExistenciaFarmacia { get => datosRegMovimientoExistenciaFarmacia; set => SetProperty(ref datosRegMovimientoExistenciaFarmacia, value); }

        //ÁREA DE ALMACENAMIENTO DE PRODUCTO FARMACÉUTICO (DEPÓSITO)
        private AUD_DatosAlmacenProductosFarmacia datosAlmacenProductosFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAlmacenProductosFarmacia DatosAlmacenProductosFarmacia { get => datosAlmacenProductosFarmacia; set => SetProperty(ref datosAlmacenProductosFarmacia, value); }

        //PROCEDIMIENTOS
        private AUD_DatosProcedimientoFarmacia datosProcedimientoFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosProcedimientoFarmacia DatosProcedimientoFarmacia { get => datosProcedimientoFarmacia; set => SetProperty(ref datosProcedimientoFarmacia, value); }

        
        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }

    }
}
