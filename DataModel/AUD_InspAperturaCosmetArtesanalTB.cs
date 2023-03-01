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
                    Numero = 1,
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
                    Numero = 2,
                    Titulo = "El área está separada",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 3,
                    Titulo = "El área está limpia",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 4,
                    Titulo = "El área está ordenada",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 5,
                    Titulo = "El área es utilizada exclusivamente para este fin",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 6,
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
                    Numero = 7,
                    Titulo = "Suministros eléctricos",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 8,
                    Titulo = "Iluminación",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 9,
                    Titulo = "Ventilación",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 10,
                    Titulo = "Buen estado de conservación del edificio",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 11,
                    Titulo = "Señalización de las vías o rutas de evacuación",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                   Numero = 12,
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
                    Numero = 13,
                    Titulo = "Pisos",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 14,
                    Titulo = "Paredes",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 15,
                    Titulo = "Techos",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 16,
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
                    Numero = 17,
                    Titulo = "Mascarillas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 18,
                    Titulo = "Cubre Cabello",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 19,
                    Titulo = "Guantes",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 20,
                    Titulo = "Anteojos (cuando aplique)",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 21,
                    Titulo = "Delantales",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 22,
                    Titulo = "Están limpios y en buen estado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 23,
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
                    Numero = 24,
                    Titulo = "Pesado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 25,
                    Titulo = "Preparación o mezclado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 26,
                    Titulo = "Llenado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 27,
                    Titulo = "Secado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 28,
                    Titulo = "Empaque",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 29,
                    Titulo = "Etiquetado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 30,
                    Titulo = "Producto terminado",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 31,
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
                    Numero = 32,
                    Titulo = "Mesa de acero inoxidable",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 33,
                    Titulo = "Balanza",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 34,
                    Titulo = "Estufas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 35,
                    Titulo = "Hornillas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 36,
                    Titulo = "Mecheros",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 37,
                    Titulo = "Moldes",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 38,
                    Titulo = "Cristalería",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 39,
                    Titulo = "Ollas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 40,
                    Titulo = "Cucharones, cucharas",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 41,
                    Titulo = "Otros",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Numero = 42,
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
                Numero = 1,
                    Titulo = "Anaqueles para almacenar los productos y materiales a utilizar",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
            },
            new ContenidoPreguntas()
            {
               Numero = 2,
                 Titulo = "Capacidad suficiente para permitir el almacenamiento ordenado de los productos y que facilite el manejo y circulación en el área",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
            },
            new ContenidoPreguntas()
            {
                Numero = 3,
                Titulo = "Área protegida de las inclemencias   del tiempo",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
            },
            new ContenidoPreguntas()
            {
                Numero = 4,
                Titulo = "Área para almacenar productos rechazados, retirados o devueltos",
               LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
            },
            new ContenidoPreguntas()
            {
                Numero = 5,
                Titulo = "Área de almacenamiento para Etiquetas, material impreso",
               LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() }
             },
            };
        }


       
    
    }

}
