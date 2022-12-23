using Aig.Auditoria2.Wasm.Theme;
using MudBlazor.ThemeManager;
using MudBlazor;
using Microsoft.AspNetCore.Components;
using Aig.Auditoria2.Events.Language;
using BlazorComponentBus;
using Aig.Auditoria2.Events.Province;

namespace Aig.Auditoria2.Shared
{
    public partial class MainLayout
    {

        private ThemeManagerTheme _themeManager = new ThemeManagerTheme();

        public bool _drawerOpen = true;
        public bool _themeManagerOpen = false;
        bool showOverlay { get; set; }=false;

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

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        void OpenThemeManager(bool value)
        {
            _themeManagerOpen = value;
        }

        void UpdateTheme(ThemeManagerTheme value)
        {
            _themeManager = value;
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            _themeManager.Theme = new MudBlazorAdminDashboard();
            _themeManager.DrawerClipMode = DrawerClipMode.Always;
            _themeManager.FontFamily = "Montserrat";
            _themeManager.DefaultBorderRadius = 3;
        }

        private List<BreadcrumbItem> _items = new List<BreadcrumbItem>
        {
            new BreadcrumbItem("Personal", href: "#"),
            new BreadcrumbItem("Dashboard", href: "#"),
        };


       

    }
}
