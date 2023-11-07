using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_ContenidoGenerico:SystemId
    {
        public AUD_ContenidoGenerico() {
            LContenido = new List<ContenidoPreguntas>();
        }
        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }
    }        

}
