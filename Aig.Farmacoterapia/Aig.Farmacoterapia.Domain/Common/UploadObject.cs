using Aig.Farmacoterapia.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Common
{
    //public class UploadObject
    //{
    //    public string FileName { get; set; }
    //    public string Extension { get; set; }
    //    public string ContentType { get; set; }
    //    public long Size { get; set; }
    //    public UploadType UploadType { get; set; }

    //    [JsonIgnore]
    //    public Stream Data { get; set; }
    //}

    public class UploadObject
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public UploadType UploadType { get; set; }
        public string AbsolutePath { get; set; }
        public string Url { get; set; }

        [JsonIgnore]
        public Stream Data { get; set; }
    }
}
