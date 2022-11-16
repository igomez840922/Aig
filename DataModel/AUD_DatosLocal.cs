using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosLocal:SystemId
    {        
        // LOCALES
        // El local está limpio y ordenado
        private enumAUD_TipoSeleccion localLimpioOrdenado;
        public enumAUD_TipoSeleccion LocalLimpioOrdenado { get => localLimpioOrdenado; set => SetProperty(ref localLimpioOrdenado, value); }

        // Observaciones
        private string localLimpioOrdenadoDesc;
        [StringLength(500)]
        public string LocalLimpioOrdenadoDesc { get => localLimpioOrdenadoDesc; set => SetProperty(ref localLimpioOrdenadoDesc, value); }

        // Instrucciones que no se debe permitir fumar, comer, beber, masticar o guardar plantas, comidas, bebidas, material de fumar y medicamentos personales
        private enumAUD_TipoSeleccion instNoComerBeberEtc;
        public enumAUD_TipoSeleccion InstNoComerBeberEtc { get => instNoComerBeberEtc; set => SetProperty(ref instNoComerBeberEtc, value); }

        // Observaciones
        private string instNoComerBeberEtcDesc;
        [StringLength(500)]
        public string InstNoComerBeberEtcDesc { get => instNoComerBeberEtcDesc; set => SetProperty(ref instNoComerBeberEtcDesc, value); }

        // Áreas externas limpias, ordenadas y libres de materiales extraños
        private enumAUD_TipoSeleccion areasExtLimpias;
        public enumAUD_TipoSeleccion AreasExtLimpias { get => areasExtLimpias; set => SetProperty(ref areasExtLimpias, value); }

        // Observaciones
        private string areasExtLimpiasDesc;
        [StringLength(500)]
        public string AreasExtLimpiasDesc { get => areasExtLimpiasDesc; set => SetProperty(ref areasExtLimpiasDesc, value); }

        // Condiciones adecuadas de suministros eléctricos
        private enumAUD_TipoSeleccion condAdecSumElectronico;
        public enumAUD_TipoSeleccion CondAdecSumElectronico { get => condAdecSumElectronico; set => SetProperty(ref condAdecSumElectronico, value); }

        // Observaciones
        private string condAdecSumElectronicoDesc;
        [StringLength(500)]
        public string CondAdecSumElectronicoDesc { get => condAdecSumElectronicoDesc; set => SetProperty(ref condAdecSumElectronicoDesc, value); }

        // Condiciones adecuadas de iluminación
        private enumAUD_TipoSeleccion adecuadaIluminacion;
        public enumAUD_TipoSeleccion AdecuadaIluminacion { get => adecuadaIluminacion; set => SetProperty(ref adecuadaIluminacion, value); }

        // Observaciones
        private string adecuadaIluminacionDesc;
        [StringLength(500)]
        public string AdecuadaIluminacionDesc { get => adecuadaIluminacionDesc; set => SetProperty(ref adecuadaIluminacionDesc, value); }

        // Condiciones adecuadas de temperatura
        private enumAUD_TipoSeleccion adecuadaTemperatura;
        public enumAUD_TipoSeleccion AdecuadaTemperatura { get => adecuadaTemperatura; set => SetProperty(ref adecuadaTemperatura, value); }

        // Observaciones
        private string adecuadaTemperaturaDesc;
        [StringLength(500)]
        public string AdecuadaTemperaturaDesc { get => adecuadaTemperaturaDesc; set => SetProperty(ref adecuadaTemperaturaDesc, value); }

        // Condiciones adecuadas de Humedad
        private enumAUD_TipoSeleccion adecuadaHumedad;
        public enumAUD_TipoSeleccion AdecuadaHumedad { get => adecuadaHumedad; set => SetProperty(ref adecuadaHumedad, value); }

        // Observaciones
        private string adecuadaHumedadDesc;
        [StringLength(500)]
        public string AdecuadaHumedadDesc { get => adecuadaHumedadDesc; set => SetProperty(ref adecuadaHumedadDesc, value); }

        // Condiciones adecuadas de Ventilación
        private enumAUD_TipoSeleccion adecuadaVentilacion;
        public enumAUD_TipoSeleccion AdecuadaVentilacion { get => adecuadaVentilacion; set => SetProperty(ref adecuadaVentilacion, value); }

        // Observaciones
        private string adecuadaVentilacionDesc;
        [StringLength(500)]
        public string AdecuadaVentilacionDesc { get => adecuadaVentilacionDesc; set => SetProperty(ref adecuadaVentilacionDesc, value); }

        // Estado de conservación del edificio
        private enumAUD_TipoSeleccion estadoConservEdificio;
        public enumAUD_TipoSeleccion EstadoConservEdificio { get => estadoConservEdificio; set => SetProperty(ref estadoConservEdificio, value); }

        // Observaciones
        private string estadoConservEdificioDesc;
        [StringLength(500)]
        public string EstadoConservEdificioDesc { get => estadoConservEdificioDesc; set => SetProperty(ref estadoConservEdificioDesc, value); }

        // Señalización de las vías o rutas de evacuación
        private enumAUD_TipoSeleccion senaRutaEvacuacion;
        public enumAUD_TipoSeleccion SenaRutaEvacuacion { get => senaRutaEvacuacion; set => SetProperty(ref senaRutaEvacuacion, value); }

        // Observaciones
        private string senaRutaEvacuacionDesc;
        [StringLength(500)]
        public string SenaRutaEvacuacionDesc { get => senaRutaEvacuacionDesc; set => SetProperty(ref senaRutaEvacuacionDesc, value); }

        // Equipo para el control de incendios
        private enumAUD_TipoSeleccion equiposControlIncendios;
        public enumAUD_TipoSeleccion EquiposControlIncendios { get => equiposControlIncendios; set => SetProperty(ref equiposControlIncendios, value); }

        // Observaciones
        private string equiposControlIncendiosDesc;
        [StringLength(500)]
        public string EquiposControlIncendiosDesc { get => equiposControlIncendiosDesc; set => SetProperty(ref equiposControlIncendiosDesc, value); }


    }
}
