using Aig.Farmacoterapia.Admin.Wasm.Extensions;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Admin.Wasm.Infrastructure.Managers.Medicament
{
    public class MedicamentManager : IMedicamentManager
    {
        private readonly HttpClient _httpClient;

        public MedicamentManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PaginatedResult<AigMedicamento>> SearchAsync(PageSearchArgs request)
        {
            var u=_httpClient.BaseAddress.AbsoluteUri;
               var response = await _httpClient.PostAsJsonAsync(AppConstants.AigMedicamentoEndpoints.Search, request);
            return await response.ToPaginatedResult<AigMedicamento>();
        }
        public async Task<IResult<int>> SaveAsync(AigMedicamento request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.AigMedicamentoEndpoints.Save, request);
            return await response.ToResult<int>();
        }
        public async Task<IResult> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(AppConstants.AigMedicamentoEndpoints.Delete(id));
            return await response.ToResult();
        }

       
    }
}