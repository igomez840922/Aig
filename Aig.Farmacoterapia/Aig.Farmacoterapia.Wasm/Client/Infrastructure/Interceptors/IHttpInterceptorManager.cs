using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Interceptors
{
    public interface IHttpInterceptorManager : IManager
    {
        void RegisterEvent();

        Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e);

        void DisposeEvent();
    }
}