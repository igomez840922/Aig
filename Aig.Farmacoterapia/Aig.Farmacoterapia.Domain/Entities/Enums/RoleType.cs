using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Enums
{
    [Flags]
    public enum RoleType
    {
        [Description("Secretaria")] //Asistente
        Secretary = 1,
        [Description("Jefe")]
        Boss = 2,
        [Description("Evaluador")]
        Evaluator = 4,
        [Description("Administrador")]
        Admin = 8,
    }
}
