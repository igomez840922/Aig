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
        [Description("Todos")]
        All = 0,
        [Description("Pendiente")]
        Pending = 1,
        [Description("Procesado")]
        Processed = 2
        
    }
}
