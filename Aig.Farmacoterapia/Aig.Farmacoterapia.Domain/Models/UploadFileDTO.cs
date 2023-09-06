using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Models
{
    public class UploadFileDTO
    {
        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("uploadType")]
        public int UploadType { get; set; }

        [JsonPropertyName("absolutePath")]
        public string AbsolutePath { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
