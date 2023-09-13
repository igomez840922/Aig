
using Aig.Farmacoterapia.Wasm.Client.Interopts;
using Microsoft.AspNetCore.Components;

namespace Aig.Farmacoterapia.Wasm.Client.Components.PdfWebViewer
{
    public partial class PdfViewer
    {
        [Parameter]
        public string Url{ get; set; }
        [Parameter]
        public ElementReference _viewer { get; set; }
        [Parameter]
        public string Width { get; set; } = "100%";
        [Parameter]
        public string Height { get; set; } = "1000px";
       
        [Inject] IPdfViewerService _serviceManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            base.OnInitialized();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender) {
                await _serviceManager.InitPdfWebViewerAsync(Url, _viewer);
            }
        }
        public void Dispose() { }
    }
}
