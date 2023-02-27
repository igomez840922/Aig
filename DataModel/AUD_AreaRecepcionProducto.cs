using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_AreaRecepcionProducto : SystemId
    {
        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }

        public void Inicializa()
        {
            LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Separada. (cuando sea posible)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de estructuras en esta área (Tarimas, mesa de trabajo).",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está esta área protegida de las inclemencias del tiempo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe rampa para carga y descarga (cuando sea necesario)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }

        /// <summary>
        /// ///////////////////////////////////////////////
        /// </summary>
    }
}
