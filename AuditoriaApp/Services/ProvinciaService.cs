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
    public class ProvinciaService : IProvinciaService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly IAccountDataService accountDataService;
        private readonly IDalService dalService;

        public ProvinciaService(IApiConnectionService apiConnectionService, IAccountDataService accountDataService, IDalService dalService)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.accountDataService = accountDataService;
            this.dalService= dalService;
        }

        
        public async Task Syncronization()
        {
            try
            {
                var data = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.AccessToken);

                var lastUpdate = await accountDataService.FirstLastUpdate();
                lastUpdate = lastUpdate != null ? lastUpdate : new APP_Updates() { SettingsUpdate = DateTime.Now.AddMonths(-3) };
                
                var content = JsonSerializer.Serialize(lastUpdate);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("Actas/DownloadProvincias", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                if(authResult.IsSuccessStatusCode)
                {                   
                    var result = JsonSerializer.Deserialize<List<ProvinciaTB>>(authContent, _options);
                    if(result?.Count > 0)
                    {
                        var appData = dalService.First<APP_Provincias>();
                        appData = appData != null ? appData : new APP_Provincias();
                        appData.LProvincias = result;
                        dalService.Save(appData);
                        //foreach( var item in result )
                        //{
                        //    dalService.Save(item);
                        //}
                    }
                }
            }
            catch { }
        }

       
        ///////////////////////////////////////////
        ///

        
        public async Task<List<ProvinciaTB>> GetAll()
        {
            try
            {
                var paises = dalService.First<APP_Provincias>();
                return paises.LProvincias;
            }
            catch { }
            return null;
        }


    }

}
