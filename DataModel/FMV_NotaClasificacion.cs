using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_NotaClasificacion:SystemId
    {
        public FMV_NotaClasificacion()
        {
            LClasificaciones = new List<NotaClasificacion>();
        }

        //Guarda los tipos de notas asociados
        private List<NotaClasificacion> lClasificaciones;
        public virtual List<NotaClasificacion> LClasificaciones { get => lClasificaciones; set => SetProperty(ref lClasificaciones, value); }

    }
}
