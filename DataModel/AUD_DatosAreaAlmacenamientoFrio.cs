using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class AUD_DatosAreaAlmacenamientoFrio : SystemId
    {
        //Está identificada
        private enumAUD_TipoSeleccion identificada;
        public enumAUD_TipoSeleccion Identificada { get => identificada; set => SetProperty(ref identificada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string identificadaDesc;
        [StringLength(500)]
        public string IdentificadaDesc { get => identificadaDesc; set => SetProperty(ref identificadaDesc, value); }

        //Está delimitada
        private enumAUD_TipoSeleccion delimitada;
        public enumAUD_TipoSeleccion Delimitada { get => delimitada; set => SetProperty(ref delimitada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string delimitadaDesc;
        [StringLength(500)]
        public string DelimitadaDesc { get => delimitadaDesc; set => SetProperty(ref delimitadaDesc, value); }

        //Está limpia
        private enumAUD_TipoSeleccion limpia;
        public enumAUD_TipoSeleccion Limpia { get => limpia; set => SetProperty(ref limpia, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string limpiaDesc;
        [StringLength(500)]
        public string LimpiaDesc { get => limpiaDesc; set => SetProperty(ref limpiaDesc, value); }

        //Está asegurada
        private enumAUD_TipoSeleccion asegurada;
        public enumAUD_TipoSeleccion Asegurada { get => asegurada; set => SetProperty(ref asegurada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string aseguradaDesc;
        [StringLength(500)]
        public string AseguradaDesc { get => aseguradaDesc; set => SetProperty(ref aseguradaDesc, value); }

        //Está separada
        private enumAUD_TipoSeleccion separada;
        public enumAUD_TipoSeleccion Separada { get => separada; set => SetProperty(ref separada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string separadaDesc;
        [StringLength(500)]
        public string SeparadaDesc { get => separadaDesc; set => SetProperty(ref separadaDesc, value); }
                
        // ¿Dispone de estructuras en esta área? (Tarimas, mesa de trabajo)
        private enumAUD_TipoSeleccion temperatura;
        public enumAUD_TipoSeleccion Temperatura { get => temperatura; set => SetProperty(ref temperatura, value); }

        // Observaciones
        private string temperaturaDesc;
        [StringLength(500)]
        public string TemperaturaDesc { get => temperaturaDesc; set => SetProperty(ref temperaturaDesc, value); }

        // ¿Está esta área protegida de las inclemencias del tiempo?
        private enumAUD_TipoSeleccion humedadRelativa;
        public enumAUD_TipoSeleccion HumedadRelativa { get => humedadRelativa; set => SetProperty(ref humedadRelativa, value); }

        // Observaciones
        private string humedadRelativaDesc;
        [StringLength(500)]
        public string HumedadRelativaDesc { get => humedadRelativaDesc; set => SetProperty(ref humedadRelativaDesc, value); }

        // Existe rampa para carga y descarga (cuando sea necesario)
        private enumAUD_TipoSeleccion equipoConservacionTemp;
        public enumAUD_TipoSeleccion EquipoConservacionTemp { get => equipoConservacionTemp; set => SetProperty(ref equipoConservacionTemp, value); }

        // Observaciones
        private string equipoConservacionTempDesc;
        [StringLength(500)]
        public string EquipoConservacionTempDesc { get => equipoConservacionTempDesc; set => SetProperty(ref equipoConservacionTempDesc, value); }

        // Existe rampa para carga y descarga (cuando sea necesario)
        private enumAUD_TipoSeleccion registroMonitoreoTemp;
        public enumAUD_TipoSeleccion RegistroMonitoreoTemp { get => registroMonitoreoTemp; set => SetProperty(ref registroMonitoreoTemp, value); }

        // Observaciones
        private string registroMonitoreoTempDesc;
        [StringLength(500)]
        public string RegistroMonitoreoTempDesc { get => registroMonitoreoTempDesc; set => SetProperty(ref registroMonitoreoTempDesc, value); }


        // Existe rampa para carga y descarga (cuando sea necesario)
        private enumAUD_TipoSeleccion sistemaAlarma;
        public enumAUD_TipoSeleccion SistemaAlarma { get => sistemaAlarma; set => SetProperty(ref sistemaAlarma, value); }

        // Observaciones
        private string sistemaAlarmaDesc;
        [StringLength(500)]
        public string SistemaAlarmaDesc { get => sistemaAlarmaDesc; set => SetProperty(ref sistemaAlarmaDesc, value); }

    }

}
