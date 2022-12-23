using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace Aig.Farmacoterapia.Admin.Wasm.Infrastructure.Interceptors
{
    public interface IHttpInterceptorManager : IManager
    {
        void RegisterEvent();

        Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e);

        void DisposeEvent();
    }
}