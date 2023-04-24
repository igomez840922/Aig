using DataModel.Helper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspAperCambUbicBotiquinTB : SystemId
    {

        private AUD_InspeccionTB inspeccion;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos del Representante Legal
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Datos del Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //CONDICIONES Y CARACTERÍSTICAS DEL ESTABLECIMIENTO
        private AUD_ContenidoGenerico condCaractEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico CondCaractEstablecimiento { get => condCaractEstablecimiento; set => SetProperty(ref condCaractEstablecimiento, value); }

        
        public void Inicializa_CondCaractEstablecimiento()
        {
            CondCaractEstablecimiento = new AUD_ContenidoGenerico();
            CondCaractEstablecimiento.LContenido = new List<ContenidoPreguntas>() {
                    //    new ContenidoPreguntas(){
                    //    Titulo = "CONDICIONES Y CARACTERÍSTICAS DEL ESTABLECIMIENTO",
                    //    IsHeader = true,
                    //},
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con letrero de identificación",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Son adecuadas las condiciones de Pisos, Paredes, Techos e Iluminación",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Es adecuado el tipo de Ventilación utilizada (Describir en las observaciones)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para monitorear la temperatura y humedad relativa de los productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la temperatura y humedad de esta área",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene registro",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los productos se encuentran en Vitrinas, Estantes, Tablillas, Anaqueles o Mostrador",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Son adecuadas y suficientes estas estructuras",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los productos están libres de polvo y almacenados ordenadamente",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El local está limpio y ordenado",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los medicamentos están separados de alimentos, insecticidas, productos veterinarios y agropecuarios",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los productos están libres de polvo y almacenados ordenadamente",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las condiciones del área pueden afectar la estabilidad de los productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        
    }

    
}
