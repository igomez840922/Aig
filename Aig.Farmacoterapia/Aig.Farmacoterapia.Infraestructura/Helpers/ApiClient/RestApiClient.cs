
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Resiliency;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient
{
    public class RestApiClient : IRestApiClient
    {
        private int _retries;
        protected readonly IRestClient _client;
        protected readonly ISystemLogger _logger;

        public RestApiClient(ISystemLogger logger)
        {
            _logger = logger;
            _client = new RestClient();
            _client.UseSerializer<RestSharperJsonSerializer>();
            _client.UserAgent = "Aig.Farmacoterapia/1.0";
            _retries = 3;
        }

        public Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, CancellationToken cancellationToken)
        {
            IRestResponse<T> result = null;
            var response = _retries > 0
                ? new RequestsRetryPolicy<T>(_logger, _retries).Execute(async () =>
                    await _client.ExecuteAsync<T>(request, cancellationToken))
                : _client.ExecuteAsync<T>(request, cancellationToken);
            result = response.Result;
            return response;
        }

        public T Execute<T>(IRestRequest request, CancellationToken cancellationToken)
        {
            var task = Task.Run(async () => await ExecuteAsync<T>(request, cancellationToken), cancellationToken);
            var result = task.Result;
            return result.Data;
        }

        public int Retries { get => _retries; set => _retries = value; }
    }
}
