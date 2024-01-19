using Aig.Farmacoterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces.Integration
{
    public interface ITramitesServices
    {
        Task<IResult> SendNote(string code, UploadFileDTO file,CancellationToken cancellationToke = default);
        Task<IResult> SendNote(string host, string code, UploadFileDTO file, CancellationToken cancellationToke = default);
    }
}
