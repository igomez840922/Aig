using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_NotaInstitucion:SystemId
    {
        public FMV_NotaInstitucion()
        {
            LInstituciones = new List<FMV_NotaDestinoTB>();
        }

        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<FMV_NotaDestinoTB> lInstituciones;
        public virtual List<FMV_NotaDestinoTB> LInstituciones { get => lInstituciones; set => SetProperty(ref lInstituciones, value); }


    }
}
