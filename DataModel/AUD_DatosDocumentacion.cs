using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosDocumentacion:SystemId
    {
       
        // ¿El establecimiento se encuentra identificado exteriormente, mediante letrero?
        private enumAUD_TipoSeleccion estIdentificadoExterior;
        public enumAUD_TipoSeleccion EstIdentificadoExterior { get => estIdentificadoExterior; set => SetProperty(ref estIdentificadoExterior, value); }

        // Observaciones
        private string estIdentificadoExteriorDesc;
        [StringLength(500)]
        public string EstIdentificadoExteriorDesc { get => estIdentificadoExteriorDesc; set => SetProperty(ref estIdentificadoExteriorDesc, value); }


        // Organigramas (General y específicos)
        private enumAUD_TipoSeleccion organigramas;
        public enumAUD_TipoSeleccion Organigramas { get => organigramas; set => SetProperty(ref organigramas, value); }

        // Observaciones
        private string organigramasDesc;
        [StringLength(500)]
        public string OrganigramasDesc { get => organigramasDesc; set => SetProperty(ref organigramasDesc, value); }

        // Descripción de puestos
        private enumAUD_TipoSeleccion descPuestos;
        public enumAUD_TipoSeleccion DescPuestos { get => descPuestos; set => SetProperty(ref descPuestos, value); }

        // Observaciones
        private string descPuestosDesc;
        [StringLength(500)]
        public string DescPuestosDesc { get => descPuestosDesc; set => SetProperty(ref descPuestosDesc, value); }

        // Regente Farmaceutico
        private enumAUD_TipoSeleccion regenteFarmaceutico;
        public enumAUD_TipoSeleccion RegenteFarmaceutico { get => regenteFarmaceutico; set => SetProperty(ref regenteFarmaceutico, value); }
        // Observaciones
        private string regenteFarmaceuticoDesc;
        [StringLength(500)]
        public string RegenteFarmaceuticoDesc { get => regenteFarmaceuticoDesc; set => SetProperty(ref regenteFarmaceuticoDesc, value); }


        // Responsable de investigación y desarrollo
        private enumAUD_TipoSeleccion respInvDesarrollo;
        public enumAUD_TipoSeleccion RespInvDesarrollo { get => respInvDesarrollo; set => SetProperty(ref respInvDesarrollo, value); }

        // Observaciones
        private string respInvDesarrolloDesc;
        [StringLength(500)]
        public string RespInvDesarrolloDesc { get => respInvDesarrolloDesc; set => SetProperty(ref respInvDesarrolloDesc, value); }


        // Responsable de producción
        private enumAUD_TipoSeleccion respProduccion;
        public enumAUD_TipoSeleccion RespProduccion { get => respProduccion; set => SetProperty(ref respProduccion, value); }

        // Observaciones
        private string respProduccionDesc;
        [StringLength(500)]
        public string RespProduccionDesc { get => respProduccionDesc; set => SetProperty(ref respProduccionDesc, value); }


        // Responsable de control de calidad
        private enumAUD_TipoSeleccion respControlCalidad;
        public enumAUD_TipoSeleccion RespControlCalidad { get => respControlCalidad; set => SetProperty(ref respControlCalidad, value); }

        // Observaciones
        private string respControlCalidadDesc;
        [StringLength(500)]
        public string RespControlCalidadDesc { get => respControlCalidadDesc; set => SetProperty(ref respControlCalidadDesc, value); }


        // Responsable de garantía de la calidad
        private enumAUD_TipoSeleccion respGarantiaCalidad;
        public enumAUD_TipoSeleccion RespGarantiaCalidad { get => respGarantiaCalidad; set => SetProperty(ref respGarantiaCalidad, value); }

        // Observaciones
        private string respGarantiaCalidadDesc;
        [StringLength(500)]
        public string RespGarantiaCalidadDesc { get => respGarantiaCalidadDesc; set => SetProperty(ref respGarantiaCalidadDesc, value); }

        // Inducción del Personal
        private enumAUD_TipoSeleccion induccionPersonal;
        public enumAUD_TipoSeleccion InduccionPersonal { get => induccionPersonal; set => SetProperty(ref induccionPersonal, value); }

        // Observaciones
        private string induccionPersonalDesc;
        [StringLength(500)]
        public string InduccionPersonalDesc { get => induccionPersonalDesc; set => SetProperty(ref induccionPersonalDesc, value); }

    }
}
