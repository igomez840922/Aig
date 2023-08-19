using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Interfaces;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Codes
{
    public interface IAigServiceManager : IManager
    {
        Task<PaginatedResult<AigService>> SearchAsync(PageArgs request);
        Task<IResult<AigService>> GetAsync(long id);
        Task<IResult<AigService>> UpdateAsync(AigService request);
        Task<IResult> ExecuteAsync(string code);
    }
}