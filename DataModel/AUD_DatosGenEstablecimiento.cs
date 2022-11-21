using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosGenEstablecimiento : SystemId
    {
        // ¿El local está ubicado en área residencial? (está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales)
        private enumAUD_TipoSeleccion localAreaResidencial;
        public enumAUD_TipoSeleccion LocalAreaResidencial { get => localAreaResidencial; set => SetProperty(ref localAreaResidencial, value); }
        private string localAreaResidencialDesc;
        [StringLength(500)]
        public string LocalAreaResidencialDesc { get => localAreaResidencialDesc; set => SetProperty(ref localAreaResidencialDesc, value); }


        // ¿Existe letrero visible que identifique la empresa?
        private enumAUD_TipoSeleccion letreroVisible;
        public enumAUD_TipoSeleccion LetreroVisible { get => letreroVisible; set => SetProperty(ref letreroVisible, value); }
        private string letreroVisibleDesc;
        [StringLength(500)]
        public string LetreroVisibleDesc { get => letreroVisibleDesc; set => SetProperty(ref letreroVisibleDesc, value); }


        // El ambiente donde se sitúa el local presenta riesgo mínimo de contaminación a los productos (ver área externa del local)
        private enumAUD_TipoSeleccion existeRiesgoContam;
        public enumAUD_TipoSeleccion ExisteRiesgoContam { get => existeRiesgoContam; set => SetProperty(ref existeRiesgoContam, value); }
        private string existeRiesgoContamDesc;
        [StringLength(500)]
        public string ExisteRiesgoContamDesc { get => existeRiesgoContamDesc; set => SetProperty(ref existeRiesgoContamDesc, value); }

        // ¿Dispone de área administrativa?
        private enumAUD_TipoSeleccion areaAdminDispone;
        public enumAUD_TipoSeleccion AreaAdminDispone { get => areaAdminDispone; set => SetProperty(ref areaAdminDispone, value); }
        private string areaAdminDisponeDesc;
        [StringLength(500)]
        public string AreaAdminDisponeDesc { get => areaAdminDisponeDesc; set => SetProperty(ref areaAdminDisponeDesc, value); }

        // Distribuye sus productos a establecimientos que están debidamente autorizados por la Dirección Nacional de Farmacia y Drogas?
        private enumAUD_TipoSeleccion distribuyeEstabAutorizados;
        public enumAUD_TipoSeleccion DistribuyeEstabAutorizados { get => distribuyeEstabAutorizados; set => SetProperty(ref distribuyeEstabAutorizados, value); }
        private string distribuyeEstabAutorizadosDesc;
        [StringLength(500)]
        public string DistribuyeEstabAutorizadosDesc { get => distribuyeEstabAutorizadosDesc; set => SetProperty(ref distribuyeEstabAutorizadosDesc, value); }


        // Mantiene registros de las importaciones oficiales aprobadas por la Dirección Nacional de Farmacia y Drogas?
        private enumAUD_TipoSeleccion registroImpAprobado;
        public enumAUD_TipoSeleccion RegistroImpAprobado { get => registroImpAprobado; set => SetProperty(ref registroImpAprobado, value); }
        private string registroImpAprobadoDesc;
        [StringLength(500)]
        public string RegistroImpAprobadoDesc { get => registroImpAprobadoDesc; set => SetProperty(ref registroImpAprobadoDesc, value); }


        //Hay evidencias de que el establecimiento verifica que los productos cumplan con las especificaciones consignadas en el certificado de registro sanitario
        private enumAUD_TipoSeleccion cumpleRegSanitario;
        public enumAUD_TipoSeleccion CumpleRegSanitario { get => cumpleRegSanitario; set => SetProperty(ref cumpleRegSanitario, value); }
        private string cumpleRegSanitarioDesc;
        [StringLength(500)]
        public string CumpleRegSanitarioDesc { get => cumpleRegSanitarioDesc; set => SetProperty(ref cumpleRegSanitarioDesc, value); }

        //Existe área de Recepción de productos
        private enumAUD_TipoSeleccion areaRecepProductos;
        public enumAUD_TipoSeleccion AreaRecepProductos { get => areaRecepProductos; set => SetProperty(ref areaRecepProductos, value); }
        private string areaRecepProductosDesc;
        [StringLength(500)]
        public string AreaRecepProductosDesc { get => areaRecepProductosDesc; set => SetProperty(ref areaRecepProductosDesc, value); }

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

        //Está ordenada
        private enumAUD_TipoSeleccion ordenada;
        public enumAUD_TipoSeleccion Ordenada { get => ordenada; set => SetProperty(ref ordenada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string ordenadaDesc;
        [StringLength(500)]
        public string OrdenadaDesc { get => ordenadaDesc; set => SetProperty(ref ordenadaDesc, value); }

        // ¿Está esta área protegida de las inclemencias del tiempo?
        private enumAUD_TipoSeleccion protegidaIncTiempo;
        public enumAUD_TipoSeleccion ProtegidaIncTiempo { get => protegidaIncTiempo; set => SetProperty(ref protegidaIncTiempo, value); }
        private string protegidaIncTiempoDesc;
        [StringLength(500)]
        public string ProtegidaIncTiempoDesc { get => protegidaIncTiempoDesc; set => SetProperty(ref protegidaIncTiempoDesc, value); }

        //Los productos dispuestos para la recepción están colocados sobre tarimas u otro mobiliario
        private enumAUD_TipoSeleccion prodRecepSobreTarimas;
        public enumAUD_TipoSeleccion ProdRecepSobreTarimas { get => prodRecepSobreTarimas; set => SetProperty(ref prodRecepSobreTarimas, value); }
        private string prodRecepSobreTarimasDesc;
        [StringLength(500)]
        public string ProdRecepSobreTarimasDesc { get => prodRecepSobreTarimasDesc; set => SetProperty(ref prodRecepSobreTarimasDesc, value); }

       
    }
}
