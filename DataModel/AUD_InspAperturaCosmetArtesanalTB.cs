using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspAperturaCosmetArtesanalTB : SystemId
    {
        public AUD_InspAperturaCosmetArtesanalTB()
        {
            GeneralesEmpresa = new AUD_GeneralesEmpresa();
            
            Propietario = new DatosPersona();

            Documentacion = new AUD_ContenidoTablas();

            Locales = new AUD_ContenidoTablas();

            AreaAlmacenamiento = new AUD_ContenidoTablas();

            DatosConclusiones = new AUD_DatosConclusiones();

            InicializaData();
        }


        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Generales Empresa
        private AUD_GeneralesEmpresa generalesEmpresa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_GeneralesEmpresa GeneralesEmpresa { get => generalesEmpresa; set => SetProperty(ref generalesEmpresa, value); }

        //PROPIETARIO ARTESANO:
        private DatosPersona propietario;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona Propietario { get => propietario; set => SetProperty(ref propietario, value); }

        //DOCUMENTACION
        private AUD_ContenidoTablas documentacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Documentacion { get => documentacion; set => SetProperty(ref documentacion, value); }

        //LOCALES
        private AUD_ContenidoTablas locales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Locales { get => locales; set => SetProperty(ref locales, value); }

        //AREA ALMACENAMIENTO
        private AUD_ContenidoTablas areaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AreaAlmacenamiento { get => areaAlmacenamiento; set => SetProperty(ref areaAlmacenamiento, value); }

        //Inconformidades o desviaciones detectadas
        private string inconformidades;
        public string Inconformidades { get => inconformidades; set => SetProperty(ref inconformidades, value); }

        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }


        private void InicializaData()
        {
            Documentacion.LContenido = new List<ContenidoTablas>() {
            new ContenidoTablas()
                {
                    Titulo = "Listado de productos a elaborar.",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
               {
                   Titulo = "Listado de materias primas a utilizar",
                   Evaluacion = enumAUD_TipoSeleccion.NA
               },
            new ContenidoTablas()
               {
                   Titulo = "Programa de limpieza ",
                   Evaluacion = enumAUD_TipoSeleccion.NA
               },
            new ContenidoTablas()
               {
                   Titulo = "Programa para el control de la fauna nociva",
                   Evaluacion = enumAUD_TipoSeleccion.NA
               },
            new ContenidoTablas()
               {
                   Titulo = "Carpeta para el archivo de los formularios de Control de Elaboración de productos Cosméticos Artesanales",
                   Evaluacion = enumAUD_TipoSeleccion.NA
               }
            };
            //////////////////////
            ///
            Locales.LContenido = new List<ContenidoTablas>()
            {
            new ContenidoTablas()
            {
                Titulo = "Áreas externas limpias, ordenadas y libres de materiales extraños",
                Evaluacion = enumAUD_TipoSeleccion.NA
            },
            new ContenidoTablas()
                {
                    Titulo = "El área está separada",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "El área está limpia",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "El área está ordenada",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "El área es utilizada exclusivamente para este fin",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con instrucciones que no se debe permitir fumar, comer, beber, masticar o guardar plantas, comidas, bebidas, material de fumar y medicamentos personales",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Condiciones adecuadas de suministros eléctricos",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Condiciones adecuadas de iluminación",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Condiciones adecuadas de ventilación",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Buen estado de conservación del edificio",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Señalización de las vías o rutas de evacuación",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Equipo para el control de incendios (detector de humo)",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de pisos",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de paredes",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de techos",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Existen lavabos o fregador",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuentan con mascarillas",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuentan con cubre cabello",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuentan con guantes",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuentan con anteojos (cuando aplique)",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuentan con delantales",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están limpios y en buen estado",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están identificadas las áreas de pesado",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están identificadas las áreas de preparación o mezclado",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están identificadas las áreas de llenado",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están identificadas las áreas de secado",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están identificadas las áreas de empaque",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están identificadas las áreas de etiquetado",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están identificadas las áreas de producto terminado",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Están identificadas las áreas de utensilios limpios",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con mesa de acero inoxidable",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con balanza",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con estufas",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con hornillas",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con mecheros",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con moldes",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con cristalería",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con ollas",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con cucharones, cucharas",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Cuenta con otros",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                },
            new ContenidoTablas()
                {
                    Titulo = "Son de uso exclusivo de esta actividad",
                    Evaluacion = enumAUD_TipoSeleccion.NA
                }
            };
            //////////////////////
            ///
            AreaAlmacenamiento.LContenido = new List<ContenidoTablas>() {
            new ContenidoTablas()
            {
                Titulo = "Anaqueles para almacenar los productos y materiales a utilizar",
                Evaluacion = enumAUD_TipoSeleccion.NA
            },
            new ContenidoTablas()
            {
                Titulo = "Capacidad suficiente para permitir el almacenamiento ordenado de los productos y que facilite el manejo y circulación en el área",
                Evaluacion = enumAUD_TipoSeleccion.NA
            },
            new ContenidoTablas()
            {
                Titulo = "Área protegida de las inclemencias   del tiempo",
                Evaluacion = enumAUD_TipoSeleccion.NA
            },
            new ContenidoTablas()
            {
                Titulo = "Área para almacenar productos rechazados, retirados o devueltos",
                Evaluacion = enumAUD_TipoSeleccion.NA
            },
            new ContenidoTablas()
            {
                Titulo = "Área de almacenamiento para Etiquetas, material impreso",
                Evaluacion = enumAUD_TipoSeleccion.NA
            },
            };
            ///////
            


        }
    
    }

}
