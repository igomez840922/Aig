using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Wasm.Client.Extensions;
using System.Net.Http.Json;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Codes
{
    public class AigServiceManager : IAigServiceManager
    {
        private readonly HttpClient _httpClient;

        public AigServiceManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        public async Task<PaginatedResult<AigService>> SearchAsync(PageArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.AigServiceEndpoints.Search, request);
            return await response.ToPaginatedResult<AigService>();
        }

        public async Task<IResult<AigService>> GetAsync(long id)
        {   
            var response = await _httpClient.GetAsync(AppConstants.AigServiceEndpoints.Get(id));
            return await response.ToResult<AigService>();
        }

        public async Task<IResult<AigService>> UpdateAsync(AigService request)
        {

            var response = await _httpClient.PostAsJsonAsync(AppConstants.AigServiceEndpoints.Update, request);
            return await response.ToResult<AigService>();

        }
        public async Task<IResult> ExecuteAsync(string code)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.AigServiceEndpoints.Execute, new { code = code });
            return await response.ToResult();
        }
       
    }
}