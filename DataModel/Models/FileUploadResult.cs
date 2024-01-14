using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class FileUploadResult
    {
        public string? AbsolutePath { get; set; }
        public string? Url { get; set; }
        public string? FileName { get; set; }
        public string? Base64 { get; set; }
    }
}
