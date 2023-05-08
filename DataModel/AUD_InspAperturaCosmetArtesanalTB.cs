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
        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos del Representante Legal
        private DatosPersona datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //DOCUMENTACION
        private AUD_ContenidoGenerico documentacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Documentacion { get => documentacion; set => SetProperty(ref documentacion, value); }

        //LOCALES
        private AUD_ContenidoGenerico locales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Locales { get => locales; set => SetProperty(ref locales, value); }

        //AREA ALMACENAMIENTO
        private AUD_ContenidoGenerico areaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenamiento { get => areaAlmacenamiento; set => SetProperty(ref areaAlmacenamiento, value); }

        public void Inicializa_Documentacion() {
            Documentacion = new AUD_ContenidoGenerico();
            Documentacion.LContenido = new List<ContenidoPreguntas>()
            {
            new ContenidoPreguntas()
                {
                    Numero = 1,
                    Titulo = "Listado de productos a elaborar.",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
               {
                    Numero = 2,
                   Titulo = "Listado de materias primas a utilizar",
                   LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
               },
            new ContenidoPreguntas()
               {
                    Numero = 3,
                   Titulo = "Programa de limpieza ",
                   LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
               },
            new ContenidoPreguntas()
               {
                    Numero = 4,
                   Titulo = "Programa para el control de la fauna nociva",
                   LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
               },
            new ContenidoPreguntas()
               {
                    Numero = 5,
                   Titulo = "Carpeta para el archivo de los formularios de Control de Elaboración de productos Cosméticos Artesanales",
                   LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
               }
            };
        }
        public void Inicializa_Locales() {
            Locales = new AUD_ContenidoGenerico();
            Locales.LContenido = new List<ContenidoPreguntas>()
            {
            new ContenidoPreguntas()
            {
                Titulo = "Área para la elaboración de cosméticos artesanales: ",
                IsHeader = true
            },
            new ContenidoPreguntas()
            {
                Titulo = "Áreas externas limpias, ordenadas y libres de materiales extraños",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El área está: ",
                IsHeader = true
            },
            new ContenidoPreguntas()
                {
                    Titulo = "Separada",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Limpia",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Ordenada",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Es utilizada exclusivamente para este fin",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Cuenta con instrucciones que no se debe permitir fumar, comer, beber, masticar o guardar plantas, comidas, bebidas, material de fumar y medicamentos personales",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
            {
                Titulo = "Condiciones adecuadas de: ",
                IsHeader = true
            },
            new ContenidoPreguntas()
                {
                    Titulo = "Suministros eléctricos",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Iluminación",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Ventilación",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Buen estado de conservación del edificio",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Señalización de las vías o rutas de evacuación",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                     Titulo = "Equipo para el control de incendios (detector de humo)",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
            {
                Titulo = "Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de: ",
                IsHeader = true
            },
            new ContenidoPreguntas()
                {
                    Titulo = "Pisos",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Paredes",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Techos",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Existen lavabos o fregador",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
            {
                Titulo = "Cuentan con los siguientes implementos: ",
                IsHeader = true
            },
            new ContenidoPreguntas()
                {
                    Titulo = "Mascarillas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Cubre Cabello",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Guantes",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Anteojos (cuando aplique)",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Delantales",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Están limpios y en buen estado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Están identificadas las áreas de pesado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
            {
                Titulo = "Están identificadas las áreas de: (según aplique)",
                IsHeader = true
            },
            new ContenidoPreguntas()
                {
                    Titulo = "Pesado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Preparación o mezclado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Llenado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Secado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Empaque",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Etiquetado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Producto terminado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Utensilios limpios",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
            {
                Titulo = "Cuenta con:",
                IsHeader = true
            },
            new ContenidoPreguntas()
                {
                    Titulo = "Mesa de acero inoxidable",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Balanza",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Estufas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Hornilla",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Mechero",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Moldes",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Cristalería",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Ollas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Cucharones, cucharas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Otros",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Son de uso exclusivo de esta actividad",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                }
            };
        }
        public void Inicializa_AreaAlmacenamiento() {
            AreaAlmacenamiento = new AUD_ContenidoGenerico();
            AreaAlmacenamiento.LContenido = new List<ContenidoPreguntas>() {
            new ContenidoPreguntas()
            {
                    Titulo = "Dispone de:",
                IsHeader = true
            },new ContenidoPreguntas()
            {
                    Titulo = "Anaqueles para almacenar los productos y materiales a utilizar",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
            },
            new ContenidoPreguntas()
            {
                 Titulo = "Capacidad suficiente para permitir el almacenamiento ordenado de los productos y que facilite el manejo y circulación en el área",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
            },
            new ContenidoPreguntas()
            {
                Titulo = "Área protegida de las inclemencias   del tiempo",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
            },
            new ContenidoPreguntas()
            {
                Titulo = "Área para almacenar productos rechazados, retirados o devueltos",
               LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
            },
            new ContenidoPreguntas()
            {
                Titulo = "Área de almacenamiento para Etiquetas, material impreso",
               LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
             },
            };
        }


       
    
    }

}
