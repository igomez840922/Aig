using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Admin.Wasm.Extensions;
using Aig.Farmacoterapia.Admin.Wasm.Infrastructure;
using System.Net.Http.Json;
using static Aig.Farmacoterapia.Admin.Wasm.Infrastructure.AppConstants;

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
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UserEndpoints.UpdateProfile, model);
            return await response.ToResult();
        }

        public async Task<IResult> ChangePasswordAsync(ChangePasswordRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UserEndpoints.ChangePassword, model);
            return await response.ToResult();
        }

        public async Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.AccountEndpoints.UpdateProfilePicture(userId), request);
            return await response.ToResult<string>();
        }
    }
}