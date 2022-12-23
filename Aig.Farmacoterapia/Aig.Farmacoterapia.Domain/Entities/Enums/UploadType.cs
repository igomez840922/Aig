using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Enums
{
    public enum UploadType : byte
    {
        [Description(@"datasheet")]
        DataSheet,

        [Description(@"prospectus")]
        Prospectus,

        [Description(@"studies")]
        Studies,

        [Description(@"users")]
        Users,
    }
}
