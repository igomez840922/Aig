using AuditoriaApp.Helper;
using DataModel.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataModel.Models;
using DataModel;

namespace AuditoriaApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IAccountDataService accountDataService;

        public AuthenticationService(IApiConnectionService apiConnectionService, AuthenticationStateProvider authStateProvider, IAccountDataService accountDataService)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            this.accountDataService = accountDataService;
        }

        public async Task<RegistrationResponseDto> RegisterUser(RegisterModel userForRegistration)
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

        public async Task<AuthResponseDto> Login(LoginModel appUser)
        {
            try {
               
                //var authenticationString = $"{appUser.UserName}:{appUser.Password}";
                //var base64String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authenticationString));
                //apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

                var content = JsonSerializer.Serialize(appUser);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("Accounts/Login", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<AuthResponseDto>(authContent, _options);

                if (!authResult.IsSuccessStatusCode)
                    return result;

                //await _localStorage.SetItemAsync("authToken", result.Token);
                //save login user data in localdb
                var data = await accountDataService.First();
                data = data != null ? data : new Data.AccountData();
                data.UserId = result.UserId;
                data.AccessToken = result.Token;
                data.UserName = appUser.UserName;
                //data.BasicToken = base64String;
                await accountDataService.Save(data);

                ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(appUser.UserName);
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                //apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

                return new AuthResponseDto { IsAuthSuccessful = true };
            }
            catch (Exception ex) { 
                return new AuthResponseDto { IsAuthSuccessful = false, ErrorMessage=ex.Message }; 
            }
            
        }

        public async Task Logout()
        {
            //await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            apiConnectionService.Client.DefaultRequestHeaders.Authorization = null;
        }

        //////////////////
        ///
        public async Task<bool> HeartBeat()
        {
            try
            {
                //var content = JsonSerializer.Serialize(userForAuthentication);
                //var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.GetAsync("accounts/heartbeat");
                var authContent = await authResult.Content.ReadAsStringAsync();
                if (!authResult.IsSuccessStatusCode && authResult.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return false;
            }
            catch (Exception ex) { }
            return true;
        }
    }
}
