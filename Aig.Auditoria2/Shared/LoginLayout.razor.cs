using Aig.Auditoria2.Events.Language;
using Aig.Auditoria2.Events.Province;
using Aig.Auditoria2.Wasm.Theme;
using BlazorComponentBus;
using MudBlazor;

namespace Aig.Auditoria2.Shared
{
    public partial class LoginLayout
    {
        private MudTheme _currentTheme = new MudBlazorAdminDashboard();
        bool showOverlay { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<OverlayShowEvent>(OverlayShowEventHandler);

            await base.OnInitializedAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        protected async Task getUserLanguaje(string? language = null)
        {
            language = string.IsNullOrEmpty(language) ? await profileService.GetLanguage() : language;
            languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));
            await this.InvokeAsync(StateHasChanged);
        }
        private void LanguageChangeEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<LanguageChangeEvent>();

            getUserLanguaje(message.Language);
        }
        private void OverlayShowEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<OverlayShowEvent>();
            showOverlay = message.Show;
            FetchData();
        }
        private async Task FetchData()
        {
            await this.InvokeAsync(StateHasChanged);
        }

    }
}
