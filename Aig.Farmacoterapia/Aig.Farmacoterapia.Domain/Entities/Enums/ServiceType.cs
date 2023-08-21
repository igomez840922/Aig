using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Enums
{
    public enum ServiceType
    {
        [Description("TODOS")]
        All = 0,
        [Description("SYS-FARM")]
        SYSFARM = 1,
        [Description("SIR-FAD")]
        SIRFAD = 2,
    }
}
