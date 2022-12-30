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
            LContactos = new List<FMV_ContactosTB>();
        }

        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<FMV_ContactosTB> lContactos;
        public virtual List<FMV_ContactosTB> LContactos { get => lContactos; set => SetProperty(ref lContactos, value); }

    }
}
