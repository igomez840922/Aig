using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies.Enums
{
    public enum EstadoEstudioDNFD
    {
        [Description("Ninguno")]
        None = 0,
        [Description("Pendiente")]
        Pending = 1,
        [Description("Procesado")]
        Processed = 2,
        [Description("Cancelado")]
        Cancelled = 4,
        [Description("Todos")]
        All = Pending & Processed & Cancelled,
    }
}
