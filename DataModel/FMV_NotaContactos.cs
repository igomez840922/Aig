using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_NotaContactos :SystemId
    {
        public FMV_NotaContactos()
        {
            LContactos = new List<Contacto>();
        }

        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<Contacto> lContactos;
        public virtual List<Contacto> LContactos { get => lContactos; set => SetProperty(ref lContactos, value); }

    }
}
