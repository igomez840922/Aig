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
        [Description("Todos")]
        All = 0,
        [Description("Pendiente")]
        Pendiente = 1,
        [Description("No Procede")]
        NotAuthorized = 2,
        [Description("Procede")]
        Authorized = 3
    }
}
