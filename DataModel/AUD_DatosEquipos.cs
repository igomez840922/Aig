using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosEquipos:SystemId
    {
        // Adecuadamente localizado
        private enumAUD_TipoSeleccion adecLocalizado;
        public enumAUD_TipoSeleccion AdecLocalizado { get => adecLocalizado; set => SetProperty(ref adecLocalizado, value); }

        // Observaciones
        private string adecLocalizadoDesc;
        [StringLength(500)]
        public string AdecLocalizadoDesc { get => adecLocalizadoDesc; set => SetProperty(ref adecLocalizadoDesc, value); }

        // Las tuberías fijas conectados al equipo están rotulados claramente indicando su contenido
        private enumAUD_TipoSeleccion tuberiasIndicanContenido;
        public enumAUD_TipoSeleccion TuberiasIndicanContenido { get => tuberiasIndicanContenido; set => SetProperty(ref tuberiasIndicanContenido, value); }

        // Observaciones
        private string tuberiasIndicanContenidoDesc;
        [StringLength(500)]
        public string TuberiasIndicanContenidoDesc { get => tuberiasIndicanContenidoDesc; set => SetProperty(ref tuberiasIndicanContenidoDesc, value); }

        // Las tuberías de servicios (agua, gases, otros), están identificados
        private enumAUD_TipoSeleccion tuberiasServIdentificadas;
        public enumAUD_TipoSeleccion TuberiasServIdentificadas { get => tuberiasServIdentificadas; set => SetProperty(ref tuberiasServIdentificadas, value); }

        // Observaciones
        private string tuberiasServIdentificadasDesc;
        [StringLength(500)]
        public string TuberiasServIdentificadasDesc { get => tuberiasServIdentificadasDesc; set => SetProperty(ref tuberiasServIdentificadasDesc, value); }


    }
}
