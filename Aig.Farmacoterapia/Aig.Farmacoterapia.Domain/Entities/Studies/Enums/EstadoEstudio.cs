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
        [Description("No Procede")]
        NotAuthorized = 0,
        [Description("Procede")]
        Authorized = 1,
    }
}
