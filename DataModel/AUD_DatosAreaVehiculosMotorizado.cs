using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class AUD_DatosAreaVehiculosMotorizado:SystemId
	{
        // TRANSPORTE
        // El transporte cuenta con controles y registro  de Temperatura y Humedad relativa
        private enumAUD_TipoSeleccion controlRegistroTemp;
        public enumAUD_TipoSeleccion ControlRegistroTemp { get => controlRegistroTemp; set => SetProperty(ref controlRegistroTemp, value); }

        // Observaciones
        private string controlRegistroTempDesc;
        [StringLength(500)]
        public string ControlRegistroTempDesc { get => controlRegistroTempDesc; set => SetProperty(ref controlRegistroTempDesc, value); }

        // El transporte mantiene los productos protegidos de la luz solar
        private enumAUD_TipoSeleccion proteccionLuzSolar;
        public enumAUD_TipoSeleccion ProteccionLuzSolar { get => proteccionLuzSolar; set => SetProperty(ref proteccionLuzSolar, value); }

        // Observaciones
        private string proteccionLuzSolarDesc;
        [StringLength(500)]
        public string ProteccionLuzSolarDesc { get => proteccionLuzSolarDesc; set => SetProperty(ref proteccionLuzSolarDesc, value); }


        // Los productos que requieren cadena de frío, se trasladan en vehículos o envases que permiten mantener la temperatura requerida
        private enumAUD_TipoSeleccion reqCadenaFrio;
        public enumAUD_TipoSeleccion ReqCadenaFrio { get => reqCadenaFrio; set => SetProperty(ref reqCadenaFrio, value); }

        // Observaciones
        private string reqCadenaFrioDesc;
        [StringLength(500)]
        public string ReqCadenaFrioDesc { get => reqCadenaFrioDesc; set => SetProperty(ref reqCadenaFrioDesc, value); }

        // Los vehículos motorizados están identificados como transporte de medicamentos y otros productos para la salud humana
        private enumAUD_TipoSeleccion vehIdentificadoTransporteMed;
        public enumAUD_TipoSeleccion VehIdentificadoTransporteMed { get => vehIdentificadoTransporteMed; set => SetProperty(ref vehIdentificadoTransporteMed, value); }

        // Observaciones
        private string vehIdentificadoTransporteMedDesc;
        [StringLength(500)]
        public string VehIdentificadoTransporteMedDesc { get => vehIdentificadoTransporteMedDesc; set => SetProperty(ref vehIdentificadoTransporteMedDesc, value); }


        // Presenta formato de verificación de mantenimiento y condiciones del vehículo
        private enumAUD_TipoSeleccion vehFormatVeriMantenimiento;
        public enumAUD_TipoSeleccion VehFormatVeriMantenimiento { get => vehFormatVeriMantenimiento; set => SetProperty(ref vehFormatVeriMantenimiento, value); }

        // Observacion
        private string vehFormatVeriMantenimientoDesc;
        [StringLength(500)]
        public string VehFormatVeriMantenimientoDesc { get => vehFormatVeriMantenimientoDesc; set => SetProperty(ref vehFormatVeriMantenimientoDesc, value); }

        // En caso de tercerización del transporte presenta contrato con la empresa que brindará el servicio
        private enumAUD_TipoSeleccion vehTercerizacion;
        public enumAUD_TipoSeleccion VehTercerizacion { get => vehTercerizacion; set => SetProperty(ref vehTercerizacion, value); }

        // Observaciones
        private string vehTercerizacionDesc;
        [StringLength(500)]
        public string VehTercerizacionDesc { get => vehTercerizacionDesc; set => SetProperty(ref vehTercerizacionDesc, value); }


        // Existe transporte según la normativa sanitaria vigente para el traslado de los productos.
        private enumAUD_TipoSeleccion vehNormSanitariaVigente;
        public enumAUD_TipoSeleccion VehNormSanitariaVigente { get => vehNormSanitariaVigente; set => SetProperty(ref vehNormSanitariaVigente, value); }

        // Observaciones
        private string vehNormSanitariaVigenteDesc;
        [StringLength(500)]
        public string VehNormSanitariaVigenteDesc { get => vehNormSanitariaVigenteDesc; set => SetProperty(ref vehNormSanitariaVigenteDesc, value); }

    }
}
