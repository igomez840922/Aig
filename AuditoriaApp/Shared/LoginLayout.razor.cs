
using AuditoriaApp.Wasm.Theme;
using BlazorComponentBus;
using MudBlazor;
using AuditoriaApp.Events.Overlay;

namespace AuditoriaApp.Shared
{
    public partial class LoginLayout
    {
        private MudTheme _currentTheme = new MudBlazorAdminDashboard()
        {
            Palette = new Palette()
            {
                Info = "#004B9C",//Colors.Blue.Darken4,
                Success = "#009688",//Colors.Green.Accent4,
                Error = "#D50000",//Colors.Red.Default,
                Warning = "#EF6C00",
                Primary = "#54565a",//Colors.Blue.Darken4,
                Secondary = "#00a0af",//Colors.Green.Accent4,
                Tertiary = "#009688",//Colors.Green.Accent4,
                //Define other properties here.
            },

        };
       

        bool showOverlay { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {

            //Subscribe Component to Language Change Event
            bus.Subscribe<OverlayShowEvent>(OverlayShowEventHandler);

            await base.OnInitializedAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
            }
            await base.OnAfterRenderAsync(firstRender);
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
