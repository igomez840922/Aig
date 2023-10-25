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
    public class CorregimientoService : ICorregimientoService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly IAccountDataService accountDataService;
        private readonly IDalService dalService;

        public CorregimientoService(IApiConnectionService apiConnectionService, IAccountDataService accountDataService, IDalService dalService)
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

                var content = JsonSerializer.Serialize(lastUpdate);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("Actas/DownloadCorregimientos", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                if(authResult.IsSuccessStatusCode)
                {                   
                    var result = JsonSerializer.Deserialize<List<CorregimientoTB>>(authContent, _options);
                    if(result?.Count > 0)
                    {
                        var appData = dalService.First<APP_Corregimientos>();
                        appData = appData != null ? appData : new APP_Corregimientos();
                        appData.LCorregimientos = result;
                        dalService.Save(appData);
                    }
                }
            }
            catch { }
        }

       
        ///////////////////////////////////////////
        ///

        
        public async Task<List<CorregimientoTB>> GetAll()
        {
            try
            {
                var paises = dalService.First<APP_Corregimientos>();
                return paises.LCorregimientos;
            }
            catch { }
            return null;
        }
        public async Task<List<CorregimientoTB>> GetAllByDist(long Id)
        {
            try
            {
                var paises = dalService.First<APP_Corregimientos>();
                if (Id > 0)
                    return paises.LCorregimientos.Where(x => x.DistritoId == Id).ToList();
                else
                    return paises.LCorregimientos;
            }
            catch { }
            return null;
        }

    }

}
