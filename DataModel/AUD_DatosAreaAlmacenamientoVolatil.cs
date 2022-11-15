using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaAlmacenamientoVolatil : SystemId
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

        //Está ordenada
        private enumAUD_TipoSeleccion ordenada;
        public enumAUD_TipoSeleccion Ordenada { get => ordenada; set => SetProperty(ref ordenada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string ordenadaDesc;
        [StringLength(500)]
        public string OrdenadaDesc { get => ordenadaDesc; set => SetProperty(ref ordenadaDesc, value); }

        //Está ordenada
        private enumAUD_TipoSeleccion kitDerrame;
        public enumAUD_TipoSeleccion KitDerrame { get => kitDerrame; set => SetProperty(ref kitDerrame, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string kitDerrameDesc;
        [StringLength(500)]
        public string KitDerrameDesc { get => kitDerrameDesc; set => SetProperty(ref kitDerrameDesc, value); }

        //Está ordenada
        private enumAUD_TipoSeleccion controlIncendio;
        public enumAUD_TipoSeleccion ControlIncendio { get => controlIncendio; set => SetProperty(ref controlIncendio, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string controlIncendioDesc;
        [StringLength(500)]
        public string ControlIncendioDesc { get => controlIncendioDesc; set => SetProperty(ref controlIncendioDesc, value); }

        //Está ordenada
        private enumAUD_TipoSeleccion adecuadaVentilacion;
        public enumAUD_TipoSeleccion AdecuadaVentilacion { get => adecuadaVentilacion; set => SetProperty(ref adecuadaVentilacion, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string adecuadaVentilacionDesc;
        [StringLength(500)]
        public string AdecuadaVentilacionDesc { get => adecuadaVentilacionDesc; set => SetProperty(ref adecuadaVentilacionDesc, value); }


    }

}
