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
using AuditoriaApp.Events.Overlay;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuditoriaApp.Pages.Inspections
{
    public partial class Index2
    {
        [Inject]
        IInspectionService inspectionService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        GenericModel<APP_Inspeccion> model { get; set; } = new GenericModel<APP_Inspeccion>();

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
            await inspectionService.Reload();

            model.ErrorMsg = null;
            model.Data = new APP_Inspeccion();

            var data = await inspectionService.FindAll(model);
            if (data != null)
            {
                model = data;
            }
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OnPagingChange(int pIndex)
        {
            if (model.PagesCount < pIndex || model.PagIdx == pIndex - 1)
                return;

            model.PagIdx = pIndex - 1;

            await FetchData();
        }

        protected async Task OnFilter()
        {
            model.PagIdx = 0;

            await FetchData();
        }

        // <summary>
        /// /////////////
        /// </summary>

        //Call Add/Edit payment Order
        private async Task SyncData(APP_Inspeccion data = null)
        {
            await bus.Publish(new OverlayShowEvent { Show = true });
            try
            {
                await inspectionService.InspectionsUpload();
                await inspectionService.InspectionsSync();
                await FetchData();
                snackbar.Add("Sincronización Finalizada", Severity.Info);
            }
            catch
            {
                snackbar.Add("Error durante la Sincronización", Severity.Error);
            }
            finally { await bus.Publish(new OverlayShowEvent { Show = false }); }
        }

        private async Task OnSelect(long Id)
        {
            await bus.Publish(new OverlayShowEvent { Show = true });
            try
            {
                if(Id>0)
                    navigationManager.NavigateTo($"inspectionsedit/{Id}");
            }
            catch
            {
                //snackbar.Add("Error durante la Sincronización", Severity.Error);
            }
            finally { await bus.Publish(new OverlayShowEvent { Show = false }); }
        }        

    }
}
