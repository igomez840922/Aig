using Aig.Farmacoterapia.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Common
{
    public class UploadObject
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public UploadType UploadType { get; set; }
        public Stream Data { get; set; }
    }
}
