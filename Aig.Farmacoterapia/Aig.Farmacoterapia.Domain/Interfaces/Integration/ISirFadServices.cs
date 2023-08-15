using Aig.Farmacoterapia.Domain.Integration.SirFad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces.Integration
{
    public interface ISirFadServices
    {
        Task GetRecords(CancellationToken cancellationToke = default);
    }
}
