using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces.Studies
{
    public interface IAigEstudioRepository
    {
        Task<PaginatedResult<AigEstudio>> ListAsync(PageSearchArgs args);
        List<string> ListEvaluatorAsync(long studyId);
    }
}
