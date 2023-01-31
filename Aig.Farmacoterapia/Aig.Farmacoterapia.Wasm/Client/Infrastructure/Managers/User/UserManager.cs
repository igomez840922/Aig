using Aig.Farmacoterapia.Wasm.Client.Extensions;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.User
{
    public class UserManager : IUserManager
    {
        private readonly HttpClient _httpClient;
        public UserManager(HttpClient httpClient)=> _httpClient = httpClient;
      
        public async Task<PaginatedResult<UserModelOutput>> SearchAsync(PageSearchArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UsersEndpoints.Search, request);
            return await response.ToPaginatedResult<UserModelOutput>();
        }
        public async Task<IResult<bool>> UsernameExists(string userName)
        {
            var response = await _httpClient.GetAsync(AppConstants.UsersEndpoints.UsernameExists(userName));
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> PhoneExistsAsync(string phone)
        {
            var response = await _httpClient.GetAsync(AppConstants.UsersEndpoints.PhoneExists(phone));
            return await response.ToResult<bool>();
        }

        //public async Task<IResult<UpdateProfileRequest>> GetAsync(string userName)
        //{
        //    var response = await _httpClient.GetAsync(AppConstants.UsersEndpoints.Get(userName));
        //    return await response.ToResult<UpdateProfileRequest>();
        //}
        public async Task<IResult<UpdateProfileRequest>> GetAsync(string userName)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UsersEndpoints.Get, new { username = userName});
            return await response.ToResult<UpdateProfileRequest>();
        }
       
        public async Task<IResult> UpdateProfileAsync(UpdateProfileRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UsersEndpoints.UpdateProfile, model);
            return await response.ToResult();
        }
        public async Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UsersEndpoints.UpdateRoles, model);
            return await response.ToResult();
        }
        public async Task<IResult> AddUserAsync(RegisterRequest model)
        {
            model.Email = model.UserName;
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UsersEndpoints.Register, model);
            return await response.ToResult();
        }
        public async Task<IResult> ChangePasswordAsync(ChangePasswordRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UsersEndpoints.ChangePassword, model);
            return await response.ToResult();
        }
        public async Task<IResult> DeleteUserAsync(string id)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UsersEndpoints.Delete,new {id= id});
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
        }
        //public async Task<IResult> DeleteProfilePictureAsync(UploadType uploadType, string image)
        //{
        //    var response = await _httpClient.DeleteAsync(AppConstants.MediaEndpoints.DeleteFile(uploadType, image));
        //    return await response.ToResult();
        //}
        public async Task<IResult> DeleteProfilePictureAsync(UploadType uploadType, string file)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.MediaEndpoints.DeleteFile, new { type = uploadType.ToString(), image = file });
            return await response.ToResult();
        }
    }
}