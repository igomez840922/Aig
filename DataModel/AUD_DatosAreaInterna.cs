using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaInterna : SystemId
    {
        // Está diseñado el edificio, de tal manera que permita el flujo de materiales, procesos y personal evitando la confusión, contaminación y errores? 
        private enumAUD_TipoSeleccion disenoPermiteFlujoMat;
        public enumAUD_TipoSeleccion DisenoPermiteFlujoMat { get => disenoPermiteFlujoMat; set => SetProperty(ref disenoPermiteFlujoMat, value); }
        private string disenoPermiteFlujoMatDesc;
        public string DisenoPermiteFlujoMatDesc { get => disenoPermiteFlujoMatDesc; set => SetProperty(ref disenoPermiteFlujoMatDesc, value); }

        //Están las áreas de acceso restringido debidamente delimitadas e identificadas? 
        private enumAUD_TipoSeleccion areaRetringDelimitada;
        public enumAUD_TipoSeleccion AreaRetringDelimitada { get => areaRetringDelimitada; set => SetProperty(ref areaRetringDelimitada, value); }
        private string areaRetringDelimitadaDesc;
        public string AreaRetringDelimitadaDesc { get => areaRetringDelimitadaDesc; set => SetProperty(ref areaRetringDelimitadaDesc, value); }

        //Se utilizan como áreas de paso las áreas de producción, almacenamiento y control de calidad
        private enumAUD_TipoSeleccion areaPasoComoAlmacen;
        public enumAUD_TipoSeleccion AreaPasoComoAlmacen { get => areaPasoComoAlmacen; set => SetProperty(ref areaPasoComoAlmacen, value); }
        private string areaPasoComoAlmacenDesc;
        public string AreaPasoComoAlmacenDesc { get => areaPasoComoAlmacenDesc; set => SetProperty(ref areaPasoComoAlmacenDesc, value); }

        //Las condiciones de iluminación, temperatura, humedad y ventilación, para la producción y almacenamiento, están acordes con los requerimientos del producto? 
        private enumAUD_TipoSeleccion condIlumTemHum;
        public enumAUD_TipoSeleccion CondIlumTemHum { get => condIlumTemHum; set => SetProperty(ref condIlumTemHum, value); }
        private string condIlumTemHumDesc;
        public string CondIlumTemHumDesc { get => condIlumTemHumDesc; set => SetProperty(ref condIlumTemHumDesc, value); }

        //Las tuberías, artefactos lumínicos, puntos de ventilación y otros servicios, están diseñados y ubicados, de tal forma que faciliten la limpieza? 
        private enumAUD_TipoSeleccion tuberiaArtefactosFacilLimpieza;
        public enumAUD_TipoSeleccion TuberiaArtefactosFacilLimpieza { get => tuberiaArtefactosFacilLimpieza; set => SetProperty(ref tuberiaArtefactosFacilLimpieza, value); }
        private string tuberiaArtefactosFacilLimpiezaDesc;
        public string TuberiaArtefactosFacilLimpiezaDesc { get => tuberiaArtefactosFacilLimpiezaDesc; set => SetProperty(ref tuberiaArtefactosFacilLimpiezaDesc, value); }

        //Dispone el edificio de extintores adecuados a las áreas y se encuentran estos ubicados en lugares estratégicos? 
        private enumAUD_TipoSeleccion disponeExtintores;
        public enumAUD_TipoSeleccion DisponeExtintores { get => disponeExtintores; set => SetProperty(ref disponeExtintores, value); }
        private string disponeExtintoresDesc;
        public string DisponeExtintoresDesc { get => disponeExtintoresDesc; set => SetProperty(ref disponeExtintoresDesc, value); }

        //Señalización de rutas de evacuación y salidas de emergencia.
        private enumAUD_TipoSeleccion senalRutaEvacuacion;
        public enumAUD_TipoSeleccion SenalRutaEvacuacion { get => senalRutaEvacuacion; set => SetProperty(ref senalRutaEvacuacion, value); }
        private string senalRutaEvacuacionDesc;
        public string SenalRutaEvacuacionDesc { get => senalRutaEvacuacionDesc; set => SetProperty(ref senalRutaEvacuacionDesc, value); }

    }
}
