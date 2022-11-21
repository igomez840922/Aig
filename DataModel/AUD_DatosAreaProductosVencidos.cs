using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaProductosVencidos : SystemId
    {
        //El área se encuentra identificada
        private enumAUD_TipoSeleccion identificada;
        public enumAUD_TipoSeleccion Identificada { get => identificada; set => SetProperty(ref identificada, value); }

        //Debe desplegar un área de texto para las observaciones.
        private string identificadaDesc;
        public string IdentificadaDesc { get => identificadaDesc; set => SetProperty(ref identificadaDesc, value); }

        //El área se encuentra asegurada(llave y/o candado)
        private enumAUD_TipoSeleccion asegurada;
        public enumAUD_TipoSeleccion Asegurada { get => asegurada; set => SetProperty(ref asegurada, value); }

        //Debe desplegar un área de texto para las observaciones.
        private string aseguradaDesc;
        public string AseguradaDesc { get => aseguradaDesc; set => SetProperty(ref aseguradaDesc, value); }

        //El área se encuentra independiente de otras áreas
        private enumAUD_TipoSeleccion independiente;
        public enumAUD_TipoSeleccion Independiente { get => independiente; set => SetProperty(ref independiente, value); }

        //Debe desplegar un área de texto para las observaciones.
        private string independienteDesc;
        public string IndependienteDesc { get => independienteDesc; set => SetProperty(ref independienteDesc, value); }

        //El área se encuentra delimitada
        private enumAUD_TipoSeleccion delimitada;
        public enumAUD_TipoSeleccion Delimitada { get => delimitada; set => SetProperty(ref delimitada, value); }

        //Debe desplegar un área de texto para las observaciones.
        private string delimitadaDesc;
        public string DelimitadaDesc { get => delimitadaDesc; set => SetProperty(ref delimitadaDesc, value); }

        //Iluminación y Ventilación
        private enumAUD_TipoSeleccion iluminacionVentilacion;
        public enumAUD_TipoSeleccion IluminacionVentilacion { get => iluminacionVentilacion; set => SetProperty(ref iluminacionVentilacion, value); }
        private string iluminacionVentilacionDesc;
        public string IluminacionVentilacionDesc { get => iluminacionVentilacionDesc; set => SetProperty(ref iluminacionVentilacionDesc, value); }


        //Responsables del Área:
        private enumAUD_TipoSeleccion responsable;
        public enumAUD_TipoSeleccion Responsable { get => responsable; set => SetProperty(ref responsable, value); }
        private string responsableDesc;
        public string ResponsableDesc { get => responsableDesc; set => SetProperty(ref responsableDesc, value); }

        //Describa el lugar donde se almacenan y las medidas de seguridad.
        private string lugarDondeAlmacenanDesc;
        public string LugarDondeAlmacenanDesc { get => lugarDondeAlmacenanDesc; set => SetProperty(ref lugarDondeAlmacenanDesc, value); }

        //Se mantiene un registro para el manejo de las sustancias controladas
        private enumAUD_TipoSeleccion registroSustControladas;
        public enumAUD_TipoSeleccion RegistroSustControladas { get => registroSustControladas; set => SetProperty(ref registroSustControladas, value); }
        private string registroSustControladasDesc;
        public string RegistroSustControladasDesc { get => registroSustControladasDesc; set => SetProperty(ref registroSustControladasDesc, value); }




    }
}
