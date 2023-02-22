using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Wasm.Client.Extensions;
using System.Net.Http.Json;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Studies
{
    public class StudyDNFDManager : IStudyDNFDManager
    {
        private readonly HttpClient _httpClient;

        public StudyDNFDManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        public async Task<PaginatedResult<AigEstudioDNFD>> SearchAsync(PageSearchArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioDNFDEndpoints.Search, request);
            return await response.ToPaginatedResult<AigEstudioDNFD>();
        }

        public async Task<IResult<AigEstudioDNFD>> GetAsync(long id)
        {   
            var response = await _httpClient.GetAsync(AppConstants.EstudioDNFDEndpoints.Get(id));
            return await response.ToResult<AigEstudioDNFD>();
        }
    
        public async Task<IResult<bool>> UpdateAsync(AigEstudioDNFD request)
        {

            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioDNFDEndpoints.Update, request);
            return await response.ToResult<bool>();

        }
        public async Task<IResult<bool>> EvaluateAsync(long id)
        {

            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioDNFDEndpoints.Evaluate, new { id = id });
            return await response.ToResult<bool>();

        }
        public async Task<IResult> DeleteAsync(long id)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioDNFDEndpoints.Delete, new { id = id });
            return await response.ToResult();
        }

    }
}