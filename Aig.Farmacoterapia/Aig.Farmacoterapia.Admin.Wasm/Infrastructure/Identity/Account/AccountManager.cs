using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Admin.Wasm.Extensions;
using Aig.Farmacoterapia.Admin.Wasm.Infrastructure;
using System.Net.Http.Json;
using Aig.Farmacoterapia.Domain.Common;
using System.Net.Http.Headers;
using Aig.Farmacoterapia.Domain.Entities.Enums;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Identity.Account
{
    public class AccountManager : IAccountManager
    {
        private readonly HttpClient _httpClient;

        public AccountManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult> UpdateProfileAsync(UpdateProfileRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.AccountEndpoints.UpdateProfile, model);
            return await response.ToResult();
        }

        public async Task<IResult> ChangePasswordAsync(ChangePasswordRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.AccountEndpoints.ChangePassword, model);
            return await response.ToResult();
        }
      
        public async Task<IResult> UploadProfilePictureAsync(UploadObject model)
        {
            var fileContent = new StreamContent(model.Data);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.ContentType);
            using var content = new MultipartFormDataContent {
               { fileContent,"file", model.FileName },
               { new StringContent(model.UploadType.ToString()),"type"},
            };
            var response = await _httpClient.PostAsync(AppConstants.MediaEndpoints.Upload(), content);
            return await response.ToResult();
            //return response.IsSuccessStatusCode?Result.Success(): Result.Fail();
        }
        public async Task<IResult> DeleteProfilePictureAsync(UploadType uploadType, string image)
        {
            var response = await _httpClient.DeleteAsync(AppConstants.MediaEndpoints.DeleteFile(uploadType,image));
            return await response.ToResult();
        }
    }
}