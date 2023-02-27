using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_AreaAdministrativa:SystemId
    {
        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }

        public void Inicializa()
        {
            LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de área administrativa?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dirección del área administrativa",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Mantiene almacenados productos o áreas de almacenamiento en el área descrita como área administrativa?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }

        /// <summary>
        /// ///////////////////////////////////////////////
        /// </summary>
    }
}
