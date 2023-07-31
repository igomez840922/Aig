using Aig.Farmacoterapia.Domain.Integration.SysFarm;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration
{
    public class SysFarmService : BaseRestService, ISysFarmService
    {
        public SysFarmService(IOptions<SysFarmConfiguration> config, IRestApiClient requester, ISystemLogger logger) : base(config, requester, logger) {; }
        public async Task<SysFarmResponse?>GetRecordsAfterDate(string date, CancellationToken cancellationToke = default)
        {
            var request = CreateRequest("api/registros", Method.GET, new Dictionary<string, string> { { "fechaConsulta", date } });
            var response = await _requester.ExecuteAsync<SysFarmResponse>(request, cancellationToke);
            if (!response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
            {
                _logger.Error(new Exception(response.Content).ToMessageAndCompleteStacktrace());
                return null;
            }
            return response.Data;
        }
        public async Task<SysFarmResponse> GetAllRecords(CancellationToken cancellationToke = default)
        {
            var request = CreateRequest("api/registros", Method.GET);
            var response = await _requester.ExecuteAsync<SysFarmResponse>(request, cancellationToke);
            if (!response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                _logger.Error(new Exception(response.Content).ToMessageAndCompleteStacktrace());
            return response.Data;
        }
    }
}
