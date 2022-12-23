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
            LInstituciones = new List<InstitucionDestinoTB>();
        }

        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<InstitucionDestinoTB> lInstituciones;
        public virtual List<InstitucionDestinoTB> LInstituciones { get => lInstituciones; set => SetProperty(ref lInstituciones, value); }


    }
}
