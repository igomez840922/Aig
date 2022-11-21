using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class AUD_DatosAreaDespachoProductos : SystemId
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
        private enumAUD_TipoSeleccion disponeEstructuras;
        public enumAUD_TipoSeleccion DisponeEstructuras { get => disponeEstructuras; set => SetProperty(ref disponeEstructuras, value); }

        // Observaciones
        private string disponeEstructurasDesc;
        [StringLength(500)]
        public string DisponeEstructurasDesc { get => disponeEstructurasDesc; set => SetProperty(ref disponeEstructurasDesc, value); }

        // ¿Está esta área protegida de las inclemencias del tiempo?
        private enumAUD_TipoSeleccion protegidaIncTiempo;
        public enumAUD_TipoSeleccion ProtegidaIncTiempo { get => protegidaIncTiempo; set => SetProperty(ref protegidaIncTiempo, value); }

        // Observaciones
        private string protegidaIncTiempoDesc;
        [StringLength(500)]
        public string ProtegidaIncTiempoDesc { get => protegidaIncTiempoDesc; set => SetProperty(ref protegidaIncTiempoDesc, value); }

        // Existe rampa para carga y descarga (cuando sea necesario)
        private enumAUD_TipoSeleccion rampaCargaDesc;
        public enumAUD_TipoSeleccion RampaCargaDesc { get => rampaCargaDesc; set => SetProperty(ref rampaCargaDesc, value); }

        // Observaciones
        private string rampaCargaDescargaDesc;
        [StringLength(500)]
        public string RampaCargaDescargaDesc { get => rampaCargaDescargaDesc; set => SetProperty(ref rampaCargaDescargaDesc, value); }

        // Los productos dispuestos para el despacho están colocados sobre tarimas u otro mobiliario
        private enumAUD_TipoSeleccion productosTarimas;
        public enumAUD_TipoSeleccion ProductosTarimas { get => productosTarimas; set => SetProperty(ref productosTarimas, value); }
        private string productosTarimasDesc;
        [StringLength(500)]
        public string ProductosTarimasDesc { get => productosTarimasDesc; set => SetProperty(ref productosTarimasDesc, value); }


    }

}
