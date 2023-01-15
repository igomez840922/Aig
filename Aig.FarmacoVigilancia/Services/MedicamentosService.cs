using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;
using DataModel.DTO;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Aig.FarmacoVigilancia.Services
{    
    public class MedicamentosService : IMedicamentosService
    {
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly ITokenMedService tokenMedService;
        public MedicamentosService(IApiConnectionService apiConnectionService, ITokenMedService tokenMedService)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.tokenMedService = tokenMedService;
        }

        
        public async Task<ProdServiceDataResponse> FindAll(ProdServiceDataRequest request)
        {
            try
            {
                var token = await tokenMedService.Get();
                if(!string.IsNullOrEmpty(token?.data.token))
                {
                    apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.data.token);

                    //var myDict = new Dictionary<string, object>()
                    //            {
                    //                { "term",filter},
                    //                { "pageIndex","1"},
                    //                { "pageSize","40"}
                    //            };
                    StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    var result = await apiConnectionService.Client.PostAsync("medicaments", content);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    var data = System.Text.Json.JsonSerializer.Deserialize<ProdServiceDataResponse>(resultContent, _options);
                    if (result.IsSuccessStatusCode)
                    {
                        return data;
                    }
                }                
            }
            catch (Exception ex) { }
            return null;
        }

       
    }

}
