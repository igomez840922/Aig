using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Domain.Response;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Studies
{
    public interface IStudyManager : IManager
    {
        Task<PaginatedResult<AigEstudio>> SearchAsync(PageSearchArgs request);
        Task<IResult<AigEstudio>> GetAsync(long id);
        Task<IResult> DeleteAsync(long id);
        Task<IResult<bool>> UpdateAsync(AigEstudio request);
        Task<IResult<List<UserModelOutput>>> GetEvaluators(long id);
        Task<IResult> SetEvaluatorsAsync(long id, string[] evaluators);

    }
}