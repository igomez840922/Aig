using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosProdAnalisisContrato : SystemId
    {
        // Contrato por escrito que establezca las funciones y responsabilidades de cada parte
        private enumAUD_TipoSeleccion contFuncionesResp;
        public enumAUD_TipoSeleccion ContFuncionesResp { get => contFuncionesResp; set => SetProperty(ref contFuncionesResp, value); }

        // Observaciones
        private string contFuncionesRespDesc;
        [StringLength(500)]
        public string ContFuncionesRespDesc { get => contFuncionesRespDesc; set => SetProperty(ref contFuncionesRespDesc, value); }

        // Análisis por contrato: el contrato establece que la aprobación final del producto lo hará el contratante a través del responsable de Control de Calidad
        private enumAUD_TipoSeleccion analisisPorCont;
        public enumAUD_TipoSeleccion AnalisisPorCont { get => analisisPorCont; set => SetProperty(ref analisisPorCont, value); }

        // Observaciones
        private string analisisPorContDesc;
        [StringLength(500)]
        public string AnalisisPorContDesc { get => analisisPorContDesc; set => SetProperty(ref analisisPorContDesc, value); }

        // El contrato establece donde se tomarán las muestras para su análisis
        private enumAUD_TipoSeleccion contMuestrasAnalisis;
        public enumAUD_TipoSeleccion ContMuestrasAnalisis { get => contMuestrasAnalisis; set => SetProperty(ref contMuestrasAnalisis, value); }

        // Observaciones
        private string contMuestrasAnalisisDesc;
        [StringLength(500)]
        public string ContMuestrasAnalisisDesc { get => contMuestrasAnalisisDesc; set => SetProperty(ref contMuestrasAnalisisDesc, value); }


        // Procedimientos a seguir si el resultado del análisis por contrato demuestra que el producto analizado debe ser rechazado
        private enumAUD_TipoSeleccion procSeguirProdRechazado;
        public enumAUD_TipoSeleccion ProcSeguirProdRechazado { get => procSeguirProdRechazado; set => SetProperty(ref procSeguirProdRechazado, value); }

        // Observaciones
        private string procSeguirProdRechazadoDesc;
        [StringLength(500)]
        public string ProcSeguirProdRechazadoDesc { get => procSeguirProdRechazadoDesc; set => SetProperty(ref procSeguirProdRechazadoDesc, value); }

        // Fabricación por contrato: realizada por un fabricante con Licencia de Operación
        private enumAUD_TipoSeleccion fabLicOperacion;
        public enumAUD_TipoSeleccion FabLicOperacion { get => fabLicOperacion; set => SetProperty(ref fabLicOperacion, value); }

        // Observaciones
        private string fabLicOperacionDesc;
        [StringLength(500)]
        public string FabLicOperacionDesc { get => fabLicOperacionDesc; set => SetProperty(ref fabLicOperacionDesc, value); }




    }
}
