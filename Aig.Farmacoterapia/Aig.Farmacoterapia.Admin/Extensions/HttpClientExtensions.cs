using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using System.Net.Http.Headers;

namespace Aig.Farmacoterapia.Admin.Extensions
{
    internal static class HttpClientExtensions
    {
        internal static async Task<string> GetToken(this HttpClient client, AppConfiguration conf) {
            var token = string.Empty;
            var model = new TokenRequest() { Email = conf.ApiUsername, Password = conf.ApiPassword };
            var response = await client.PostAsJsonAsync("api/identity/token", model);
            var result = await response.ToResult<TokenResponse>();
            if (result.Succeeded) token = result.Data?.Token ?? string.Empty;
            return token;
        }
        internal static async Task<IResult<string>> PostFileAsync(this HttpClient client, UploadObject model, AppConfiguration conf)
        {
            var fileContent = new StreamContent(model.Data);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.ContentType);
            using var content = new MultipartFormDataContent {
                   { fileContent,"file", model.FileName },
                   { new StringContent(model.UploadType.ToString()),"type"}
                };
            var token = await client.GetToken(conf);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/media/upload");
            request.Content = content;
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await client.SendAsync(request);
            return await response.ToResult<string>();
        }
    }
}
