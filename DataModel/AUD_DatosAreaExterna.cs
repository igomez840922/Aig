using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaExterna:SystemId
    {
        // El establecimiento se encuentra identificado exteriormente, mediante letrero? 
        private enumAUD_TipoSeleccion identificada;
        public enumAUD_TipoSeleccion Identificada { get => identificada; set => SetProperty(ref identificada, value); }
        private string identificadaDesc;
        public string IdentificadaDesc { get => identificadaDesc; set => SetProperty(ref identificadaDesc, value); }

        // Está diseñado el edificio de tal manera que facilite la limpieza, mantenimiento y ejecución apropiada de las operaciones?
        private enumAUD_TipoSeleccion disenoFacilitaLimpMant;
        public enumAUD_TipoSeleccion DisenoFacilitaLimpMant { get => disenoFacilitaLimpMant; set => SetProperty(ref disenoFacilitaLimpMant, value); }
        private string disenoFacilitaLimpMantDesc;
        public string DisenoFacilitaLimpMantDesc { get => disenoFacilitaLimpMantDesc; set => SetProperty(ref disenoFacilitaLimpMantDesc, value); }

        //Las vías de acceso interno a las instalaciones ¿están pavimentadas o construidas de manera tal que el polvo no sea fuente de contaminación en el interior de la planta?
        private enumAUD_TipoSeleccion viaAccesoInternoInst;
        public enumAUD_TipoSeleccion ViaAccesoInternoInst { get => viaAccesoInternoInst; set => SetProperty(ref viaAccesoInternoInst, value); }
        private string viaAccesoInternoInstDesc;
        public string ViaAccesoInternoInstDesc { get => viaAccesoInternoInstDesc; set => SetProperty(ref viaAccesoInternoInstDesc, value); }

        //Existen fuentes de contaminación ambiental en el área circundante al edificio? En caso afirmativo, ¿se adoptan medidas de resguardo? 
        private enumAUD_TipoSeleccion fuentesContaminaAmbiental;
        public enumAUD_TipoSeleccion FuentesContaminaAmbiental { get => fuentesContaminaAmbiental; set => SetProperty(ref fuentesContaminaAmbiental, value); }
        private string fuentesContaminaAmbientalDesc;
        public string FuentesContaminaAmbientalDesc { get => fuentesContaminaAmbientalDesc; set => SetProperty(ref fuentesContaminaAmbientalDesc, value); }

        //Está diseñado y equipado el edificio de tal forma que ofrezca la máxima protección contra el ingreso de insectos y animales? 
        private enumAUD_TipoSeleccion proteccionContraAnimales;
        public enumAUD_TipoSeleccion ProteccionContraAnimales { get => proteccionContraAnimales; set => SetProperty(ref proteccionContraAnimales, value); }
        private string proteccionContraAnimalesDesc;
        public string ProteccionContraAnimalesDesc { get => proteccionContraAnimalesDesc; set => SetProperty(ref proteccionContraAnimalesDesc, value); }

    }
}
