using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Wasm.Client.Extensions;
using System.Net.Http.Json;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Codes
{
    public class CodesManager : ICodesManager
    {
        private readonly HttpClient _httpClient;

        public CodesManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        public async Task<PaginatedResult<AigCodigoEstudio>> SearchAsync(PageSearchArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.CodesEndpoints.Search, request);
            return await response.ToPaginatedResult<AigCodigoEstudio>();
        }

        public async Task<IResult<AigCodigoEstudio>> GetAsync(long id)
        {   
            var response = await _httpClient.GetAsync(AppConstants.CodesEndpoints.Get(id));
            return await response.ToResult<AigCodigoEstudio>();
        }

        public async Task<IResult<List<AigCodigoEstudio>>> GetCodesAsync(string value)
        {
            if (string.IsNullOrEmpty(value)) value = string.Empty;
            var response = await _httpClient.PostAsJsonAsync(AppConstants.CodesEndpoints.List, new { Value = value });
            return await response.ToResult<List<AigCodigoEstudio>>();
        }

        public async Task<IResult<bool>> UpdateAsync(AigCodigoEstudio request)
        {

            var response = await _httpClient.PostAsJsonAsync(AppConstants.CodesEndpoints.Update, request);
            return await response.ToResult<bool>();

        }
        public async Task<IResult> DeleteAsync(long id)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.CodesEndpoints.Delete, new { id = id });
            return await response.ToResult();
        }
      
    }
}