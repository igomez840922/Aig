using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class Prospectus
    {
        public string Description { get; set; }
        public string WhatIsIt { get; set; }
        public string WhatDoYouNeed { get; set; }
        public string WayOfUse { get; set; }
        public string AdverseEffects { get; set; }
        public string Conservation { get; set; }
        public string Content { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
