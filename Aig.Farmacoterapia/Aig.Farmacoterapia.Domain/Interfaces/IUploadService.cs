using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadAsync(UploadObject request);
        Task<bool> DeleteAsync(string relativePath);
        Task<byte[]> GetFileAsync(string file, UploadType uploadType);

    }
}
