using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Interfaces;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Medicament
{
    public interface IAigRecordManager : IManager
    {
        Task<PaginatedResult<AigRecord>> AdminSearchAsync(PageSearchArgs request);
        Task<IResult<AigRecord>> GetAsync(long id);
        Task<IResult<bool>> UpdateAsync(AigRecord request);
        Task<IResult> UploadFileAsync(UploadObject model);
        Task<IResult> DeleteFileAsync(UploadType uploadType, string file);
    }
}