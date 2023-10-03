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
    public class LicenseOptionService : ILicenseOptionService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public LicenseOptionService(IApiConnectionService apiConnectionService, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<GenericModel<LicenseOptionTB>> FindAll(GenericModel<LicenseOptionTB> model)
        {
            try
            {
                model.Data = null;
                model.Ldata = null; model.Total = 0;

                string Token = await _localStorage.GetItemAsync<string>("authToken");
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

                var content = JsonSerializer.Serialize(model);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("LicenseOption/FindAll", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GenericModel<LicenseOptionTB>>(authContent, _options);
                if (authResult.IsSuccessStatusCode)
                {
                    model.Ldata = result.Ldata; model.Total = result.Total;
                }
            }
            catch (Exception ex)
            { model.ErrorMsg = ex.Message; }
            return model;
        }

        public async Task<List<LicenseOptionTB>> GetAll()
        {
            try
            {
                string Token = await _localStorage.GetItemAsync<string>("authToken");
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

                //var content = JsonSerializer.Serialize(model);
                //var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.GetAsync("LicenseOption/GetAll");
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<LicenseOptionTB>>(authContent, _options);
                if (authResult.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            catch(Exception ex) { }
            return null;
        }

        public async Task<LicenseOptionTB> Get(long Id)
        {
            try
            {
                string Token = await _localStorage.GetItemAsync<string>("authToken");
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

                //var content = JsonSerializer.Serialize(model);
                //var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.GetAsync(string.Format("LicenseOption/Get?Id={0}", Id));
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LicenseOptionTB>(authContent, _options);
                if (authResult.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            catch { }
            return null;
        }

        public async Task<LicenseOptionTB> Save(LicenseOptionTB data)
        {
            try
            {
                string Token = await _localStorage.GetItemAsync<string>("authToken");
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

                var content = JsonSerializer.Serialize(data);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("LicenseOption/Save", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LicenseOptionTB>(authContent, _options);

                return result;
            }
            catch (Exception ex)
            { }
            return null;
        }

        public async Task<LicenseOptionTB> Delete(long Id)
        {
            try
            {
                string Token = await _localStorage.GetItemAsync<string>("authToken");
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

                //var content = JsonSerializer.Serialize(model);
                //var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.DeleteAsync(string.Format("LicenseOption/Delete?Id={0}", Id));
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LicenseOptionTB>(authContent, _options);

                return result;
            }
            catch { }
            return null;
        }

        


    }

}
