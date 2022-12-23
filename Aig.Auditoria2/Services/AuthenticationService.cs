using Aig.Auditoria2.Helper;
using Blazored.LocalStorage;
using DataModel.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aig.Auditoria2.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider; 
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(IApiConnectionService apiConnectionService, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider; 
            _localStorage = localStorage;
        }

        public async Task<RegistrationResponseDto> RegisterUser(RegisterDTO userForRegistration)
        {
            try
            {
                var content = JsonSerializer.Serialize(userForRegistration);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var registrationResult = await apiConnectionService.Client.PostAsync("accounts/registration", bodyContent);
                var registrationContent = await registrationResult.Content.ReadAsStringAsync();

                if (!registrationResult.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<RegistrationResponseDto>(registrationContent, _options);
                    return result;
                }

                return new RegistrationResponseDto { IsSuccessfulRegistration = true };
            }
            catch (Exception ex) { return new RegistrationResponseDto { IsSuccessfulRegistration = false, ErrorMessage = ex.Message }; }
           
        }

        public async Task<AuthResponseDto> Login(LoginDTO userForAuthentication)
        {
            try {
                var content = JsonSerializer.Serialize(userForAuthentication);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("accounts/login", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<AuthResponseDto>(authContent, _options);

                if (!authResult.IsSuccessStatusCode)
                    return result;

                await _localStorage.SetItemAsync("authToken", result.Token);
                ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(userForAuthentication.UserName);
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

                return new AuthResponseDto { IsAuthSuccessful = true };
            }
            catch (Exception ex) { 
                return new AuthResponseDto { IsAuthSuccessful = false, ErrorMessage=ex.Message }; 
            }
            
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            apiConnectionService.Client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
