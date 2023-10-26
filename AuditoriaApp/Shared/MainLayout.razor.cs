using AuditoriaApp.Wasm.Theme;
using MudBlazor.ThemeManager;
using MudBlazor;
using Microsoft.AspNetCore.Components;
using BlazorComponentBus;
using AuditoriaApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using DataModel;
using DataModel.Models;
using AuditoriaApp.Events.Overlay;

namespace AuditoriaApp.Shared
{
    public partial class MainLayout:IDisposable
    {
        [Inject]
        ISystemUserService systemUserService { get; set; }
        
        [Inject]
        AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        [Inject]
        IAuthenticationService authenticationService { get; set; }
        
        private ThemeManagerTheme _themeManager = new ThemeManagerTheme();
        MudTheme MyCustomTheme = new MudTheme()
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

        public bool _drawerOpen = true;
        public bool _themeManagerOpen = false;
        bool showOverlay { get; set; }=false;

        //private System.Timers.Timer heartBeatTimer = new(5 * 1000);

        protected async override Task OnInitializedAsync()
        {
            //InitHeartBeatTimer 
            //heartBeatTimer.Elapsed += (sender, eventArgs) => {
            //    _ = InvokeAsync(async () =>
            //    {
            //        //await HeartBeat();
            //    });
            //};
            //heartBeatTimer.Start();

            //Subscribe Component to Language Change Event
            bus.Subscribe<OverlayShowEvent>(OverlayShowEventHandler);
            bus.Subscribe<Events.LoginProcess.CheckLoginEvent>(CheckLoginEventHandler);

            quartzSchedulerService.Start();

            await base.OnInitializedAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
               
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        private async void OverlayShowEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<OverlayShowEvent>();
            showOverlay = message.Show; 
            await FetchData();
        }
        private void CheckLoginEventHandler(MessageArgs args)
        {
            //HeartBeat();
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


        private async Task OpenProfile()
        {
            //var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            //var userClaims = authstate.User;
            ////var isRole = userClaims.IsInRole("Client");
            //var user = (await systemUserService.GetByName(userClaims.Identity.Name));
            //if(user != null)
            //{
            //    //Open Modal
            //    var parameters = new DialogParameters();
            //    parameters.Add("User", user);
            //    var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Large, Position = DialogPosition.Center, FullWidth = true, DisableBackdropClick = true };
            //    var dialog = await DialogService.ShowAsync<AuditoriaApp.Components.SystemUsers.Edit>(string.Format("Edit"), parameters, options);
            //    var result = await dialog.Result;
            //    if (!result.Cancelled)
            //    {
            //        FetchData();
            //    }
            //}

        }

        private async Task OpenChangePsw()
        {
            //var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            //var userClaims = authstate.User;
            ////var isRole = userClaims.IsInRole("Client");
            //var user = (await systemUserService.GetByName(userClaims.Identity.Name));
            //if (user != null)
            //{
            //    if (user != null)
            //    {
            //        var newUser = new ChangePswModel() { Id = user.Id };
            //        //Open Modal
            //        var parameters = new DialogParameters();
            //        parameters.Add("User", newUser);
            //        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Large, Position = DialogPosition.Center, FullWidth = true, DisableBackdropClick = true };
            //        var dialog = await DialogService.ShowAsync<AuditoriaApp.Components.SystemUsers.ChangePsw>(string.Format("Change Password"), parameters, options);
            //        var result = await dialog.Result;
            //        if (!result.Cancelled)
            //        {
            //            FetchData();
            //        }
            //    }
            //}

        }

        /// <summary>
        /// ///////////////////////////
        /// </summary>

        private async Task HeartBeat()
        {
            try
            {
                var result = await authenticationService.HeartBeat();
                if (!result)
                {
                    snackbar.Add("Sorry. Other instance with your credentials have been detected !!!", Severity.Error);

                    navigationManager.NavigateTo("/logout");
                }
            }
            catch { }
        }

        public void Dispose() {

            //heartBeatTimer?.Dispose();
            quartzSchedulerService.Stop();

            bus.UnSubscribe<OverlayShowEvent>(OverlayShowEventHandler);
            bus.UnSubscribe<Events.LoginProcess.CheckLoginEvent>(CheckLoginEventHandler);

            
        }
    }
}
