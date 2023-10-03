using Blazored.LocalStorage;
using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AuditoriaApp.Services
{
    public class PaymentService : IPaymentService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public PaymentService(IApiConnectionService apiConnectionService, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LicenseClientTB> ChargeCreditCard(ChargeCreditCardModel model)
        {
            try
            {
               
                string Token = await _localStorage.GetItemAsync<string>("authToken");
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

                var content = JsonSerializer.Serialize(model);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("Payment/ChargeCreditCard", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                if (authResult.IsSuccessStatusCode)
                {

                    var result = JsonSerializer.Deserialize<LicenseClientTB>(authContent, _options);
                    return result;
                }
                else
                {
                    var result = JsonSerializer.Deserialize<string>(authContent, _options);
                    return new LicenseClientTB() { Invalid=true, ErrorMsg = result };
                }
            }
            catch (Exception ex)
            { }
            return null;
        }

        


    }

}
