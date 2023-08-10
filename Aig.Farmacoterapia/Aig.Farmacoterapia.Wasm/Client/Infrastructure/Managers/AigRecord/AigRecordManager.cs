using Aig.Farmacoterapia.Wasm.Client.Extensions;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Aig.Farmacoterapia.Domain.Entities.Products;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Medicament
{
    public class AigRecordManager : IAigRecordManager
    {
        private readonly HttpClient _httpClient;

        public AigRecordManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public async Task<PaginatedResult<AigRecord>> AdminSearchAsync(PageSearchArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.AigRecordManagerEndpoints.AdminSearch, request);
            return await response.ToPaginatedResult<AigRecord>();
        }
      
        public async Task<IResult<AigRecord>> GetAsync(long id)
        {
            var response = await _httpClient.GetAsync(AppConstants.AigRecordManagerEndpoints.Get(id));
            return await response.ToResult<AigRecord>();
        }
        public async Task<IResult> UploadFileAsync(UploadObject model)
        {
            var fileContent = new StreamContent(model.Data);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.ContentType);
            using var content = new MultipartFormDataContent {
               { fileContent,"file", model.FileName },
               { new StringContent(model.UploadType.ToString()),"type"},
            };
            var response = await _httpClient.PostAsync(AppConstants.MediaEndpoints.Upload(), content);
            return await response.ToResult();
        }
      
        public async Task<IResult> DeleteFileAsync(UploadType uploadType, string file)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.MediaEndpoints.DeleteFile, new { type = uploadType.ToString(), image= file });
            return await response.ToResult();
        }
     
       public async Task<IResult<bool>> UpdateAsync(AigRecord request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.AigRecordManagerEndpoints.Update, request);
            return await response.ToResult<bool>();
           
        }

    }
}