using Aig.Farmacoterapia.Domain.Common;
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
    
    }
}
