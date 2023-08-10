using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface IAigRecordRepository
    {
        Task<PaginatedResult<AigRecord>> AdminListAsync(PageSearchArgs args);
        Task<PaginatedResult<AigRecord>> ListAsync(PageSearchArgs args);
    }
}
