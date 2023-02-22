using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Response;

namespace Aig.Farmacoterapia.Admin.Wasm.Infrastructure.Managers.Medicament
{
    public interface IMedicamentManager : IManager
    {
        Task<IResult<DashboardMedicamentResponse>> GetDashBoardInfoAsync();
        Task<PaginatedResult<AigMedicamento>> AdminSearchAsync(PageSearchArgs request);
        Task<IResult<AigMedicamento>> GetAsync(long id);
        Task<IResult> DeleteAsync(long id);
        Task<IResult<List<AigFormaFarmaceutica>>> GetFarmaceuticaAsync(string value);
        Task<IResult<List<AigViaAdministracion>>> GetMedicationRouteAsync(string value);
        Task<IResult<List<AigFabricante>>> GetMarkerAsync(string value);
        Task<IResult<bool>> UpdateAsync(AigMedicamento request);
        Task<IResult> UploadFileAsync(UploadObject model);
        Task<IResult> DeleteFileAsync(UploadType uploadType, string file);
    }
}