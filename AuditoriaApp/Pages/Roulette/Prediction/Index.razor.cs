using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using AuditoriaApp.Services;

namespace AuditoriaApp.Pages.Roulette.Prediction
{
    public partial class Index
    {
        [Inject]
        ISystemUserService SystemUserService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        public List<TableNumber> lSelectedBtns { get; set; } = new List<TableNumber>();

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            //bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
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
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {
            try {
                lSelectedBtns = lSelectedBtns?.Count >0? lSelectedBtns: new List<TableNumber>();
                lSelectedBtns.Clear();
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }
            
        }

        protected async Task UndoLastEntry()
        {
            try
            {
                lSelectedBtns?.RemoveAt(0);
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }
        }
        protected async Task GetPredictions()
        {
            try
            {
               
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }
        }

        protected async Task OnSelectNumberEvent(TableNumber data)
        {
            try
            {
                lSelectedBtns.Insert(0, data);
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }
        }

    }

}
