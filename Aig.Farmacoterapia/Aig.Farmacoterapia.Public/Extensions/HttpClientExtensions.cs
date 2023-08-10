using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Identity;
using System.Net.Http.Headers;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities.Products;

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
        internal static async Task<PaginatedResult<AigRecord>> SearchAsync(this HttpClient client, PageSearchArgs model, AppConfiguration conf)
        {
            //var token = await client.GetToken(conf);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await client.PostAsJsonAsync("api/record/search", model);
            return await response.ToPaginatedResult<AigRecord>();
        }
        internal static async Task<IResult<AigRecord>> GetDetailsAsync(this HttpClient client, int id, AppConfiguration conf)
        {
            var response = await client.GetAsync($"api/record/{id}");
            return await response.ToResult<AigRecord>();
        }
        internal static async Task<IResult<AigRecord>> DataSheetURL(this HttpClient client, string file, AppConfiguration conf)
        {
            var response = await client.GetAsync($"api/record/datasheet/{file}");
            return await response.ToResult<AigRecord>();
        }
        internal static async Task<IResult<AigRecord>> ProspectusURL(this HttpClient client, string file, AppConfiguration conf)
        {
            var response = await client.GetAsync($"api/record/prospectus/{file}");
            return await response.ToResult<AigRecord>();
        }

    }
}
