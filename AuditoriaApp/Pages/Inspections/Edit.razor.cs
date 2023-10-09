using AuditoriaApp.Services;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuditoriaApp.Pages.Inspections
{
    public partial class Edit
    {
        [Inject]
        IInspectionService inspectionService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        [Parameter]
        public long Id { get; set; }

        public APP_Inspeccion model { get; set; } 

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

        public void Dispose()
        {
            //bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
        }

        protected async Task FetchData()
        {
            try {
                model = await inspectionService.Get(Id);
                if(model == null)
                {
                    navigationManager.NavigateTo($"inspections");
                    return;
                }
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }
            
        }
        
        protected async Task BackToMain()
        {
            try
            {
                navigationManager.NavigateTo($"inspections");
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }

        }
    }
}
