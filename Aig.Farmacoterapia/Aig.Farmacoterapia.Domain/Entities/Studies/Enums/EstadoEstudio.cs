using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies.Enums
{
    public enum EstadoEstudio
    {
        [Description("Ninguno")]
        None = 0,
        [Description("No Procede")]
        NotAuthorized = 1,
        [Description("Procede")]
        Authorized = 2,
        [Description("Todos")]
        All = NotAuthorized & Authorized,
    }
}
