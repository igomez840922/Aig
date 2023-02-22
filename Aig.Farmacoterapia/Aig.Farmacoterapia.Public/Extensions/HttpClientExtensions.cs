using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Identity;
using System.Net.Http.Headers;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Aig.Farmacoterapia.Domain.Interfaces;

namespace Aig.Farmacoterapia.Public.Extensions
{
    internal static class HttpClientExtensions
    {
        internal static async Task<string> GetToken(this HttpClient client, AppConfiguration conf) {
            var token = string.Empty;
            var model = new TokenRequest() { Email = conf.ApiUsername, Password = conf.ApiPassword };
            var response = await client.PostAsJsonAsync("api/identity/login", model);
            var result = await response.ToResult<TokenResponse>();
            if (result.Succeeded) token = result.Data?.Token ?? string.Empty;
            return token;
        }
        internal static async Task<PaginatedResult<AigMedicamento>> SearchAsync(this HttpClient client, PageSearchArgs model, AppConfiguration conf)
        {
            //var token = await client.GetToken(conf);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await client.PostAsJsonAsync("api/medicament/search", model);
            return await response.ToPaginatedResult<AigMedicamento>();
        }
        internal static async Task<IResult<AigMedicamento>> GetDetailsAsync(this HttpClient client, int id, AppConfiguration conf)
        {
            var response = await client.GetAsync($"api/medicament/{id}");
            return await response.ToResult<AigMedicamento>();
        }
        internal static async Task<IResult<AigMedicamento>> DataSheetURL(this HttpClient client, string file, AppConfiguration conf)
        {
            var response = await client.GetAsync($"api/medicament/datasheet/{file}");
            return await response.ToResult<AigMedicamento>();
        }
        internal static async Task<IResult<AigMedicamento>> ProspectusURL(this HttpClient client, string file, AppConfiguration conf)
        {
            var response = await client.GetAsync($"api/medicament/prospectus/{file}");
            return await response.ToResult<AigMedicamento>();
        }

    }
}
