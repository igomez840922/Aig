using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_AreaAlmacenamiento:SystemId
    {
        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }

        public void Inicializa()
        {
            LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Claramente  Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Seca",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tamaño aproximado del Depósito",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "La  capacidad del área es suficiente para almacenar productos, manejo adecuado de productos y circulación del personal (de ser negativa la respuesta, indicar motivo)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "SON ADECUADAS LAS CONDICIONES",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Piso",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Techo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Paredes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Luces de emergencia",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ventilación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Suministro eléctrico",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "SON ADECUADAS LAS CONDICIONES",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Piso",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Techo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Paredes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Luces de emergencia",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ventilación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Suministro eléctrico",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "DISPONEN DE SUFICIENTE EQUIPO PARA EL CONTROL DE INCENDIOS",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Extintores Vigentes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Alarma",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Detectores de humo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe señalización de rutas de evacuación en caso de siniestros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe salida de emergencia identificada del local",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "DISPONE DE ESTRUCTURAS DONDE ALMACENAN LOS PRODUCTOS",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Anaqueles",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Estantes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tablillas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Son adecuadas, suficientes e identificadas estas estructuras",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los muebles son colocados manteniendo un pie de distancia de las paredes y del techo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con área de desperdicios",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "CONDICIONES GENERALES",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El área de almacenamiento está libre de polvo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para monitorear la temperatura y humedad relativa de acuerdo con las especificaciones de almacenamiento del fabricante",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Temperatura",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Humedad Relativa",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene registro",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los registros se registran por lo menos tres veces al día",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Es adecuada la temperatura de almacenamiento de los productos allí almacenados (verifique)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe letrero visible que identifique los rangos de temperatura y humedad",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para el control de fauna nociva (cebadera y certificado de fumigación)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe flujo lógico de operaciones",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Precauciones en el área de Almacenamiento. No se permite fumar, comer, guardar comidas o cualquier otro objeto que pudiera afectar la calidad de los productos. Art. 418. Decreto Ejecutivo 115 de 16 de agosto de 2022",
                        IsHeader=true,
                    },
             };
        }

    }
}
