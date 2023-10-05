using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;

namespace AuditoriaApp.Services
{    
    public class UploadService : IUploadService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions options;
        private readonly IAccountDataService accountDataService;

        public UploadService(IApiConnectionService apiConnectionService, IAccountDataService accountDataService)
        {
            this.apiConnectionService = apiConnectionService;
            this.options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.accountDataService = accountDataService;
        }

        public async Task<FileUploadResult> UploadFile(IBrowserFile File)
        {

            var accountData = await accountDataService.First();
            apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accountData.AccessToken);

            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(new StreamContent(File.OpenReadStream(File.Size)), "file", File.Name);;

                var authResult = await apiConnectionService.Client.PostAsync("FileUpload/UploadFile", formData);
                var authContent = await authResult.Content.ReadAsStringAsync();
                if (authResult.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<FileUploadResult>(authContent, options);
                    return result;
                }
                return null;
            }            
        }
                
        public async Task<bool> DeleteFile(AttachmentTB data)
        {
            var accountData = await accountDataService.First();
            apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accountData.AccessToken);

            var content = JsonSerializer.Serialize(data);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var authResult = await apiConnectionService.Client.PostAsync("FileUpload/DeleteFile", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            if (authResult.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }



    }

}
