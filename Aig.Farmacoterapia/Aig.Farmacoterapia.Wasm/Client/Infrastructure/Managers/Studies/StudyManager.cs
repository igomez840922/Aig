using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Wasm.Client.Extensions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Studies
{
    public class StudyManager : IStudyManager
    {
        private readonly HttpClient _httpClient;

        public StudyManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        public async Task<PaginatedResult<AigEstudio>> SearchAsync(PageSearchArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Search, request);
            return await response.ToPaginatedResult<AigEstudio>();
        }

        public async Task<IResult<AigEstudio>> GetAsync(long id)
        {   
            var response = await _httpClient.GetAsync(AppConstants.EstudioEndpoints.Get(id));
            return await response.ToResult<AigEstudio>();
        }
    
        public async Task<IResult<AigEstudio>> UpdateAsync(AigEstudio request)
        {

            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Update, request);
            return await response.ToResult<AigEstudio>();

        }
        public async Task<IResult> DeleteAsync(long id)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Delete, new { id = id });
            return await response.ToResult();
        }
        public async Task<IResult<List<UserModelOutput>>> GetEvaluators(long id)
        {
            var response = await _httpClient.GetAsync(AppConstants.EstudioEndpoints.GetEvaluators(id));
            return await response.ToResult<List<UserModelOutput>>();
        }
        public async Task<IResult> SetEvaluatorsAsync(long id, string[] evaluators)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Evaluators, new { studyId = id, evaluators = evaluators });
            return await response.ToResult();
        }
        public async Task<IResult> CloneAsync(long id)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Clone, new { id = id });
            return await response.ToResult();
        }
        //public async Task<IResult> UploadFileAsync(UploadObject model)
        //{
        //    var fileContent = new StreamContent(model.Data);
        //    fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.ContentType);
        //    using var content = new MultipartFormDataContent {
        //       { fileContent,"file", model.FileName },
        //       { new StringContent(model.UploadType.ToString()),"type"},
        //    };
        //    var response = await _httpClient.PostAsync(AppConstants.MediaEndpoints.Upload(), content);
        //    return await response.ToResult();
        //}

        //public async Task<IResult> DeleteFileAsync(UploadType uploadType, string file)
        //{
        //    var response = await _httpClient.PostAsJsonAsync(AppConstants.MediaEndpoints.DeleteFile, new { type = uploadType.ToString(), image = file });
        //    return await response.ToResult();
        //}

        public async Task<IResult<UploadObject>> UploadFileAsync(UploadObject model)
        {
            var fileContent = new StreamContent(model.Data);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.ContentType);
            using var content = new MultipartFormDataContent {
               { fileContent,"file", model.FileName },
               { new StringContent(model.UploadType.ToString()),"type"},
            };
            var response = await _httpClient.PostAsync(AppConstants.MediaEndpoints.Upload(), content);
            return await response.ToResult<UploadObject>();
        }
        public async Task<IResult> DeleteFileAsync(UploadType uploadType, string file)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.MediaEndpoints.DeleteFile, new { type = uploadType.ToString(), image = file });
            return await response.ToResult();
        }
    }
}