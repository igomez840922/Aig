
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Text.Json.Serialization;
using System.Threading;

namespace Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient
{
    public class TokenData
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }

    public class TokenResult
    {
        [JsonPropertyName("data")]
        public TokenData Data { get; set; }

        [JsonPropertyName("messages")]
        public List<object> Messages { get; set; }

        [JsonPropertyName("succeeded")]
        public bool Succeeded { get; set; }
    }

    public abstract class BaseRestService
    {
        protected readonly IRestApiClient _requester;
        protected IApiConfiguration _config;
        protected readonly ISystemLogger _logger;
        public BaseRestService(IRestApiClient requester, ISystemLogger logger)
        {
            _requester = requester;
            _logger = logger;
        }
     
        public async Task<string> GetTokenAsync(CancellationToken cancellationToke = default)
        {
            var uri = BuildUri("api/identity/login");
            var absoluteUri = uri.AbsoluteUri;
            IRestRequest request = new RestRequest(absoluteUri, Method.POST);
            request.AddJsonBody(new { email = _config.User, password = _config.Password });
            var response = await _requester.ExecuteAsync<TokenResult>(request, cancellationToke);
            if (!response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                _logger.Error(new Exception(response.Content).ToMessageAndCompleteStacktrace());
            return response?.Data?.Data?.Token;
        }
        public string GetToken()
        {
            var task = Task.Run(async () => await GetTokenAsync(default));
            return task.Result;
        }
        protected IRestRequest CreateRequest(string path, Method method, Dictionary<string, string> parameters = default)
        {
            var uri = BuildUri(path);
            var absoluteUri = uri.AbsoluteUri;
            if (parameters?.Count > 0)
                absoluteUri = QueryHelpers.AddQueryString(uri.AbsoluteUri, parameters);
            IRestRequest request = new RestRequest(absoluteUri, method);
            //var token = _config.Token;
            //if (string.IsNullOrEmpty(token))
            //    token = GetToken();
            //request.AddOrUpdateHeader("Authorization",$"Bearer {token}");
            return request;
        }

        protected Uri BuildUri(string path)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = _config.Https ? Uri.UriSchemeHttps: Uri.UriSchemeHttp,
                Host = _config.Host,
                Path = $"{path}",
                Port= _config.Port??-1
            };
            return uriBuilder.Uri;
        }
        //public async Task<EstablecimientoInspeccion> SaveUpdateAsync(EstablecimientoInspeccion item, CancellationToken cancellationToke = default)
        //{
        //    var request = CreateRequest("SaveUpdate", Method.POST);
        //    request.AddJsonBody(item);
        //    var response = await _requester.ExecuteAsync<EstablecimientoInspeccion>(request, cancellationToke);
        //    if (!response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
        //        throw new Exception(response.Content);
        //    return response.Data;
        //}

    }
}
