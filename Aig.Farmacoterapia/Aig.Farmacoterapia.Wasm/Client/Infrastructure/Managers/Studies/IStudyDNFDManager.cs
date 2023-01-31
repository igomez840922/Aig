using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Response;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Studies
{
    public interface IStudyDNFDManager : IManager
    {
        Task<PaginatedResult<AigEstudioDNFD>> SearchAsync(PageSearchArgs request);
        Task<IResult<AigEstudioDNFD>> GetAsync(long id);
        Task<IResult> DeleteAsync(long id);
        Task<IResult<bool>> UpdateAsync(AigEstudioDNFD request);
      
    }
}