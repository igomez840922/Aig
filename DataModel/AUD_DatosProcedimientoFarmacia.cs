using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosProcedimientoFarmacia : SystemId
    {
        //El establecimiento debe tener los procedimientos básicos de las principales actividades que realiza el personal; cada una por separado.
        private enumAUD_TipoSeleccion procPrincActRealizaPersonal;
        public enumAUD_TipoSeleccion ProcPrincActRealizaPersonal { get => procPrincActRealizaPersonal; set => SetProperty(ref procPrincActRealizaPersonal, value); }

        //Almacenamiento de los productos farmacéuticos
        private enumAUD_TipoSeleccion almacenamProdFarmaceuticos;
        public enumAUD_TipoSeleccion AlmacenamProdFarmaceuticos { get => almacenamProdFarmaceuticos; set => SetProperty(ref almacenamProdFarmaceuticos, value); }

        //Limpieza de las áreas
        private enumAUD_TipoSeleccion retiroReemplazo;
        public enumAUD_TipoSeleccion RetiroReemplazo { get => retiroReemplazo; set => SetProperty(ref retiroReemplazo, value); }

        //Limpieza de las áreas
        private enumAUD_TipoSeleccion limpiezaAreas;
        public enumAUD_TipoSeleccion LimpiezaAreas { get => limpiezaAreas; set => SetProperty(ref limpiezaAreas, value); }

        //Programa de Capacitación
        private enumAUD_TipoSeleccion programaCapacitacion;
        public enumAUD_TipoSeleccion ProgramaCapacitacion { get => programaCapacitacion; set => SetProperty(ref programaCapacitacion, value); }

        //Transporte de medicamentos (Cadena de Frío)
        private enumAUD_TipoSeleccion transporteMedicamentoCadFrio;
        public enumAUD_TipoSeleccion TransporteMedicamentoCadFrio { get => transporteMedicamentoCadFrio; set => SetProperty(ref transporteMedicamentoCadFrio, value); }

        //Manejo de los productos de Cadena de Frío
        private enumAUD_TipoSeleccion manejoMedicamentoCadFrio;
        public enumAUD_TipoSeleccion ManejoMedicamentoCadFrio { get => manejoMedicamentoCadFrio; set => SetProperty(ref manejoMedicamentoCadFrio, value); }
        
        //Control de Fauna
        private enumAUD_TipoSeleccion controlFauna;
        public enumAUD_TipoSeleccion ControlFauna { get => controlFauna; set => SetProperty(ref controlFauna, value); }

        //Expediente para el archivo cronológico de la inspección y auditoria realizadas por la DNFD
        private enumAUD_TipoSeleccion expArchivoCronologInspAudit;
        public enumAUD_TipoSeleccion ExpArchivoCronologInspAudit { get => expArchivoCronologInspAudit; set => SetProperty(ref expArchivoCronologInspAudit, value); }

    }
}
