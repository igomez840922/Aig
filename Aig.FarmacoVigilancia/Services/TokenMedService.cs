using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;
using DataModel.DTO;
using System.Text.Json;
using System.Security.Policy;

namespace Aig.FarmacoVigilancia.Services
{    
    public class TokenMedService : ITokenMedService
    {
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration configuration;

        public TokenMedService(IApiConnectionService apiConnectionService, IConfiguration configuration)
        {
            this.apiConnectionService = apiConnectionService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.configuration = configuration;
        }

        
        public async Task<ProdServiceTokenResponse> Get()
        {
            try
            {
                
                var myDict = new Dictionary<string, object>()
                                {
                                    { "email",configuration["ApiUsr"]},
                                    { "password",configuration["ApiPsw"]}
                                };
                StringContent content = new StringContent(JsonConvert.SerializeObject(myDict), Encoding.UTF8, "application/json");
                var result = await apiConnectionService.Client.PostAsync("identity/login", content);
                var resultContent = await result.Content.ReadAsStringAsync();
                var data = System.Text.Json.JsonSerializer.Deserialize<ProdServiceTokenResponse>(resultContent, _options);
                if (result.IsSuccessStatusCode)
                {
                    return data;
                }
            }
            catch (Exception ex) { }
            return null;
        }

       
    }

}
