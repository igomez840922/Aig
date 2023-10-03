using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Blazored.LocalStorage;
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
        private readonly ILocalStorageService localStorage;

        public UploadService(IApiConnectionService apiConnectionService, ILocalStorageService localStorage)
        {
            this.apiConnectionService = apiConnectionService;
            this.options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.localStorage = localStorage;
        }

        public async Task<FileUploadResult> UploadFile(IBrowserFile File)
        {
            
            string Token = await localStorage.GetItemAsync<string>("authToken");
            apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

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
            string Token = await localStorage.GetItemAsync<string>("authToken");
            apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

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
