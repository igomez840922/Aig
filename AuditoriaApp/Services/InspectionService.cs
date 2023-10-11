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
    public class InspectionService : IInspectionService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly IAccountDataService accountDataService;
        private readonly IDalService dalService;

        public InspectionService(IApiConnectionService apiConnectionService, IAccountDataService accountDataService, IDalService dalService)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.accountDataService = accountDataService;
            this.dalService= dalService;
        }

        
        public async Task InspectionsSync()
        {
            try
            {
                var data = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.AccessToken);

                var lastUpdate = await accountDataService.FirstLastUpdate();
                lastUpdate = lastUpdate != null ? lastUpdate : new APP_Updates() { InspectionsUpdate = DateTime.Now.AddMonths(-3) };
                //lastUpdate.InspectionsUpdate = DateTime.Now.AddMonths(-3);

                var content = JsonSerializer.Serialize(lastUpdate);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var authResult = await apiConnectionService.Client.PostAsync("Actas/DownloadPending", bodyContent);
                var authContent = await authResult.Content.ReadAsStringAsync();
                if(authResult.IsSuccessStatusCode)
                {
                    lastUpdate.InspectionsUpdate = DateTime.Now;
                    await accountDataService.SaveLastUpdate(lastUpdate);

                    var result = JsonSerializer.Deserialize<List<AUD_InspeccionTB>>(authContent, _options);
                    if(result?.Count > 0)
                    {
                        foreach( var item in result )
                        {
                            var appItem = dalService.Find<APP_Inspeccion>(x => x.InspeccionId == item.Id);
                            appItem = appItem!= null? appItem: new APP_Inspeccion() { InspeccionId = item.Id};
                            if (!appItem.PendingUpdate)
                            {
                                appItem.NumActa = item.NumActa;
                                appItem.Inspeccion = item;
                                dalService.Save(appItem);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public async Task InspectionsUpload()
        {
            try
            {
                var data = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.AccessToken);

                var lInspections = dalService.FindAll<APP_Inspeccion>(x=>x.PendingUpdate);
                foreach( var appItem in lInspections )
                {
                    var content = JsonSerializer.Serialize(appItem.Inspeccion);
                    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                    var authResult = await apiConnectionService.Client.PostAsync("Actas/UploadPending", bodyContent);
                    var authContent = await authResult.Content.ReadAsStringAsync();
                    if (authResult.IsSuccessStatusCode)
                    {
                        appItem.PendingUpdate = false;
                        dalService.Save(appItem);
                    }
                }
            }
            catch { }
        }

        public async Task<bool> InspectionsUploadOne(long Id)
        {
            try
            {
                var data = await accountDataService.First();
                apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", data.AccessToken);

                var appItem = dalService.Get<APP_Inspeccion>(Id);
                if (appItem != null)
                {
                    var content = JsonSerializer.Serialize(appItem.Inspeccion);
                    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                    var authResult = await apiConnectionService.Client.PostAsync("Actas/UploadPending", bodyContent);
                    var authContent = await authResult.Content.ReadAsStringAsync();
                    if (authResult.IsSuccessStatusCode)
                    {
                        appItem.PendingUpdate = false;
                        dalService.Save(appItem);

                        await InspectionsSync();

                        return true;
                    }
                }
            }
            catch { }
            return false;
        }


        ///////////////////////////////////////////
        ///

        public async Task<GenericModel<APP_Inspeccion>> FindAll(GenericModel<APP_Inspeccion> model)
        {
            try
            {
                model.Ldata = null;
                model.Total = 0;
                model.Ldata = (from data in dalService.DBContext.Set<APP_Inspeccion>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter)))
                               orderby data.CreatedDate descending
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in dalService.DBContext.Set<APP_Inspeccion>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter)))
                               select data).Count();

                return model;
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<APP_Inspeccion>> GetAll()
        {
            return dalService.GetAll<APP_Inspeccion>();
        }

        public async Task<APP_Inspeccion> Get(long Id)
        {
            return dalService.Get<APP_Inspeccion>(Id);

        }
        public async Task Reload()
        {
             dalService.Reload();
        }

        public async Task<APP_Inspeccion> Save(APP_Inspeccion data)
        {

            return dalService.Save(data);
        }

        public async Task<APP_Inspeccion> Delete(long Id)
        {
            return dalService.Delete<APP_Inspeccion>(Id);
        }

    }

}
