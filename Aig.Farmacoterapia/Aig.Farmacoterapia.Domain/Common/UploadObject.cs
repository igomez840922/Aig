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
#pragma warning disable CS8618 // Non-nullable property 'FileName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string FileName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'FileName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Extension' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Extension { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Extension' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public long Size { get; set; }
        public UploadType UploadType { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Data' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public Stream  Data { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Data' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
