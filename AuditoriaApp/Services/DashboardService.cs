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
    public class DashboardService : IDashboardService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly IAccountDataService accountDataService;
        private readonly IDalService dalService;

        public DashboardService(IApiConnectionService apiConnectionService, IAccountDataService accountDataService, IDalService dalService)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.accountDataService = accountDataService;
            this.dalService= dalService;
        }
               
        
        ///////////////////////////////////////////
        ///
                
        public async Task<APP_Dashboard> Get()
        {
            try {

                var dashboad = new APP_Dashboard();

                dashboad.Total = dalService.Count<APP_Inspeccion>();
                dashboad.TotalPending = dalService.Count<APP_Inspeccion>(x=>x.PendingUpdate);

                dashboad.TotalRest = dashboad.Total - dashboad.TotalPending;

                dashboad.ChartLabels = new List<string>() {"Pendientes","Resto"};
                dashboad.ChartData = new List<double>() { dashboad.TotalPending, dashboad.TotalRest };

                return dashboad;
            }
            catch { }
            return null;
        }
        

    }

}
