using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components.Authorization;
using AuditoriaApp.Services;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using static MudBlazor.CategoryTypes;

namespace AuditoriaApp.Services
{    
    public class PaisService : IPaisService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly IAccountDataService accountDataService;
        private readonly IDalService dalService;

        public PaisService(IApiConnectionService apiConnectionService, IAccountDataService accountDataService, IDalService dalService)
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

                var authResult = await apiConnectionService.Client.PostAsync("Actas/DownloadPaises", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                if(authResult.IsSuccessStatusCode)
                {                   
                    var result = JsonSerializer.Deserialize<List<PaisTB>>(authContent, _options);
                    if(result?.Count > 0)
                    {
                        var paises = dalService.First<APP_Paises>();
                        paises = paises!=null? paises: new APP_Paises();
                        paises.LPaises = result;
                        dalService.Save(paises);

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

        
        public async Task<List<PaisTB>> GetAll()
        {
            try {
                var paises = dalService.First<APP_Paises>();
                return paises.LPaises;
            }
            catch { }
            return null;
        }

       
    }

}
