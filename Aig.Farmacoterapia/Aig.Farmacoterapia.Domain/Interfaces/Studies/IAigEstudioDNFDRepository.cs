using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces.Studies
{
    public interface IAigEstudioDNFDRepository
    {
        Task<PaginatedResult<AigEstudioDNFD>> ListAsync(PageSearchArgs args);
    }
}
