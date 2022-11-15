using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaRecProducto : SystemId
    {
        // ÁREA DE RECEPCIÓN DE PRODUCTOS
        // Delimitada
        private enumAUD_TipoSeleccion delimitada;
        public enumAUD_TipoSeleccion Delimitada { get => delimitada; set => SetProperty(ref delimitada, value); }

        private string delimitadaDesc;
        [StringLength(500)]
        public string DelimitadaDesc { get => delimitadaDesc; set => SetProperty(ref delimitadaDesc, value); }


        // Identificada
        private enumAUD_TipoSeleccion identificada;
        public enumAUD_TipoSeleccion Identificada { get => identificada; set => SetProperty(ref identificada, value); }

        private string identificadaDesc;
        [StringLength(500)]
        public string IdentificadaDesc { get => identificadaDesc; set => SetProperty(ref identificadaDesc, value); }

        // Limpia
        private enumAUD_TipoSeleccion limpia;
        public enumAUD_TipoSeleccion Limpia { get => limpia; set => SetProperty(ref limpia, value); }
        
        private string limpiaDesc;
        [StringLength(500)]
        public string LimpiaDesc { get => limpiaDesc; set => SetProperty(ref limpiaDesc, value); }

        // Separada
        private enumAUD_TipoSeleccion separada;
        public enumAUD_TipoSeleccion Separada { get => separada; set => SetProperty(ref separada, value); }
        
        private string separadaDesc;
        [StringLength(500)]
        public string SeparadaDesc { get => separadaDesc; set => SetProperty(ref separadaDesc, value); }

        // Ordenada
        private enumAUD_TipoSeleccion ordenada;
        public enumAUD_TipoSeleccion Ordenada { get => ordenada; set => SetProperty(ref ordenada, value); }

        private string ordenadaDesc;
        [StringLength(500)]
        public string OrdenadaDesc { get => ordenadaDesc; set => SetProperty(ref ordenadaDesc, value); }


        // ¿Dispone de estructuras en ésta área? (Tarimas, mesa de trabajo)
        private enumAUD_TipoSeleccion disponeEstructurasTarimas;
        public enumAUD_TipoSeleccion DisponeEstructurasTarimas { get => disponeEstructurasTarimas; set => SetProperty(ref disponeEstructurasTarimas, value); }

        // ¿Dispone de estructuras en ésta área? (Tarimas, mesa de trabajo)
        private enumAUD_TipoSeleccion disponeEstructurasMesas;
        public enumAUD_TipoSeleccion DisponeEstructurasMesas { get => disponeEstructurasMesas; set => SetProperty(ref disponeEstructurasMesas, value); }

        private string disponeEstructurasDesc;
        [StringLength(500)]
        public string DisponeEstructurasDesc { get => disponeEstructurasDesc; set => SetProperty(ref disponeEstructurasDesc, value); }


        // ¿Está esta área protegida de las inclemencias del tiempo?
        private enumAUD_TipoSeleccion areaProtegidaIncTiempo;
        public enumAUD_TipoSeleccion AreaProtegidaIncTiempo { get => areaProtegidaIncTiempo; set => SetProperty(ref areaProtegidaIncTiempo, value); }
        
        private string areaProtegidaIncTiempoDesc;
        [StringLength(500)]
        public string AreaProtegidaIncTiempoDesc { get => areaProtegidaIncTiempoDesc; set => SetProperty(ref areaProtegidaIncTiempoDesc, value); }

       
        // Existe rampa para carga y descarga (cuando sea necesario)
        private enumAUD_TipoSeleccion rampaCargaDescarga;
        public enumAUD_TipoSeleccion RampaCargaDescarga { get => rampaCargaDescarga; set => SetProperty(ref rampaCargaDescarga, value); }

        // Observación
        private string rampaCargaDescargaDesc;
        [StringLength(500)]
        public string RampaCargaDescargaDesc { get => rampaCargaDescargaDesc; set => SetProperty(ref rampaCargaDescargaDesc, value); }

    }
}
