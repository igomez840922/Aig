using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaProductosRetirados : SystemId
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

        //Se lleva un registro de los productos a destruir y de los productos ya destruidos
        private enumAUD_TipoSeleccion registroProdDestruidos;
        public enumAUD_TipoSeleccion RegistroProdDestruidos { get => registroProdDestruidos; set => SetProperty(ref registroProdDestruidos, value); }
        private string registroProdDestruidosDesc;
        [StringLength(500)]
        public string RegistroProdDestruidosDesc { get => registroProdDestruidosDesc; set => SetProperty(ref registroProdDestruidosDesc, value); }


        //Cuenta con un área de cuarentena
        private enumAUD_TipoSeleccion areaCuarentena;
        public enumAUD_TipoSeleccion AreaCuarentena { get => areaCuarentena; set => SetProperty(ref areaCuarentena, value); }
        private string areaCuarentenaDesc;
        [StringLength(500)]
        public string AreaCuarentenaDesc { get => areaCuarentenaDesc; set => SetProperty(ref areaCuarentenaDesc, value); }


    }
}
