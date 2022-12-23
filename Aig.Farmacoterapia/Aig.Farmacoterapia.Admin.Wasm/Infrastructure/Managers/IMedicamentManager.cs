using Aig.Farmacoterapia.Admin.Wasm.Infrastructure;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Admin.Wasm.Infrastructure.Managers
{
    public interface IMedicamentManager : IManager
    {
        Task<PaginatedResult<AigMedicamento>> SearchAsync(PageSearchArgs request);
    }
}