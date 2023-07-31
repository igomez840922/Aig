using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient
{
    public interface IRestApiClient
    {
        Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, CancellationToken cancellationToken);
        T Execute<T>(IRestRequest request, CancellationToken cancellationToken);
        int Retries { get; set; }
    }
}
