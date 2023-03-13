using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies
{
    public class AigEstudioFile
    {
        [IgnoreDataMember]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Nombre { get; set; }
        public UploadObject? Document { get; set; } 
        
    }
}
