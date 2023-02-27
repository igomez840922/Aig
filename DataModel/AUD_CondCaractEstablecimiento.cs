using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_CondCaractEstablecimiento:SystemId
    {
        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }

        public void Inicializa()
        {
            LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "El local está ubicado en área residencial?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe letrero visible que identifique la empresa?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con área separada para la conservación y consumo de alimentos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }

        /// <summary>
        /// ///////////////////////////////////////////////
        /// </summary>
    }
}
