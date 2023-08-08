using Aig.Farmacoterapia.Domain.Integration.SysFarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces.Integration
{
    public interface ISysFarmService
    {
        Task<SysFarmResponse> GetRecords(CancellationToken cancellationToke = default);
    }
}
