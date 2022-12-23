using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class AUD_DatosAreaDispensado : SystemId
    {
        // Existe un área separada e identificada, para llevar a cabo las operaciones de dispensación?
        private enumAUD_TipoSeleccion existe;
        public enumAUD_TipoSeleccion Existe { get => existe; set => SetProperty(ref existe, value); }
        // Observaciones
        private string existeDesc;
        public string ExisteDesc { get => existeDesc; set => SetProperty(ref existeDesc, value); }

        //Tiene paredes, pisos, techos lisos y curvas sanitarias? private enumAUD_TipoSeleccion existe;
        private enumAUD_TipoSeleccion paredesPisosTechos;
        public enumAUD_TipoSeleccion ParedesPisosTechos { get => paredesPisosTechos; set => SetProperty(ref paredesPisosTechos, value); }
        // Observaciones
        private string paredesPisosTechosDesc;
        public string ParedesPisosTechosDesc { get => paredesPisosTechosDesc; set => SetProperty(ref paredesPisosTechosDesc, value); }

        //Cuenta con un sistema de inyección y extracción de aire que garanticen la no contaminación cruzada y seguridad del operario? 
        private enumAUD_TipoSeleccion sistInyExtAire;
        public enumAUD_TipoSeleccion SistInyExtAire { get => sistInyExtAire; set => SetProperty(ref sistInyExtAire, value); }
        // Observaciones
        private string sistInyExtAireDesc;
        public string SistInyExtAireDesc { get => sistInyExtAireDesc; set => SetProperty(ref sistInyExtAireDesc, value); }

        //Se mide la presión diferencial
        private enumAUD_TipoSeleccion medPresionDif;
        public enumAUD_TipoSeleccion MedPresionDif { get => medPresionDif; set => SetProperty(ref medPresionDif, value); }
        // Observaciones
        private string medPresionDifDesc;
        public string MedPresionDifDesc { get => medPresionDifDesc; set => SetProperty(ref medPresionDifDesc, value); }

        //Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles
        private enumAUD_TipoSeleccion precausionesNecesarioas;
        public enumAUD_TipoSeleccion PrecausionesNecesarioas { get => precausionesNecesarioas; set => SetProperty(ref precausionesNecesarioas, value); }
        // Observaciones
        private string precausionesNecesarioasDesc;
        public string PrecausionesNecesarioasDesc { get => precausionesNecesarioasDesc; set => SetProperty(ref precausionesNecesarioasDesc, value); }

        //Se cuenta con sistemas para la extracción localizada de polvos, cuando aplique?
        private enumAUD_TipoSeleccion sistExtracPolvo;
        public enumAUD_TipoSeleccion SistExtracPolvo { get => sistExtracPolvo; set => SetProperty(ref sistExtracPolvo, value); }
        // Observaciones
        private string sistExtracPolvoDesc;
        public string SistExtracPolvoDesc { get => sistExtracPolvoDesc; set => SetProperty(ref sistExtracPolvoDesc, value); }

        //Existe un área adyacente al área de dispensado, que se encuentre delimitada e identificada en donde se coloquen las materias primas que serán pesadas o medidas y las materias primas dispensadas que se utilizarán en la producción?
        private enumAUD_TipoSeleccion areaAdyacente;
        public enumAUD_TipoSeleccion AreaAdyacente { get => areaAdyacente; set => SetProperty(ref areaAdyacente, value); }
        // Observaciones
        private string areaAdyacenteDesc;
        public string AreaAdyacenteDesc { get => areaAdyacenteDesc; set => SetProperty(ref areaAdyacenteDesc, value); }

    }

}
