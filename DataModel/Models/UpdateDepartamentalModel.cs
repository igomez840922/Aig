using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class UpdateDepartamentalModel
    {
        public string NumTramite { get; set; }
        public List<AttachmentTB> LAttachments { get; set; }
        public TipoTramiteFVRE TipoTramiteFVRE { get; set; }
    }
}
