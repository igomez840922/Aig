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

    }
}
