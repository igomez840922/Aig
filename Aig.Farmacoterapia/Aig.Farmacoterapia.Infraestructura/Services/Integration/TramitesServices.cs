using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Text.Json.Serialization;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.SysFarm
{
    public class ResponseModel
    {
        [JsonPropertyName("messages")]
        public List<object> Messages { get; set; }

        [JsonPropertyName("succeeded")]
        public bool Succeeded { get; set; }
    }
    public class TramitesServices : BaseRestService, ITramitesServices
    {
        private readonly IReportService _reportService;
        public TramitesServices(IRestApiClient requester, IReportService reportService, IOptions<TramitesConfiguration> config, ISystemLogger logger):base(requester, logger)
        {
            _reportService = reportService;
           this._config = config.Value;
        }
        public async Task<IResult> SendNote(string code, UploadFileDTO file, CancellationToken cancellationToke = default)
        {
            var request = CreateRequest($"api/tramitesAPIM/note/{code}", Method.POST);
            request.AddJsonBody(file);
            var response = await _requester.ExecuteAsync<ResponseModel>(request, cancellationToke);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
            {
                _logger.Error(new Exception(response.Content).ToMessageAndCompleteStacktrace());
                return Result.Fail(response.StatusDescription);
            }
            return Result.Success();
        }
      
    }
}
