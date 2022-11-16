using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAutoInspeccion : SystemId
    {        
        // AUTO INSPECCIÓN
        private enumAUD_TipoSeleccion autoInspeccion;
        public enumAUD_TipoSeleccion AutoInspeccion { get => autoInspeccion; set => SetProperty(ref autoInspeccion, value); }

        // Observaciones
        private string autoInspeccionDesc;
        [StringLength(500)]
        public string AutoInspeccionDesc { get => autoInspeccionDesc; set => SetProperty(ref autoInspeccionDesc, value); }

    }
}
