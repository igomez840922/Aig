using AuditoriaApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Quartz.Util;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace AuditoriaApp.Helper
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        //private readonly HttpClient _httpClient;
        private readonly IApiConnectionService apiConnectionService;
        private readonly IAccountDataService accountDataService;
        private readonly AuthenticationState _anonymous;

        public AuthStateProvider(IApiConnectionService apiConnectionService, IAccountDataService accountDataService)
        {
            this.apiConnectionService = apiConnectionService;
            this.accountDataService = accountDataService;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var data = await accountDataService.First();
            if(data==null || string.IsNullOrWhiteSpace(data.AccessToken))
                return _anonymous;

            apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.AccessToken);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(data.AccessToken), "jwtAuthType")));
        }

        public void NotifyUserAuthentication(string email)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}