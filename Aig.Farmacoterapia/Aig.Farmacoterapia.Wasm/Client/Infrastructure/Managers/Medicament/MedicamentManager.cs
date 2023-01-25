using Aig.Farmacoterapia.Wasm.Client.Extensions;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Response;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Medicament
{
    public class MedicamentManager : IMedicamentManager
    {
        private readonly HttpClient _httpClient;

        public MedicamentManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IResult<DashboardMedicamentResponse>> GetDashBoardInfoAsync()
        {
            var response = await _httpClient.GetAsync(AppConstants.MedicamentEndpoints.Dashboard);
            return await response.ToResult<DashboardMedicamentResponse>();
        }
        public async Task<PaginatedResult<AigMedicamento>> AdminSearchAsync(PageSearchArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.MedicamentEndpoints.AdminSearch, request);
            return await response.ToPaginatedResult<AigMedicamento>();
        }
      
        public async Task<IResult<AigMedicamento>> GetAsync(long id)
        {
            var response = await _httpClient.GetAsync(AppConstants.MedicamentEndpoints.Get(id));
            return await response.ToResult<AigMedicamento>();
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
            var response = await _httpClient.DeleteAsync(AppConstants.MediaEndpoints.DeleteFile(uploadType, file));
            return await response.ToResult();
        }

      
        public async Task<IResult<bool>> UpdateAsync(AigMedicamento request)
        {
           
            var response = await _httpClient.PostAsJsonAsync(AppConstants.MedicamentEndpoints.Update, request);
            return await response.ToResult<bool>();
           
        }
        public async Task<IResult> DeleteAsync(long id)
        {
            var response = await _httpClient.DeleteAsync(AppConstants.MedicamentEndpoints.Delete(id));
            return await response.ToResult();
        }

        public async Task<IResult<List<AigFormaFarmaceutica>>> GetFarmaceuticaAsync(string value)
        {   
            if (string.IsNullOrEmpty(value)) value = string.Empty;
            var response = await _httpClient.PostAsJsonAsync(AppConstants.MedicamentEndpoints.Pharmaceutica, new { Value = value });
            return await response.ToResult<List<AigFormaFarmaceutica>>();
        }
        public async Task<IResult<List<AigViaAdministracion>>> GetMedicationRouteAsync(string value)
        {
            if (string.IsNullOrEmpty(value)) value = string.Empty;
            var response = await _httpClient.PostAsJsonAsync(AppConstants.MedicamentEndpoints.MedicationRoutel, new { Value = value });
            return await response.ToResult<List<AigViaAdministracion>>();
        }
        public async Task<IResult<List<AigFabricante>>> GetMarkerAsync(string value)
        {
            if (string.IsNullOrEmpty(value)) value = string.Empty;
            var response = await _httpClient.PostAsJsonAsync(AppConstants.MedicamentEndpoints.Marker, new { Value = value });
            return await response.ToResult<List<AigFabricante>>();
        }
    }
}