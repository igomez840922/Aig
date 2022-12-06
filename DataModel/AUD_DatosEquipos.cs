using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosEquipos:SystemId
    {
        // Adecuadamente localizado
        private enumAUD_TipoSeleccion adecLocalizado;
        public enumAUD_TipoSeleccion AdecLocalizado { get => adecLocalizado; set => SetProperty(ref adecLocalizado, value); }

        // Observaciones
        private string adecLocalizadoDesc;
        [StringLength(500)]
        public string AdecLocalizadoDesc { get => adecLocalizadoDesc; set => SetProperty(ref adecLocalizadoDesc, value); }

        // Las tuberías fijas conectados al equipo están rotulados claramente indicando su contenido
        private enumAUD_TipoSeleccion tuberiasIndicanContenido;
        public enumAUD_TipoSeleccion TuberiasIndicanContenido { get => tuberiasIndicanContenido; set => SetProperty(ref tuberiasIndicanContenido, value); }

        // Observaciones
        private string tuberiasIndicanContenidoDesc;
        [StringLength(500)]
        public string TuberiasIndicanContenidoDesc { get => tuberiasIndicanContenidoDesc; set => SetProperty(ref tuberiasIndicanContenidoDesc, value); }

        // Las tuberías de servicios (agua, gases, otros), están identificados
        private enumAUD_TipoSeleccion tuberiasServIdentificadas;
        public enumAUD_TipoSeleccion TuberiasServIdentificadas { get => tuberiasServIdentificadas; set => SetProperty(ref tuberiasServIdentificadas, value); }

        // Observaciones
        private string tuberiasServIdentificadasDesc;
        [StringLength(500)]
        public string TuberiasServIdentificadasDesc { get => tuberiasServIdentificadasDesc; set => SetProperty(ref tuberiasServIdentificadasDesc, value); }

        ////////////////////////////////
        ///////////////////////////////
        ///
        // Está el equipo utilizado en la producción diseñado y construido de acuerdo a la operación que en él se realice? 
        private enumAUD_TipoSeleccion disenoConstAcordeOpera;
        public enumAUD_TipoSeleccion DisenoConstAcordeOpera { get => disenoConstAcordeOpera; set => SetProperty(ref disenoConstAcordeOpera, value); }

        // Observaciones
        private string disenoConstAcordeOperaDesc;
        [StringLength(500)]
        public string DisenoConstAcordeOperaDesc { get => disenoConstAcordeOperaDesc; set => SetProperty(ref disenoConstAcordeOperaDesc, value); }

        // La ubicación del equipo facilita su limpieza, así como la del área en la que se encuentra?  
        private enumAUD_TipoSeleccion ubicacionFacilitaLimpieza;
        public enumAUD_TipoSeleccion UbicacionFacilitaLimpieza { get => ubicacionFacilitaLimpieza; set => SetProperty(ref ubicacionFacilitaLimpieza, value); }

        // Observaciones
        private string ubicacionFacilitaLimpiezaDesc;
        [StringLength(500)]
        public string UbicacionFacilitaLimpiezaDesc { get => ubicacionFacilitaLimpiezaDesc; set => SetProperty(ref ubicacionFacilitaLimpiezaDesc, value); }

        // Si el equipo es muy pesado, está diseñado para que se pueda ejecutar su limpieza, sanitización o esterilización en el área de producción? 
        private enumAUD_TipoSeleccion equipoPesado;
        public enumAUD_TipoSeleccion EquipoPesado { get => equipoPesado; set => SetProperty(ref equipoPesado, value); }

        // Observaciones
        private string equipoPesadoDesc;
        [StringLength(500)]
        public string EquipoPesadoDesc { get => equipoPesadoDesc; set => SetProperty(ref equipoPesadoDesc, value); }

        // Son las superficies de los equipos que tienen contacto directo con las materias primas, productos en proceso, de acero inoxidable de acuerdo a su uso u otro material que no sea reactivo, aditivo y adsorbente? 
        private enumAUD_TipoSeleccion superficieContactDirecto;
        public enumAUD_TipoSeleccion SuperficieContactDirecto { get => superficieContactDirecto; set => SetProperty(ref superficieContactDirecto, value); }

        // Observaciones
        private string superficieContactDirectoDesc;
        [StringLength(500)]
        public string SuperficieContactDirectoDesc { get => superficieContactDirectoDesc; set => SetProperty(ref superficieContactDirectoDesc, value); }

        // Los soportes de los equipos que lo requieran son de acero inoxidable u otro material que no contamine?  
        private enumAUD_TipoSeleccion soporteAceroInox;
        public enumAUD_TipoSeleccion SoporteAceroInox { get => soporteAceroInox; set => SetProperty(ref soporteAceroInox, value); }

        // Observaciones
        private string soporteAceroInoxDesc;
        [StringLength(500)]
        public string SoporteAceroInoxDesc { get => soporteAceroInoxDesc; set => SetProperty(ref soporteAceroInoxDesc, value); }

    }
}
