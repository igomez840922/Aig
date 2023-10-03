using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using AuditoriaApp.Services;
using Microsoft.Extensions.Configuration;

namespace AuditoriaApp.Pages.DashBoard
{

    public partial class Dashboard
    {
        
        [Inject]
        IDialogService DialogService { get; set; }
        [Inject]
        ISystemUserService systemUserService { get; set; }
        [Inject]
        AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }
        [Inject]
        IConfiguration configuration { get; set; }
              

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            base.OnInitialized();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                await getUserData();

                FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        public void Dispose()
        {
            
        }

        private async Task getUserData()
        {
            try
            {
                var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
                var userClaims = authstate.User;
                if (!userClaims.IsInRole("Admin"))
                {
                    var user = await systemUserService.GetByName(userClaims.Identity.Name);
                    //model.userId = user.Id;
                }
            }
            catch { }
        }

        protected async Task FetchData()
        {
           
            await this.InvokeAsync(StateHasChanged);
        }
               

    }

}
