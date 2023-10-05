using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components.Authorization;
using AuditoriaApp.Services;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{    
    public class SystemUserService : ISystemUserService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly IAccountDataService accountDataService;

        public SystemUserService(IApiConnectionService apiConnectionService, IAccountDataService accountDataService)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.accountDataService = accountDataService;
        }

        public async Task<GenericModel<ApplicationUser>> FindAll(GenericModel<ApplicationUser> model)
        {
            try
            {
                model.Data = null;
                model.Ldata = null; model.Total = 0;

                var data = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.AccessToken);

                var content = JsonSerializer.Serialize(model);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("systemuser/FindAll", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GenericModel<ApplicationUser>>(authContent, _options);
                if (authResult.IsSuccessStatusCode)
                {
                    model.Ldata = result.Ldata; model.Total = result.Total;
                }
            }
            catch (Exception ex)
            { model.ErrorMsg = ex.Message; }
            return model;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            try
            {
                var data = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.AccessToken);

                //var content = JsonSerializer.Serialize(model);
                //var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.GetAsync("systemuser/GetAll");
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ApplicationUser>>(authContent, _options);
                if (authResult.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            catch { }
            return null;
        }

        public async Task<ApplicationUser> Get(string Id)
        {
            try
            {
                var data = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.AccessToken);

                //var content = JsonSerializer.Serialize(model);
                //var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.GetAsync(string.Format("systemuser/Get?Id={0}", Id));
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApplicationUser>(authContent, _options);
                if (authResult.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            catch { }
            return null;
        }

        public async Task<ApiResponse> Save(DataModel.Models.RegisterModel data)
        {
            try
            {
                var accountData = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accountData.AccessToken);

                var content = JsonSerializer.Serialize(data);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("systemuser/Save", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse>(authContent, _options);

                return result;
            }
            catch (Exception ex)
            { }
            return null;
        }

        public async Task<ApiResponse> Update(ApplicationUser data)
        {
            try
            {
                var accountData = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accountData.AccessToken);

                var content = JsonSerializer.Serialize(data);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("systemuser/Update", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse>(authContent, _options);

                return result;
            }
            catch (Exception ex)
            { }
            return null;
        }

        public async Task<ApiResponse> Delete(string Id)
        {
            try
            {
                var accountData = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accountData.AccessToken);

                //var content = JsonSerializer.Serialize(model);
                //var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.DeleteAsync(string.Format("systemuser/Delete?Id={0}", Id));
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse>(authContent, _options);

                return result;
            }
            catch { }
            return null;
        }

        public async Task<ApiResponse> ChangePsw(ChangePswModel data)
        {
            try
            {
                var accountData = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accountData.AccessToken);

                var content = JsonSerializer.Serialize(data);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("systemuser/ChangePsw", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse>(authContent, _options);

                return result;
            }
            catch (Exception ex)
            { }
            return null;
        }

        public async Task<ApplicationUser> GetByName(string name)
        {
            try
            {
                var accountData = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accountData.AccessToken);

                //var content = JsonSerializer.Serialize(model);
                //var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.GetAsync(string.Format("systemuser/getbyname?name={0}", name));
                var authContent = await authResult.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApplicationUser>(authContent, _options);
                if (authResult.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            catch { }
            return null;
        }


    }

}
