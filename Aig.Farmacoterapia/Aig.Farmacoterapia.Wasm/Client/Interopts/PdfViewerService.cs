using Aig.Farmacoterapia.Wasm.Client.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Farmacoterapia.Wasm.Client.Interopts
{
    public interface IPdfViewerService : IManager
    {
        Task InitPdfWebViewerAsync(string url, ElementReference viewer);
    }
    public class PdfViewerService : IPdfViewerService
    {
        private readonly IJSRuntime _jsRuntime;
        public PdfViewerService(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;
        public async Task InitPdfWebViewerAsync(string url, ElementReference viewer) {
            await _jsRuntime.InvokeVoidAsync("webviewerFunctions.initWebViewer", url, viewer);
        }
    }

}
