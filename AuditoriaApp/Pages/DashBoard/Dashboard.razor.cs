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
        IDashboardService dashboardService { get; set; }   

        APP_Dashboard model { get; set; }

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
                FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        public void Dispose()
        {
            
        }

        

        protected async Task FetchData()
        {
            try {
                model = await dashboardService.Get();
            }
            catch { }
            await this.InvokeAsync(StateHasChanged);
        }
               

    }

}
