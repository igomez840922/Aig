using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class AUD_DatosAreaProdSujetosControl : SystemId
    {
        //Está identificada
        private enumAUD_TipoSeleccion independiente;
        public enumAUD_TipoSeleccion Independiente { get => independiente; set => SetProperty(ref independiente, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string independienteDesc;
        [StringLength(500)]
        public string IndependienteDesc { get => independienteDesc; set => SetProperty(ref independienteDesc, value); }


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

        //Está ordenada
        private enumAUD_TipoSeleccion ordenada;
        public enumAUD_TipoSeleccion Ordenada { get => ordenada; set => SetProperty(ref ordenada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string ordenadaDesc;
        [StringLength(500)]
        public string OrdenadaDesc { get => ordenadaDesc; set => SetProperty(ref ordenadaDesc, value); }

        //Está ordenada
        private enumAUD_TipoSeleccion iluminacion;
        public enumAUD_TipoSeleccion Iluminacion { get => iluminacion; set => SetProperty(ref iluminacion, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string iluminacionDesc;
        [StringLength(500)]
        public string IluminacionDesc { get => iluminacionDesc; set => SetProperty(ref iluminacionDesc, value); }


        //Está ordenada
        private enumAUD_TipoSeleccion identificadaVencidos;
        public enumAUD_TipoSeleccion IdentificadaVencidos { get => identificadaVencidos; set => SetProperty(ref identificadaVencidos, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string identificadaVencidosDesc;
        [StringLength(500)]
        public string IdentificadaVencidosDesc { get => identificadaVencidosDesc; set => SetProperty(ref identificadaVencidosDesc, value); }

        //Está ordenada
        private enumAUD_TipoSeleccion monitorTemperaturaHumedad;
        public enumAUD_TipoSeleccion MonitorTemperaturaHumedad { get => monitorTemperaturaHumedad; set => SetProperty(ref monitorTemperaturaHumedad, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string monitorTemperaturaHumedadDesc;
        [StringLength(500)]
        public string MonitorTemperaturaHumedadDesc { get => monitorTemperaturaHumedadDesc; set => SetProperty(ref monitorTemperaturaHumedadDesc, value); }


        //Está ordenada
        private enumAUD_TipoSeleccion monitorTemperatura;
        public enumAUD_TipoSeleccion MonitorTemperatura { get => monitorTemperatura; set => SetProperty(ref monitorTemperatura, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string monitorTemperaturaDesc;
        [StringLength(500)]
        public string MonitorTemperaturaDesc { get => monitorTemperaturaDesc; set => SetProperty(ref monitorTemperaturaDesc, value); }

        //Está ordenada
        private enumAUD_TipoSeleccion monitorHumedad;
        public enumAUD_TipoSeleccion MonitorHumedad { get => monitorHumedad; set => SetProperty(ref monitorHumedad, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string monitorHumedadDesc;
        [StringLength(500)]
        public string MonitorHumedadDesc { get => monitorHumedadDesc; set => SetProperty(ref monitorHumedadDesc, value); }

        //Está ordenada
        private enumAUD_TipoSeleccion mantineRegistro;
        public enumAUD_TipoSeleccion MantineRegistro { get => mantineRegistro; set => SetProperty(ref mantineRegistro, value); }

        private string mantineRegistroDesc;
        public string MantineRegistroDesc { get => mantineRegistroDesc; set => SetProperty(ref mantineRegistroDesc, value); }

        private string respnsableArea;
        public string RespnsableArea { get => respnsableArea; set => SetProperty(ref respnsableArea, value); }

        private string lugarDesc;
        public string LugarDesc { get => lugarDesc; set => SetProperty(ref lugarDesc, value); }

    }

}
