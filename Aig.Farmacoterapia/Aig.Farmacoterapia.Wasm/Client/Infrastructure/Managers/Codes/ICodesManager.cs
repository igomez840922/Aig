using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Domain.Response;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Codes
{
    public interface ICodesManager : IManager
    {
        Task<PaginatedResult<AigCodigoEstudio>> SearchAsync(PageSearchArgs request);
        Task<IResult<AigCodigoEstudio>> GetAsync(long id);
        Task<IResult<List<AigCodigoEstudio>>> GetCodesAsync(string value);
        Task<IResult> DeleteAsync(long id);
        Task<IResult<bool>> UpdateAsync(AigCodigoEstudio request);

    }
}