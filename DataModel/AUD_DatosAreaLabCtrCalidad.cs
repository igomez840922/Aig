using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaLabCtrCalidad : SystemId
    {
        // Equipo e instrumentos de laboratorio de control son apropiados a los procedimientos de análisis que se realizarán
        private enumAUD_TipoSeleccion instrumentosApropiados;
        public enumAUD_TipoSeleccion InstrumentosApropiados { get => instrumentosApropiados; set => SetProperty(ref instrumentosApropiados, value); }

        // Observaciones
        private string instrumentosApropiadosDesc;
        [StringLength(500)]
        public string InstrumentosApropiadosDesc { get => instrumentosApropiadosDesc; set => SetProperty(ref instrumentosApropiadosDesc, value); }

        // Área para almacenar los patrones
        private enumAUD_TipoSeleccion areaAlmacenPatrones;
        public enumAUD_TipoSeleccion AreaAlmacenPatrones { get => areaAlmacenPatrones; set => SetProperty(ref areaAlmacenPatrones, value); }

        // Observaciones
        private string areaAlmacenPatronesDesc;
        [StringLength(500)]
        public string AreaAlmacenPatronesDesc { get => areaAlmacenPatronesDesc; set => SetProperty(ref areaAlmacenPatronesDesc, value); }

        // Cuentan con especificaciones para materia prima
        private enumAUD_TipoSeleccion especificMateriaPrima;
        public enumAUD_TipoSeleccion EspecificMateriaPrima { get => especificMateriaPrima; set => SetProperty(ref especificMateriaPrima, value); }

        // Observaciones
        private string especificMateriaPrimaDesc;
        [StringLength(500)]
        public string EspecificMateriaPrimaDesc { get => especificMateriaPrimaDesc; set => SetProperty(ref especificMateriaPrimaDesc, value); }

        // Cuentan con especificaciones para material de acondicionamiento
        private enumAUD_TipoSeleccion especificMateriaAcond;
        public enumAUD_TipoSeleccion EspecificMateriaAcond { get => especificMateriaAcond; set => SetProperty(ref especificMateriaAcond, value); }

        // Observaciones
        private string especificMateriaAcondDesc;
        [StringLength(500)]
        public string EspecificMateriaAcondDesc { get => especificMateriaAcondDesc; set => SetProperty(ref especificMateriaAcondDesc, value); }

        // Cuentan con especificaciones para productos semi-elaborados y a granel
        private enumAUD_TipoSeleccion especificProdSemiElab;
        public enumAUD_TipoSeleccion EspecificProdSemiElab { get => especificProdSemiElab; set => SetProperty(ref especificProdSemiElab, value); }

        // Observaciones
        private string especificProdSemiElabDesc;
        [StringLength(500)]
        public string EspecificProdSemiElabDesc { get => especificProdSemiElabDesc; set => SetProperty(ref especificProdSemiElabDesc, value); }

        // Cuentan con especificaciones para productos terminados
        private enumAUD_TipoSeleccion especificProdTerminado;
        public enumAUD_TipoSeleccion EspecificProdTerminado { get => especificProdTerminado; set => SetProperty(ref especificProdTerminado, value); }

        // Observaciones
        private string especificProdTerminadoDesc;
        [StringLength(500)]
        public string EspecificProdTerminadoDesc { get => especificProdTerminadoDesc; set => SetProperty(ref especificProdTerminadoDesc, value); }

        //////////////////
        ////////////////////
        /////////////////////////
        ///

        //Existe un área destinada para el laboratorio de control de calidad que se encuentra identificada y separada del área de producción?
        private enumAUD_TipoSeleccion existe;
        public enumAUD_TipoSeleccion Existe { get => existe; set => SetProperty(ref existe, value); }

        // Observaciones
        private string existeDesc;
        [StringLength(500)]
        public string ExisteDesc { get => existeDesc; set => SetProperty(ref existeDesc, value); }


        //Tiene paredes lisas que faciliten su limpieza?
        private enumAUD_TipoSeleccion limpia;
        public enumAUD_TipoSeleccion Limpia { get => limpia; set => SetProperty(ref limpia, value); }

        // Observaciones
        private string limpiaDesc;
        [StringLength(500)]
        public string LimpiaDesc { get => limpiaDesc; set => SetProperty(ref limpiaDesc, value); }

        //Tiene una campana de extracción para los vapores nocivos?
        private enumAUD_TipoSeleccion campanaExtraccion;
        public enumAUD_TipoSeleccion CampanaExtraccion { get => campanaExtraccion; set => SetProperty(ref campanaExtraccion, value); }

        // Observaciones
        private string campanaExtraccionDesc;
        [StringLength(500)]
        public string CampanaExtraccionDesc { get => campanaExtraccionDesc; set => SetProperty(ref campanaExtraccionDesc, value); }

        //Tiene suficiente iluminación y ventilación? 
        private enumAUD_TipoSeleccion iluminacionVentilacion;
        public enumAUD_TipoSeleccion IluminacionVentilacion { get => iluminacionVentilacion; set => SetProperty(ref iluminacionVentilacion, value); }

        // Observaciones
        private string iluminacionVentilacionDesc;
        [StringLength(500)]
        public string IluminacionVentilacionDesc { get => iluminacionVentilacionDesc; set => SetProperty(ref iluminacionVentilacionDesc, value); }

        //Dispone de suficiente espacio para evitar confusiones y contaminación cruzada? 
        private enumAUD_TipoSeleccion espacioSuficiente;
        public enumAUD_TipoSeleccion EspacioSuficiente { get => espacioSuficiente; set => SetProperty(ref espacioSuficiente, value); }

        // Observaciones
        private string espacioSuficienteDesc;
        [StringLength(500)]
        public string EspacioSuficienteDesc { get => espacioSuficienteDesc; set => SetProperty(ref espacioSuficienteDesc, value); }

        //Según las operaciones que se realizan se dispone de las siguientes áreas 
        private enumAUD_TipoSeleccion areaMicrobiologia;
        public enumAUD_TipoSeleccion AreaMicrobiologia { get => areaMicrobiologia; set => SetProperty(ref areaMicrobiologia, value); }

        // Observaciones
        private string areaMicrobiologiaDesc;
        [StringLength(500)]
        public string AreaMicrobiologiaDesc { get => areaMicrobiologiaDesc; set => SetProperty(ref areaMicrobiologiaDesc, value); }

        private enumAUD_TipoSeleccion areaFisicoQuimica;
        public enumAUD_TipoSeleccion AreaFisicoQuimica { get => areaFisicoQuimica; set => SetProperty(ref areaFisicoQuimica, value); }

        // Observaciones
        private string areaFisicoQuimicaDesc;
        [StringLength(500)]
        public string AreaFisicoQuimicaDesc { get => areaFisicoQuimicaDesc; set => SetProperty(ref areaFisicoQuimicaDesc, value); }

        private enumAUD_TipoSeleccion areaInstrumental;
        public enumAUD_TipoSeleccion AreaInstrumental { get => areaInstrumental; set => SetProperty(ref areaInstrumental, value); }

        // Observaciones
        private string areaInstrumentalDesc;
        [StringLength(500)]
        public string AreaInstrumentalDesc { get => areaInstrumentalDesc; set => SetProperty(ref areaInstrumentalDesc, value); }

        private enumAUD_TipoSeleccion areaLavadoUtensilios;
        public enumAUD_TipoSeleccion AreaLavadoUtensilios { get => areaLavadoUtensilios; set => SetProperty(ref areaLavadoUtensilios, value); }

        // Observaciones
        private string areaLavadoUtensiliosDesc;
        [StringLength(500)]
        public string AreaLavadoUtensiliosDesc { get => areaLavadoUtensiliosDesc; set => SetProperty(ref areaLavadoUtensiliosDesc, value); }

        //Existe equipo de seguridad como
        private enumAUD_TipoSeleccion equipoSegDucha;
        public enumAUD_TipoSeleccion EquipoSegDucha { get => equipoSegDucha; set => SetProperty(ref equipoSegDucha, value); }

        // Observaciones
        private string equipoSegDuchaDesc;
        [StringLength(500)]
        public string EquipoSegDuchaDesc { get => equipoSegDuchaDesc; set => SetProperty(ref equipoSegDuchaDesc, value); }

        private enumAUD_TipoSeleccion equipoSegLavaOjo;
        public enumAUD_TipoSeleccion EquipoSegLavaOjo { get => equipoSegLavaOjo; set => SetProperty(ref equipoSegLavaOjo, value); }

        // Observaciones
        private string equipoSegLavaOjoDesc;
        [StringLength(500)]
        public string EquipoSegLavaOjoDesc { get => equipoSegLavaOjoDesc; set => SetProperty(ref equipoSegLavaOjoDesc, value); }

        private enumAUD_TipoSeleccion equipoSegExtintores;
        public enumAUD_TipoSeleccion EquipoSegExtintores { get => equipoSegExtintores; set => SetProperty(ref equipoSegExtintores, value); }

        // Observaciones
        private string equipoSegExtintoresDesc;
        [StringLength(500)]
        public string EquipoSegExtintoresDesc { get => equipoSegExtintoresDesc; set => SetProperty(ref equipoSegExtintoresDesc, value); }


        private enumAUD_TipoSeleccion equipoSegElemProtec;
        public enumAUD_TipoSeleccion EquipoSegElemProtec { get => equipoSegElemProtec; set => SetProperty(ref equipoSegElemProtec, value); }

        // Observaciones
        private string equipoSegElemProtecDesc;
        [StringLength(500)]
        public string EquipoSegElemProtecDesc { get => equipoSegElemProtecDesc; set => SetProperty(ref equipoSegElemProtecDesc, value); }

    }
}
